using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipODFreq
{
    public class tblDataLogODModel
    {
        public Guid Id { get; set; }
        public int? ShaftNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Part { get; set; }
        public string MeasType { get; set; }
        public string WorkOrder { get; set; }
        public double? DiamReading { get; set; }
        public double? DiamLL { get; set; }
        public double? DiamUL { get; set; }
        public string PassFail { get; set; }
    }
}
