using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.Models;

namespace TS.UserControls.Models
{
    public class DriveInformation : BaseInformation
    {        
        public string Model { get; set; }
        public string MediaType { get; set; }
        public string Status { get; set; }
        public int VolumeIndex { get; set; }        
        public ObservableCollection<PartitionInformation> PartitionInformations { get; set; } = new ObservableCollection<PartitionInformation>();
    }
}
