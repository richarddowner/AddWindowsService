using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace AddWindowsService
{
    [RunInstaller(true)]
    public class WindowsService : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public WindowsService()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "Change My Name";
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}