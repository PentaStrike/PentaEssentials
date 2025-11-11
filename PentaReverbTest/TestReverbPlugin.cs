namespace PentaReverbTest;

// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using PentaEssentials;
using PentaEssentials.Reverb;

public class TestReverbPlugin : PentaPlugin
{
    
    public override string ModuleName => "Penta Reverbing Testing";
    
    public override string ModuleVersion => "0.0.1";

    public override string ModuleDescription => "Essentials plugin";
    
    
    public async override void Load(bool hotReload)
    {
        Logger.LogInformation("! Ⓟⓔⓝⓣⓐ REVERB TESTING !");
        
        Capability.Resolve();

        var pentaR = ((PentaReverb)Capability.PentaReverb.Get());
        
        await pentaR.ConnectAsync();

        var channel = await pentaR.SubscribePrivateAsync("private-chat");
        await channel.TriggerAsync("client-message-send", new { text = "payload" });
       

    }
  
}