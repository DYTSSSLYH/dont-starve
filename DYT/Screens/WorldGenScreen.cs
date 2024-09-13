using System;
using System.Collections.Generic;
using System.Reflection;
using DYT.Tools;
using DYT.Widgets;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;
using Screen = DYT.Widgets.Screen;

namespace DYT.Screens
{
    public class ModData
    {
        public KnownModIndex.CachedData index;
    }
    
    public class WorldGenScreen : Screen
    {
        public GameObject movieDialog;

        private float MIN_GEN_TIME = 9.5f;
        private const bool PLAY_PRE_WORLDGEN_MOVIE = false;
        private float MIN_GEN_TIME_WITH_MOVIE_AT_START = 3.0f;
        private PlayerProfile profile;
        private bool log;
        private Image bg;
        private Transform worldanim;
        private UIAnim hand1;
        private Text worldgentext;
        private Text flavourtext;
        private string genparam;
        private string modparam;
        private string worlddata;
        private bool done;
        private float total_time;
        private Action<string> cb;
        private string[] verbs;
        private string[] nouns;
        private int verbidx;
        private int nounidx;
        private string backgroundSound;
        private bool isPlaying;
        
        public WorldGenScreen Init(PlayerProfile profile, Action<string> cb,
            GameLogic.WorldGenOptions worldGenOptions)
        {
            base.Init();
            this.profile = profile;
            log = true;

            bg = GetComponent<Image>();
            bg.Awake();
            bg.Start();

            Transform bottomRoot = transform.Find("BottomRoot");

            worldanim = bottomRoot.Find("WorldAnim");
            
            hand1 = bottomRoot.Find("Hand1").GetComponent<UIAnim>();
            hand1.Awake();
            hand1.Start();
            hand1.GetAnimState().SetFloat("Time", Random.Range(0, 2f));

            worldgentext = transform.Find("CenterRoot").Find("WorldGenText").GetComponent<Text>();
            worldgentext.Awake();
            worldgentext.Start();

            bool rog_enabled = false;
            // In case we are generating a world from SW and the player doesn't have ROG installed
            // or disabled it when generating the world
            if (worldGenOptions.custom_options != null && worldGenOptions.custom_options.ROGEnabled)
            {
                rog_enabled = worldGenOptions.custom_options.ROGEnabled;
            }

            if (worldGenOptions.level_type == "cave")
            {
                bg.SetTint(
                    Constant.BGCOLOURS.PURPLE[0], Constant.BGCOLOURS.PURPLE[1], Constant.BGCOLOURS.PURPLE[2], 1);
                worldanim.Find("GeneratingCave").gameObject.SetActive(true);
                worldgentext.SetString("正在凿刻洞穴");
            }
            else if (worldGenOptions.level_type == "volcano")
            {
                bg.SetTint(60 / 255f, 80 / 255f, 85 / 255f, 1);
                worldanim.Find("GeneratingVolcano").gameObject.SetActive(true);
                worldgentext.SetString("岩浆正在沸腾");
            }
            else if (worldGenOptions.level_type is "survival" or "adventure")
            {
                if (rog_enabled)
                {
                    bg.SetTint(
                        Constant.BGCOLOURS.PURPLE[0],
                        Constant.BGCOLOURS.PURPLE[1],
                        Constant.BGCOLOURS.PURPLE[2],
                        1
                    );
                }
                else
                {
                    bg.SetTint(
                        Constant.BGCOLOURS.RED[0], Constant.BGCOLOURS.RED[1], Constant.BGCOLOURS.RED[2], 1);
                }
                
                worldanim.Find("GeneratingWorld").gameObject.SetActive(true);
                worldgentext.SetString("正在生成世界");
            }
            else if (worldGenOptions.level_type == "shipwrecked")
            {
                bg.SetTint(Constant.BGCOLOURS.TEAL[0], Constant.BGCOLOURS.TEAL[1], Constant.BGCOLOURS.TEAL[2], 1);
                worldanim.Find("GeneratingShipwrecked").gameObject.SetActive(true);
                worldgentext.SetString("正在生成岛屿");
            }
            else
            {
                bg.SetTint(
                    Constant.BGCOLOURS.GREEN[0], Constant.BGCOLOURS.GREEN[1], Constant.BGCOLOURS.GREEN[2], 1);
                worldanim.Find("GeneratingHamlet").gameObject.SetActive(true);
                worldgentext.SetString("正在生成高原");
            }
            
            flavourtext = transform.Find("CenterRoot").Find("FlvarText").GetComponent<Text>();

            MainFunctions.Settings.save_slot = MainFunctions.Settings.save_slot.GetValueOrDefault(1);
            GenParameters gen_parameters = new();

            gen_parameters.level_type = worldGenOptions.level_type;
            if (string.IsNullOrWhiteSpace(gen_parameters.level_type)) gen_parameters.level_type = "free";

            gen_parameters.world_gen_choices = worldGenOptions.custom_options;
            if (gen_parameters.world_gen_choices == null)
            {
                gen_parameters.world_gen_choices = new CustomScreen.ChangedOption
                {
                    optionList =
                    {
                        {"monsters", "default"},
                        {"animals", "default"},
                        {"resources", "default"},
                        {"unprepared", "default"},
                    }
                };
            }

            gen_parameters.current_level = worldGenOptions.level_world;

            if (gen_parameters.level_type == "adventure")
            {
                if (!gen_parameters.current_level.HasValue || gen_parameters.current_level.Value < 1)
                {
                    gen_parameters.current_level = 1;
                }

                gen_parameters.adventure_progress =
                    worldGenOptions.adventure_progress.GetValueOrDefault(1);
            }

            gen_parameters.profiledata = worldGenOptions.profiledata;
            if (gen_parameters.profiledata == null)
            {
                gen_parameters.profiledata = new PlayerProfile.Data
                {
                    unlocked_characters = new List<string>()
                };
            }

            bool[] DLCEnabledTable = new bool[DLCSupport.DLC_LIST.Count + 1];
            foreach (int dlcIndex in DLCSupport.DLC_LIST)
                DLCEnabledTable[dlcIndex] = DLCSupport.IsDLCEnabled(dlcIndex);
            gen_parameters.DLCEnabled = DLCEnabledTable;

            // In case we are generating a world from SW and the player doesn't have ROG installed
            // or disabled it when generating the world
            gen_parameters.ROGEnabled = rog_enabled;

            ModData modData = new()
            {
                index = KnownModIndex.CacheSaveData()
            };

            genparam = JsonConvert.SerializeObject(gen_parameters);
            modparam = JsonConvert.SerializeObject(modData);

            TheSim.GenerateNewWorld(genparam, modparam, worldData =>
            {
                worlddata = worldData;
                done = true;
            });

            total_time = 0;
            this.cb = cb;
            Main.TheFrontEnd.DoFadeIn(2);

            verbs = Util.shuffleArray(Strings.UI.WORLDGEN.VERBS);

            if (worldGenOptions.level_type == "porkland")
            {
                nouns = Util.shuffleArray(Strings.UI.WORLDGEN.NOUNS.PORKLAND);
            }
            else if (worldGenOptions.level_type is "shipwrecked" or "volcano")
            {
                nouns = Util.shuffleArray(Strings.UI.WORLDGEN.NOUNS.SHIPWRECKED);
            }
            else
            {
                nouns = Util.shuffleArray(Strings.UI.WORLDGEN.NOUNS.BASE_GAME);
            }

            verbidx = 0;
            nounidx = 0;
            ChangeFlavourText();
            
            SetBackgroundSound(worldGenOptions);
            
            if (!PLAY_PRE_WORLDGEN_MOVIE)
            {
                Main.TheFrontEnd.GetSound().PlayOneShot(ResourcesTool.Load<AudioClip>(backgroundSound));
            }

            return this;
        }

