using System;
using System.Collections.Generic;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;
using Random = UnityEngine.Random;

namespace DYT.Map
{
    /// <summary>
    /// Example story for DS
    /// 
    /// Goals: 
    ///     Kill ALL the Spiders (The pig village is in trouble, can you defend it and remove the threat?)
	/// 
    ///     1. To get to the pig village you must first pass through a mountain pass
    ///         LOCK: 	Bolder blocks your path
    ///         KEY:		You must build a pickaxe 
	/// 
    ///     2. You must gather enough meat for the pigs
    ///             so that they have time to help you with the spiders
    ///         LOCK: 	Pig friendship (Pig village)
    ///         KEY:		Meat
    /// 
    /// Requirements:
    ///     1. 	LOCK: 	Narrow area that can be blocked with boulders
    ///         KEY:		Rocks on the ground, Twigs/grass, time to dig through the boulders
    ///     2.	LOCK: 	Pig village with pigs and fireplace
    ///         KEY:		Sources of meat and ways to get it; Carrots & Rabbits, wandering spiders
	/// 
    /// So working backwards: (create a random number of empty nodes between each)
    /// 
    /// Area 0
    ///     1. Create evil spider dens
    ///     2. Create pig village far enough away from spider dens, but close enough to annoy them
    ///     3. Create Meat source close enough to pig village
    ///         (this includes wood/etc to stay safe at night) it probably wants to stay away from spiders
    ///     4. Lock all this behind LOCK 1
    /// Area 1
    ///     1. Add rock source
    ///     2. Add twigs/grass source
    ///     3. Add Starting position
    /// </summary>
    public class Story
    {
        public string id;
        public int loop_blanks;
        public Dictionary<string, object> gen_params;
        public int impassible_value;
        public Level level;
        public Dictionary<string, Task> tasks;
        public Dictionary<string, Dictionary<string, string>> GlobalTags;
        public Dictionary<string, Graph> TERRAIN;
        public Terrain terrain;
        public Graph rootNode;
        public Graph startNode;
        public Graph finalNode;
        public MapTags map_tags;
        public object water_content;
        
        
        public Story(){}
        public Story(
            string id, List<Task> tasks, Terrain terrain,
            Dictionary<string, object> gen_params, Level level
        )
        {
            this.id = id;
            loop_blanks = 1;
            this.gen_params = gen_params;
            impassible_value = (int)
                gen_params.GetValueOrDefault("impassible_value", Constant.GROUND.IMPASSABLE);
            this.level = level;
            
            this.tasks = new Dictionary<string, Task>();
            foreach (Task task in tasks) this.tasks.Add(task.id, task);
            GlobalTags = new Dictionary<string, Dictionary<string, string>>();
            TERRAIN = new Dictionary<string, Graph>();
            this.terrain = terrain;

            rootNode = new Graph(id, new Graph());
            startNode = null;
            finalNode = null;
            
            map_tags = new MapTags();
            
            water_content = new object();
        }
        

        public void ModRoom(string roomname, Room room)
        {
            List<ActionParams> modfns = ModManager.GetPostInitFns("RoomPreInit", roomname);
            foreach (ActionParams modfn in modfns)
            {
                DebugPrint.print($"Applying mod to room '{roomname}'");
                modfn(room);
            }
        }

        public Room GetRoom(string roomname)
        {
            Room newRoom = terrain.rooms[roomname];
            ModRoom(roomname, newRoom);
            return newRoom;
        }

