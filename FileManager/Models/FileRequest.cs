using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models
{
    public class FileRequest
    {
        public string FolderPath { get; set; }
        public string[] Filters { get; set; }
        public bool IsRecursive { get; set; }
    }
}
