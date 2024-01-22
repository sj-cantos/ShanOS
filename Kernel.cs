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
        private UserManager userManager;
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
            this.userManager = new UserManager(); // Assume you have a UserManager class

            // Create some example users
            this.userManager.AddUser("admin", "adminpass");
            this.userManager.AddUser("user1", "userpass");
           
        }

        protected override void Run()
        {


            while (!userManager.IsUserLoggedIn()) 
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                User user = userManager.GetUser(username);

                if (user != null && user.Password == password)
                {
                    userManager.Login(user.Username, password);
                   
                    break;
                }
                else
                {
                    Console.WriteLine("Login failed. Invalid username or password.");

                    
                }
            } 

            if (userManager.IsUserLoggedIn())
            {
                Console.Write($"{userManager.GetCurrentUsername()}@ShanOS:~> ");
                string input = Console.ReadLine();
                Console.WriteLine(commandManager.processCommand(input));
            }
        }

    }
}
