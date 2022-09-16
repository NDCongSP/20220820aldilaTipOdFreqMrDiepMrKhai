using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipOdFreqAdmin
{
    public class tblDataLogPolishingModel
    {
        public Guid? Id { get; set; }
        public string Station { get; set; }
        public int? ShaftNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Part { get; set; }
        public string WorkOrder { get; set; }
        public double? FreqReading { get; set; }
        public double? FreqTarget { get; set; }
        public double? MortorPolishing { get; set; }
        public int? FormulaPO { get; set; }
        public string LogType { get; set; }

    }
}
