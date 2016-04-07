using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model
{
    public class SearchModel
    {
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 搜索条件的值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 搜索条件的运算方式
        /// </summary>
        public string Operator { get; set; }
    }

    
}
