using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanOS.Commands
{
    internal class CommandManager
    {
        private List<Command> commands;

        public CommandManager() {
            this.commands = new List<Command>(1);
        }

        public String processCommand(String command)
        {
            String[] commandinputs = command.Split();
            List<String> arguments = new List<String>();
            String commandInput = commandinputs[0];

            int ctr = 0;
            foreach (String s in commandinputs)
            {
                if(ctr == 0)
                {
                    arguments.Add(s);
                    ++ctr;
                }
            }
            foreach (Command cmd in this.commands)
            {
                if(cmd.name == commandInput)
                {
                    cmd.execute(arguments.ToArray());
                }
            }
            return "";
        }
    }
}
