using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace momotLabs
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {

        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;
        public Installer1()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();
            // Учётная запись для службы
            processInstaller.Account = ServiceAccount.LocalSystem;
            // Режим запуска (в данном случае Manual (вручную)).
            // Если служба не является драйвером устройства допустимы только значения Manual, Authomatic (автоматический запуск при загрузке системы) и Disabled (отключено).
            serviceInstaller.StartType = ServiceStartMode.Manual;
            // Имя службы (должно совпадать с именем класса службы).
            serviceInstaller.ServiceName = "ServiceTest";
            // Отображаемое имя службы. Под ним служба будет отображаться в различных утилитах для работы со службами Windows.
            // Это необязательные параметр. При его отсутствии будет отображаться ServiceName.
            serviceInstaller.DisplayName = "Служба ServiceTest";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
