using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Security
{
   public class RoleRights
    {
        [Key, Column(Order = 0)]
        public Int32 CompanyCode { get; set; }
        [Key, Column(Order = 1)]
        public string RoleCode { get; set; }
        [Key, Column(Order = 2)]
        public Int32 SecurableItem { get; set; }
    }
}
