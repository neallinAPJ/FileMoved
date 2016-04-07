using FileMover.Common;
using FileMover.Model;
using FileMover.Model.CustomConfigNode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileMover
{
    /// <summary>
    /// 配置文件帮助类
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 读取App.Config,File节点的数据
        /// </summary>
        /// <returns></returns>
        public static List<FileSettingModel> GetFileSettings()
        {
            List<FileSettingModel> FileSettings = new List<FileSettingModel>();
            try
            {               
                FileConfigurationSection fileSection = (FileConfigurationSection)ConfigurationManager.GetSection("File");
                FileSettings = (from item in fileSection.KeyValues.Cast<FloderSetting>()
                                select new FileSettingModel()
                                    {
                                        ToFloder = item.ToFolder,
                                        FromFloders =ConvertHelper.StringArrayConverToList(item.FromFolder),
                                        Sub =item.Sub!="false"?true:false,
                                        Struct = item.Struct != "false" ? true : false,
                                        SearchModels = (from search in item.KeyValues.Cast<SearchSetting>()
                                                        select new SearchModel()
                                                        {
                                                            Key = search.Key,
                                                            Value = search.Value,
                                                            Operator = search.Operator
                                                        }).ToList()
                                    }).ToList();
                return FileSettings;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(string.Format("Read the configuration file error, error message：{0}", ex.Message));
                return FileSettings;
            }
        }
        
    }
}
