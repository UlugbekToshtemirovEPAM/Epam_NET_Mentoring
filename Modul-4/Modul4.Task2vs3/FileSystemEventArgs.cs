using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4.Task2vs3
{
        public class FileSystemEventArgs : EventArgs
        {
            public FileSystemInfo FileSystemInfo { get; }
            public bool Abort { get; set; }
            public bool Exclude { get; set; }

            public FileSystemEventArgs(FileSystemInfo fileSystemInfo)
            {
                FileSystemInfo = fileSystemInfo;
            }
        }
}
