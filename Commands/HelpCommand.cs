﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanOS.Commands
{
    internal class HelpCommand : Command
    {
        public HelpCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
           
            return "Displaying help information...\n" +
                "------GENERAL COMMANDS-------\n" +
                "help\t - displays ommands \n" +
                "echo [text]\t - prints text \n" +
                "shutdown\t - shuts the system down \n" +
                "------FILE SYSTEM COMMANDS------\n" +
                "file mk [filename.txt]\t - creates a file \n"
                + "file rm [filename.txt]\t - deletes a file\n" +
                "file mkdir [dir name]\t - creates a new directory\n"
                + "file rmdir [dir name]\t - deletes a directory\n" +
                "file write [filename.txt] [content]\t - writes content to a file\n" +
                "file cat [filename.txt]\t - reads the content of a file\n";
        }
    }
}
