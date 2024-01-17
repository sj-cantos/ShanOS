using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanOS.Commands
{
    internal class HelpCommand : Command
    {
        public HelpCommand() : base("help") { }

        public override string execute(string[] args)
        {
           
            return "Displaying help information...";
        }
    }
}
