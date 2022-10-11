using System;

namespace RatMigration.RatShell.Commands
{
	public class Info : Command
	{
		public Info()
		{
			Description = "Gets information about the system.";
			Name = nameof(Info);
		}

		int screenX = 800;
		int screenY = 640;
		public string user = "user";
		public string hostName = "rat_os";
		public string version = "v 0.2.10";

		public override string Invoke(string[] Args)
		{
			string Response = "";
			uint maxmem = Cosmos.Core.CPU.GetAmountOfRAM();
			ulong availableMem = Cosmos.Core.GCImplementation.GetAvailableRAM();
			ulong usedmem = availableMem - maxmem;
			try
			{
				switch (Args[0])
				{
					case "user":
						Response += user;
						break;

					case "mem":
						Response += "Memory Used: " + ((usedmem / 1024) / 1024) + "/" + maxmem;//must fix this lol
						Response += "\nMemory Available: " + availableMem;
						break;

					case "screen":
						Response += "Screensize (Columns and Rows): " + screenX + " x " + screenY;
						break;

					case "ver":
						Response += version;
						break;

					case "host":
						Response += hostName;
						break;

					default:
						Response += "Unexpected argument: " + Args[0];
						break;
				}
			}
			catch (Exception E)
			{
				return E.Message;
			}
			return Response;
		}
	}
}