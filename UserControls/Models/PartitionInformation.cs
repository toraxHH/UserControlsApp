using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.Models;

namespace TS.UserControls.Models
{
    public class PartitionInformation : BaseInformation
    {        
        public int DiskIndex { get; set; }
        public int PartitionIndex { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