        public Node LinkNodesByKeys(Graph startParentNode, Dictionary<string, Graph> unusedTasks)
        {
            StoryGen.print_lockandkey_ex("\n\n### START PARENT NODE:", startParentNode.id);
            Graph lastNode = startParentNode;
            Dictionary<string, List<Graph>> availableKeys = new Dictionary<string, List<Graph>>();
            foreach (string v in tasks[startParentNode.id].keys_given)
            {
                availableKeys.Add(v, new List<Graph>());
                availableKeys[v].Add(startParentNode);
            }
            Dictionary<string, Graph> usedTasks = new Dictionary<string, Graph>();

            startParentNode.story_depth = 0;
            int story_depth = 1;
            Graph currentNode = null;

            while (Util.GetTableSize(unusedTasks) > 0)
            {
                Graph effectiveLastNode = lastNode;

                StoryGen.print_lockandkey_ex("\n\n### About to insert a node. Last node:", lastNode.id);

                StoryGen.print_lockandkey_ex("\tHave Keys:");
                foreach ((string key, List<Graph> keyNodes) in availableKeys)
                    StoryGen.print_lockandkey_ex("\t\t", key, Util.GetTableSize(keyNodes));

                foreach ((string taskid, Graph node) in unusedTasks)
                {
                    StoryGen.print_lockandkey_ex($"  TASK: {taskid}");
                    StoryGen.print_lockandkey_ex("\t Locks:");

                    Dictionary<string, Dictionary<string, object>> locks =
                        new Dictionary<string, Dictionary<string, object>>();
                    foreach (string v in tasks[taskid].locks)
                    {
                        Dictionary<string, object> lockDic = new Dictionary<string, object>()
                        {
                            ["keys"] = LockAndKey.LOCKS_KEYS[v],
                            ["unlocked"] = false
                        };
                        locks.Add(v, lockDic);
                        StoryGen.print_lockandkey_ex(
                            "\t\tLock:", v,
                            DebugTools.tabletoliststring((List<string>)lockDic["keys"], x => x)
                        );
                    }

                    Dictionary<string, Graph> unlockingNodes = new Dictionary<string, Graph>();

                    //-- For each lock:
                    foreach ((string lockKey, Dictionary<string, object> lockData) in locks)
                    {
                        StoryGen.print_lockandkey_ex("\tUnlocking", lockKey);
                        //-- Do we have any key for
                        foreach ((string key, List<Graph> keyNodes) in availableKeys)
                        {
                            //-- this lock?
                            foreach (string reqKey in lockData.Keys)
                            {
                                if (reqKey == key) //-- If yes, get the nodes with
                                {
                                    //-- that key so that we
                                    foreach (Graph node1 in keyNodes) unlockingNodes.Add(node1.id, node1);
                                    lockData["unlocked"] = true; //-- Also unlock the lock
                                    StoryGen.print_lockandkey_ex("\t\t\tUnlocked!", key);
                                }
                            }
                        }
                    }

                    bool unlocked = true;
                    foreach ((string lockKey, Dictionary<string, object> lockData) in locks)
                    {
                        StoryGen.print_lockandkey_ex("\tDid we unlock ", lockKey);
                        if ((bool)lockData["unlocked"] == false)
                        {
                            StoryGen.print_lockandkey_ex("\t\tno.");
                            unlocked = false;
                            break;
                        }
                    }

                    //-- this task is presently unlockable!
                    if (unlocked)
                    {
                        currentNode = node;
                        StoryGen.print_lockandkey_ex(
                            "StartParentNode", startParentNode.id, "currentNode", currentNode.id
                        );

                        Dictionary<string, object> lowest = new Dictionary<string, object>()
                        {
                            ["i"] = 999, ["node"] = null
                        };
                        Dictionary<string, object> highest = new Dictionary<string, object>()
                        {
                            ["i"] = -1, ["node"] = null
                        };
                        foreach ((string id, Graph node2) in unlockingNodes)
                        {
                            if (node2.story_depth >= (int)highest["i"])
                            {
                                highest["i"] = node2.story_depth;
                                highest["node"] = node2;
                            }

                            if (node2.story_depth < (int)lowest["i"])
                            {
                                lowest["i"] = node2.story_depth;
                                lowest["node"] = node2;
                            }
                        }

                        if (!gen_params.ContainsKey("branching") ||
                            (string)gen_params["branching"] == "default"
                           )
                        {
                            effectiveLastNode = Util.GetRandomItem(unlockingNodes);
                            StoryGen.print_lockandkey_ex(
                                $"\tAttaching {currentNode.id} to random key", effectiveLastNode.id
                            );
                        }
                        else if ((string)gen_params["branching"] == "most")
                        {
                            effectiveLastNode = (Graph)lowest["node"];
                            StoryGen.print_lockandkey_ex(
                                $"\tAttaching {currentNode.id} to lowest key", effectiveLastNode.id
                            );
                        }
                        else if ((string)gen_params["branching"] == "least")
                        {
                            effectiveLastNode = (Graph)highest["node"];
                            StoryGen.print_lockandkey_ex(
                                $"\tAttaching {currentNode.id} to highest key", effectiveLastNode.id
                            );
                        }
                        else if ((string)gen_params["branching"] == "never")
                        {
                            effectiveLastNode = lastNode;
                            StoryGen.print_lockandkey_ex(
                                $"\tAttaching {currentNode.id} to end of chain", effectiveLastNode.id
                            );
                        }

                        break;
                    }
                }

                if (currentNode == null)
                {
                    currentNode = GetRandomNodeFromTasks(unusedTasks);
                    StoryGen.print_lockandkey_ex(
                        $"\t\tAttaching random node {currentNode.id} to last node", effectiveLastNode.id
                    );
                }

                currentNode.story_depth = story_depth;
                story_depth++;

                Node lastNodeExit = effectiveLastNode.GetRandomNode();
                Node currentNodeEntrance = effectiveLastNode.GetRandomNode();
                if (currentNode.entrancenode != null) currentNodeEntrance = currentNode.entrancenode;

                Assert.IsNotNull(lastNodeExit);
                Assert.IsNotNull(currentNodeEntrance);

                if (gen_params.ContainsKey("island_percent") &&
                    (float)gen_params["island_percent"] > Random.value &&
                    currentNodeEntrance.data.entrance == false
                   ) SeperateStoryByBlanks(lastNodeExit, currentNodeEntrance);
                else
                {
                    rootNode.LockGraph(
                        $"{effectiveLastNode.id}->{currentNode.id}", lastNodeExit, currentNodeEntrance,
                        new Dictionary<string, object>(){
                            ["type"] = "none", ["key"] = tasks[currentNode.id].locks, ["node"] = null
                        }
                    );
                }
                
                StoryGen.print_lockandkey_ex("\t\tAdding keys to keyring:");
                foreach (string v in tasks[currentNode.id].keys_given)
                {
                    if (!availableKeys.ContainsKey(v)) availableKeys.Add(v, new List<Graph>());
                    availableKeys[v].Add(currentNode);
                    StoryGen.print_lockandkey_ex("\t\t", v);
                }
                
                unusedTasks.Remove(currentNode.id);
                usedTasks.Add(currentNode.id, currentNode);
                lastNode = currentNode;
                currentNode = null;
            }
            
            return lastNode.GetRandomNode();
        }

