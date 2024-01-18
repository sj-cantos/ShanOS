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

            this.commandManager  = new CommandManager();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);
            this.vfs = new CosmosVFS();
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();          
            string result = this.commandManager.processCommand(input);
            Console.WriteLine(result);
        }
    }
}
