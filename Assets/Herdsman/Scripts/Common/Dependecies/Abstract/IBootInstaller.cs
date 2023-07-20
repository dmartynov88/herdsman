using System.Threading;
using Cysharp.Threading.Tasks;

namespace Common.Dependecies.Abstract
{
    public interface IBootInitializer
    {
        UniTask Initialize(CancellationToken cancellationToken);
    }
}