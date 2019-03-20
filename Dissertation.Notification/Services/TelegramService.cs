using System;
//using TeleSharp.TL;
//using TLSharp;
//using TLSharp.Core;
using Telegram.Bot;

namespace Dissertation.Notification.Services
{
    public class TelegramService 
    {
        private TelegramBotClient _client;

        public TelegramService()
        {
            _client = new TelegramBotClient("api-key");
        }

        public void Notify(string subject, string message)
        {
           _client.SendTextMessageAsync("@air_pollution_yk", message);
        }
    }
}
