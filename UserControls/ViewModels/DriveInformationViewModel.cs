using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TS.UserControls.Models;
using UserControls.Models;

namespace UserControls.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DriveInformationViewModel
    {

        #region Variable
        public ObservableCollection<DriveInformation> DriveInformations { get; set; } = new ObservableCollection<DriveInformation>();

        #endregion



        public ObservableCollection<DriveInformation> GetDriveInformations()
        {
            ObservableCollection<DriveInformation> driveInformations = new ObservableCollection<DriveInformation>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + "Win32_DiskDrive");

            foreach (ManagementObject share in searcher.Get())
            {
                DriveInformation curDrive = new DriveInformation()
                {
                    Total = new SizeInformation(Convert.ToInt32(share["Size"])), 
                    VolumeIndex = Convert.ToInt32(share["Index"]),
                    Model = share["Model"]?.ToString() ?? "<No Information>",
                    MediaType = share["MediaType"]?.ToString() ?? "<No Information>",
                    Status = share["Status"]?.ToString() ?? "<No Information>",
                };                

                driveInformations.Add(curDrive);

                foreach (ManagementObject diskPartition in share.GetRelated("Win32_DiskPartition"))
                {
                    int diskIndex = Convert.ToInt32(diskPartition["DiskIndex"]);
                    int partitionIndex = Convert.ToInt32(diskPartition["Index"]);

                    foreach (var item in diskPartition.GetRelated("Win32_LogicalDisk"))
                    {
                        PartitionInformation partitionInformation = new PartitionInformation()
                        {
                            DiskIndex = diskIndex,
                            PartitionIndex = partitionIndex,                            
                            Letter = item["Name"]?.ToString() ?? "<No Information>",
                            Label = item["VolumeName"]?.ToString() ?? "<No nformation>",
                            Description = item["Description"]?.ToString() ?? "<No Information>",
                            Total = new SizeInformation(Convert.ToInt32(item["Size"])),
                            Free = new SizeInformation(Convert.ToInt64(item["FreeSpace"])),
                            
                        };

                        curDrive.Used = new SizeInformation(curDrive.Total.SizeInByte - curDrive.Free.SizeInByte);

                        curDrive.PartitionInformations.Add(partitionInformation);
                    }
                }
            }

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_CDROMDrive");

            foreach (ManagementObject cd in searcher.Get())
            {
                DriveInformation curDrive = new DriveInformation()
                {
                    Model = cd["Caption"]?.ToString() ?? "<No Information>",
                    MediaType = cd["MediaType"]?.ToString() ?? "<No Information>",
                    Status = cd["Status"]?.ToString() ?? "<No Information>",
                    Letter = cd["Drive"]?.ToString() ?? "<No Information>"

                };

                driveInformations.Add(curDrive);

                PartitionInformation partitionInformation = new PartitionInformation()
                {
                    Letter = cd["Drive"]?.ToString() ?? "<No Information>",
                    Label = cd["VolumeName"]?.ToString() ?? "<No Information>",
                    Description = cd["Description"]?.ToString() ?? "<No Information>"
                };

                curDrive.PartitionInformations.Add(partitionInformation);
            }

            return driveInformations;
        }
    }
}
