using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.ViewModel
{
    public class AnimalProfileVM
    {
        public Int32 FarmID { get; set; }
        public Int32 AnimalCode { get; set; }
        public string AnimalName { get; set; }
        public string AnimalSymbol { get; set; }
        public Int16 AnimalStatus { get; set; }
        public string CauseOfDeath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Int16 Gender { get; set; }
        public Int32 SireCode { get; set; }
        public Int32 BreederCode { get; set; }
        public string BreederFormula { get; set; }
        public string Talents { get; set; }
        public decimal? Weight { get; set; }
        public string FightingRecord { get; set; }
        public decimal? StandardPrice { get; set; }
        public string Remarks { get; set; }
        public string AnimalPhoto { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string FileName { get; set; }
    }
}
