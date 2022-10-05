//Big thanks to Tech Media
using System;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace RatMigration
{
    public class Kernel : Sys.Kernel
    {
        public string user = "user";
        public string hostname = "rat_os";

        protected override void BeforeRun()
        {
            CosmosVFS VFS = new();
            VFSManager.RegisterVFS(VFS);//registers the VFS we made
            Console.Clear();
            RatShell.Shell.Initialize();
            Console.WriteLine("Successfully booted!");// posting when system booted up, i  might remove this later or replace it
            //Console.WriteLine($"The current time is {DateTime.Now}");
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