using System;
using Reminder.Core.Bootstrap;
using Reminder.Core.Descriptor;
using Reminder.Core.Service;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Service;
using SimpleInjector;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Reminder
{
    public class Reminder
    {
        private static ITelegramBotClient _botClient;
        private static Container _container;
        private static DescriptorService _descriptorService;
        private static BotExecutor _botExecutor;

        public static void Main()
        {
            _container = BotBootStrap.Bootstrap();
            InitBot();
        }

        private static void InitBot()
        {
            RegisterBot();
            User me = _botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            _botExecutor = _container.GetInstance<BotExecutor>();
            _botClient.OnMessage += Bot_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();
        }

        private static void RegisterBot()
        {
            _container.RegisterSingleton(CreateBotInstance);
            CompleteRegistration();
        }

        private static void CompleteRegistration()
        {
            _descriptorService = _container.GetInstance<DescriptorService>();
            _container.Verify();
        }

        private static TelegramBotClient CreateBotInstance()
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient(_descriptorService.GetDescriptor<WebSettingsDescriptor>().SecretKey);
            _botClient = telegramBotClient;
            return telegramBotClient;
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            _botExecutor.ProcessUserMessage(e.Message.From.Id.ToString(), e.Message.Text);
        }
    }
}