using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cosmos.HAL;
using Cosmos.System.Network;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DHCP;

namespace RatMigration.RatShell.Commands
{
    internal class Network : Command
    {
        public Network()
        {
            Description = "Displays networking info";
            Name = nameof(Network);
        }

        public override string Invoke(string[] Args)
        {
            string Response = "";
            NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0"); //get network device by name
            IPConfig.Enable(nic, new Address(192, 168, 1, 69), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254)); //enable IPv4 configuration

            using (var xClient = new DHCPClient())
            {
                /** Send a DHCP Discover packet **/
                //This will automatically set the IP config after DHCP response
                xClient.SendDiscoverPacket();
            }
            try
            {
                switch (Args[0])
                {
                    case "ip":
                    Response = NetworkConfiguration.CurrentAddress.ToString();
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
