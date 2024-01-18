using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanOS.Commands
{
    internal class EchoCommand : Command
    {
        public EchoCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            // Join the arguments into a single string
            string echoedText = string.Join(" ", args);

            return echoedText;
        }
    }
}

