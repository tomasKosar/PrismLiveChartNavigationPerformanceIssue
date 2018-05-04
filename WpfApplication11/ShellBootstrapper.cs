using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace WpfApplication11
{
    public class ShellBootstrapper : UnityBootstrapper
    {
        private readonly IUnityContainerFactory containerFactory;

        public ShellBootstrapper(IUnityContainerFactory containerFactory)
        {
            this.containerFactory = containerFactory;
        }

        protected override DependencyObject CreateShell()
        {
            Window shell = this.Container.Resolve<MainWindow>();

            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override IUnityContainer CreateContainer()
        {
            return this.containerFactory.GetContainer();
        }
    }
}
