using System.Net;
using PusherClient;

namespace PentaEssentials.Reverb;

public class PentaReverbAuthorizer : IAuthorizer
{
    private HttpClient _client;
    
    public string PentaReverbHost { get; set; }
    public string PentaReverbBroadcastingHost { get; set; }
    public string PentaIntegrationToken { get; set; }

    public PentaReverbAuthorizer()
    {
        
        var handler = new HttpClientHandler
        {
            CookieContainer = new CookieContainer(),
            UseCookies = true
        };

        _client = new HttpClient(handler);

        var loginData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("integration_token", PentaIntegrationToken),
        });

        var response = _client.PostAsync(this.PentaReverbHost, loginData).GetAwaiter().GetResult();
    }

    public string Authorize(string channelName, string socketId)
    {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("socket_id", socketId),
            new KeyValuePair<string, string>("channel_name", channelName)
        });
        
        var response = _client.PostAsync(this.PentaReverbBroadcastingHost, content).GetAwaiter().GetResult();
        return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }
}