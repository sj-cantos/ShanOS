using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace ShanOS.Commands
{
    internal class ShutDownCommand : Command
    {
        public ShutDownCommand() : base("shutdown") { }

        public override string execute(string[] args)
        {
            Console.WriteLine("Are you sure you want to shutdown");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Sys.Power.Shutdown();
                return "Shutting down the system";
            }
            else { return "Shutdown aborted"; }
           
        }
    }
}