        public void SetBackgroundSound(GameLogic.WorldGenOptions world_gen_options)
        {
            if (world_gen_options.level_type == "cave") backgroundSound = "Sounds/dontstarve/HUD/caveGen";
            else if (world_gen_options.level_type == "survival")
            {
                backgroundSound = "Sounds/dontstarve/HUD/worldGen";
            }
            else if (world_gen_options.level_type == "shipwrecked")
            {
                backgroundSound = "Sounds/dontstarve_DLC002/common/GenShipwrecked_LP";
            }
            else if (world_gen_options.level_type == "volcano")
            {
                backgroundSound = "Sounds/dontstarve_DLC002/common/GenShipwrecked_volcano_LP";
            }
            else
            {
                backgroundSound = "Sounds/dontstarve_DLC003/HUD/worldGen";
            }
        }

        public override void OnUpdate(float dt)
        {
            if (PLAY_PRE_WORLDGEN_MOVIE && !isPlaying)
            {
                float movieStartTime = TheSim.GetTick() * TheSim.GetTickTime();
                string moviename = "movies/worldgen.ogv";
                Main.TheFrontEnd.PushScreen(Instantiate(movieDialog).GetComponent<MovieDialog>()
                    .Init(moviename, () =>
                    {
                        MainFunctions.SetPause(false);
                        Main.TheFrontEnd.GetSound().PlayOneShot(
                            ResourcesTool.Load<AudioClip>(backgroundSound));
                        float movieEndTime = TheSim.GetTick() * TheSim.GetTickTime();
                        float moviePlayTime = movieEndTime - movieStartTime;
                        MIN_GEN_TIME -= moviePlayTime;
                        if (MIN_GEN_TIME < MIN_GEN_TIME_WITH_MOVIE_AT_START)
                        {
                            MIN_GEN_TIME = MIN_GEN_TIME_WITH_MOVIE_AT_START;
                        }
                    }, true));

                isPlaying = true;
            }
            total_time += dt;
            if (done)
            {
                if (worlddata == "")
                {
                    DebugPrint.print("RESTARTING GENERATION");
                    done = false;
                    worlddata = null;
                    TheSim.GenerateNewWorld(genparam, modparam, worlddata =>
                    {
                        this.worlddata = worlddata;
                        done = true;
                    });
                    return;
                }

                if (worlddata.StartsWith("error"))
                {
                    done = false;
                    cb(worlddata);
                }
                else if (total_time > MIN_GEN_TIME && cb != null)
                {
                    done = false;
                    Main.TheFrontEnd.Fade(false, 1, () => cb(worlddata));
                }
            }
        }

        public void ChangeFlavourText()
        {
            flavourtext.SetString($"{verbs[verbidx]} {nouns[nounidx]}");

            verbidx = (verbidx + 1) % verbs.Length;
            nounidx = (nounidx + 1) % nouns.Length;

            float time = Util.GetRandomWithVariance(2, 1);
            inst.DoTaskInTime(time, ChangeFlavourText);
        }
    }
}