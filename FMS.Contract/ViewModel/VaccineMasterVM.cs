using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.ViewModel
{
   public class VaccineMasterVM
    {
        public Int32 FarmID { get; set; }
        public Int32 VaccineCode { get; set; }
        public string VaccineName { get; set; }
        public string VaccineType { get; set; }
        public string VaccineCompany { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string BatchNo { get; set; }
        public string Supplier { get; set; }
        public Int32 Quantity { get; set; }
        public string Photo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string FileName { get; set; }
    }
}
