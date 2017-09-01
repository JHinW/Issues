# .net core

**how owin web differ from .net core web**
https://github.com/wangjinisda/Cognitive-Speech-STT-ServiceLibrary/tree/aspnet_core_integration/SpeechLuisOwin  

web built with owin seems better in concurrency but worse in GC which is opposite to .net core


**enable https in asp.net core in programming way**  
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?tabs=aspnetcore2x  

```csharp
public static void Main(string[] args)
{
    BuildWebHost(args).Run();
}

public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseKestrel(options =>
        {
            options.Listen(IPAddress.Loopback, 5000);
            options.Listen(IPAddress.Loopback, 5001, listenOptions =>
            {
                listenOptions.UseHttps("testCert.pfx", "testPassword");
            });
        })
        .Build();
```
