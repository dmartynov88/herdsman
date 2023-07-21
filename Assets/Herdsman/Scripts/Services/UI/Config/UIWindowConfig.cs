using UnityEngine;

namespace Herdsman.Scripts.Services.UI.Abstract
{
    public class UIWindowConfig
    {
        [field: SerializeField] public WindowType windowType { get; private set; }
        [field: SerializeField] public string windowPrefabName { get; private set; }
    }
}