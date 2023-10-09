using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 마감 뷰모델
    /// </summary>
    public class DeadlineViewModel : ViewModelBase
    {
        public DeadlineViewModel()
        {
        }

        public DeadlineViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
        }
    }
}
