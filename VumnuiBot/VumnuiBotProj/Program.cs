﻿using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;


namespace VumnuiBotProj
{
    internal class Program
    {

        private static DiscordSocketClient _socketClient;

        private static bool _isRunning;

        static async Task Main(string[] args)
        {



            _isRunning = BuildProgram();
            
            Program program = new Program();
            

            await program.StartBotAsync();

            while (_isRunning) { Task.Delay(1000); }

            await program.StopBotAsync();


        }

        private static bool BuildProgram()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.CancelKeyPress += OnCancelKeyPressed;

            return true;
        }
        private async Task StartBotAsync()
        {

            _socketClient = new DiscordSocketClient();
            var botToken = GetBotToken();

            _socketClient.Log += Log;
            _socketClient.Ready += OnReady;

            try
            {
                await _socketClient.LoginAsync(TokenType.Bot, botToken);

                await _socketClient.StartAsync();

            }
            catch (Exception ex) { Console.WriteLine("Помилка: " + ex.ToString()); }


        }

        private async Task StopBotAsync()
        {
            Console.WriteLine("Завершення роботи.");

            try
            {

                Console.WriteLine("Вихід з системи...");
                await _socketClient.LogoutAsync();

                Console.WriteLine("Відключення...");
                await _socketClient.StopAsync();

            }
            catch (Exception ex) { Console.WriteLine("Помилка: " + ex.ToString()); }

            Console.WriteLine("Бота зупинено.");
        }

        private async Task OnReady()
        {
            Console.WriteLine("З'єднання з ботом встановлено!");
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

        private static void OnCancelKeyPressed(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _isRunning = false;
        }

        
    }
}
