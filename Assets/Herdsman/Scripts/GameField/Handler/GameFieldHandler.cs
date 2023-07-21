using Common.Scenes.Models;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameFieldHandler
{
    //load scene from addressables
    //change weather, control day/night, armageddon mode ;)

    public async UniTask LoadGameField(SceneConfig sceneConfig)
    {
        //ToDo load scene from addressables
        await SceneManager.LoadSceneAsync(sceneConfig.SceneName, LoadSceneMode.Additive);
    }
}
