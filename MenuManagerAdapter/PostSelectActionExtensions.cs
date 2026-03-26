using PluginPostSelectAction = CS2MenuManager.API.Enum.PostSelectAction;
using CorePostSelectAction = CounterStrikeSharp.API.Modules.Menu.PostSelectAction;

namespace MenuManagerAdapter;

internal static class PostSelectActionExtensions
{
    public static PluginPostSelectAction ToPlugin(this CorePostSelectAction action) => action switch
    {
        CorePostSelectAction.Close => PluginPostSelectAction.Close,
        CorePostSelectAction.Reset => PluginPostSelectAction.Reset,
        CorePostSelectAction.Nothing => PluginPostSelectAction.Nothing,
        _ => throw new ArgumentOutOfRangeException()
    };

    public static CorePostSelectAction ToCore(this PluginPostSelectAction action) => action switch
    {
        PluginPostSelectAction.Close => CorePostSelectAction.Close,
        PluginPostSelectAction.Reset => CorePostSelectAction.Reset,
        PluginPostSelectAction.Nothing => CorePostSelectAction.Nothing,
        _ => throw new ArgumentOutOfRangeException()
    };
}