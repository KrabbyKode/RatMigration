//Big thanks to Tech Media
using System;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace RatMigration
{
    public class Kernel : Sys.Kernel
    {
        private CosmosVFS vfs; //makes a Virtual Filesystem called "vfs"
        public string user = "user";
        public string hostname = "rat_os";


        protected override void BeforeRun()
        {
            vfs= new CosmosVFS(); //initialize the filesystem, this only runs once (hence beforerun)
            VFSManager.RegisterVFS(vfs);//registers the VFS we made
            RatShell.Shell.Initialize();
            Console.Clear();
            //Console.WriteLine("System booted at:");// posting when system booted up, i  might remove this later or replace it
            //DateTime.Now.ToString("hh:mm:ss tt");
            // Datetime.ToString with arguments isn't plugged
            Console.WriteLine(DateTime.Now);
            //Console.SetWindowSize(90, 30);
        }

        protected override void Run()
        {
            Console.Write("> ");
            string repsonse = RatShell.Shell.Invoke(Console.ReadLine().Split('\n'));
            Console.WriteLine(repsonse); // writes the responce to the users command
        }
    }
}