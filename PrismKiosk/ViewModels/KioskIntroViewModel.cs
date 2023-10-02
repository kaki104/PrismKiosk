using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 키오스크 인트로 뷰모델
    /// </summary>
    public class KioskIntroViewModel : ViewModelBase
    {
        public KioskIntroViewModel()
        {
            
        }
        public KioskIntroViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
        }
    }
}
