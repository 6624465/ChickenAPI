using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Contract.Security
{
    public class Registration
    {
        [Key, Column(Order = 0)]
        public Int64 id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
