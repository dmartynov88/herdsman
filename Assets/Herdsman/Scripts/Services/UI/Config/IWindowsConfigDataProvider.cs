using System.Collections.Generic;

namespace Services.UI.Abstract
{
    public interface IWindowsConfigDataProvider
    {
        bool TryGetWindowsConfigData(WindowType windowType, out UIWindowConfig windowConfig);
    }
}