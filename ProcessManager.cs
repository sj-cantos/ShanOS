using System;
using System.Collections.Generic;
using System.Text;
using ShanOS.Commands;
using ShanOS.CosmosMemoryManagement;

namespace ShanOS.ProcessManagement
{
    internal class ProcessManager
    {
        private List<Process> processes;
        private MemoryManager memoryManager;
        private int lastProcessId; 

        public ProcessManager()
        {
            this.processes = new List<Process>();
          
            this.lastProcessId = 0; 
        }

        public void CreateProcess(string name, string status, string memory)
        {
            
            int newProcessId = ++lastProcessId;

         
            Process newProcess = new Process { Id = newProcessId, Name = name, Status = status, Memory = memory };
            processes.Add(newProcess);

            Console.WriteLine($"Process '{name}' started with ID: {newProcessId}");
        }


        public string GetProcesses()
        {
            StringBuilder listBuilder = new StringBuilder();
            listBuilder.AppendLine("Id\t Name\t Status\t Memory Allocated");

            foreach (var item in processes)
            {
                listBuilder.AppendLine($"{item.Id}\t {item.Name}\t {item.Status}\t {item.Memory}");
            }

            return listBuilder.ToString();
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
