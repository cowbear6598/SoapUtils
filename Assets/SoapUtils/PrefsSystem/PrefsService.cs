using UnityEngine;

namespace SoapUtils.PrefsSystem
{
    internal class PrefsService : IPrefsService
    {
        public void SetString(string name, string content)
        {
            PlayerPrefs.SetString(name, content);
            PlayerPrefs.Save();
        }

        public void SetInt(string name, int number)
        {
            PlayerPrefs.SetInt(name, number);
            PlayerPrefs.Save();
        }

        public void SetFloat(string name, float number)
        {
            PlayerPrefs.SetFloat(name, number);
            PlayerPrefs.Save();
        }

        public bool Exist(string name) => PlayerPrefs.HasKey(name);

        public string GetString(string name) => Exist(name) ? PlayerPrefs.GetString(name) : "";
        public int GetInt(string name) => Exist(name) ? PlayerPrefs.GetInt(name) : 0;
        public float GetFloat(string name) => Exist(name) ? PlayerPrefs.GetFloat(name) : 0;
    }
}