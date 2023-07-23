using System;
using UnityEngine;

namespace Services.UI.Abstract
{
    [Serializable]
    public class UIWindowConfig
    {
        [field: SerializeField] public WindowType WindowType { get; private set; }
        [field: SerializeField] public string WindowPrefabName { get; private set; }
    }
}