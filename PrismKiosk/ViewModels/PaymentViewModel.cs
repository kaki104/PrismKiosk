using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 결제 뷰모델
    /// </summary>
    public class PaymentViewModel : ViewModelBase
    {
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
        }
    }
}
