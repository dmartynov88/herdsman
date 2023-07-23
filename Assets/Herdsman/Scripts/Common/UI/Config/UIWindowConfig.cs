using System;
using UnityEngine;

namespace Common.UI.Config
{
    [Serializable]
    public class UIWindowConfig
    {
        [field: SerializeField] public WindowType WindowType { get; private set; }
        [field: SerializeField] public string WindowPrefabName { get; private set; }
    }
}