using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model
{
    public class FileSettingModel
    {
        public string ToFloder { get; set; }
        public List<string> FromFloders { get; set; }
        public bool Sub { get; set; }
        public bool Struct { get; set; }

        public List<SearchModel> SearchModels { get; set; }
    }
}
