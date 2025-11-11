using System.Net;
using PentaEssentialsShared;
using PusherClient;

namespace PentaEssentials.Reverb;

public class PentaReverb : PusherClient.Pusher, IPentaReverb
{
    
    public PentaReverb(string key, PusherOptions options) : base(key, options)
    {
        
    }

    public Task<Channel> SubscribePrivateAsync(string channelName)
    {
        return this.SubscribeAsync($"private-{channelName}");
    }

  
    
}

