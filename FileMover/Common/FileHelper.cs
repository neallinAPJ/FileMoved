using FileMover.Common;
using FileMover.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover
{
    /// <summary>
    /// 文件处理帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 批量移动文件
        /// </summary>
        /// <param name="fileList">需要移动的文件路径</param>
        /// <param name="toFloder">需要移动到哪个路径</param>
        public static void MoveFiles(List<FileInfos> fileList,FileSettingModel fileSetting,string fromFloder)
        {
            foreach (var file in fileList)
            {
                if (file.Exist)
                {
                    try
                    {
                        string toFloder = fileSetting.ToFloder;
                        if (fileSetting.Struct==true)
                        {
                            toFloder = file.Directory.Replace(fromFloder, fileSetting.ToFloder);
                        }
                        if (!Directory.Exists(toFloder))
                        {
                            Directory.CreateDirectory(toFloder);
                        }
                        var toFloderFile = @toFloder + "\\" + file.FileName;
                        var fromFloderFile = @file.FullName;
                        File.Move(fromFloderFile, toFloderFile);
                        LogHelper.WriteLog(string.Format("Move File: {0}. Success.", file.FileName.Trim()));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(string.Format("Move folder: {0}. Failure.", file.FileName.Trim()));
                        LogHelper.WriteLog(string.Format("Error Message: {0}.", ex.Message));
                    }
                }
            }
        }
        /// <summary>
        /// 查找某个文件夹和子文件中的所有文件
        /// </summary>
        /// <param name="dirPath">文件夹路径</param>
        public static void FindFile(string dirPath, FileSettingModel fileSetting, ref List<FileInfos> fileList) //参数dirPath为指定的目录  
        {
              
            try
            {
                if (Directory.Exists(dirPath))
                {
                    DirectoryInfo Dir = new DirectoryInfo(dirPath);
                    foreach (FileInfo file in Dir.GetFiles()) //查找文件  
                    {
                        if (SearchHelper.IsSearchSuccess(fileSetting.SearchModels, file))
                        {
                            fileList.Add(new FileInfos
                            {
                                FullName = file.FullName,
                                Exist = file.Exists,
                                FileName = file.Name,
                                CreateDate = file.CreationTime,
                                LastWriteTime = file.LastWriteTime,
                                LastAccessTime = file.LastAccessTime,
                                FileType = file.Extension,
                                FileAttributes = file.Attributes,
                                FileSize = file.Length,
                                IsReadOnly = file.IsReadOnly,
                                Directory = file.DirectoryName
                            });
                        }

                    }
                    if (fileSetting.Sub == true)
                    {
                        foreach (DirectoryInfo d in Dir.GetDirectories())//查找子目录  
                        {
                            FindFile(Dir + "\\" + d.ToString(), fileSetting, ref fileList);
                        }
                    }                   
                }
                else
                {
                    LogHelper.WriteLog(string.Format("The folder {0} does not exist", dirPath));  
                }
                
            }  
            catch(Exception e)  
            {
                string errorMessage = string.Format("Traverse the file error, error message：{0}", e.Message);
                LogHelper.WriteLog(errorMessage);  
             }
        }  
       
    }
}
