using System.Collections.Generic;
using System.Net.Sockets;
using Reminder.Core.Repository;
using Reminder.Core.Service;
using Reminder.StateMachine.Descriptor;
using Reminder.StateMachine.Model;
using Telegram.Bot;

namespace Reminder.StateMachine.Service
{
    public class BotExecutor
    {
        private const string FIRST_QUESTION_ID = "initQuestion";
        private readonly BotDescriptor _botDescriptor;
        private readonly IRepository<HistoryModel> _repository;
        private TelegramBotClient _telegramBotClient;
        private IQuestionPrintService _questionPrintService;
        private HandlerService _handlerService;
        private ActionService _actionService;

        public BotExecutor(DescriptorService descriptorService,
                           IRepository<HistoryModel> repository,
                           TelegramBotClient telegramBotClient,
                           HandlerService handlerService,
                           IQuestionPrintService questionPrintService,
                           ActionService actionService)
        {
            _botDescriptor = descriptorService.GetDescriptor<BotDescriptor>();
            _repository = repository;
            _handlerService = handlerService;
            _actionService = actionService;
            _telegramBotClient = telegramBotClient;
            _questionPrintService = questionPrintService;
        }

        //TODO: разнести на мтеодоы переименовать переменные !!!!!!!!
        public void ProcessUserMessage(string userId, string message)
        {
            if (!_repository.Has(userId)) {
                StartBot(userId, message);
                return;
            }
            HistoryModel historyModel = _repository.Get(userId);
            AnswerModel answerModel = historyModel.GetLast();
            if (string.IsNullOrEmpty(answerModel.AnswerId)) {
                QuestionDescriptor questionDescriptor = _botDescriptor.GetQuestionById(FIRST_QUESTION_ID);
                AnswerDescriptor answer = HandleQuestion(userId, message, questionDescriptor);
                ExecuteActions(userId, message, questionDescriptor);
                PrintQuestion(userId, answer.QuestionDescriptor);
                historyModel.Add(AnswerModel.Create(FIRST_QUESTION_ID, message, answer.Id));
                return;
            }
            AnswerDescriptor answerDescriptor = _botDescriptor.GetAnswerDescriptorById(answerModel.QuestionId, answerModel.AnswerId);
            QuestionDescriptor answerDescriptorQuestionDescriptor = answerDescriptor.QuestionDescriptor;
            ExecuteActions(userId, message, answerDescriptorQuestionDescriptor);
            AnswerDescriptor resultAnswer = HandleQuestion(userId, message, answerDescriptorQuestionDescriptor);
            historyModel.Add(AnswerModel.Create(answerDescriptorQuestionDescriptor.Id, message, resultAnswer.Id));
            if (answerDescriptor.QuestionDescriptor != null) {
                PrintQuestion(userId, resultAnswer.QuestionDescriptor);
            }
        }

        private void StartBot(string userId, string message)
        {
            QuestionDescriptor questionDescriptor = _botDescriptor.GetQuestionById(FIRST_QUESTION_ID);
            PrintQuestion(userId, questionDescriptor);
            AnswerModel answerModel = AnswerModel.Create(FIRST_QUESTION_ID, null, null);
            HistoryModel historyModel = new HistoryModel();
            historyModel.Add(answerModel);
            _repository.Save(userId, historyModel);
            /*HandleQuestion(userId, message, questionDescriptor);
            ExecuteActions(userId, message, questionDescriptor);*/
        }

        private AnswerDescriptor HandleQuestion(string userId, string message, QuestionDescriptor questionDescriptor)
        {
            return _handlerService.Handle(questionDescriptor, message, userId);
        }

        private void ExecuteActions(string userId, string message, QuestionDescriptor questionDescriptor)
        {
            _actionService.ExecuteActions(new ActionModel(message, userId), questionDescriptor.ActionDescriptors);
        }

        private void PrintQuestion(string userId, QuestionDescriptor questionDescriptor)
        {
            _questionPrintService.PrintQuestion(userId, questionDescriptor);
        }
    }
}