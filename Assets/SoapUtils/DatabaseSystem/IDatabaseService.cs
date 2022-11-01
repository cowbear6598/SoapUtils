using Cysharp.Threading.Tasks;

namespace SoapUtils.DatabaseSystem
{
    public interface IDatabaseService
    {
        UniTask<string> DoGet(int domainIndex, string api, params string[] data);
        UniTask<string> DoPost(int domainIndex, string api, object data);
        UniTask<string> DoPost(int domainIndex, string api, string token, object data);
    }
}