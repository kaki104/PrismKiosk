using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System.Windows.Input;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 키오스크 인트로 뷰모델
    /// </summary>
    public class KioskIntroViewModel : ViewModelBase
    {
        /// <summary>
        /// 마우스 다운 커맨드
        /// </summary>
        public ICommand MouseDownCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public KioskIntroViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public KioskIntroViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }

        private void Init()
        {
            MouseDownCommand = new DelegateCommand(OnMouseDown);
        }
        /// <summary>
        /// 마우스 다운 커맨드 실행
        /// </summary>
        private void OnMouseDown()
        {
            //OrderStart 화면으로 네비게이션
            RegionManager.RequestNavigate("KioskContentRegion", "OrderStart");
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //동영상 플레이 중지 혹은 작업 중지
        }
    }
}