        public Graph GetRandomNodeFromTasks(Dictionary<string, Graph> taskSet)
        {
            int sz = Util.GetTableSize(taskSet);
            string task = null;
            if (sz > 0)
            {
                int choice = Random.Range(0, sz);
                
                //-- special order
                foreach ((string taskid, Graph _) in taskSet)
                {
                    task = taskid;
                    if (choice < 0) break;
                    choice--;
                }
            }
            //--print("G2 task ", task)
            return TERRAIN[task];
        }
        
        
        public void GenerateNodesFromTasks(
            Func<Story, Graph, Dictionary<string, Graph>, Node> linkFn
        ) {
            //--print("Story:GenerateNodesFromTasks creating stories")

            Dictionary<string, Graph> unusedTasks = new Dictionary<string, Graph>();
            
            //-- Generate all the TERRAIN
            foreach ((string key, Task task) in tasks)
            {
                //--print("Story:GenerateNodesFromTasks k,task",k,task,  GetTableSize(self.TERRAIN))
                Graph node = null;
                if (task.gen_method == "lagoon") node = GenerateIslandFromTask(task, false);
                else if (task.gen_method == "volcano") node = GenerateIslandFromTask(task, true);
                else node = GenerateNodesFromTask(task, task.crosslink_factor ?? 1);
                TERRAIN.Add(task.id, node);
                unusedTasks.Add(task.id, node);
            }
            
            //--print("Story:GenerateNodesFromTasks lock terrain")
            
            Dictionary<string, Graph> startTasks = new Dictionary<string, Graph>();
            if (gen_params.ContainsKey("start_task") &&
                TERRAIN.ContainsKey((string)gen_params["start_task"])
            ) {
                DebugPrint.print($"Story:GenerateNodesFromTasks start_task {gen_params["start_task"]}");
                startTasks.Add(
                    (string)gen_params["start_task"], TERRAIN[(string)gen_params["start_task"]]
                );
            }
            else
            {
                foreach ((string key, Task task) in tasks)
                {
                    if (task.locks.Count == 0 || task.locks[0] == LockAndKey.LOCKS["LOCKS"])
                    {
                        startTasks.Add(task.id, TERRAIN[task.id]);
                    }
                }
            }
            
            //--print("Story:GenerateNodesFromTasks finding start parent node")

            Graph startParentNode = Util.GetRandomItem(TERRAIN);
            if (Util.GetTableSize(startTasks) > 0) startParentNode = Util.GetRandomItem(startTasks);

            unusedTasks.Remove(startParentNode.id);
            
            //--print("Lock and Key")

            Node finalNode = linkFn(this, startParentNode, unusedTasks); //--startParentNode
            //--print("LinkIslandsByKeys")
            //--finalNode = self:LinkIslandsByKeys(startParentNode, unusedTasks)
        }

