using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanOS.Commands
{
    internal class HelpCommand : Command
    {
        public HelpCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
           
            return "Displaying help information.../n" +
                "help - displays ommands /n" +
                "efho - prints text /n"+
                "shutdown - shuts the system down";
        }
    }
}
