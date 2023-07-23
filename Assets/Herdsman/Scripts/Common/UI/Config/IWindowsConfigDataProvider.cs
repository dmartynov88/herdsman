namespace Common.UI.Config
{
    public interface IWindowsConfigDataProvider
    {
        bool TryGetWindowsConfigData(WindowType windowType, out UIWindowConfig windowConfig);
    }
}