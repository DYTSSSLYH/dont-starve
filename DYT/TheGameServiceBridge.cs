using System;
using System.Collections.Generic;
using UnityEngine;

namespace DYT
{
    public class TheGameServiceBridge
    {
        // —— 本地持久化键前缀 ——
        private const string AchvMetaNamePrefix = "gs:achvmeta:name:";  // 成就名称
        private const string AchvMetaDescPrefix = "gs:achvmeta:desc:";  // 成就描述
        private const string AchvMetaPtsPrefix  = "gs:achvmeta:pts:";   // 成就点数
        
        // 成就元数据
        private class AchievementMeta
        {
            public string Name;
            public string Desc;
            public int Points;
        }
        private readonly Dictionary<string, AchievementMeta> _achvMeta =
            new Dictionary<string, AchievementMeta>(StringComparer.Ordinal);
        

        // ========== 成就：注册/达成/清除/查询 ==========

        /// <summary>
        /// 注册一个成就（带元数据）
        /// </summary>
        public void RegisterAchievement(string name, string steamId, int psn)
        {
            _achvMeta[name] = new AchievementMeta
            {
                Name = name,
                Desc = steamId,
                Points = psn
            };
            PersistAchievementMeta(name, _achvMeta[name]);
        }

        // ========== 成就元数据持久化（可选） ==========

        private static void PersistAchievementMeta(string id, AchievementMeta meta)
        {
            if (meta == null || string.IsNullOrEmpty(id)) return;
            PlayerPrefs.SetString(AchvMetaNamePrefix + id, meta.Name ?? id);
            PlayerPrefs.SetString(AchvMetaDescPrefix + id, meta.Desc ?? "");
            PlayerPrefs.SetInt(AchvMetaPtsPrefix + id, meta.Points);
            PlayerPrefs.Save();
        }
    }
}