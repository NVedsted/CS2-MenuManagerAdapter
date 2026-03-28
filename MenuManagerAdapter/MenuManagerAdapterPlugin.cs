using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using MenuManager;

namespace MenuManagerAdapter;

public class MenuManagerAdapterPlugin : BasePlugin
{
    public override string ModuleName => "Menu Manager Adapter";
    public override string ModuleVersion => "0.0.1";
    public override string ModuleAuthor => "Nicklas Vedsted";
    public override string ModuleDescription => "Makes plugins built on top of MenuManagerCS2 use CS2MenuManagerer instead.";

    public override void Load(bool hotReload)
    {
        PluginCapability<IMenuApi> capability = new("menu:nfcore");
        Capabilities.RegisterPluginCapability(capability, () => new MenuApiAdapter(this));
    }
}