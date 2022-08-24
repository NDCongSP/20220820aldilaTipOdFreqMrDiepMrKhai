using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipODFreq
{
    public class PartInfoModel
    {
        public Guid Id { get; set; }
        public string ItemNumber { get; set; }
        public int? Freq { get; set; }
        public double? DiamLL { get; set; }
        public double? DiamUL { get; set; }
        public string TipOdLength { get; set; }
        public int? FormulaGId { get; set; }
        public int? FormulaPoId { get; set; }
        public int? GU { get; set; }
        public int? GV { get; set; }
        public double? GX { get; set; }
        public double? GY { get; set; }
        public int? GZ { get; set; }
        public double? GP { get; set; }
        public int? PoU { get; set; }
        public int? PoV { get; set; }
        public double? PoX { get; set; }
        public double? PoY { get; set; }
        public int? PoZ { get; set; }
        public double? PoP { get; set; }

    }
}
