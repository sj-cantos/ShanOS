using ShanOS.ProcessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanOS.Commands
{
    internal class ProcessCommand: Command
    {
        private ProcessManager processManager;
        public ProcessCommand(string name, ProcessManager processManager) : base (name) {
            this.processManager = processManager;
        }

        public override string execute(string[] args)
        {
            string response = processManager.GetProcesses();
            return response;
        }
    }
}
