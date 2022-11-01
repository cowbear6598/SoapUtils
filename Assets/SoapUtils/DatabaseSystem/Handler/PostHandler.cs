using System;
using System.Text;
using Cysharp.Threading.Tasks;
using SoapUtils.Installers;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace SoapUtils.DatabaseSystem
{
    internal class PostHandler
    {
        [Inject] private SoapSettingsInstaller.DatabaseSettings settings;

        public async UniTask<string> Post(int domainIndex, string api, object data)
        {
            var req = SetRequest(domainIndex, api, data);

            req.SetRequestHeader("Content-Type", "application/json");
            
            await req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
#if UNITY_EDITOR
                Debug.Log($"{req.url}: \n {req.downloadHandler.text}");
#endif
                return req.downloadHandler.text;
            }

            throw new Exception(req.error);
        }

        public async UniTask<string> Post(int domainIndex, string api, string token, object data)
        {
            var req = SetRequest(domainIndex, api, data);

            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("Authorization", token);
            
            await req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
#if UNITY_EDITOR
                Debug.Log($"{req.url}: \n {req.downloadHandler.text}");
#endif
                return req.downloadHandler.text;
            }

            throw new Exception(req.error);
        }

        private string url(int domainIndex, string api) => $"{settings.domains[domainIndex]}{api}";

        private UnityWebRequest SetRequest(int domainIndex, string api, object data)
        {
            using UnityWebRequest req = new UnityWebRequest(url(domainIndex, api), "POST");
            req.uploadHandler   = GetUploadHandler(data);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.timeout         = settings.timeout;
            return req;
        }

        private UploadHandler GetUploadHandler(object data)
        {
            if (data == null) return null;

            byte[] jsonRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));

            UploadHandler uploadHandler = new UploadHandlerRaw(jsonRaw);
            uploadHandler.contentType = "application/json";

            return uploadHandler;
        }
    }
}