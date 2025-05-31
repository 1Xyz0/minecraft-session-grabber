using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyz.config
{
    public class Config
    {

        public static string Webhook = "";
        public static string ProgramTitle = "xyz";


        public static bool OpenRandomPrograms = false;
        public static int Timeout = 5000;

        public static bool DownloadProgramOnComputer = false;
        public static string DownloadLink = "";
        public static string FileName = "xget34";
        public static string FileType = "exe"; // exe | dll | py | bat | txt | json |
    
    }
}
