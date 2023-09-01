using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.RatShell.Commands
{
    public class Dictionary : Command
    {
        public Dictionary()
        {
            Description = "This command allows the user to store words for later. Or for Word Kleptomaniacs";
            Name = nameof(Dictionary);
        }
        static void Main(string[] args)
        {
            Dictionary<string, int> inputDictionary = new Dictionary<string, int>();
            string Response = "";
            try
            {
                
                switch (args[0]) 
                {
                    case "add":
                        string[] inputArray = Response.Split(',');
                        int age = int.Parse(inputArray[1].Trim());
                        inputDictionary.Add(Response);
                        break;

                    default:
                        Response += "Unexpected argument: " + args[0];
                        break;
                }
            }
            catch (Exception E)
            {
               // return E.Message;
            }
            //return Response; 

        }
    }
}
//dictionary add hello, world