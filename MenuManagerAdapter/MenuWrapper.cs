using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;
using CS2MenuManager.API.Enum;
using PostSelectAction = CounterStrikeSharp.API.Modules.Menu.PostSelectAction;

namespace MenuManagerAdapter;

internal class MenuWrapper(CS2MenuManager.API.Interface.IMenu inner) : IMenu
{
    public ChatMenuOption AddMenuOption(
        string display,
        Action<CCSPlayerController, ChatMenuOption> onSelect,
        bool disabled = false)
    {
        var option = new ChatMenuOption(display, disabled, onSelect);
        var item = inner.AddItem(display, (player, _) => onSelect(player, option));
        item.PostSelectAction = PostSelectAction.ToPlugin();
        return option;
    }

    public PostSelectAction PostSelectAction
    {
        get => inner.ItemOptions.FirstOrDefault()?.PostSelectAction.ToCore() ?? PostSelectAction.Close;
        set { inner.ItemOptions.ForEach(o => o.PostSelectAction = value.ToPlugin()); }
    }

    public void Open(CCSPlayerController player) => inner.Display(player, 0);

    public void OpenToAll() => inner.DisplayToAll(0);

    public string Title
    {
        get => inner.Title;
        set => inner.Title = value;
    }

    public List<ChatMenuOption> MenuOptions => inner.ItemOptions
        .Select(o => new ChatMenuOption(
            o.Text,
            o.DisableOption != DisableOption.None,
            (controller, _) => o.OnSelect?.Invoke(controller, o))).ToList();

    public bool ExitButton
    {
        get => inner.ExitButton;
        set => inner.ExitButton = value;
    }
}