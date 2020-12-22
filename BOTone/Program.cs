using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Newtonsoft.Json;

namespace BOTone {
    public class Program {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private EventHandler _handler = (sender, args) => { };

        private DiscordSocketConfig _socketConfig = new DiscordSocketConfig {
            LogLevel = Discord.LogSeverity.Verbose,
            MessageCacheSize = 1000,
        };


        public DiscordSocketClient Client { get; private set; }

        public async Task MainAsync(){
            string token = Environment.GetEnvironmentVariable("BotToken");
       
            Client = new DiscordSocketClient(_socketConfig);
            Client.Log += Log;
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();
            Client.Ready += ClientOnReady;


            await Task.Delay(-1);
        }

        private Task ClientOnReady(){
            Log("clientReay");
            return null;
        }

        private static void Log(string msg){
            Console.WriteLine(msg);
        }

        private static Task Log(LogMessage msg){
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}