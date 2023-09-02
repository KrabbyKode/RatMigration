using System;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using RatMigration.RatShell;
using RatMigration.RatShell.Commands;

namespace RatMigration
{
	public class Kernel : Sys.Kernel
	{
        private string copiedText = ""; //some code fragment, i forgot what it does. Im not gonna delete it in case i need it.
        public string user = "user"; //need to change this, since there are three pre-built user accounts. 
		public string hostName = "rat_os"; //obviously

		protected override void BeforeRun()
		{
			CosmosVFS VFS = new();
			VFSManager.RegisterVFS(VFS);//registers the VFS we made
			Console.Clear();
			Shell.Initialize();
			Console.WriteLine("Successfully booted!");// posting when system booted up, i  might remove this later or replace it
            RatMigration.RatShell.Commands.Program.Main();

        }

		protected override void Run()
		{
			Console.Write("> ");
			string repsonse = Shell.Invoke(Console.ReadLine().Split(' '));//ads a space after ">"
			Console.WriteLine(repsonse); // writes the responce to the users command

        }
    }
}