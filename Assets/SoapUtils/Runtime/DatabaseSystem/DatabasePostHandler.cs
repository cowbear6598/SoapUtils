using System;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace SoapUtils.Runtime.DatabaseSystem
{
    public class DatabasePostHandler
    {
        [Inject] private DatabaseService.Settings settings;
        
        public async UniTask<string> Post(int domainIndex, string api, object data)
        {
            using UnityWebRequest req = new UnityWebRequest(url(domainIndex, api), "POST");
            req.uploadHandler   = GetUploadHandler(data);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            req.timeout = settings.timeout;
            
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