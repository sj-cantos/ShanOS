using ShanOS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using ShanOS.CosmosMemoryManagement;

namespace ShanOS
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        private MemoryManager memoryManager;
        private CosmosVFS vfs;
        protected override void BeforeRun()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("-----------------ShanOS booted succesfully-------------");
            Console.WriteLine("=======================================================");

           
            this.vfs = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);

            this.memoryManager = new MemoryManager();
            this.commandManager = new CommandManager(memoryManager);

        }

        protected override void Run()
        {
            Console.Write("Input: ");                
            Console.WriteLine(this.commandManager.processCommand(Console.ReadLine()));
        }
    }
}
