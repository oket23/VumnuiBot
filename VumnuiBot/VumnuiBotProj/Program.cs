using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace VumnuiBotProj
{
    internal class Program
    {

        private static DiscordSocketClient _socketClient;
        private static string _botToken;

        private static bool _isRunning;

        private static ulong VictorUserId = 628586067888701459;
        private static ulong OlegUserId = 313225171286884353;
        private static ulong AndriiUserId = 418423106567274506;
        private static ulong KomoryUserId = 585897470035361812;
        private static ulong HicayneUserId = 483649106628313088;


        static async Task Main(string[] args)
        {

            Program program = new Program();

            _isRunning = true;
            Console.CancelKeyPress += OnCanselKeyPress;
            //AppDomain.CurrentDomain.ProcessExit += OnProcessExit;



            Console.OutputEncoding = Encoding.UTF8;


            await program.StartBotAsync();

            while (_isRunning) { Task.Delay(1000); }

            await program.StopBotAsync();

        }

        private async Task StartBotAsync()
        {
            _botToken = GetBotToken();
            _socketClient = new DiscordSocketClient();

            _socketClient.Log += Log;
            _socketClient.Ready += OnReady;
            


            await _socketClient.LoginAsync(TokenType.Bot, _botToken);
            await _socketClient.StartAsync();

        }

        private async Task StopBotAsync()
        {
            Console.WriteLine("Завершення роботи бота...");

            string textMessage = "а всьо бля, вирубають:(";

            try
            {
                await SendPrivateMessage(VictorUserId, textMessage);
                await SendPrivateMessage(OlegUserId, textMessage);
                await SendPrivateMessage(AndriiUserId, textMessage);
                await SendPrivateMessage(KomoryUserId, textMessage);
                await SendPrivateMessage(HicayneUserId, textMessage);
            }
            catch (Exception ex) { Console.WriteLine("Помилка! " + ex.ToString()); }


            await _socketClient.LogoutAsync();
            Console.WriteLine("Бот вийшов із системи.");

            
            await _socketClient.StopAsync();
            Console.WriteLine("Бот зупинений.");
        }

        private string GetBotToken()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("C:\\Users\\malya\\OneDrive\\Desktop\\VumnuiBot\\VumnuiBot\\config.json").Build();

            return configuration["bot_token"];

        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task OnReady()
        {
            Console.WriteLine($"Bot is ready!");

            string textMessage = "під'йом сука! Мене знову їбашать";

            try
            {
                await SendPrivateMessage(VictorUserId, textMessage);
                await SendPrivateMessage(OlegUserId, textMessage);
                await SendPrivateMessage(AndriiUserId, textMessage);
                await SendPrivateMessage(KomoryUserId, textMessage);
                await SendPrivateMessage(HicayneUserId, textMessage);
            }
            catch (Exception ex) { Console.WriteLine("Помилка! " + ex.ToString()); }

        }

        private async Task SendPrivateMessage(ulong userId, string message)
        {

            var user = await GetUserAsync(userId);

            try
            {
                if (user != null) {

                    var dmChannel = await user.CreateDMChannelAsync();

                    await dmChannel.SendMessageAsync(user.Username + ", " + message);

                    Console.WriteLine($"Повідомлення до {user.Username} успішно доставлене!");
                }
                else
                {
                    Console.WriteLine("Бубу в голові маєш");
                }

            }
            catch (Exception ex) { Console.WriteLine("Помилка! " + ex.ToString());}
        }

        private async Task<IUser> GetUserAsync(ulong userId)
        {
            return await _socketClient.GetUserAsync(userId) ?? await _socketClient.Rest.GetUserAsync(userId);
        }

        //private static async void OnProcessExit(object sender, EventArgs e)
        //{
        //    _isRunning = false;
        //}
        private static void OnCanselKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _isRunning = false;
        }
    }
        
    
}
