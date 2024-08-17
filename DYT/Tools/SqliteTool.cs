using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;

namespace DYT.Tools
{
    public static class SqliteTool
    {
        private static SqliteConnection _sqliteConnection;
        private static SqliteCommand _sqliteCommand;
        private static SqliteDataReader _sqliteDataReader;
        
        public static void LoadDatabase(string path)
        {
            _sqliteConnection = new SqliteConnection($"Data Source={path}");
        }

        
        
        public static void Open()
        {
            _sqliteConnection.Open();
            Debug.Log("Connected to db，连接数据库成功！");
        }
    
        public static void Close()
        {
            _sqliteDataReader?.Dispose();
            _sqliteDataReader = null;
            _sqliteCommand?.Dispose();
            _sqliteCommand = null;
            _sqliteConnection?.Close();
            Debug.Log ("Closed db，成功关闭数据库！");
        }
        

        public static SqliteDataReader ExecuteCommand(
            string commandText, Dictionary<string, object> parameterDictionary = null)
        {
            _sqliteCommand = _sqliteConnection.CreateCommand();
            _sqliteCommand.CommandText = commandText;
            if (parameterDictionary != null)
            {
                foreach (string key in parameterDictionary.Keys)
                {
                    _sqliteCommand.Parameters.AddWithValue(key, parameterDictionary[key]);
                }
            }
            
            try
            {
                _sqliteDataReader = _sqliteCommand.ExecuteReader();
                return _sqliteDataReader;
            }
            catch (Exception)
            {
                Close();
                throw;
            }
        }
        
        public static void ExecuteNonQuery(
            string commandText, Dictionary<string, object> parameterDictionary = null)
        {
            Open();
            
            _sqliteCommand = _sqliteConnection.CreateCommand();
            _sqliteCommand.CommandText = commandText;
            if (parameterDictionary != null)
            {
                foreach (string key in parameterDictionary.Keys)
                {
                    _sqliteCommand.Parameters.AddWithValue(key, parameterDictionary[key]);
                }
            }

            try
            {
                _sqliteCommand.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }

        public static void ExecuteTransaction(params string[] commandTextArray)
        {
            Open();
            
            _sqliteCommand = _sqliteConnection.CreateCommand();
            SqliteTransaction transaction = _sqliteConnection.BeginTransaction();
            try
            {
                foreach (string commandText in commandTextArray)
                {
                    _sqliteCommand.CommandText = commandText;
                    _sqliteCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                Close();
                throw;
            }
            transaction.Commit();
            
            transaction.Dispose();
            Close();
        }
    }
}