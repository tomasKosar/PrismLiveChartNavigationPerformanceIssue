using System.Windows;
using Microsoft.Practices.Prism.Regions;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool switcher = false;

        private readonly IRegionManager regionManager;

        public MainWindow(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.InitializeComponent();

            this.regionManager.RegisterViewWithRegion("MainTestRegion", typeof(LiveChart));
            this.regionManager.RegisterViewWithRegion("MainTestRegion", typeof(OtherView));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate("MainTestRegion", switcher ? typeof(LiveChart).FullName : typeof(OtherView).FullName);

            switcher = !switcher;
        }
    }
}
