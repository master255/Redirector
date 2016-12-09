using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Net;

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
                                    WebServer ws = new WebServer(SendResponse, "http://127.0.0.1:7777/check/");
                                    ws.Run();
                                    var process = Process.Start(startInfo);
                                    process.WaitForExit();
                                    ws.Stop();

                                }
                                catch (Exception exception)
                                {
                                
                                }
                                
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
        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("1");
        }
    }
}
