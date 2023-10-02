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
    /// 뷰모델 베이스
    /// </summary>
    public abstract class ViewModelBase : BindableBase
    {
        /// <summary>
        /// 컨테이터 프로바이더
        /// </summary>
        protected IContainerProvider ContainerProvider;

        private bool _isBusy;
        /// <summary>
        /// IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public ViewModelBase()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public ViewModelBase(IContainerProvider containerProvider)
        {
            ContainerProvider = containerProvider;
        }
    }
}
