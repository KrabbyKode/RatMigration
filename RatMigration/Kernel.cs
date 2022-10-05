//Big thanks to Tech Media
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using RatMigration.Commands;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using System.Net;

namespace RatMigration
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        private CosmosVFS vfs; //makes a Virtual Filesystem called "vfs"
        public string user = "user";
        public string hostname = "rat_os";


        protected override void BeforeRun()
        {
            this.vfs= new CosmosVFS(); //initialize the filesystem, this only runs once (hence beforerun)
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);//registers the VFS we made
            this.commandManager = new CommandManager();
            Console.Clear();
            Console.WriteLine("System booted at:");// posting when system booted up, i  might remove this later or replace it
            DateTime.Now.ToString("hh:mm:ss tt");
            Console.WriteLine(DateTime.Now);
            //Console.SetWindowSize(90, 30);
        }

        protected override void Run()
        {
            //Console.WriteLine("> ");
            String repsonse;
            String input = Console.ReadLine();
            repsonse = this.commandManager.processInput(input); //The value of processInput is stored in response.
            Console.WriteLine(repsonse); // writes the responce to the users command
        }
    }
}
