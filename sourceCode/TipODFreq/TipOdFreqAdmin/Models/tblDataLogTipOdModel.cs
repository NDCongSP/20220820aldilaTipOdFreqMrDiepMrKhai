using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipOdFreqAdmin
{
    public class tblDataLogTipOdModel
    {
        public Guid Id { get; set; }
        public string Station { get; set; }
        public int? ShaftNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string WorkOrder { get; set; }
        public string Part { get; set; }
        public double? DiamReading { get; set; }
        public string MeasType { get; set; }
        public double? DiamLL { get; set; }
        public double? DiamUL { get; set; }
        public string PassFail { get; set; }
        public string LogType { get; set; }
    }
}