        public void SeperateStoryByBlanks(Node startnode, Node endnode)
        {
            Graph blank_node = new Graph($"LOOP_BLANK{loop_blanks}", new Graph
            {
                parent = rootNode,
                default_bg = Constant.GROUND.IMPASSABLE,
                colour = new Color { r = 0.3f, g = .8f, b = .5f, a = 1 },
                background = "BGImpassable"
            });
            WorldSim.AddChild(
                rootNode.id, $"LOOP_BLANK{loop_blanks}", Constant.GROUND.IMPASSABLE, 0, 0, 0, 1, "blank"
            );
            Node blank_subnode = blank_node.AddNode(new Node
            {
                id = $"LOOP_BLANK_SUB {loop_blanks}",
                data = new Room
                {
                    type = "blank",
                    tags = { "RoadPoison", "ForceDisconnected" },
                    colour = new Color { r = 0.3f, g = .8f, b = .5f, a = .50f },
                    value = impassible_value
                }
            });
            loop_blanks++;
            rootNode.LockGraph(
                $"{startnode.id}->{blank_subnode.id}", startnode, blank_subnode,
                new Dictionary<string, object>()
                {
                    ["type"]="none", ["key"]=LockAndKey.KEYS["NONE"], ["node"]=null
                }
            );
            rootNode.LockGraph(
                $"{endnode.id}->{blank_subnode.id}", 	endnode, 	blank_subnode,
                new Dictionary<string, object>()
                {
                    ["type"]="none", ["key"]=LockAndKey.KEYS["NONE"], ["node"]=null
                }
            );
        }

