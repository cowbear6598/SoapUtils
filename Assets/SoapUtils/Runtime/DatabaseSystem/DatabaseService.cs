using System;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace SoapUtils.Runtime.DatabaseSystem
{
    public class DatabaseService : IDatabaseService
    {
        [Inject] private readonly DatabaseGetHandler  getHandler;
        [Inject] private readonly DatabasePostHandler postHandler;
        
        public async UniTask<string> DoGet(int domainIndex, string api, params string[] data) => await getHandler.Get(domainIndex, api, data);
        public async UniTask<string> DoPost(int domainIndex, string api, object data) => await postHandler.Post(domainIndex, api, data);
        
        [Serializable]
        public class Settings
        {
            public string[] domains;
            public int      timeout;
        }
    }
}