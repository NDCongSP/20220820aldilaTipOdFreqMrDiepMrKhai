using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipODFreq
{
    public class tblDataLogFreqModel
    {
        public Guid Id { get; set; }
        public string Station { get; set; }
        public int? ShaftNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string WorkOrder { get; set; }
        public string Part { get; set; }
        public double? Freq01Reading { get; set; }
        public int? MotorSandingSpeed { get; set; }
        public double? Freq02Reading { get; set; }
        public int? MotorPolishingSpeed { get; set; }
        public double? FreqTarget { get; set; }
        public int? FormulaGId { get; set; }
        public int? FormulaPoId { get; set; }
        public string LogStyle { get; set; }
    }
}
