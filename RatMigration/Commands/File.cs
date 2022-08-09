using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //helps with file creation/deletion and whatnot
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
//Cosmos uses the DOS file naming schemes, so 0 instead of C:\
namespace RatMigration.Commands
{
    public class File : Command // file create Text.txt will be our blueprint
    {
        public File(String name) : base (name) { } //we are creating the "file" part of the command. create and the filename will be the arg

        public override string execute(string[] args)//it always wants some return value, like dude be silent
        {
            String response = "";
            switch (args[0]) //if our first arguament [0] is "create", then we run the next code
            {
                case "create": //args[0]
                    try //this is to see if the file was created sucessfully
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]); //this method was also used to register the vfs. You could use this to automaticly make files. args[1] is for the name the user makes
                        response = "File " + args[1] + " created!";
                    }
                    catch (Exception ex)
                    {
                        response =ex.ToString();//i can currently think of many ways the file could fail, so thats why we used the ToString (the OS will give you the error itself)
                        break;
                    }
                    break; //done with case, switch statement is donezo

                case "erase":
                    try 
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]); 
                        response = "File " + args[1] + " erased!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                case "createdir": //this is for directories
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                        response = "Directory " + args[1] + " created!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                case "erasedir":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1],true);
                        response = "Directory " + args[1] + " erased!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                case "writestr": //its str because the string will be converted to bytes
                    try //file (label) writestr[0] 0:\Text.txt[1] Abc[2]
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();
                        if (fs.CanWrite)
                        {
                            int ctr = 0; //this part will take al the spaces out of the string we write to a text file
                            StringBuilder sb = new StringBuilder();
                            foreach (String s in args)
                            {
                                if (ctr > 1)
                                    sb.Append(s+' ');
                                ++ctr;
                            }
                            Byte[] data=Encoding.ASCII.GetBytes(sb.ToString());//gets the bytes of arg[2] AKA what the user types
                            fs.Write(data, 0, data.Length); //writes data to stream starts at 0=the start, and ends in the end
                            fs.Close(); //closes the stream
                            response = "File written!";
                        }
                        else
                        {
                            response = "Unable to write!";
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                case "readstr":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();
                        if (fs.CanRead)
                        {
                            Byte[] data=new byte[256];
                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);
                        }
                        else
                        {
                            response = "Unable to read!";
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;




                default:
                    response = "Unexpected argument: " + args[0]; //if you give a bullshit argument, it will tell you that it's an error and shame you with what you typed.
                    break;

            }
            return response;
        }
    }
    
}
/* File arguments:
 * create
 * createdir
 * erase
 * erasedir
 * 
 * The whole "case" argument can be copied and pasted for all of the arguments that we need
 */ 