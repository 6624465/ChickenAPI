using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Utility
{
    public class DocumentNumberDetail
    {
        [Key, Column(Order = 0)]
        public Int64 BranchID { get; set; }
        [Key, Column(Order = 1)]
        public string DocumentKey { get; set; }
        [Key, Column(Order = 2)]
        public Int16 YearNo { get; set; }
        public Int64 January { get; set; }
        public Int64 February { get; set; }
        public Int64 March { get; set; }
        public Int64 April { get; set; }
        public Int64 May { get; set; }
        public Int64 June { get; set; }
        public Int64 July { get; set; }
        public Int64 August { get; set; }
        public Int64 September { get; set; }
        public Int64 October { get; set; }
        public Int64 November { get; set; }
        public Int64 December { get; set; }
    }
}
