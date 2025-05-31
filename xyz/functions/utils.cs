using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace xyz.functions
{
    class utils
    {
        public static async Task<string> GetIp()
        {
            HttpClient client = new HttpClient();

            string ip = await client.GetStringAsync("https://api.ipify.org");

            return ip;
        }


        public static string GetMac()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in interfaces)
            {
                var address = adapter.GetPhysicalAddress();
                if (address != null && address.ToString() != "")
                {
                    return address.ToString();
                }
            }

            return "not found";
        }


        public static string GetSid()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            data.sid = identity.User.Value;

            return data.sid;
        }


        public static string GetHwid()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["ProcessorId"].ToString();
                }
            }
            catch { }

            return "not found";
        }

    }
}
