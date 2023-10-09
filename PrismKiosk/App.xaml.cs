using Prism.Ioc;
using Prism.Regions;
using PrismKiosk.Models;
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
            //IAppContext와 AppContext를 싱글톤으로 등록
            containerRegistry.RegisterSingleton<IAppContext, AppContext>();

            //RegionNavigation을 사용할 화면을 등록
            //인트로 화면
            containerRegistry.RegisterForNavigation<KioskIntro>();
            //주문 구분 화면
            containerRegistry.RegisterForNavigation<OrderStart>();
            //메뉴 선택 화면
            containerRegistry.RegisterForNavigation<SelectMenu>();
            //결제 화면
            containerRegistry.RegisterForNavigation<Payment>();

            //관리자 로그인
            containerRegistry.RegisterForNavigation<ManagerLogin>();
            //마감
            containerRegistry.RegisterForNavigation<Deadline>();
        }
    }
}
