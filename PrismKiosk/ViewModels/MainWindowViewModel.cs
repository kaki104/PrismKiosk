using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 메인 윈도우 뷰모델
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Prism Kiosk Sample";
        /// <summary>
        /// 타이틀
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainWindowViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public MainWindowViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            var regionManager = ContainerProvider.Resolve<IRegionManager>();
            //2개의 리즌에 시작할 화면 지정
            regionManager.RegisterViewWithRegion("KioskContentRegion", "KioskIntro");
            regionManager.RegisterViewWithRegion("ManagerContentRegion", "ManagerLogin");
        }
    }
}
