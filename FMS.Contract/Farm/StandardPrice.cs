using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class StandardPrice
    {
        public Int32 FarmID { get; set; }
        [Key, Column(Order = 0)]
        public Int32 StandardPriceId { get; set; }
        public Int32 SireCode { get; set; }
        public Int32 BreederCode { get; set; }
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExRate { get; set; }
        public decimal LocalPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
