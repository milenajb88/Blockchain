using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Logger3
    {
        private static Logger3 instance = new Logger3();
        private const string logFilePath = @"D:\NodosBlockChain\Node3\Log.txt";

        private Logger3()
        {

        }

        public static Logger3 getInstance()
        {
            if (instance == null)
            {
                instance = new Logger3();
            }
            return instance;
        }

        public void Debug(string message)
        {
            getInstance();
            TextWriter tsw = new StreamWriter(logFilePath, true);
            tsw.Write(String.Format("{0} - {1}", DateTime.Now.ToString("HH:mm:ss"), message));
            tsw.WriteLine();
            tsw.Close();
        }

        public void CleanLog()
        {
            File.WriteAllText(logFilePath, String.Empty);
        }
    }
}
