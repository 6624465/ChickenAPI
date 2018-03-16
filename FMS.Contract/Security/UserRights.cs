using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Security
{
   public class UserRights
    {
        [Key, Column(Order = 0)]
        public Int32 UserID { get; set; }
        [Key, Column(Order = 1)]
        public Int16 SecurableItem { get; set; }
        [Key, Column(Order = 2)]
        public Int16 LinkGroup { get; set; }
        [Key, Column(Order = 3)]
        public string LinkID { get; set; }
    }
}
