using FileMover.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Common
{
    /// <summary>
    /// 查询帮助类
    /// </summary>
    public class SearchHelper
    {
        /// <summary>
        /// 判断该文件是否符合搜索条件
        /// </summary>
        /// <param name="searchList">搜索条件</param>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public static bool IsSearchSuccess(List<SearchModel> searchList, FileInfo file)
        {
            bool result = true;
            foreach (var item in searchList)
            {
                EnumOperator operatorAction = (EnumOperator)Enum.Parse(typeof(EnumOperator), item.Operator);
                switch (item.Key)
                {
                    case "CreateDate_Day":
                        int day = -Convert.ToInt32(item.Value);
                        DateTime searchCreateDate_Day = Convert.ToDateTime(DateTime.Now.AddDays(day).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchCreateDate_Day, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "CreateDate_Month":
                        int month = -Convert.ToInt32(item.Value);
                        DateTime searchCreateDate_Month = Convert.ToDateTime(DateTime.Now.AddMonths(month).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchCreateDate_Month, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "CreateDate_Year":
                        int year = -Convert.ToInt32(item.Value);
                        DateTime searchCreateDate_Year = Convert.ToDateTime(DateTime.Now.AddYears(year).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchCreateDate_Year, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "CreateDate":
                        DateTime searchCreateDate = Convert.ToDateTime(item.Value);
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchCreateDate, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastWriteTime_Day":
                        int day_LastWriteTime = -Convert.ToInt32(item.Value);
                        DateTime searchLastWriteTime_Day = Convert.ToDateTime(DateTime.Now.AddDays(day_LastWriteTime).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastWriteTime_Day, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastWriteTime_Month":
                        int month_LastWriteTime = -Convert.ToInt32(item.Value);
                        DateTime searchLastWriteTime_Month = Convert.ToDateTime(DateTime.Now.AddMonths(month_LastWriteTime).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastWriteTime_Month, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastWriteTime_Year":
                        int year_LastWriteTime = -Convert.ToInt32(item.Value);
                        DateTime searchLastWriteTime_Year = Convert.ToDateTime(DateTime.Now.AddYears(year_LastWriteTime).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastWriteTime_Year, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastWriteTime":
                        DateTime searchLastWriteTime = Convert.ToDateTime(item.Value);
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastWriteTime, Convert.ToDateTime(file.LastWriteTime.ToShortDateString()));
                        break;
                    case "LastAccessTime_Day":
                        int day_LastAccessTime = -Convert.ToInt32(item.Value);
                        DateTime searchLastAccessTime_Day = Convert.ToDateTime(DateTime.Now.AddDays(day_LastAccessTime).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastAccessTime_Day, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastAccessTime_Month":
                        int month_LastAccessTime = -Convert.ToInt32(item.Value);
                        DateTime searchLastAccessTime_Month = Convert.ToDateTime(DateTime.Now.AddMonths(month_LastAccessTime).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastAccessTime_Month, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastAccessTime_Year":
                        int year_LastAccessTime = -Convert.ToInt32(item.Value);
                        DateTime searchLastAccessTime_Year = Convert.ToDateTime(DateTime.Now.AddYears(year_LastAccessTime).ToShortDateString());
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastAccessTime_Year, Convert.ToDateTime(file.CreationTime.ToShortDateString()));
                        break;
                    case "LastAccessTime":
                        DateTime searchLastAccessTime = Convert.ToDateTime(item.Value);
                        result = IsOperatorSuccess<DateTime, DateTime>(operatorAction, searchLastAccessTime, Convert.ToDateTime(file.LastAccessTime.ToShortDateString()));
                        break;
                    case "FileSize":
                        long searchFileSize = Convert.ToInt64(item.Value) * 1024;
                        result = IsOperatorSuccess<long, long>(operatorAction, searchFileSize, file.Length);
                        break;
                    case "FileType":
                        List<string> searchFileTypes = ConvertHelper.StringArrayConverToList(item.Value);
                        result = IsOperatorSuccess<List<string>, string>(operatorAction, searchFileTypes, file.Extension);
                        break;
                    case "FileName":
                        string searchFileName = item.Value;
                        result = IsOperatorSuccess<string, string>(operatorAction, searchFileName, file.Name.Remove(file.Name.IndexOf(".")));
                        break;
                }
            }
            return result;
        }
        /// <summary>
        /// 是否运算成功
        /// </summary>
        /// <typeparam name="T">搜索字段的类型</typeparam>
        /// <param name="operatorAction">运算符</param>
        /// <param name="searchParam">搜索条件参数</param>
        /// <param name="fileParam">文件对应的对比参数</param>
        /// <returns></returns>
        public static bool IsOperatorSuccess<T, F>(EnumOperator operatorAction, T searchParam, F fileParam)
        {
            dynamic param1 = searchParam;
            dynamic param2 = fileParam;
            switch (operatorAction)
            {
                case EnumOperator.BW:
                    if (param2.StartsWith(param1))
                    {
                        return true;
                    }
                    break;
                case EnumOperator.CT:
                    if (typeof(T) == typeof(string))
                    {
                        if (param2.Contains(param1))
                        {
                            return true;
                        }
                    }
                    if (typeof(T) == typeof(List<string>))
                    {
                        if (param1.Contains(param2))
                        {
                            return true;
                        }
                    }
                    break;
                case EnumOperator.EW:
                    if (param2.EndsWith(param1))
                    {
                        return true;
                    }
                    break;
                case EnumOperator.EQ:
                    if (param2 == param1)
                    {
                        return true;
                    }
                    break;
                case EnumOperator.GT:
                    if (param2 > param1)
                    {
                        return true;
                    }
                    break;
                case EnumOperator.GE:
                    if (param2 >= param1)
                    {
                        return true;
                    }
                    break;
                case EnumOperator.LT:
                    if (param2 < param1)
                    {
                        return true;
                    }
                    break;
                case EnumOperator.LE:
                    if (param2 <= param1)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
