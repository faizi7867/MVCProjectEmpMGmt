using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Model.Properties
{
    public class EmpModel
    {
        public int id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public int? addressid { get; set; }
        [Required]
        public string code { get; set; }
        public AddressModel address { get; set; }
    }
}
