using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Logger1
    {
        private static Logger1 instance = new Logger1();
        private const string logFilePath = @"D:\NodosBlockChain\Node1\Log.txt";

        private Logger1()
        {

        }

        public static Logger1 getInstance()
        {
            if(instance == null)
            {
                instance = new Logger1();
            }
            return instance;
        }

        public void Debug(string message)
        {
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
