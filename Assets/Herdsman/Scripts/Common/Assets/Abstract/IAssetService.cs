using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Common.Assets.Abstract
{
    public interface IAssetService : IDisposable
    {
        UniTask<TObject> LoadAsync<TObject>(string assetId, IAssetContext context, CancellationToken cancellationToken)
            where TObject : Object;

        UniTask<TObject> LoadComponentAsync<TObject>(string assetId, IAssetContext context,
            CancellationToken cancellationToken);

        UniTask<TObject> LoadAsync<TObject>(string assetId, CancellationToken cancellationToken)
            where TObject : Object;

        UniTask<TObject> LoadComponentAsync<TObject>(string assetId, CancellationToken cancellationToken);

        UniTask<Scene> LoadSceneAsync(string assetId, CancellationToken cancellationToken);
        UniTask<Scene> LoadSceneAsync(string assetId, IAssetContext context, CancellationToken cancellationToken);
        UniTask<Scene> LoadSceneAsync(string assetId, LoadSceneMode loadMode, CancellationToken cancellationToken);
        UniTask<Scene> LoadSceneAsync(string assetId, IAssetContext context, LoadSceneMode loadMode, CancellationToken cancellationToken);
        
        void Unload(IAssetContext context);
    }
}