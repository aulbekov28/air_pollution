using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Notification.Services
{
    public interface INotifier
    {
        void Notify(string message, string subject);
        void Notify(string message);
    }
}