        //-- Generate a subgraph containing all the items for this story
        public Graph GenerateNodesFromTask(Task task, int? crossLinkFactor)
        {
            //--print("Story:GenerateNodesFromTask", task.id)
            //-- Create stack of rooms
            Stack<Room> room_choices = new Stack<Room>();

            if (task.entrance_room != null)
            {
                float r = Random.value;
                if (task.entrance_room_chance == 0 || task.entrance_room_chance > r)
                {
                    task.entrance_room[0] = Util.GetRandomItem(task.entrance_room);
                    //--print("\tAdding entrance: ",task.entrance_room,
                    //"rolled:",r,"needed:",task.entrance_room_chance)
                    Room new_room = GetRoom(task.entrance_room[0]);
                    Assert.IsNotNull(
                        new_room, $"Couldn't find entrance room with name {task.entrance_room}"
                    );

                    new_room.contents ??= new Room.Contents();
                    
                    new_room.contents.fn?.Invoke(new_room);
                    new_room.type = task.entrance_room[0];
                    new_room.entrance = true;
                    room_choices.Push(new_room);
                }
            }

            if (task.room_choices != null)
            {
                foreach ((string room, int count) in (Dictionary<string, int>)task.room_choices)
                {
                    //--print("Story:GenerateNodesFromTask adding "..count.." of "..room,
                    //self.terrain.rooms[room].contents.fn)
                    for (int i = 0; i < count; i++)
                    {
                        Room new_room = GetRoom(room);
                        
                        Assert.IsNotNull(new_room, $"Couldn't find room with name {room}");
                        new_room.contents ??= new Room.Contents();
                        
                        //-- Do any special processing for this room
                        new_room.contents.fn?.Invoke(new_room);
                        new_room.type = room; //--new_room.type or "normal"
                        room_choices.Push(new_room);
                    }
                }
            }
            
            Graph task_node = new Graph(task.id, new Graph()
            {
                parent = rootNode,
                default_bg = task.room_bg,
                colour = task.colour,
                background = task.background_room,
                random_set_pieces = task.random_set_pieces,
                set_pieces = task.set_pieces,
                maze_tiles = task.maze_tiles,
                treasures = task.treasures,
                random_treasures = task.random_treasures,
            });
            task_node.substitutes = task.substitutes;
            //--print ("Adding Voronoi Child", self.rootNode.id, task.id, task.room_bg, task.room_bg,
            //task.colour.r, task.colour.g, task.colour.b, task.colour.a )
            
            WorldSim.AddChild(
                rootNode.id, task.id, task.room_bg,
                task.colour.r, task.colour.g, task.colour.b, task.colour.a
            );

            Node newNode = null;
            Node prevNode = null;
            //-- TODO: we could shuffleArray here on rom_choices_.et to make it more random
            int roomID = 0;
            //--print("Story:GenerateNodesFromTask adding "..room_choices:getn().." rooms")
            while (room_choices.Count > 0)
            {
                Room next_room = room_choices.Pop();
                //-- TODO: add room names for special rooms
                next_room.id = $"{task.id}:{roomID}:{next_room.type}";
                next_room.task = task.id;
                
                RunTaskSubstitution(task, next_room.contents.distributeprefabs);
                
                //-- TODO: Move this to
                GetExtrasForRoom(
                    next_room, out Dictionary<string, object> extra_contents, out List<string> extra_tags
                );

                newNode = task_node.AddNode(new Node{
                    id = next_room.id,
                    data = new Room
                    {
                        type = next_room.entrance ? "blocker" : next_room.type,
                        colour = next_room.colour,
                        value = next_room.value,
                        internal_type = next_room.internal_type,
                        tags = extra_tags,
                        custom_tiles = next_room.custom_tiles,
                        custom_objects = next_room.custom_objects,
                        terrain_contents = next_room.contents,
                        terrain_contents_extra = extra_contents,
                        terrain_filter = terrain.filter,
                        entrance = next_room.entrance,
                    }
                });

                if (prevNode != null)
                {
                    //--dumptable(prevNode)
                    //--print("Story:GenerateNodesFromTask Adding edge "..newNode.id.." -> "..prevNode.id)
                    Edge edge = task_node.AddEdge(new Edge{node1id = newNode.id,node2id = prevNode.id});
                }
                
                //--dumptable(newNode)
                //-- This will make long line of nodes
                prevNode = newNode;
                roomID++;
            }
            
            if (task.make_loop) task_node.MakeLoop();
            if (crossLinkFactor.HasValue) task_node.CrosslinkRandom(crossLinkFactor.Value);
            //--print("Story:GenerateNodesFromTask done", task_node.id)
            return task_node;
        }

