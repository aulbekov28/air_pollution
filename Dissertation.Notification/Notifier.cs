using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Notification.Services;
using Telegram.Bot.Types;

namespace Dissertation.Notification
{
    public class Notifier : INotifier
    {
        private TelegramService service;

        public Notifier()
        {
            service = new TelegramService();
        }
        
        public void Notify( string message, string subject = "Prediction")
        {
            service.Notify("prediction", message);
        }

        public void Notify(string message)
        {
            this.Notify(message, string.Empty);
        }
    }
}
