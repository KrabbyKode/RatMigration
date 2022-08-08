using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using RatMigration.Commands;

namespace RatMigration
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;

        protected override void BeforeRun()
        {
            this.commandManager = new CommandManager();
        }

        protected override void Run()
        {
            String repsonse; //stores response
            String input = Console.ReadLine();
            repsonse = this.commandManager.processInput(input); //The value of processInput is stored in response
            Console.WriteLine(repsonse); // writes the responce to the users command
        }
    }
}
