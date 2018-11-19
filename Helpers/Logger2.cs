using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Logger2
    {
        private static Logger2 instance = new Logger2();
        private const string logFilePath = @"D:\NodosBlockChain\Node2\Log.txt";

        private Logger2()
        {

        }

        public static Logger2 getInstance()
        {
            if (instance == null)
            {
                instance = new Logger2();
            }
            return instance;
        }

        public void Debug(string message)
        {
            TextWriter tsw = new StreamWriter(logFilePath, true);
            tsw.Write(String.Format("{0} - {1}", DateTime.Now, message));
            tsw.WriteLine();
            tsw.Close();
        }

        public void CleanLog()
        {
            File.WriteAllText(logFilePath, String.Empty);
        }
    }
}
