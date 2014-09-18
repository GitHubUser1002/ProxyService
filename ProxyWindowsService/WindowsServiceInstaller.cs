using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;

namespace ProxyWindowsService
{
    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {
        private ServiceProcessInstaller _process;
        private ServiceInstaller _service;

        public WindowsServiceInstaller()
        {
            _process = new ServiceProcessInstaller();
            _process.Account = ServiceAccount.LocalSystem;
            _service = new ServiceInstaller();
            _service.ServiceName = "Secret Windows Service";
            Installers.Add(_process);
            Installers.Add(_service);
        }
    }
}
