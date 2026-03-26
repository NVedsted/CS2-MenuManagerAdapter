using System.Collections.Frozen;
using CS2MenuManager.API.Menu;
using MenuManager;

namespace MenuManagerAdapter;

public static class MenuTypeExtensions
{
    public static Type ToNewMenuType(this MenuType type) => type switch
    {
        MenuType.ChatMenu => typeof(ChatMenu),
        MenuType.ConsoleMenu => typeof(ConsoleMenu),
        MenuType.CenterMenu => typeof(CenterHtmlMenu),
        MenuType.ButtonMenu => typeof(WasdMenu),
        _ => typeof(PlayerMenu),
    };

    private static readonly FrozenDictionary<Type, MenuType> TypeMap = new Dictionary<Type, MenuType>
    {
        { typeof(ChatMenu), MenuType.ChatMenu },
        { typeof(WasdMenu), MenuType.ButtonMenu },
        { typeof(CenterHtmlMenu), MenuType.CenterMenu },
        { typeof(ConsoleMenu), MenuType.ConsoleMenu },
    }.ToFrozenDictionary();

    public static MenuType ToOldMenuType(this Type type) => TypeMap.GetValueOrDefault(type, MenuType.Default);
}