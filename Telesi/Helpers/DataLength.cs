using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telesi.Types;

namespace Telesi.Helpers
{
    class DataLength{
        public int dataLength(string path_)
        {
            string[] dataInventory = File.ReadAllLines(path_);
            return dataInventory.Length;
        }
    }
}
