using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.Models
{
    public class BaseInformation
    {
        public SizeInformation Total { get; set; }
        public SizeInformation Free { get; set; }
        public SizeInformation Used { get; set; }
        public double FreeProcent => Total.SizeInByte == 0 ? 0 : Math.Round((double)Free.SizeInByte / Total.SizeInByte, 4, MidpointRounding.AwayFromZero);
        public string Letter { get; set; }
    }
}
