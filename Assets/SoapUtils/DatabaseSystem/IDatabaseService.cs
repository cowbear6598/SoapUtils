using Cysharp.Threading.Tasks;

namespace SoapUtils.DatabaseSystem
{
    public interface IDatabaseService
    {
        UniTask<string> DoGet(int domainIndex, string api, params string[] data);
        UniTask<string> DoGet(int domainIndex, string api, string token, params string[] data);
        
        UniTask<string> DoPost(int domainIndex, string api, object data);
        UniTask<string> DoPost(int domainIndex, string api, string token, object data);
        
        UniTask<string> DoPut(int domainIndex, string api, object data);
        UniTask<string> DoPut(int domainIndex, string api, string token, object data);
        
        UniTask<string> DoDelete(int domainIndex, string api, string token, object data);
    }
}