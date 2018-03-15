using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Contract.Farm
{
   public class FarmProfile
    {
        [Key, Column(Order = 0)]
        public Int32 FarmID { get; set; }
    }
}
