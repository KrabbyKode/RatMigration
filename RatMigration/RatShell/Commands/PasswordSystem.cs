using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.FileSystem.VFS;
using System.IO;
using System.Collections;

namespace RatMigration.RatShell.Commands
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Dictionary<string, string> users = new Dictionary<string, string>()
        {
            {"admin", "admin"},
            {"user1", "password1"},
            {"user2", "password2"},
            {"user3", "password3"}
        };

                Console.WriteLine("Please log in!");
                Console.WriteLine("User:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                if (users.ContainsKey(username))
                {
                    if (users[username] == password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Access granted.");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Password incorrect! Access denied.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username not found! Access denied.");
                    Console.ResetColor();
                }
            }
        }
    }
}
//string[] Args