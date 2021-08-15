using Reminder.Core.Descriptor;
using Reminder.Core.Repository;
using Reminder.Core.Service;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;
using Reminder.StateMachine.Repository;
using Reminder.StateMachine.Service;
using SimpleInjector;

namespace Reminder.Core.Bootstrap
{
    public static class BotBootStrap
    {
        private static Container _container;
        private static DescriptorService _descriptorService;
        private static PathManager _pathManager;

        public static Container Bootstrap()
        {
            _pathManager = new PathManager();
            _descriptorService = new DescriptorService();
            InitInjector();
            LoadDescriptors();
            return _container;
        }

        private static void LoadDescriptors()
        {
            string path = _pathManager.GetResourcePath();
            _descriptorService.LoadDescriptor<WebSettingsDescriptor>(path + Descriptors.WEB_SETTINGS);
            InitBotDescriptor(path);
            InitService();
        }

        private static void InitService()
        {
            if (_descriptorService.GetDescriptor<WebSettingsDescriptor>().Fake) {
                _container.Register<IQuestionPrintService, FakeQuestionPrintService>(Lifestyle.Singleton);
                return;
            }
            _container.Register<IQuestionPrintService, QuestionPrintService>(Lifestyle.Singleton);
        }

        private static void InitBotDescriptor(string path)
        {
            WebSettingsDescriptor webSettingsDescriptor = _descriptorService.GetDescriptor<WebSettingsDescriptor>();
            if (webSettingsDescriptor.Fake) {
                _descriptorService.LoadDescriptor<BotDescriptor>(path + Descriptors.FAKE_BOT_CONFIG);
                return;
            }
            _descriptorService.LoadDescriptor<BotDescriptor>(path + Descriptors.BOT_CONFIG);
        }

        private static void InitInjector()
        {
            _container = new Container();
            _container.Options.EnableAutoVerification = false;

            _container.Register(() => _descriptorService, Lifestyle.Singleton);

            _container.Register(() => _pathManager, Lifestyle.Singleton);
            _container.Register<BotExecutor>(Lifestyle.Singleton);
            _container.Register<HandlerService>(Lifestyle.Singleton);
            _container.Register<ActionService>(Lifestyle.Singleton);
            _container.Register<IRepository<HistoryModel>, MemoryRepository>(Lifestyle.Singleton);
        }
    }
}