using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipODFreq
{
    public class tblTipOdFreqModel
    {
        public Guid Id { get; set; }
        public string ItemNumber { get; set; }
        public int? FreqTarget { get; set; }
        public double? DiamLL { get; set; }
        public double? DiamUL { get; set; }
        public string TipOdLength { get; set; }
        public int? FormulaGId { get; set; }
        public int? FormulaPoId { get; set; }

    }
}
