using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 주문 구분(시작) 뷰모델
    /// </summary>
    public class OrderStartViewModel : ViewModelBase
    {
        /// <summary>
        /// 주문 구분 선택 커맨드
        /// </summary>
        public ICommand OrderTypeCommand { get; set; }
        /// <summary>
        /// 장애인UI 커맨드
        /// </summary>
        public ICommand DisabledCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public OrderStartViewModel()
        {

        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public OrderStartViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }

        private void Init()
        {
            OrderTypeCommand = new DelegateCommand<string>(OnOrderType);
            DisabledCommand = new DelegateCommand<string>(OnDisabled);
        }
        private void TimerTick(object sender, EventArgs e)
        {
            ClearAppContextAndGoHome();
        }

        /// <summary>
        /// 장애인 UI, 일반 UI 전환
        /// </summary>
        private void OnDisabled(string para)
        {
            AppContext.IsDisabledUi = para.ToLower() == "disabled" ? true : false;
        }

        /// <summary>
        /// 주문 구분 선택
        /// </summary>
        /// <param name="orderType"></param>
        private void OnOrderType(string orderType)
        {
            AppContext.IsEatIn = orderType.ToLower() == "eatin" ? true : false;
            //주문 구분 선택 후 메뉴 선택 화면으로 이동
            RegionManager.RequestNavigate("KioskContentRegion", "SelectMenu");
        }

        /// <summary>
        /// 들어올때
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            AppContext.KioskStatus = Commons.StatusEnum.OrderStart;

            Timer = new DispatcherTimer(TimeSpan.FromSeconds(30),
                        DispatcherPriority.Normal, TimerTick, App.Current.Dispatcher);
            Timer.Start();
        }
        /// <summary>
        /// 나갈때
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            DestroyTimer();
        }
        /// <summary>
        /// 지워질 때
        /// </summary>
        public override void Destroy()
        {
            DestroyTimer();
        }
        private void DestroyTimer()
        {
            if(Timer == null)
            {
                return;
            }
            Timer.Stop();
            Timer = null;
        }
    }
}
