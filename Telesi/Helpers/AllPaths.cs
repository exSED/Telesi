using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesi.Helpers
{
    class AllPaths
    {
        public string Inve_() {
            return Directory.GetCurrentDirectory() + "/packageInventory.log";
        }
        public string Invo_()
        {
            return Directory.GetCurrentDirectory() + "/packageInvoice.log";
        }
        public string ProdInvo_()
        {
            return Directory.GetCurrentDirectory() + "/packageProdsInvoice.log";
        }
        public string Temp_()
        {
            return Directory.GetCurrentDirectory() + "/tem.log";
        }
    }
}
