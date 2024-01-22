using System;
using System.Linq;
using Cosmos.Core;
using Cosmos.HAL;
using ShanOS.Commands;
using ShanOS.CosmosMemoryManagement;
    internal class MemoryCommand : Command
    {
        private MemoryManager memoryManager;

        public MemoryCommand(string name, MemoryManager memoryManager) : base(name)
        {
            this.memoryManager = memoryManager;
        }

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

                    case "allocate":
                        response = AllocateMemory(args);
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
        ulong usedMemory = MemoryManager.GetUsedMemory(); // Use the type name here
        ulong freeMemory = totalMemory - usedMemory;
        string freeMemoryInfo = $"Free Memory: {freeMemory} bytes";
        return freeMemoryInfo;
    }

    private string GetUsedMemory()
    {
        ulong usedMemory = MemoryManager.GetUsedMemory(); // Use the type name here
        string usedMemoryInfo = $"Used Memory: {usedMemory} bytes";
        return usedMemoryInfo;
    }

    private string ClearConsole()
        {
            Console.Clear();
            return "Console cleared.";
        }

    private string AllocateMemory(string[] args)
    {
        if (args.Length < 2)
        {
            return "Insufficient arguments for allocate command.";
        }

        if (ulong.TryParse(args[1], out ulong size))
        {
            // Cast size to uint when calling AllocateMemory
            IntPtr allocatedMemory = MemoryManager.AllocateMemory((uint)size);

            if (allocatedMemory != IntPtr.Zero)
            {
                return $"Allocated {size} bytes at address: {allocatedMemory.ToInt64()}";
            }
            else
            {
                return "Memory allocation failed.";
            }
        }
        else
        {
            return "Invalid size argument for allocate command.";
        }
    }

}

