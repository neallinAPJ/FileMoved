using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover
{
    /// <summary>
    /// 日志记录帮助类
    /// </summary>
    public class LogHelper
    {
        private static String _logPath;
        const String LogFormat = "TimerLog{0}{1}.txt";
        static String logFolder;

        static LogHelper()
        {
            logFolder = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Logs");

            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            ReSetLogFileName();
        }


        public static void ReSetLogFileName()
        {
            _logPath = Path.Combine(logFolder, string.Format(LogFormat, System.DateTime.Now.Year, System.DateTime.Now.Month.ToString("00")));
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void WriteLog(string msg)
        {
            msg = string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd mm:ss"), msg);

            using (TextWriter tw = File.AppendText(_logPath))
            {
                tw.WriteLine(msg);
            }
        }
    }
}
