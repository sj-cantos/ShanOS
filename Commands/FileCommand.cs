using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using ShanOS.CosmosMemoryManagement;
using ShanOS.ProcessManagement;
using Cosmos.HAL.BlockDevice.Registers;
namespace ShanOS.Commands
{
    internal class FileCommand : Command
    {
        private MemoryManager memoryManager;
        private ProcessManager processManager;
        public FileCommand(string name, ProcessManager processManager) : base(name) {
            this.processManager = processManager;
        }

        public override string execute(string[] args)
        {
            string response = "";

            string currentDirectory = Directory.GetCurrentDirectory();
            string root = "0:\\";

            switch (args[0])
            {
                
                case "mk":
                    try
                    {

                        uint fileSize = 1024; // Set your desired file size
                        IntPtr fileData = MemoryManager.AllocateMemory(fileSize);
                        string filePath = Path.Combine(root + currentDirectory, args[1]);

                        processManager.CreateProcess("create file", "finished", fileSize.ToString());
                        Sys.FileSystem.VFS.VFSManager.CreateFile(filePath);
                        response = $"Your file {args[1]} was created successfully at {filePath}.";
                        MemoryManager.FreeMemory(fileData);

                    }
                    catch (Exception e)
                    {

                        response = $"File creation failed. Error: {e.ToString()}";
                        break;
                    }
                    break;

                case "rm":
                    try
                    {
                        uint fileSize = 1024; // Set your desired file size
                        IntPtr fileData = MemoryManager.AllocateMemory(fileSize);
                        processManager.CreateProcess("create file", "finished", fileSize.ToString());
                        string filePath = Path.Combine(root + currentDirectory, args[1]);
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(filePath);
                        response = $"Your file {args[1]} was deleted successfully at {filePath}.";
                        MemoryManager.FreeMemory(fileData);
                    }
                    catch (Exception e)
                    {
                        response = $"File deletion failed. Error: {e.ToString()}";
                        break;
                    }

                    break;

                case "mkdir":
                    try
                    {
                        uint fileSize = 1024;
                        IntPtr fileData = MemoryManager.AllocateMemory(fileSize);
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(root + args[1]);
                        //processManager.CreateProcess("create dir", "finished", fileSize.ToString());
                        response = $"Your directory {args[1]} was  created successfully.";
                        MemoryManager.FreeMemory(fileData);
                    }
                    catch (Exception e)
                    {
                        response = $"Directory creation failed. Error: {e.ToString()}";
                        break;
                    }

                    break;

                case "rmdir":
                    try
                    {
                        uint fileSize = 1024;
                        IntPtr intPtr = MemoryManager.AllocateMemory(fileSize);
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(root + args[1], true);
                        response = $"Your directory {args[1]} was  deleted successfully.";
                        processManager.CreateProcess("remove dir", "finished", fileSize.ToString());
                        MemoryManager.FreeMemory(intPtr);
                    }
                    catch (Exception e)
                    {
                        response = $"Directory deletion failed. Error: {e.ToString()}";
                        break;
                    }

                    break;

                

                case "cd":
                    try
                    {
                        Directory.SetCurrentDirectory(args[1]);
                        currentDirectory = args[1];
                        response = $"Changed directory to {args[1]}.";
                    }
                    catch (Exception e)
                    {
                        response = $"Failed to change directory. Error: {e.ToString()}";
                        break;
                    }

                    break;
                
                case "write":
                    try
                    {
                        uint fileSize = 1024;
                        IntPtr fileData = MemoryManager.AllocateMemory(fileSize);
                        string filePath = Path.Combine(root + currentDirectory, args[1]);

                      
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine($"File '{args[1]}' does not exist. Use 'mk {args[1]}' to create it first.");
                            break;
                        }

                       
                        string content = "";
                        for (int i = 2; i < args.Length; i++)
                        {
                            content += args[i] + " ";
                        }

                        File.WriteAllText(filePath, content);
                        response = $"Successfully wrote content to file '{args[1]}'.";
                        processManager.CreateProcess("write file", "finished", fileSize.ToString());
                        MemoryManager.FreeMemory(fileData);
                    }
                    catch (Exception e)
                    {
                        response = $"Error writing to file: {e.Message}";
                        break;
                    }
                    break;



                case "cat":
                    try
                    {
                        string filePath = Path.Combine(root + currentDirectory, args[1]);
                        uint fileSize = 1024;
                        IntPtr fileData = MemoryManager.AllocateMemory(fileSize);
                        if (File.Exists(filePath))
                        {
                            string content = File.ReadAllText(filePath);
                            response = $"Contents of {args[1]}:\n{content}";
                        }
                        else
                        {
                            response = $"File '{args[1]}' does not exist.";
                        }
                        processManager.CreateProcess("read file", "finished", fileSize.ToString());
                        MemoryManager.FreeMemory(fileData);
                    }
                    catch (Exception e)
                    {
                        response = $"Failed to read file. Error: {e.Message}";
                    }
                    break;



                default:
                    response = $"Unexpected argument";
                    break;
            }

            return response;
        }
    }
}
