using System.Collections.Generic;
using UnityEngine;

namespace Common.UI.Config
{
    [CreateAssetMenu(fileName = "UiConfigSo", menuName = "Configs/UiConfigSo")]
    public class UiConfigSo : ScriptableObject, IWindowsConfigDataProvider
    {
        [field: SerializeField] private List<UIWindowConfig> WindowsConfigsData { get; set; }
        public bool TryGetWindowsConfigData(WindowType windowType, out UIWindowConfig windowConfig)
        {
            foreach (var config in WindowsConfigsData)
            {
                if (config.WindowType == windowType)
                {
                    windowConfig = config;
                    return true;
                }
            }

            windowConfig = null;
            return false;
        }
    }
}