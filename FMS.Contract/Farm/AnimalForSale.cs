using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class AnimalForSale
    {
        [Key, Column(Order = 0)]
        public Int32 SaleID { get; set; }
        public Int32 FarmID { get; set; }
        public Int32 AnimalCode { get; set; }
        public Int16 AnimalAge { get; set; }
        public string Breed { get; set; }
        public Int32 SireCode { get; set; }
        public Int32 BreederCode { get; set; }
        public string Talents { get; set; }
        public Int32 Age { get; set; }
        public decimal Weight { get; set; }
        public string FightingRecord { get; set; }
        public bool? IsShowStandardPrice { get; set; }
        public string AnimalPhoto { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
