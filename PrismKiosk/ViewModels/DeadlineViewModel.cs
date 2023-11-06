using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using PrismKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 마감 뷰모델
    /// </summary>
    public class DeadlineViewModel : ViewModelBase
    {
        private IList<Order> _currentOrders;
        /// <summary>
        /// 현재 주문 목록
        /// </summary>
        public IList<Order> CurrentOrders
        {
            get => _currentOrders;
            set => SetProperty(ref _currentOrders, value);
        }
        /// <summary>
        /// 마감 커맨드
        /// </summary>
        public ICommand MakeDeadlineCommand { get; set; }
        /// <summary>
        /// 로그아웃 커맨드
        /// </summary>
        public ICommand LogoutCommand { get; set; }
        /// <summary>
        /// 검색 커맨드
        /// </summary>
        public ICommand SearchCommand { get; set; }

        private DateTime _deadlineDatetime;
        /// <summary>
        /// 마감일
        /// </summary>
        public DateTime DeadlineDatetime
        {
            get => _deadlineDatetime;
            set => SetProperty(ref _deadlineDatetime, value);
        }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public DeadlineViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public DeadlineViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }
        /// <summary>
        /// 초기화
        /// </summary>
        private void Init()
        {
            MakeDeadlineCommand = new DelegateCommand(OnMakeDeadline);
            LogoutCommand = new DelegateCommand(OnLogout);
            //비동기 메서드 호출
            SearchCommand = new DelegateCommand(async () => await OnSearchAsync());
        }
        /// <summary>
        /// 검색
        /// </summary>
        private async Task OnSearchAsync()
        {
            //검색 조건의 일자가 오늘이면
            if (DeadlineDatetime.Date == DateTime.Today)
            {
                CurrentOrders = AppContext.Orders;
            }
            else
            {
                //데이터를 db에서 조회하거나 서비스에서 조회를 하면 비동기로 처리되기 때문에 비동기 메서드로 만들었습니다.
                await Task.Delay(10);

                //이전에 마감된 데이터를 조회해서 출력해야함 - 여기는 셈플 데이터로 대체
                List<Order> list = new();
                for (int i = 0; i < 100; i++)
                {
                    list.Add(new Order
                    {
                        OrderId = Guid.NewGuid(),
                        TotalQuantity = i,
                        TotalAmount = 10000 + i,
                        ReceivedAmount = 10000 + i,
                        OrderDatetime = DeadlineDatetime.Date,
                        IsDeadline = true,
                        DeadlineDatetime = DeadlineDatetime.Date
                    });
                }
                CurrentOrders = list;
            }
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OnLogout()
        {
            MessageBoxResult result = MessageBox.Show("로그아웃 하시겠습니까?", "확인", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            LogoutManager();
        }
        /// <summary>
        /// 마감
        /// </summary>
        private void OnMakeDeadline()
        {
            //모든 데이터가 마감되어 있으면 더이상 마감하지 않음
            if (CurrentOrders.All(o => o.IsDeadline))
            {
                _ = MessageBox.Show("모든 주문이 마감처리되어 있습니다.");
                return;
            }

            MessageBoxResult result = MessageBox.Show("마감처리 하시겠습니까?", "확인", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            foreach (Order order in CurrentOrders)
            {
                order.IsDeadline = true;
                order.DeadlineDatetime = DateTime.Now;
            }
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            DeadlineDatetime = DateTime.Now;
            await OnSearchAsync();
        }
    }
}
