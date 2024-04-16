using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace All_in_OSU_
{
    class LoggerClass
    {
        private bool LoggingEnabled = false;

        public LoggerClass(bool isLogEnabled)
        {
            LoggingEnabled = false;
        }

        public void Log(string log)
        {
            try
            {
                if (File.ReadAllText("AIO.log").Length > 1000000)
                {
                    File.Delete("AIO.log");
                }
            }
            catch { }

            StreamWriter sw = new StreamWriter("AIO.log", true);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " :: " + log);
            sw.Close();
        }

        public void Error(string log, Exception ex)
        {
            StreamWriter sw = new StreamWriter("AIO.log", true);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " :: (Error) " + log);
            sw.WriteLine("> " + ex.Message);
            sw.WriteLine("> " + ex.Source);
            sw.Close();
        }
    }
}
