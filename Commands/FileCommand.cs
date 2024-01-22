﻿using System;
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
            if (args.Length < 2)
            {
                return "Insufficient arguments provided.";
            }
            string currentDirectory = Sys.FileSystem.VFS.VFSManager.GetDirectory(Sys.FileSystem.VFS.VFSManager.CurrentDirectory).ToString();

            switch (args[0])
            {
                
                case "mk":
                    try
                    {

                        Sys.FileSystem.VFS.VFSManager.CreateFile(Path.Combine(currentDirectory, args[1]));
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

                case "ls":
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
                    break;

                case "cd":
                    try
                    {
                        Directory.SetCurrentDirectory(args[1]);
                        response = $"Changed directory to {args[1]}.";
                    }
                    catch (Exception e)
                    {
                        response = $"Failed to change directory. Error: {e.ToString()}";
                    }
                    break;
                case "pwd":
                    response = $"Current directory: {Directory.GetCurrentDirectory()}";
                    break;

                case "cat":
                    try
                    {
                        string content = File.ReadAllText(args[1]);
                        response = $"Contents of {args[1]}:\n{content}";
                    }
                    catch (Exception e)
                    {
                        response = $"Failed to read file. Error: {e.ToString()}";
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
