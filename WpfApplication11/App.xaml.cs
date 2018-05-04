using System.Windows;
using Microsoft.Practices.Unity;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.ShutdownMode = ShutdownMode.OnMainWindowClose;

            var container = new UnityContainerFactory().GetContainer();

            var bootstrapper = container.Resolve<ShellBootstrapper>();
            bootstrapper.Run();
        }
    }
}
