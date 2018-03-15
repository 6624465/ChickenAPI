using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Contract.Security
{
   public class Roles
    {
        [Key, Column(Order = 0)]
        public Int32 CompanyCode { get; set; }
        [Key, Column(Order = 1)]
        public string RoleCode { get; set; }
    }
}
