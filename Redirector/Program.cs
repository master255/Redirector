using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace Redirector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (String arg in args)
                {
                    if (arg == "/start")
                    {
                        foreach (String arg1 in args)
                        {
                            if (arg1.StartsWith("/file="))
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.FileName = ConfigurationManager.AppSettings["app"];
                                int tempNum = 4;
                                try
                                {
                                    tempNum = Int32.Parse(ConfigurationManager.AppSettings["num"]);
                                    startInfo.Arguments = "http" + arg1.Substring(6 + tempNum);
                                    Process.Start(startInfo);
                                }
                                catch (Exception exception)
                                {}
                            }
                        }
                    }
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
