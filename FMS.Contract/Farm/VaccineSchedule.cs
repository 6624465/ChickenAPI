using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class VaccineSchedule
    {
        [Key, Column(Order = 0)]
        public Int32 FarmID { get; set; }
        [Key, Column(Order = 1)]
        public Int32 VaccineCode { get; set; }
        public Int16? AnimalAge { get; set; }
        public string VaccineName { get; set; }
        public string VaccineCompany { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
