using Common.Scenes.Models;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameFieldHandler
{
    //load scene from addressables
    //change weather, control day/night, armageddon mode ;)

    private SceneConfig sceneConfig;

    public async UniTask LoadGameField(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
        
        //ToDo load scene from addressables
        await SceneManager.LoadSceneAsync(sceneConfig.SceneName, LoadSceneMode.Additive);
    }

    public async UniTask  UnloadGameField()
    {
        await SceneManager.UnloadSceneAsync(sceneConfig.SceneName);
    }
}
