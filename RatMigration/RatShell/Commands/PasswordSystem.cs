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
            // Create a dictionary of usernames and passwords for authentication
            Dictionary<string, string> users = new Dictionary<string, string>()
            {
                {"admin", "admin"},
                {"user1", "password1"},
                {"user2", "password2"},
                {"user3", "password3"}
            };

            // Continuously prompt for login until successful
            while (true)
            {
                Console.WriteLine("Please log in!");
                Console.WriteLine("User:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                // Check if the entered username exists in the dictionary
                if (users.ContainsKey(username))
                {
                    // Check if the entered password matches the stored password
                    if (users[username] == password)
                    {
                        // Successful login, display a message in green and exit the loop
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Access granted.");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        // Incorrect password, display an error message in red
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Password incorrect! Access denied.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    // Username not found, display an error message in red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username not found! Access denied.");
                    Console.ResetColor();
                }
            }
        }
    }
}

//string[] Args