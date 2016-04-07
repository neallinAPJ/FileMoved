using FileMover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //读取App.config中自定义节点file的配置项
                List<FileSettingModel> fileSettings = ConfigHelper.GetFileSettings();
                List<FileInfos> fileList = new List<FileInfos>();
                LogHelper.WriteLog("Begin to move file.");
                foreach (var item in fileSettings)
                {
                    foreach (var fromfloder in item.FromFloders)
                    {
                        LogHelper.WriteLog(string.Format("Traverse folder：{0}", fromfloder));
                        FileHelper.FindFile(fromfloder, item, ref fileList);
                        LogHelper.WriteLog(string.Format("From the {0} folder, move to folder {1}", fromfloder, item.ToFloder));
                        FileHelper.MoveFiles(fileList, item, fromfloder);
                        fileList.Clear();
                    }
                    
                }
                LogHelper.WriteLog("End to move file.");               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
            }
            
        }
    }
}
