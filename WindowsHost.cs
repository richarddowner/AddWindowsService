using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;

namespace AddWindowsService
{
    class WindowsHost : ServiceBase
    {
        public WindowsHost()
        {
            ServiceName = ConfigurationSettings.AppSettings["ServiceName"];
            CanStop = Boolean.Parse(ConfigurationSettings.AppSettings["CanStop"]);
            CanPauseAndContinue = Boolean.Parse(ConfigurationSettings.AppSettings["CanPauseAndContinue"]);
            AutoLog = Boolean.Parse(ConfigurationSettings.AppSettings["AutoLog"]);
        }

        protected override void OnStart(string[] args)
        {
            Process.Start(ConfigurationSettings.AppSettings["ProcessExe"]);
        }

        protected override void OnStop()
        {
            try
            {
                foreach (var proc in Process.GetProcessesByName(ConfigurationSettings.AppSettings["ProcessName"]))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            ServiceBase.Run(new WindowsHost());
        }
    }
}