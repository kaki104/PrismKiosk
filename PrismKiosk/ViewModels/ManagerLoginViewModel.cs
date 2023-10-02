using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 관리자 로그인 뷰모델
    /// </summary>
    public class ManagerLoginViewModel : ViewModelBase
    {
        public ManagerLoginViewModel()
        {
        }
        public ManagerLoginViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
        }
    }
}
