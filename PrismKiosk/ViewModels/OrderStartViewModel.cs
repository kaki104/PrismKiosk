using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 주문 구분(시작) 뷰모델
    /// </summary>
    public class OrderStartViewModel : ViewModelBase
    {
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
        }
    }
}
