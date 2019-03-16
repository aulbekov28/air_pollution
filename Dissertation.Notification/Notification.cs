using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Notification.Services;
using Telegram.Bot.Types;

namespace Dissertation.Notification
{
    public class Notification
    {
        private TelegramService service;

        public Notification()
        {
            service = new TelegramService();
        }
        
        public void SendTelegramChannel(string message)
        {
            service.Notify("prediction",message);
        }
    }
}
