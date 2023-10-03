using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 메뉴 선택 뷰 모델
    /// </summary>
    public class SelectMenuViewModel : ViewModelBase
    {
        public SelectMenuViewModel()
        {
            
        }
        public SelectMenuViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
        }
    }
}
