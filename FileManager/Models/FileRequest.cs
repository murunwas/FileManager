using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models
{
    public class FileRequest
    {
        public string[] Filters { get; set; }= new string[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
        public bool IsRecursive { get; set; } = false;
    }
}
