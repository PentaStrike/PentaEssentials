using CounterStrikeSharp.API.Core;

namespace PentaEssentialsShared;

public interface IPentaConfiguration
{
    private static string APIEndpoint {get; set;}
    private static string APIKey {get; set;}
    private static string WSSEndpoint {get; set;}
}