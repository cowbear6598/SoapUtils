using System;
using System.Text;
using Cysharp.Threading.Tasks;
using SoapUtils.Installers;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace SoapUtils.DatabaseSystem
{
    public class RequestHandler
    {
        [Inject] private SoapSettingsInstaller.DatabaseSettings settings;

        public async UniTask<string> Request(string method, int domainIndex, string api, string token = "", object data = null, params string[] queries)
        {
            using UnityWebRequest req = new UnityWebRequest(url(domainIndex, api, queries), method);

            if (data != null)
                req.uploadHandler = GetUploadHandler(data);

            req.downloadHandler = new DownloadHandlerBuffer();
            req.timeout         = settings.timeout;

            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("Authorization", token);

            await req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
#if UNITY_EDITOR
                Debug.Log($"result: \n {req.downloadHandler.text}");
#endif
                return req.downloadHandler.text;
            }

            throw new Exception(req.error);
        }

        private string url(int domainIndex, string api, params string[] queries)
        {
            string url = $"{settings.domains[domainIndex]}{api}";

            if (queries.Length > 0)
            {
                url += "?";

                for (int i = 0; i < queries.Length; i++)
                {
                    url += queries[i] + ((i == queries.Length - 1) ? "" : "&");
                }
            }

#if UNITY_EDITOR
            Debug.Log($"req url: {url}");
#endif

            return url;
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