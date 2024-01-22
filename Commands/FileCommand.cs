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

            string currentDirectory = Directory.GetCurrentDirectory();
            string root = "0:\\";

            switch (args[0])
            {
                
                case "mk":
                    try
                    {

                        Console.WriteLine(currentDirectory);
                        string filePath = Path.Combine(root + currentDirectory, args[1]);
                        Sys.FileSystem.VFS.VFSManager.CreateFile(filePath);
                        response = $"Your file {args[1]} was created successfully at {filePath}.";
                       
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
                        string filePath = Path.Combine(root + currentDirectory, args[1]);
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(filePath);
                        response = $"Your file {args[1]} was deleted successfully at {currentDirectory}.";
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
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(root + args[1]);
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
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(root + args[1], true);
                        response = $"Your dir {args[1]} was  deleted successfully.";
                    }
                    catch (Exception e)
                    {
                        response = $"Directory deletion failed. Error: {e.ToString()}";
                        break;
                    }

                    break;

                case "ls":
                    try
                    {
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
                    } catch(Exception e)
                    {
                        response = $"Error occured: {e.Message}";
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
                case "pwd":
                    response = $"Current directory: {Directory.GetCurrentDirectory()}";
                    break;

                case "cat":
                    try
                    {
                        string content = File.ReadAllText(root + args[1]);
                        response = $"Contents of {args[1]}:\n{content}";
                    }
                    catch (Exception e)
                    {
                        response = $"Failed to read file. Error: {e.ToString()}";
                        break;
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
