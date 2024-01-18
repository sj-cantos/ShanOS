using ShanOS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;


namespace ShanOS
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        private CosmosVFS vfs;
        protected override void BeforeRun()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("-----------------ShanOS booted succesfully-------------");
            Console.WriteLine("=======================================================");

           
            this.vfs = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);
            this.commandManager = new CommandManager();

        }

        protected override void Run()
        {
            Console.Write("Input: ");                
            Console.WriteLine(this.commandManager.processCommand(Console.ReadLine()));
        }
    }
}
