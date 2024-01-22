using System;
using System.Linq;
using Cosmos.Core;
using Cosmos.HAL;

namespace ShanOS.Commands
{
    internal class MemoryCommand : Command
    {
        private MemoryManager memoryManager = new MemoryManager();

        public MemoryCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            string response = "";

            if (args.Length < 1)
            {
                return "Insufficient arguments provided.";
            }

            try
            {
                switch (args[0])
                {
                    case "info":
                        response = GetMemoryInfo();
                        break;

                    case "free":
                        response = GetFreeMemory();
                        break;

                    case "used":
                        response = GetUsedMemory();
                        break;

                    case "clear":
                        response = ClearConsole();
                        break;

                    default:
                        response = $"Unknown memory command";
                        break;
                }
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.ToString()}";
            }

            return response;
        }

        private string GetMemoryInfo()
        {
            ulong totalMemory = CPU.GetAmountOfRAM();
            string memoryInfo = $"Total Memory: {totalMemory} bytes";
            return memoryInfo;
        }

        private string GetFreeMemory()
        {
            // In a real system, you would need more sophisticated memory management to accurately determine free memory.
            // For simplicity, let's assume that free memory is the difference between total memory and used memory.
            ulong totalMemory = CPU.GetAmountOfRAM();
            ulong usedMemory = memoryManager.GetUsedMemory();
            ulong freeMemory = totalMemory - usedMemory;
            string freeMemoryInfo = $"Free Memory: {freeMemory} bytes";
            return freeMemoryInfo;
        }

        private string GetUsedMemory()
        {
            ulong usedMemory = memoryManager.GetUsedMemory();
            string usedMemoryInfo = $"Used Memory: {usedMemory} bytes";
            return usedMemoryInfo;
        }

        private string ClearConsole()
        {
            Console.Clear();
            return "Console cleared.";
        }
    }
}
