using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands
{
    internal class sysinfo : Command
    {
        public sysinfo(String name) : base(name) { }
        int screenX = 800;
        int screenY = 640;
        public string user = "user";
        public string hostname = "rat_os";
        public string version = "v 0.2.10";
        public override String execute(String[] args)
        {
            String response = "";
            uint maxmem = Cosmos.Core.CPU.GetAmountOfRAM();
            ulong availableMem = Cosmos.Core.GCImplementation.GetAvailableRAM();
            ulong usedmem = availableMem - maxmem;
            switch (args[0])
            {
                case "user":
                    try
                    {
                        Console.WriteLine(user);
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                    }
                    break;

                case "mem":
                    try
                    {
                        Console.WriteLine("Memory Used: " + usedmem + "/" + maxmem);
                        Console.WriteLine("Memory Available: " + availableMem);
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                    }
                    break;

                case "screen":
                    try
                    {
                        Console.WriteLine("Screensize (Columns and Rows): " + screenX + " x " + screenY);
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                    }
                    break;

                case "ver":
                    try
                    {
                        Console.WriteLine(version);
                    }
                    catch (Exception ex)
                    {
                        response = ex?.ToString();
                    }
                    break;

                case "host":
                    try
                    {
                        Console.WriteLine(hostname);
                    }
                    catch (Exception ex)
                    {
                        response = ex?.ToString();
                    }
                    break;

                default:
                    response = "Unexpected argument: " + args[0];
                    break;
            }
            return response;
        }
    }
}