        public Graph GenerateIslandFromTask(Task task, bool randomize)
        {
            if (task.room_choices == null || task.room_choices.GetType() != typeof(List<>)) return null;

            Graph task_node = new Graph(task.id, new Graph
            {
                parent = rootNode,
                default_bg = task.room_bg,
                colour = task.colour,
                background = task.background_room,
                random_set_pieces = task.random_set_pieces,
                set_pieces = task.set_pieces,
                maze_tiles = task.maze_tiles,
                treasures = task.treasures,
                random_treasures = task.random_treasures,
            });
            task_node.substitutes = task.substitutes;
            
            WorldSim.AddChild(
                rootNode.id, task.id, task.room_bg,
                task.colour.r, task.colour.g, task.colour.b, task.colour.a
            );

            List<List<Node>> layout = new List<List<Node>>();
            int layoutdepth = 1;
            int roomID = 0;
            
            List<Dictionary<string, int>> taskRoomChoices =
                (List<Dictionary<string, int>>)task.room_choices;
            for (int i = 0; i < taskRoomChoices.Count; i++)
            {
                layout.Add(new List<Node>());
                
                List<string> rooms = new List<string>();
                foreach ((string room, int count) in taskRoomChoices[i])
                {
                    //--print("Story:GenerateIslandFromTask adding "..count.." of "..room,
                    //self.terrain.rooms[room].contents.fn)
                    for (int j = 0; j < count; j++) rooms.Add(room);
                }
                if (randomize) rooms = Util.shuffleArray(rooms);
                
                foreach (string room in rooms)
                {
                    Room new_room = GetRoom(room);
                    
                    Assert.IsNotNull(new_room, $"Couldn't find room with name {room}");
                    new_room.contents ??= new Room.Contents();
                    
                    //-- Do any special processing for this room
                    new_room.contents.fn?.Invoke(new_room);
                    new_room.type = room; //--new_room.type or "normal"
                    new_room.id = $"{task.id}:{roomID}:{new_room.type}";
                    new_room.task = task.id;
                    
                    RunTaskSubstitution(task, new_room.contents.distributeprefabs);
                    
                    //-- TODO: Move this to
                    GetExtrasForRoom(
                        new_room,
                        out Dictionary<string, object> extra_contents, out List<string> extra_tags
                    );

                    Node newNode = task_node.AddNode(new Node
                    {
                        id = new_room.id,
                        data = new Room
                        {
                            type = new_room.entrance ? "blocker" : new_room.type,
                            colour = new_room.colour,
                            value = new_room.value,
                            internal_type = new_room.internal_type,
                            tags = extra_tags,
                            custom_tiles = new_room.custom_tiles,
                            custom_objects = new_room.custom_objects,
                            terrain_contents = new_room.contents,
                            terrain_contents_extra = extra_contents,
                            terrain_filter = terrain.filter,
                            entrance = new_room.entrance,
                        }
                    });
                    
                    layout[layoutdepth].Add(newNode);
                    roomID++;
                }
                layoutdepth++;
            }
            
            //--link the nodes in a 'web'
            for (int depth = layout.Count - 1; depth >= 0; depth--)
            {
                //--print("Linking " .. #layout[depth] .. " at depth " .. depth)
                for (int i = 0; i < layout[depth].Count; i++)
                {
                    //--link each task at this depth with a random task in the previous depth
                    int node = Mathf.FloorToInt(
                        layout[depth - 1].Count * ((i - 1) / (float)layout[depth].Count) + 1
                    );
                    //--print(node .. " = " .. #layout[depth - 1] .. ", " .. i .. ", " .. #layout[depth])
                    Assert.IsTrue(1 <= node && node < layout[depth - 1].Count);
                    Node roomnode = layout[depth][i];
                    Node roomnode2 = layout[depth - 1][i];
                    
                    //--print("  Linking " .. roomnode.id .. " -> ".. roomnode2.id)
                    task_node.AddEdge(new Edge { node1id = roomnode.id, node2id = roomnode2.id });
                }
                
                //--connect inner layer with itself
                for (int i = 1; i < layout[depth].Count; i++)
                {
                    Node node1 = layout[0][0];
                    Node node2 = layout[0][i];
                    //--print("  Linking " .. node1.id .. " -> ".. node2.id)
                    task_node.AddEdge(new Edge { node1id = node1.id, node2id = node2.id });
                }
                
                //--connect layer nodes
                for (int i = 1; i < layout[depth].Count - 1; i++)
                {
                    Node node1 = layout[depth][i];
                    Node node2 = layout[depth][i + 1];
                    //--print("  Linking " .. node1.id .. " -> ".. node2.id)
                    task_node.AddEdge(new Edge { node1id = node1.id, node2id = node2.id });
                }
                //--print("  Linking " ..
                //layout[depth][ #layout[depth] ].id .. " -> ".. layout[depth][1].id)
                task_node.AddEdge(new Edge
                {
                    node1id = layout[depth][layout[depth].Count - 1].id, node2id = layout[depth][0].id
                });
            }

            //--print(GetTableSize(task_node))
            return task_node;
        }

