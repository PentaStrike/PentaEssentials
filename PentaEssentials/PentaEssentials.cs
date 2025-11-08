using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Capabilities;
using CounterStrikeSharp.API.Core.Plugin.Host;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;
using PentaEssentialsShared;

namespace PentaEssentials;

public class PentaEssentials : PentaPlugin
{
    
    public override string ModuleName => "Penta Essentials";
    
    public override string ModuleVersion => "0.0.1";

    public override string ModuleDescription => "Essentials plugin";
    
    
    public override void Load(bool hotReload)
    {
        Logger.LogInformation("ⓅⓔⓝⓣⓐⒺⓢⓢⓔⓝⓣⓘⓐⓛⓢ");
        
        Capability.Resolve();
        
    }
  
}