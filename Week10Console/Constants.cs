using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Console
{
    internal class Constants
    {
        private const string folderName = "temp";

        public static string directoryPath => Path.Combine(Directory.GetCurrentDirectory(), folderName);
    }
}