        public void GetExtrasForRoom(
            Room next_room,
            out Dictionary<string, object> extra_contents, out List<string> extra_tags
        ) {
            extra_contents = new Dictionary<string, object>();
            extra_tags = new List<string>();
            
            if (next_room.tags == null) return;
            
            foreach (string tag in next_room.tags)
            {
                map_tags.Tag[tag](map_tags.TagData, out string type, out string extra);
                if (type == "STATIC")
                {
                    if (!extra_contents.ContainsKey("static_layouts"))
                        extra_contents.Add("static_layouts", new object());
                    extra_contents["static_layouts"] = extra;
                }
                if (type == "ITEM")
                {
                    if (!extra_contents.ContainsKey("prefabs"))
                        extra_contents.Add("prefabs", new object());
                    extra_contents["prefabs"] = extra;
                }
                if (type == "TAG") extra_tags.Add(extra);
                if (type == "GLOBALTAG")
                {
                    if (!GlobalTags.ContainsKey(extra))
                        GlobalTags.Add(extra, new Dictionary<string, string>());
                    if (!GlobalTags[extra].ContainsKey(next_room.task))
                        GlobalTags[extra].Add(next_room.task, null);
                    //--print("Adding GLOBALTAG", extra, next_room.task, next_room.id)
                    GlobalTags[extra][next_room.task] = next_room.id;
                }
            }
        }

        public Dictionary<string, object> RunTaskSubstitution(
            Task task, Dictionary<string, object> items
        ) {
            if (task.substitutes == null || items == null) return items;

            foreach ((string key, Task.Substitute value) in task.substitutes)
            {
                if (!items.ContainsKey(key)) continue;
                
                if (Mathf.Approximately(value.percent, 1) || value.percent == 0)
                {
                    items[value.name] = items[key];
                    items.Remove(key);
                }
                else
                {
                    items[value.name] = (int)items[key] * value.percent;
                    items[key] = (int)items[key] * (1 - value.percent);
                }
            }
            
            return items;
        }
    }
    
    public class StoryGen
    {
        public static void print_lockandkey_ex(params object[] args)
        {
            //print(...)
        }
        
        private static Node linkNodesByLocksOrKeys(
            Story story, Graph startParentNode, Dictionary<string, Graph> unusedTasks
        ) {
            DebugPrint.print("LinkNodesByKeys");
            return story.LinkNodesByKeys(startParentNode, unusedTasks);
        }
        
        public static object SHIPWRECKED_STORY(
            List<Task> tasks, Dictionary<string, object> story_gen_params, Level level
        ) {
            return null;
        }
        
        public static object VOLCANO_STORY(
            List<Task> tasks, Dictionary<string, object> story_gen_params, Level level
        ) {
            return null;
        }
        
        public static object PORKLAND_STORY(
            List<Task> tasks, Dictionary<string, object> story_gen_params, Level level
        ) {
            return null;
        }
        
        public static object DEFAULT_STORY(
            List<Task> tasks, Dictionary<string, object> story_gen_params, Level level
        ) {
            DebugPrint.print("Building DEFAULT STORY", tasks);
            float start_time = MainFunctions.GetTimeReal();

            Story story = new Story("GAME", tasks, Terrain.terrain, story_gen_params, level);
            story.GenerateNodesFromTasks(linkNodesByLocksOrKeys);

            return null;
        }
    }
}