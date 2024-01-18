using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
namespace ShanOS.Commands
{
    internal class FileCommand : Command
    {
        public FileCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            string response = "";
            switch (args[0])
            {
                
                case "mk":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
                        response = $"Your file {args[1]} was created successfully.";
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
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
                        response = $"Your file {args[1]} was deleted successfully.";
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
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                        response = $"Your dir {args[1]} was  created successfully.";
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
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1], true);
                        response = $"Your dir {args[1]} was  deleted successfully.";
                    }
                    catch (Exception e)
                    {
                        response = $"Directory deletion failed. Error: {e.ToString()}";
                        break;
                    }

                    break;

                /*case "ls":
                    string[] dirDirectories = Directory.GetDirectories(Directory.GetCurrentDirectory());
                    foreach (var dir in dirDirectories)
                    {
                        Console.WriteLine(dir + " | Directory");
                    }
                    string[] dirFiles = Directory.GetFiles(Directory.GetCurrentDirectory());
                    foreach (var file in dirFiles)
                    {
                        Console.WriteLine(file + " | File");
                    }
                    break;*/

                default:
                    response = $"Unexpected argument {args[0]}";
                    break;
            }

            return response;
        }
    }
}
