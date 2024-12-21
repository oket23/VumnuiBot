using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;


namespace VumnuiBotProj
{
    internal class Program
    {

        private static DiscordSocketClient _socketClient;
        private static string _botToken;

        static async Task Main(string[] args)
        {

            _botToken = GetBotToken();
            _socketClient = new DiscordSocketClient();


            await _socketClient.LoginAsync(TokenType.Bot, _botToken);

            await _socketClient.StartAsync();

            await Task.Delay(-1);


        }

        private static string GetBotToken()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("C:\\Users\\malya\\OneDrive\\Desktop\\VumnuiBot\\VumnuiBot\\config.json").Build();

            return configuration["bot_token"];

        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        
    }
}
