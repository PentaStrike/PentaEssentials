using System.Text.Json;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities;
using PentaEssentialsShared;

namespace PentaEssentials;

public class PentaConfiguration : IPentaConfiguration
{
    public string APIEndpoint {get; set;}
    public string APIKey {get; set;}
    public string WSSEndpoint {get; set;}
    
    public static PentaConfiguration Make()
    {
        
        var pathToConfig = Path.Combine(Application.RootDirectory, "configs/plugins/PentaEssentials/core.json");
        
        if (File.Exists(pathToConfig))
        {
            string json = File.ReadAllText(pathToConfig);
            
            return JsonSerializer.Deserialize<PentaConfiguration>(json);
        }
        else
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string configPayload = JsonSerializer.Serialize(new PentaConfiguration()
                {
                    APIEndpoint = "https://api.pentastrike.ru", APIKey = "test-key", WSSEndpoint = "wss://reverb.pentastrike.ru", 
                },
                
                options);
            
            File.Create(pathToConfig).WriteByte(Convert.ToByte(configPayload));

            return Make();
        }

        
    }
}