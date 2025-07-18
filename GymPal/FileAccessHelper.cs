using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal
{
    public static class FileAccessHelper
    {
        public static readonly string FILENAME = Path.Combine(FileSystem.AppDataDirectory, "movements.db3");

    }
}
