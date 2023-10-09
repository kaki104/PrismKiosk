using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <summary>
        /// 마감 커맨드
        /// </summary>
        public ICommand MakeDeadlineCommand { get; set; }
        /// <summary>
        /// 로그아웃 커맨드
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        private DateTime _deadlineDatetime;
        /// <summary>
        /// 마감일
        /// </summary>
        public DateTime DeadlineDatetime
        {
            get { return _deadlineDatetime; }
            set { SetProperty(ref _deadlineDatetime, value); }
        }

        public DeadlineViewModel()
        {
        }

        public DeadlineViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }

        private void Init()
        {
            MakeDeadlineCommand = new DelegateCommand(OnMakeDeadline);
            LogoutCommand = new DelegateCommand(OnLogout);
        }
        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OnLogout()
        {
            var result = MessageBox.Show("로그아웃 하시겠습니까?", "확인", MessageBoxButton.YesNo);
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
            if(AppContext.Orders.All(o => o.IsDeadline))
            {
                MessageBox.Show("모든 주문이 마감처리되어 있습니다.");
                return;
            }

            var result = MessageBox.Show("마감처리 하시겠습니까?", "확인", MessageBoxButton.YesNo);
            if(result != MessageBoxResult.Yes)
            {
                return;
            }
            foreach(var order in AppContext.Orders)
            {
                order.IsDeadline = true;
                order.DeadlineDatetime = DateTime.Now;
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            DeadlineDatetime = DateTime.Now;
        }
    }
}
