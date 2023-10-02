using Prism.Ioc;
using Prism.Regions;
using PrismKiosk.Views;
using System.Windows;

namespace PrismKiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //RegionNavigation을 사용할 화면을 등록
            containerRegistry.RegisterForNavigation<KioskIntro>();
            containerRegistry.RegisterForNavigation<ManagerLogin>();
        }
    }
}
