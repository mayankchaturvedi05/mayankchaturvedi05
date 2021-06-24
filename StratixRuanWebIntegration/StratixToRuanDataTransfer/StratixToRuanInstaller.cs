using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace StratixToRuanDataTransfer
{
    [RunInstaller(true)]
    public class StratixToRuanInstaller : Installer
    {

        public StratixToRuanInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            // Setup the Service Account type per your requirement
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            serviceInstaller.ServiceName = "StratixToRuanService";
            serviceInstaller.DisplayName = "StratixToRuan Service";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.Description = "Heidtman Custom StratixToRuan Service";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }

    }
}