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
            this.commands.Add(new HelpCommand("help"));
            this.commands.Add(new EchoCommand("efho"));
            this.commands.Add(new ShutDownCommand("shutdown"));
            this.commands.Add(new FileCommand("file"));
        }

        public String processCommand(String command)
        {
            String[] commandinputs = command.Split();
            List<String> arguments = commandinputs.Skip(1).ToList();
            String commandInput = commandinputs[0];

        
            foreach (Command cmd in this.commands)
            {
                if(cmd.name == commandInput)
                {
                     return cmd.execute(arguments.ToArray());
                }
            }
            return $" Your command {commandInput} does not exists.";
        }
    }
}
