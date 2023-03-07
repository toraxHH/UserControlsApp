using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.Models
{
    public class SizeInformation
    {
        // 1073741823
        // Bezogen auf Byte und binäres System (PC)
        const long KB = 1024;
        const long MB = 1048576;
        const long GB = 1073741824;
        long sizeInBytes;
        public long SizeInByte
        {
            get => sizeInBytes;
            set
            {
                sizeInBytes = value;
                double tmp;

                switch (sizeInBytes)
                {
                    // Umrechnung Byte in Gibibyte
                    case long i when i >= GB:
                        CurrentSize = Math.Round(sizeInBytes / Math.Pow(1024.0, 3), 2, MidpointRounding.AwayFromZero);
                        SizeUnit = "GB";
                        break;
                    // Umrechnung Byte in Mebibyte
                    case long i when i >= MB:
                        tmp = sizeInBytes / Math.Pow(1024.0, 2);
                        CurrentSize = Math.Round(tmp, 2, MidpointRounding.AwayFromZero);
                        if (tmp < 1024.0 && CurrentSize >= 1024.0)
                        {
                            SizeUnit = "GB";
                            CurrentSize = 1;
                        }
                        else
                            SizeUnit = "MB";
                        break;
                    // Umrechnung Byte in Kibibyte
                    case long i when i >= KB:
                        tmp = sizeInBytes / 1024.0;
                        CurrentSize = Math.Round(tmp, 2, MidpointRounding.AwayFromZero);
                        if (tmp < 1024.0 && CurrentSize >= 1024.0)
                        {
                            SizeUnit = "MB";
                            CurrentSize = 1;
                        }
                        else
                            SizeUnit = "KB";
                        //CurrentSize = 
                        break;
                    default:
                        CurrentSize = sizeInBytes;
                        SizeUnit = "B";
                        break;
                }
            }
        }

        public double CurrentSize { get; private set; }
        public string SizeUnit { get; set; }
        public string SizeOutput => $"{CurrentSize.ToString("N2")} {SizeUnit}";

        public SizeInformation(long sizeInByte)
        {
            SizeInByte = sizeInByte;
        }
    }
}
