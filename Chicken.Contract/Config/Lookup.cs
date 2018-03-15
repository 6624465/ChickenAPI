using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Contract.Config
{
    public class Lookup
    {
        [Key, Column(Order = 0)]
        public Int16 LookupID { get; set; }
    }
}
