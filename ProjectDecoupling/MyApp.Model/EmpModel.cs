using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public  class EmpModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int? addressid { get; set; }
        public string code { get; set; }

        public virtual AddressModel Address { get; set; }
    }
}
