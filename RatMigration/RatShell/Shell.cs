using System.Collections.Generic;
using System;

namespace RatMigration.RatShell
{
	public static class Shell
	{
		#region Methods

		public static ReturnCode TryInvoke(string Name, string[] Args, out string Return)
		{
			if (Commands.Count == 0)
			{
				Return = "Command not found!";
				return ReturnCode.CommandNotFound;
			}

			for (int I = 0; I < Commands.Count; I++)
			{
				// Use .ToLower to normalize strings.
				if (Commands[I].Name.ToLower() == Name.ToLower())
				{
					Return = Commands[I].Invoke(Args);
					return ReturnCode.Success;
				}
			}
			Return = $"Command '{Name}' not found!";
			return ReturnCode.CommandNotFound;
		}
		public static string Invoke(string Name, string[] Args)
		{
			TryInvoke(Name, Args, out string S);
			return S;
		}
		public static string Invoke(string[] Args)
		{
			string[] NewArgs = new string[Args.Length - 1];
			for (int I = 0; I < NewArgs.Length; I++)
			{
				NewArgs[I] = Args[I + 1];
			}

			TryInvoke(Args[0], NewArgs, out string Return);
			return Return;
		}
		public static void Initialize()
		{
			// Create all command objects.
			_ = new Commands.Clear();
			_ = new Commands.Credits();
			_ = new Commands.File();
			_ = new Commands.Help();
			_ = new Commands.Info();
			_ = new Commands.Reboot();
			_ = new Commands.Shutdown();
            _ = new Commands.Time();

            // Log for debugging
            Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("[ OK ] ");
			Console.ResetColor();
			Console.WriteLine("Initialized RatShell successfully.");
		}

		#endregion

		#region Fields

		internal static List<Command> Commands { get; set; } = new();

		#endregion
	}
}