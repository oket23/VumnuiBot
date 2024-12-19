using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;


namespace VumnuiBotProj
{
    internal class Program
    {

        private static DiscordSocketClient _socketClient;

        static async Task Main(string[] args)
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("C:\\Users\\malya\\OneDrive\\Desktop\\VumnuiBot\\VumnuiBot\\config.json").Build();

            string botToken = configuration["bot_token"];

            
           

        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        
    }
}
