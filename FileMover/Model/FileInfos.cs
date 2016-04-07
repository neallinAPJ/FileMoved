using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model
{
    /// <summary>
    /// 文件信息Model
    /// </summary>
    public class FileInfos
    {
        public string FullName { get; set; }
        public bool Exist { get; set; }
        public bool IsReadOnly { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public FileAttributes FileAttributes { get; set; }
        public string Directory { get; set; }
    }
}
