using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesi.Types{
    public class Products{
        public string id_ { get; set; }
        public string name_ { get; set; }
        public string count_ { get; set; }
        public string price_ { get; set; }
    }
    public class PProds_{
        public List<Products> lol { get; set; }
    }
}