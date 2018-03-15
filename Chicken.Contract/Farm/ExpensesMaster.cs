using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Contract.Farm
{
   public class ExpensesMaster
    {
        [Key, Column(Order = 0)]
        public Int32 FramID { get; set; }
        [Key, Column(Order = 1)]
        public Int32 ExpensesCode { get; set; }
    }
}
