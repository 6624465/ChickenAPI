using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class MedicineMaster
    {
        public Int32 FarmID { get; set; }
        [Key, Column(Order = 0)]
        public Int32 MedicineCode { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public string MedicineCompany { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string BatchNo { get; set; }
        public Int16? Quantity { get; set; }
        public string Supplier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
