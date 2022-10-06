using Cosmos.System.FileSystem.VFS;
using System.Text;
using System.IO; //helps with file creation/deletion and whatnot
using System;

namespace RatMigration.RatShell.Commands
{
	public class File : Command
	{
		public File()
		{
			Description = "This command helps with interacting with files on the filesystem.";
			Name = nameof(File);
		}

		public override string Invoke(string[] Args)
		{
			string Response = "";
			try
			{
				switch (Args[0]) //if our first arguament [0] is "create", then we run the next code
				{
					case "touch": // Creates a file with the specified name.
						VFSManager.CreateFile(Args[1]); //this method was also used to register the vfs. You could use this to automaticly make files. args[1] is for the name the user makes
						Response += $"Created file '{Args[1]}' successfully!";
						break;

					case "rm": // Removes a file with the specified name.
						VFSManager.DeleteFile(Args[1]);
						Response += $"Erased file '{Args[1]}' successfully!";
						break;

					case "mkdir": // Same as touch but for directories.
						VFSManager.CreateDirectory(Args[1]);
						Response += $"Created directory '{Args[1]}' successfully!";
						break;

					case "rmdir": // Same as rm but for directories.
						if (Args[1] == "-r")
						{
							VFSManager.DeleteDirectory(Args[1], true);
						}
						else
						{
							VFSManager.DeleteDirectory(Args[1], false);
						}
						Response += $"Erased directory '{Args[1]}' succesfully!";
						break;

					case "write": // Writes a string to a file.
						FileStream Stream = (FileStream)VFSManager.GetFile(Args[1]).GetFileStream();
						if (Stream.CanWrite)
						{
							int ctr = 0; //this part will take al the spaces out of the string we write to a text file
							StringBuilder sb = new();
							foreach (string S in Args)
							{
								if (ctr > 1)
									sb.Append(S + ' ');
								++ctr;
							}
							byte[] data = Encoding.ASCII.GetBytes(sb.ToString());//gets the bytes of arg[2] AKA what the user types
							Stream.Write(data, 0, data.Length); //writes data to stream starts at 0=the start, and ends in the end
							Stream.Close(); //closes the stream
							Response += $"Wrote {data.Length} bytes to {Args[1]}.";
						}
						else
						{
							Response += "Unable to write!";
							break;
						}
						break;

					case "cat": // Reads the contents from a file as text.
						BinaryReader Reader = new((MemoryStream)VFSManager.GetFile(Args[1]).GetFileStream());
						if (Reader.BaseStream.CanRead)
						{
							Response += Encoding.ASCII.GetString(Reader.ReadBytes((int)Reader.BaseStream.Length));
						}
						else
						{
							Response += "Unable to read!";
							break;
						}
						break;

					case "ls":
						Response += $"Listing files for directory '{Args[1]}'";
						foreach (string S in Directory.GetFiles(Args[1]))
						{
							Response += $"\n{S}";
						}
						break;

					default:
						Response += "Unexpected argument: " + Args[0]; //if you give a bullshit argument, it will tell you that it's an error and shame you with what you typed.
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