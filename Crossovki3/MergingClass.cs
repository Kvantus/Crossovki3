using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crossovki3
{
    public static class MergingClass
    {
        public static string MyUnrecFile { get; set; }

        public class ResultTable
        {
            public string Supplier { get; set; }
            public string Brand { get; set; }
            public string NumberNice { get; set; }
            public string NumberBad { get; set; }
            public string OEMBrand { get; set; }
            public string OEMNumber { get; set; }
            public string PartName { get; set; }
            public string OEMPartName { get; set; }
        }
    }
}
