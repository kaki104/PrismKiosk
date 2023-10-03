using Prism.Mvvm;
using PrismKiosk.Commons;

namespace PrismKiosk.Models
{
    /// <summary>
    /// AppContext - 애플리케이션에서 전체적으로 유지하는 데이터 보관
    /// </summary>
    public class AppContext : BindableBase, IAppContext
    {
        /// <summary>
        /// 관리자 로그인 여부
        /// </summary>
        public bool IsLogin { get; set; }

        private bool _isOpenCase;
        /// <summary>
        /// 케이스 오픈 여부
        /// </summary>
        public bool IsOpenCase
        {
            get { return _isOpenCase; }
            set { SetProperty(ref _isOpenCase, value); }
        }
        private bool _isDisabledUi;
        /// <summary>
        /// 장애인 UI 여부
        /// </summary>
        public bool IsDisabledUi
        {
            get { return _isDisabledUi; }
            set { SetProperty(ref _isDisabledUi, value); }
        }
        private StatusEnum _kioskStatus;
        /// <summary>
        /// 키오스크 상태
        /// </summary>
        public StatusEnum KioskStatus
        {
            get { return _kioskStatus; }
            set { SetProperty(ref _kioskStatus, value); }
        }
        private bool _isEatIn;
        /// <summary>
        /// 매장 이용 여부 false이면 포장
        /// </summary>
        public bool IsEatIn
        {
            get { return _isEatIn; }
            set { SetProperty(ref _isEatIn, value); }
        }
    }
}
