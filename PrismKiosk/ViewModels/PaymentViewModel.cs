using Prism.Commands;
using Prism.Ioc;
using PrismKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 결제 뷰모델
    /// </summary>
    public class PaymentViewModel : ViewModelBase
    {
        /// <summary>
        /// 결제 완료 커맨드
        /// </summary>
        public ICommand CompleteCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public PaymentViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public PaymentViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }

        private void Init()
        {
            CompleteCommand = new DelegateCommand(OnComplete);
        }
        /// <summary>
        /// 결제 완료
        /// </summary>
        private void OnComplete()
        {
            //결제 완료 일시 입력
            AppContext.CurrentOrder.OrderDatetime = DateTime.Now;
            //결제 완료 목록에 추가
            AppContext.Orders.Add(AppContext.CurrentOrder);
            AppContext.CurrentOrder = null;
            //처음 화면으로 이동
            ClearAppContextAndGoHome();
        }
    }
}
