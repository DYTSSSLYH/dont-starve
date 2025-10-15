using System.Collections.Generic;

namespace DYT.Map.StaticLayouts
{
    public class SkeletonResearchlab1
    {
        public static Layout Main()
        {
            return new Layout
            {
                version = "1.1",
                luaversion = "5.1",
                orientation = "orthogonal",
                width = 32,
                height = 32,
                tilewidth = 16,
                tileheight = 16,
                properties = { },
                tilesets =
                {
                    new Layout.Tile
                    {
                        name = "tiles",
                        firstgid = 1,
                        tilewidth = 64,
                        tileheight = 64,
                        spacing = 0,
                        margin = 0,
                        image = "../../../../tools/tiled/dont_starve/tiles.png",
                        imagewidth = 512,
                        imageheight = 128,
                        properties = { },
                        tiles = { }
                    }
                },
                layers =
                {
                    new Layout.Item
                    {
                        type = "tilelayer",
                        name = "BG_TILES",
                        x = 0,
                        y = 0,
                        width = 32,
                        height = 32,
                        visible = true,
                        opacity = 1,
                        properties = { },
                        encoding = "lua",
                        data =
                        {
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                        }
                    },
                    new Layout.Item
                    {
                        type = "objectgroup",
                        name = "FG_OBJECTS",
                        visible = true,
                        opacity = 1,
                        properties = { },
                        objects = new List<Layout.Item>
                        {
                            new()
                            {
                                name = "",
                                type = "skeleton",
                                shape = "rectangle",
                                x = 249,
                                y = 280,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = { }
                            },
                            new()
                            {
                                name = "",
                                type = "evergreen_short",
                                shape = "rectangle",
                                x = 44,
                                y = 46,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "evergreen_tall",
                                shape = "rectangle",
                                x = 416,
                                y = 48,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "evergreen_normal",
                                shape = "rectangle",
                                x = 446,
                                y = 323,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "evergreen_tall",
                                shape = "rectangle",
                                x = 87,
                                y = 17,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "evergreen_tall",
                                shape = "rectangle",
                                x = 125,
                                y = 486,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "researchlab",
                                shape = "rectangle",
                                x = 126,
                                y = 177,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "treasurechest",
                                shape = "rectangle",
                                x = 171,
                                y = 132,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "farmplot",
                                shape = "rectangle",
                                x = 182,
                                y = 239,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "farmplot",
                                shape = "rectangle",
                                x = 225,
                                y = 187,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "pitchfork",
                                shape = "rectangle",
                                x = 285,
                                y = 253,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                            new()
                            {
                                name = "",
                                type = "strawhat",
                                shape = "rectangle",
                                x = 187,
                                y = 312,
                                width = 0,
                                height = 0,
                                visible = true,
                                properties = {}
                            },
                        }
                    }
                }
            };
        }
    }
}