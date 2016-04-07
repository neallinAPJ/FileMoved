using FileMover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Common
{
    public class ConvertHelper
    {
        /// <summary>
        /// 把以“；”分隔的字符串转换成list数组
        /// </summary>
        /// <param name="param">字符串</param>
        /// <returns></returns>
        public static List<string> StringArrayConverToList(string param)
        {
            List<string> results = new List<string>();
            string[] paramArray = param.Split(';');
            foreach (var item in paramArray)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    results.Add(item.Trim().TrimEnd('\\'));
                }
            }
            return results;
        }
        /// <summary>
        /// 把List数组转换成RangeModel类型
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static RangeModel ListConvertToRangeModel(List<string> list, EnumfieldType type)
        {
            RangeModel model = new RangeModel();
            switch (type)
            {
                case EnumfieldType.Date:
                    if (list.Count >= 2)
                    {
                        model.Min = Convert.ToDateTime(list[0]);
                        model.Max = Convert.ToDateTime(list[1]);
                    }
                    if (list.Count == 1)
                    {
                        model.Value = Convert.ToDateTime(list[0]);
                    }
                    break;
                case EnumfieldType.Long:
                    if (list.Count >= 2)
                    {
                        model.Min = Convert.ToInt64(list[0]);
                        model.Max = Convert.ToInt64(list[1]);
                    }
                    if (list.Count == 1)
                    {
                        model.Value = Convert.ToInt64(list[0]);
                    }
                    break;
            }
            return model;
        }
    }
}
