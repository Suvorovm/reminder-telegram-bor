using System;
using Reminder.Core.Descriptor;
using Reminder.Core.Service;
using SimpleInjector;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Reminder
{
    class Program
    {
        private static ITelegramBotClient _botClient;
        private static Container _container;
        private static DescriptorService _descriptorService;

        public static void Main() {
            /*botClient = new TelegramBotClient("1849985188:AAHVwdMWcUy0B7p2PIHtTgvn2qXcwJ2gdJY");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
                             );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();*/
            InitInjector();
            InitBot();
        }

        private static void InitBot()
        {
            _botClient = new TelegramBotClient(_descriptorService.GetDescriptor<WebSettingsDescriptor>().SecretKey);

            var me = _botClient.GetMeAsync().Result;
            Console.WriteLine(
                              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
                             );

            _botClient.OnMessage += Bot_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();
        }

        private static void InitInjector()
        {
            _container = new Container();
            _container.Register<DescriptorService>(Lifestyle.Singleton);
            _container.Register<PathManager>(Lifestyle.Singleton);
            _container.Verify();
            LoadDescriptors();

        }
        private static void LoadDescriptors()
        {
            _descriptorService = _container.GetInstance<DescriptorService>();
            PathManager pathManager = _container.GetInstance<PathManager>();
            string path = (pathManager.GetResourcePath());
            _descriptorService.LoadDescriptor<WebSettingsDescriptor>(path + Descriptors.WEB_SETTINGS);

        }
        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
            /*if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                                                     chatId: e.Message.Chat,
                                                     text:   "You said:\n" + e.Message.Text
                                                    );
            }*/
        }
    }
}