using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Patterndesignexercises
{
    public class Logger
    {
        private static Logger instance;
        private Logger()
        {
           WriteLine("private constructor");
        }
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
        public void WriteLog(string msg)
        {
           WriteLine($"Log: {msg}");
        }
    }
    internal class logger_ex_2_
    {
        public static void Main(string[] args)
        {
            Logger logger =Logger.Instance;
            logger.WriteLog("application started");
            logger.WriteLog("user logged in");
          

        }
    }
}
