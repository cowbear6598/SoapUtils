using Cysharp.Threading.Tasks;
using Zenject;

namespace SoapUtils.DatabaseSystem
{
    internal class DatabaseService : IDatabaseService
    {
        [Inject] private readonly RequestHandler requestHandler;

        public async UniTask<string> DoGet(int domainIndex, string api, params string[] data) => await requestHandler.Request("GET", domainIndex, api, "", null, data);
        public async UniTask<string> DoGet(int domainIndex, string api, string token, params string[] data) => await requestHandler.Request("GET", domainIndex, api, token, null, data);

        public async UniTask<string> DoPost(int domainIndex, string api, object data) => await requestHandler.Request("POST", domainIndex, api, "", data);
        public async UniTask<string> DoPost(int domainIndex, string api, string token, object data) => await requestHandler.Request("POST", domainIndex, api, token, data);

        public async UniTask<string> DoPut(int domainIndex, string api, object data) => await requestHandler.Request("PUT", domainIndex, api, "", data);
        public async UniTask<string> DoPut(int domainIndex, string api, string token, object data) => await requestHandler.Request("PUT", domainIndex, api, token, data);

        public async UniTask<string> DoDelete(int domainIndex, string api, string token, object data) => await requestHandler.Request("DELETE", domainIndex, api, token, data);
    }
}