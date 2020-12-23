using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace fggpbot {
    public class Program {
        private DiscordSocketClient? _client;

        public static void Main(string[] args){
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync(){
            using (ServiceProvider? services = ConfigureServices()) {
                _client = services.GetRequiredService<DiscordSocketClient>();

                _client.Log += Log;
                services.GetRequiredService<CommandService>().Log += Log;
                _client.Ready += ClientOnReady;

                await _client.LoginAsync(TokenType.Bot,
                    Environment.GetEnvironmentVariable("token", EnvironmentVariableTarget.Process));
                await _client.StartAsync();


                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

                await Task.Delay(Timeout.Infinite);
            }
        }

        private ServiceProvider ConfigureServices(){
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .AddSingleton<PictureService>()
                .BuildServiceProvider();
        }

        private Task ClientOnReady(){
            Log("clientReady Task");

            return Task.CompletedTask;
        }

        private void Log(string msg){
            Console.WriteLine(msg);
        }

        private Task Log(LogMessage msg){
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}