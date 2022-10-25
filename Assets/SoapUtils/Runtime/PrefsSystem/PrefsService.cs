﻿using UnityEngine;

namespace SoapUtils.Runtime.PrefsSystem
{
    public class PrefsService : IPrefsService
    {
        public enum PrefsType
        {
            Account,
            Password,
            IsUsingVibration,
            BGM_Volume,
            Effect_Volume
        }
        
        public void SetString(PrefsType type, string content)
        {
            PlayerPrefs.SetString(type.ToString(), content);
            PlayerPrefs.Save();
        }
        
        public void SetInt(PrefsType type, int number)
        {
            PlayerPrefs.SetInt(type.ToString(), number);
            PlayerPrefs.Save();
        }
        
        public void SetFloat(PrefsType type, float number)
        {
            PlayerPrefs.SetFloat(type.ToString(), number);
            PlayerPrefs.Save();
        }
        
        public bool Exist(PrefsType type) => PlayerPrefs.HasKey(type.ToString());

        public string GetString(PrefsType type) => Exist(type) ? PlayerPrefs.GetString(type.ToString()) : "";
        public int GetInt(PrefsType type) => Exist(type) ? PlayerPrefs.GetInt(type.ToString()) : 0;
        public float GetFloat(PrefsType type) => Exist(type) ? PlayerPrefs.GetFloat(type.ToString()) : 0;
    }
}