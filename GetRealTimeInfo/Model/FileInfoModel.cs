using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRealTimeInfo.Model
{
    public class FileInfoModel
    {
        public int fsize { get; set; }

        public string hash { get; set; }

        public string mimeType { get; set; }

        public long putTime { get; set; }
    }
}
