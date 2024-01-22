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
           
            return "Displaying help information...\n" +
                "help - displays ommands \n" +
                "echo [args] - prints text \n" +
                "shutdown - shuts the system down \n" +
                "file mk [args] - creates a file \n"
                + "file rm [args] - deletes a file\n" +
                "file mkdir [args] - creates a new directory\n"
                + "file rmdir [args] - deletes a directory\n" +
                "ls - lists all of the directories\n";
        }
    }
}
