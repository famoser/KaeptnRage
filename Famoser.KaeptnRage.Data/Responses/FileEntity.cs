using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.KaeptnRage.Data.Responses
{
    public class FileEntity
    {
        public DateTime ChangeDate { get; set; }
        public string FileName { get; set; }
        public byte[] Bytes { get; set; }
    }
}
