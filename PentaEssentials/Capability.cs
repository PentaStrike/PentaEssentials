using CounterStrikeSharp.API.Core.Capabilities;
using PentaEssentialsShared;

namespace PentaEssentials;

public class Capability
{
    public static readonly PluginCapability<IPentaConfiguration> CoreConfig = new ("penta:essentials:configuration");
    private static PentaConfiguration _PentaConfig;
    
    public static void Resolve()
    {
        Capabilities.RegisterPluginCapability(CoreConfig, (() => (_PentaConfig = PentaConfiguration.Make())));
    }
}