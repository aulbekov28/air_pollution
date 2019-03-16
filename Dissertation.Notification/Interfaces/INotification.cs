using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Notification.Services
{
    interface INotification
    {
        void Notify(string subject, string message);
    }
}
