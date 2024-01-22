using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShanOS.CosmosMemoryManagement;
using ShanOS.ProcessManagement;
namespace ShanOS.Commands
{
    internal class CommandManager
    {
        private List<Command> commands;

        public CommandManager(MemoryManager memoryManager, ProcessManager processManager) {
            this.commands = new List<Command>(1);
            this.commands.Add(new HelpCommand("help"));
            this.commands.Add(new EchoCommand("echo"));
            this.commands.Add(new ShutDownCommand("shutdown"));
            this.commands.Add(new FileCommand("file", processManager));
            this.commands.Add(new MemoryCommand("memory", memoryManager));
            this.commands.Add(new ProcessCommand("processes", processManager));
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
