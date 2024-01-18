using System;
using System.Collections.Generic;
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
            }

            return response;
        }
    }
}
