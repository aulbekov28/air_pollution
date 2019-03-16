using Dissertation.Service.IntegrationApp.Classes;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Integration logic = new Integration();
            logic.StartCycle();
            Console.ReadKey();
        }
    }
}
