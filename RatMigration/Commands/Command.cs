using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands
{
    public class Command
    {
        public readonly String name; // readonly because we arent going to be altering the name. 

        public Command (String name) { this.name = name; } //ask for the name, and sets String name to user input. This sets the name to whatever we want
        public virtual String execute(String[] args) //we store the command's arguments in an array (signified by []) and args is what
        {
            return "";
        }

    }
}

