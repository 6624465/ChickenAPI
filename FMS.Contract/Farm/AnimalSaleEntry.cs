using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class AnimalSaleEntry
    {
        [Key, Column(Order = 0)]
        public Int32 SaleEntryID { get; set; }
        public Int32 FarmID { get; set; }
        public Int32 AnimalCode { get; set; }
        public Int16 AnimalStatus { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerPhoneNo { get; set; }
        public string BuyerMobileNo { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
