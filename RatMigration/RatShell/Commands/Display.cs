using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.RatShell.Commands
{
    public class Display : Command
    {
        public Display()
        {
            Description = "Changes Display Settings";
            Name = nameof(Display);
        }

        public override string Invoke(string[] Args)
        {
            string Response = "";
            int screenX = 800;
            int screenY = 640;
            try
            {
                switch (Args[0])
                {
                    case "help":
                        Response = "";
                        break;

                    case "color":
                        Response = "";
                        break;

                    default:
                        Response += "Unexpected argument: " + Args[0];
                        break;
                }

                switch (Args[1])
                {
                    case "placeholder":
                        Response = "";
                        break;

                    default:
                        Response += "Unexpected argument: " + Args[1];
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