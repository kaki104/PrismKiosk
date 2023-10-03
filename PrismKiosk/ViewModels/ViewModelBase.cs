using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using PrismKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 뷰모델 베이스, 바인드어블베이스, 네이게이션어웨어
    /// </summary>
    public abstract class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        /// <summary>
        /// 컨테이터 프로바이더
        /// </summary>
        protected IContainerProvider ContainerProvider;
        /// <summary>
        /// 리즌 메니저
        /// </summary>
        protected IRegionManager RegionManager;
        private IAppContext _appContext;
        /// <summary>
        /// 앱 컨텍스트
        /// </summary>
        public IAppContext AppContext
        {
            get { return _appContext; }
            set { SetProperty(ref _appContext, value); }
        }
        /// <summary>
        /// 타이머
        /// </summary>
        protected DispatcherTimer Timer;

        /// <summary>
        /// 처음으로 커맨드
        /// </summary>
        public ICommand HomeCommand { get; set; }
        /// <summary>
        /// 뒤로가기 커맨드
        /// </summary>
        public ICommand GoBackCommand { get; set; }

        private bool _isBusy;
        /// <summary>
        /// IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public ViewModelBase()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public ViewModelBase(IContainerProvider containerProvider)
        {
            ContainerProvider = containerProvider;
            RegionManager = ContainerProvider.Resolve<IRegionManager>();
            AppContext = ContainerProvider.Resolve<IAppContext>();
            Init();
        }

        private void Init()
        {
            HomeCommand = new DelegateCommand<string>(OnHome);
            GoBackCommand = new DelegateCommand<string>(OnGoBack);
        }
        /// <summary>
        /// 뒤로 돌아가기
        /// </summary>
        private void OnGoBack(string viewType)
        {
            if (viewType != "kiosk")
            {
                return;
            }
            var regionJournal = RegionManager.Regions["KioskContentRegion"].NavigationService.Journal;
            if(regionJournal != null && regionJournal.CanGoBack)
            {
                regionJournal.GoBack();
            }
        }

        /// <summary>
        /// 홈 화면으로 이동 - kiosk이면 동작
        /// </summary>
        /// <param name="viewType"></param>
        private void OnHome(string viewType)
        {
            if (viewType != "kiosk")
            {
                return;
            }
            ClearAppContextAndGoHome();
        }
        /// <summary>
        /// AppContext 내용 클리어
        /// </summary>
        protected void ClearAppContextAndGoHome()
        {
            //지금까지 주문 내역 클리어
            AppContext.IsEatIn = false;

            //처음 화면으로 이동
            var region = RegionManager.Regions["KioskContentRegion"];
            if (region == null)
            {
                return;
            }
            region.RemoveAll();
            region.RequestNavigate("KioskIntro");
        }

        /// <summary>
        /// 네비게이션 되었을 때
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        /// <summary>
        /// 네비게이션이 가능한지
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 네비게이션 되기 전에
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
