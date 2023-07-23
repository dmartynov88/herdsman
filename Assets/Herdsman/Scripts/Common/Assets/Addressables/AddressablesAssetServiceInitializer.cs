using System.Threading;
using Common.Dependecies.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Assets.Addressables
{
    public class AddressablesAssetServiceInitializer : IBootInitializer
    {
        public UniTask Initialize(CancellationToken cancellationToken)
        {
            return UnityEngine.AddressableAssets.Addressables
                .InitializeAsync()
                .WithCancellation(cancellationToken);
        }
    }
}