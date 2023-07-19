using System.Threading;
using Cysharp.Threading.Tasks;

namespace Dependecies.Abstract
{
    public interface IBootInitializer
    {
        UniTask Initialize(CancellationToken cancellationToken);
    }
}