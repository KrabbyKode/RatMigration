﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands
{
    public class clear : Command //whatever class we write past the colon, Help will inherit it
    {
        //this part sets the command
        public clear(String name) : base(name) { } //base refers to the parent (Command). We are taking a string, and passing it to the base
        //the part below sets up the response

        public override String execute(String[] args)
        {
            Console.Clear();
            return "";
        }

    }
}