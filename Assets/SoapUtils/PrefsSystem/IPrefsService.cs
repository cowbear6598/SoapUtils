namespace SoapUtils.PrefsSystem
{
    public interface IPrefsService
    {
        void SetString(string name, string content);
        void SetInt(string name, int number);
        void SetFloat(string name, float number);

        bool Exist(string name);
        
        string GetString(string name);
        int GetInt(string name);
        float GetFloat(string name);
    }
}