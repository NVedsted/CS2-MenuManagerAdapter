using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;
using CS2MenuManager.API.Class;
using MenuManager;
using BaseMenu = CS2MenuManager.API.Class.BaseMenu;

namespace MenuManagerAdapter;

internal class MenuApiAdapter(MenuManagerAdapterPlugin plugin) : IMenuApi
{
    public IMenu GetMenu(
        string title,
        Action<CCSPlayerController>? backAction = null,
        Action<CCSPlayerController>? resetAction = null) =>
        GetMenuForcetype(title, MenuType.Default, backAction, resetAction);

    public IMenu NewMenu(string title, Action<CCSPlayerController>? backAction = null) =>
        GetMenu(title, backAction);

    public IMenu GetMenuForcetype(
        string title,
        MenuType type,
        Action<CCSPlayerController>? backAction = null,
        Action<CCSPlayerController>? resetAction = null)
    {
        if (resetAction is not null)
        {
            throw new NotSupportedException("Reset action is not supported by the adapter");
        }

        var pluginMenu = CS2MenuManager.API.Class.MenuManager.MenuByType(type.ToNewMenuType(), title, plugin);

        if (backAction is not null)
        {
            pluginMenu.PrevMenu = new BackActionMenu(plugin, backAction);
        }

        return new MenuWrapper(pluginMenu);
    }

    public IMenu NewMenuForcetype(string title, MenuType type, Action<CCSPlayerController>? backAction = null) =>
        GetMenuForcetype(title, type, backAction);

    public void CloseMenu(CCSPlayerController player) => CS2MenuManager.API.Class.MenuManager.CloseActiveMenu(player);

    public MenuType GetMenuType(CCSPlayerController player) => MenuTypeManager.GetPlayerMenuType(player)!.ToOldMenuType();

    public bool HasOpenedMenu(CCSPlayerController player) =>
        CS2MenuManager.API.Class.MenuManager.GetActiveMenu(player) is not null;

    private class BackActionMenu(BasePlugin plugin, Action<CCSPlayerController> backAction) : BaseMenu("", plugin)
    {
        public override void Display(CCSPlayerController player, int time)
        {
            backAction(player);
        }

        public override void DisplayAt(CCSPlayerController player, int firstItem, int time) => Display(player, time);
    }
}