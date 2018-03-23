using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class TreatmentEntry
    {

        [Key, Column(Order = 0)]
        public Int32 RecordID { get; set; }
        //[Key, Column(Order = 1)]
        public Int32 FarmID { get; set; }
        //[Key, Column(Order = 2)]
        public Int32 AnimalCode { get; set; }
        public string MedicineName { get; set; }
        public string Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Dosage { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
