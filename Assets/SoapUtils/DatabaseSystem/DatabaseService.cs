using Cysharp.Threading.Tasks;
using Zenject;

namespace SoapUtils.DatabaseSystem
{
    internal class DatabaseService : IDatabaseService
    {
        [Inject] private readonly GetHandler  getHandler;
        [Inject] private readonly PostHandler postHandler;
        [Inject] private readonly PutHandler  putHandler;
        
        public async UniTask<string> DoGet(int domainIndex, string api, params string[] data) => await getHandler.Get(domainIndex, api, data);
        
        public async UniTask<string> DoPost(int domainIndex, string api, object data) => await postHandler.Post(domainIndex, api, data);
        public async UniTask<string> DoPost(int domainIndex, string api, string token, object data) => await postHandler.Post(domainIndex, api, token, data);
        
        public async UniTask<string> DoPut(int domainIndex, string api, object data) => await putHandler.Put(domainIndex, api, data);
        public async UniTask<string> DoPut(int domainIndex, string api, string token, object data) => await putHandler.Put(domainIndex, api, token, data);
    }
}