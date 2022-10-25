namespace SoapUtils.PrefsSystem
{
    public interface IPrefsService
    {
        void SetString(PrefsService.PrefsType type, string content);
        void SetInt(PrefsService.PrefsType type, int number);
        void SetFloat(PrefsService.PrefsType type, float number);

        bool Exist(PrefsService.PrefsType type);
        
        string GetString(PrefsService.PrefsType type);
        int GetInt(PrefsService.PrefsType type);
        float GetFloat(PrefsService.PrefsType type);
    }
}