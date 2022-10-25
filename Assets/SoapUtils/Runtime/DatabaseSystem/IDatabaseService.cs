using Cysharp.Threading.Tasks;

namespace SoapUtils.Runtime.DatabaseSystem
{
    public interface IDatabaseService
    {
        UniTask<string> DoGet(int domainIndex, string api, params string[] data);
        UniTask<string> DoPost(int domainIndex, string api, object data);
    }
}