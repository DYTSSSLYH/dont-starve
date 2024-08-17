using System;
using System.Collections.Generic;
using System.Reflection;
using DYT;
using Newtonsoft.Json;
using UnityEngine;

public class Morgue
{
    public class Data : IComparable<Data>
    {
        public int? daysSurvived { get; set; }
        public string character { get; set; }
        public string killedBy { get; set; }
        public string world { get; set; }
        
        public int CompareTo(Data other)
        {
            return other.daysSurvived.GetValueOrDefault(1) - daysSurvived.GetValueOrDefault(1);
        }
    }
    public static List<Data> persistData { get; private set; } = new List<Data>();
    private static bool _dirty { get; set; } = true;
    
    #region 1

    public static void Sort(string field = null)
    {
        if (string.IsNullOrWhiteSpace(field)) persistData.Sort();
        else
        {
            FieldInfo fieldInfo = typeof(Data).GetField(field);
            persistData.Sort((a ,b) =>
            {
                object aVal = fieldInfo.GetValue(a);
                object bVal = fieldInfo.GetValue(b);
            
                if (fieldInfo.FieldType == typeof(string))
                {
                    if (aVal == null) aVal = "";
                    if (bVal == null) bVal = "";
                }
                else
                {
                    if (aVal == null) aVal = 0;
                    if (bVal == null) bVal = 0;
                }

                return aVal.GetHashCode() - bVal.GetHashCode();
            });
        }
    }
    
    #endregion

    #region 2

    public static string GetSaveName()
    {
        return "morgue";
    }
    

    public static void Load(Action<bool> callback)
    {
        TheSim.GetPersistentString(GetSaveName(), (load_success, str) =>
        {
            // Can ignore the successfulness cause we check the string
            Set(str, callback);
        }, false);
    }

    public static void Set(string str, Action<bool> callback)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            Debug.Log($"PlayerDeaths could not load {GetSaveName()}");
            callback?.Invoke(false);
        }
        else
        {
            DebugPrint.Print($"PlayerDeaths loaded {GetSaveName()}", str.Length);

            persistData = JsonConvert.DeserializeObject<List<Data>>(str);
            Sort();

            _dirty = false;
            callback?.Invoke(true);
        }
    }

    #endregion
}