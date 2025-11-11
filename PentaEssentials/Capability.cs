using CounterStrikeSharp.API.Core.Capabilities;
using PentaEssentials.Reverb;
using PentaEssentialsShared;
using PusherClient;

namespace PentaEssentials;

public class Capability
{
    public static readonly PluginCapability<IPentaConfiguration> CoreConfig = new ("penta:essentials:configuration");
    private static PentaConfiguration _PentaConfig;
    
    
    public static readonly PluginCapability<IPentaReverb> PentaReverb = new("penta:essentials:reverb");
    private static PentaReverb _PentaReverb;
    
    public static void Resolve()
    {
        Capabilities.RegisterPluginCapability(CoreConfig, (() => (_PentaConfig = PentaConfiguration.Make())));
        
        var options = new PusherOptions
        {
            Host = "reverb.pentastrike.ru", Authorizer = new PentaReverbAuthorizer()
            {
               PentaReverbHost = "https://pentastrike.ru/reverb/penta-auth",
               PentaReverbBroadcastingHost = "https://pentastrike.ru/broadcasting/auth",
               PentaIntegrationToken = ""
            }
        };
        
        Capabilities.RegisterPluginCapability(PentaReverb, (() => (_PentaReverb = new PentaReverb("", options)
        )));
    }
}