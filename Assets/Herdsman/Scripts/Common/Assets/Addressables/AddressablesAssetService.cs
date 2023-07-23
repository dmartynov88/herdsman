using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common.Assets.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Common.Assets.Addressables
{
    public partial class AddressablesAssetService : IAssetService
    {
        private readonly Dictionary<string, GameObject> loadedGameObjects = new();
        private readonly Dictionary<string, Object> loadedObjects = new();
        private readonly Dictionary<string, SceneInstance> loadedSceneObjects = new();
        private readonly Dictionary<string, UniTaskCompletionSource> loadingAssetCompletionSources = new();

        private readonly Dictionary<IAssetContext, HashSet<string>> assetsByContext = new();
        private readonly Dictionary<string, HashSet<IAssetContext>> contextsByAsset = new();

        public UniTask<Scene> LoadSceneAsync(string assetId, CancellationToken cancellationToken)
        {
            return LoadSceneAsync(assetId, GlobalAssetContext.Instance, LoadSceneMode.Single, cancellationToken);
        }
        
        public UniTask<Scene> LoadSceneAsync(string assetId, IAssetContext context, CancellationToken cancellationToken)
        {
            return LoadSceneAsync(assetId, context, LoadSceneMode.Single, cancellationToken);
        }
        
        public UniTask<Scene> LoadSceneAsync(string assetId, LoadSceneMode loadMode, CancellationToken cancellationToken)
        {
            return LoadSceneAsync(assetId, GlobalAssetContext.Instance, loadMode, cancellationToken);
        }
        
        public async UniTask<Scene> LoadSceneAsync(string assetId, IAssetContext context, LoadSceneMode loadMode, CancellationToken cancellationToken)
        {
            Debug.Log($"Loading scene '{assetId}'...");
            
            if (loadingAssetCompletionSources.TryGetValue(assetId, out UniTaskCompletionSource loadingInProgress)) {
                await loadingInProgress.Task;
            }
            
            if (!loadedSceneObjects.TryGetValue(assetId, out SceneInstance asset))
            {
                UniTaskCompletionSource loadingCompletionSource = new();
                loadingAssetCompletionSources.Add(assetId, loadingCompletionSource);

                try
                {
                    asset = await UnityEngine.AddressableAssets.Addressables
                        .LoadSceneAsync(assetId, loadMode)
                        .WithCancellation(cancellationToken);
                }
                catch (Exception e)
                {
                    loadingAssetCompletionSources.Remove(assetId);
                    loadingCompletionSource.TrySetException(e);
                    throw;
                }

                loadedSceneObjects.Add(assetId, asset);

                Debug.Log($"The scene '{assetId}' is loaded");

                loadingAssetCompletionSources.Remove(assetId);
                loadingCompletionSource.TrySetResult();
            }
            else
            {
                Debug.Log($"Return cached asset '{assetId}'");
            }

            AddAssetToContext(assetId, context);

            return asset.Scene;
        }
        
        public async UniTask<TObject> LoadAsync<TObject>(string assetId, IAssetContext context,
            CancellationToken cancellationToken) where TObject : Object
        {
            Debug.Log($"Loading asset '{assetId}'...");

            if (loadingAssetCompletionSources.TryGetValue(assetId, out UniTaskCompletionSource loadingInProgress))
            {
                await loadingInProgress.Task;
            }

            if (!loadedObjects.TryGetValue(assetId, out Object asset))
            {
                UniTaskCompletionSource loadingCompletionSource = new();
                loadingAssetCompletionSources.Add(assetId, loadingCompletionSource);

                try
                {
                    asset = await UnityEngine.AddressableAssets.Addressables
                        .LoadAssetAsync<TObject>(assetId)
                        .WithCancellation(cancellationToken);
                }
                catch (Exception e)
                {
                    loadingAssetCompletionSources.Remove(assetId);
                    loadingCompletionSource.TrySetException(e);

                    throw;
                }

                loadedObjects.Add(assetId, asset);

                Debug.Log($"The asset '{assetId}' is loaded");

                loadingAssetCompletionSources.Remove(assetId);
                loadingCompletionSource.TrySetResult();
            }
            else
            {
                Debug.Log($"Return cached asset '{assetId}'");
            }

            AddAssetToContext(assetId, context);

            return (TObject)asset;
        }

        public async UniTask<TObject> LoadComponentAsync<TObject>(string assetId, IAssetContext context,
            CancellationToken cancellationToken)
        {
            Debug.Log($"Loading asset '{assetId}'...");

            if (loadingAssetCompletionSources.TryGetValue(assetId, out UniTaskCompletionSource loadingInProgress))
            {
                await loadingInProgress.Task;
            }

            if (!loadedGameObjects.TryGetValue(assetId, out GameObject asset))
            {
                UniTaskCompletionSource loadingCompletionSource = new();
                loadingAssetCompletionSources.Add(assetId, loadingCompletionSource);

                try
                {
                    asset = await UnityEngine.AddressableAssets.Addressables
                        .LoadAssetAsync<GameObject>(assetId)
                        .WithCancellation(cancellationToken);
                }
                catch (Exception e)
                {
                    loadingAssetCompletionSources.Remove(assetId);
                    loadingCompletionSource.TrySetException(e);

                    throw;
                }

                loadedGameObjects.Add(assetId, asset);

                Debug.Log($"The asset '{assetId}' is loaded");

                loadingAssetCompletionSources.Remove(assetId);
                loadingCompletionSource.TrySetResult();
            }
            else
            {
                Debug.Log($"Return cached asset '{assetId}'");
            }

            AddAssetToContext(assetId, context);

            return asset.GetComponent<TObject>();
        }

        public UniTask<TObject> LoadAsync<TObject>(string assetId, CancellationToken cancellationToken)
            where TObject : Object
        {
            return LoadAsync<TObject>(assetId, GlobalAssetContext.Instance, cancellationToken);
        }

        public UniTask<TObject> LoadComponentAsync<TObject>(string assetId, CancellationToken cancellationToken)
        {
            return LoadComponentAsync<TObject>(assetId, GlobalAssetContext.Instance, cancellationToken);
        }
        
        private void AddAssetToContext(string assetId, IAssetContext context)
        {
            if (assetsByContext.TryGetValue(context, out HashSet<string> contextAssets) is false)
            {
                contextAssets = new HashSet<string>();
                assetsByContext[context] = contextAssets;
            }

            contextAssets.Add(assetId);

            if (contextsByAsset.TryGetValue(assetId, out HashSet<IAssetContext> assetContexts) is false)
            {
                assetContexts = new HashSet<IAssetContext>();
                contextsByAsset[assetId] = assetContexts;
            }

            assetContexts.Add(context);
        }


        public void Unload(IAssetContext context)
        {
            if (assetsByContext.ContainsKey(context) is false)
            {
                return;
            }

            HashSet<string> assetsToUnload = RemoveAssets(context);

            ReleaseAssets(assetsToUnload);
        }

        private HashSet<string> RemoveAssets(IAssetContext context)
        {
            HashSet<string> assets = assetsByContext[context];
            HashSet<string> assetsToUnload = new();

            foreach (string asset in assets)
            {
                HashSet<IAssetContext> assetContexts = contextsByAsset[asset];
                assetContexts.Remove(context);

                if (assetContexts.Count == 0)
                {
                    assetsToUnload.Add(asset);
                    contextsByAsset.Remove(asset);
                }
            }

            assetsByContext.Remove(context);

            return assetsToUnload;
        }

        private void ReleaseAssets(HashSet<string> assetsToUnload)
        {
            foreach (string asset in assetsToUnload)
            {
                if (loadedObjects.ContainsKey(asset))
                {
                    UnityEngine.AddressableAssets.Addressables.Release(loadedObjects[asset]);
                    loadedObjects.Remove(asset);

                    Debug.Log($"Release object asset '{asset}'");
                }

                if (loadedGameObjects.ContainsKey(asset))
                {
                    UnityEngine.AddressableAssets.Addressables.Release(loadedGameObjects[asset]);
                    loadedGameObjects.Remove(asset);

                    Debug.Log($"Release game object asset '{asset}'");
                }
                
                if (loadedSceneObjects.ContainsKey(asset))
                {
                    UnityEngine.AddressableAssets.Addressables.Release(loadedSceneObjects[asset]);
                    SceneManager.UnloadSceneAsync(loadedSceneObjects[asset].Scene);
                    loadedSceneObjects.Remove(asset);

                    Debug.Log($"Release scene asset '{asset}'");
                }
            }
        }

        public void Dispose()
        {
            foreach (IAssetContext context in assetsByContext.Keys.ToArray())
            {
                Unload(context);

                Debug.Log($"Dispose context '{context.GetType()}'");
            }
        }

        private class GlobalAssetContext : IAssetContext
        {
            public static readonly GlobalAssetContext Instance = new();

            private GlobalAssetContext()
            {
                //empty
            }
        }
    }
}