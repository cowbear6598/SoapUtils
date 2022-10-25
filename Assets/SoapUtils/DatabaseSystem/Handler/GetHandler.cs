using System;
using Cysharp.Threading.Tasks;
using SoapUtils.Installers;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace SoapUtils.DatabaseSystem
{
    internal class GetHandler
    {
        [Inject] private SoapSettingsInstaller.DatabaseSettings settings;
        
        public async UniTask<string> Get(int domainIndex, string api, params string[] data)
        {
            using UnityWebRequest req = UnityWebRequest.Get(url(domainIndex, api, data));
            
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
        
        private string url(int domainIndex, string api, params string[] data)
        {
            string finalUrl = $"{settings.domains[domainIndex]}{api}?";

            for (int i = 0; i < data.Length; i++)
                finalUrl += data[i];

            return finalUrl;
        }
    }
}