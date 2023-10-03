using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 뷰모델 베이스, 바인드어블베이스, 네이게이션어웨어
    /// </summary>
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        /// <summary>
        /// 컨테이터 프로바이더
        /// </summary>
        protected IContainerProvider ContainerProvider;
        /// <summary>
        /// 리즌 메니저
        /// </summary>
        protected IRegionManager RegionManager;

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
            RegionManager = ContainerProvider.Resolve<IRegionManager>();
        }
        /// <summary>
        /// 네비게이션 되었을 때
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        /// <summary>
        /// 네비게이션이 가능한지
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 네비게이션 되기 전에
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

    }
}
