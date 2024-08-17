using System.Collections.Generic;

namespace DYT
{
    public class Achievement
    {
        public string name;

        public class ID
        {
            public string steam;
            public int psn;
        }

        public ID id;
    }

    public class Achievements
    {
        public static List<Achievement> achievementList = new List<Achievement>
        {
            new Achievement
            {
                name = "achievement_1",
                id = new Achievement.ID
                {
                    steam = "achievement_1",
                    psn = 0,
                },
            },
            new Achievement
            {
                name = "achievement_2",
                id = new Achievement.ID
                {
                    steam = "achievement_2",
                    psn = 1,
                },
            },
            new Achievement
            {
                name = "achievement_3",
                id = new Achievement.ID
                {
                    steam = "achievement_3",
                    psn = 2,
                },
            },
            new Achievement
            {
                name = "achievement_4",
                id = new Achievement.ID
                {
                    steam = "achievement_6",
                    psn = 3,
                },
            },
            new Achievement
            {
                name = "achievement_5",
                id = new Achievement.ID
                {
                    steam = "achievement_5",
                    psn = 4,
                },
            },
            new Achievement
            {
                name = "achievement_6",
                id = new Achievement.ID
                {
                    steam = "achievement_6",
                    psn = 5,
                },
            },
            new Achievement
            {
                name = "achievement_7",
                id = new Achievement.ID
                {
                    steam = "achievement_7",
                    psn = 6,
                },
            },
            new Achievement
            {
                name = "achievement_8",
                id = new Achievement.ID
                {
                    steam = "achievement_8",
                    psn = 7,
                },
            },
            new Achievement
            {
                name = "achievement_9",
                id = new Achievement.ID
                {
                    steam = "achievement_9",
                    psn = 8,
                },
            },
            new Achievement
            {
                name = "achievement_10",
                id = new Achievement.ID
                {
                    steam = "achievement_10",
                    psn = 9,
                },
            },
        };
    }
}