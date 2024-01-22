using System;
using System.Collections.Generic;
using ShanOS.Commands;
using ShanOS.CosmosMemoryManagement;

namespace ShanOS.ProcessManagement
{
    internal class ProcessManager
    {
        private List<Process> processes;
        private MemoryManager memoryManager;
        private int lastProcessId; 

        public ProcessManager(MemoryManager memoryManager)
        {
            this.processes = new List<Process>();
            this.memoryManager = memoryManager;
            this.lastProcessId = 0; 
        }

        public void CreateProcess(string name, string status, string memory)
        {
            
            int newProcessId = ++lastProcessId;

         
            Process newProcess = new Process { Id = newProcessId, Name = name, Status = status, Memory = memory };
            processes.Add(newProcess);

            Console.WriteLine($"Process '{name}' started with ID: {newProcessId}");
        }


        public List<Process> GetProcesses()
        {
            return processes;
        }
    }

    public class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Memory { get; set; }
    }
}
