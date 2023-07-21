using Common.Scenes.Models;

namespace Common.Scenes.Abstract
{
    public interface ISceneConfigProvider
    {
        SceneConfig GetSceneConfig();
    }
}