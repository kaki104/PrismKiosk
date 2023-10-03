using PrismKiosk.Commons;

namespace PrismKiosk.Models
{
    /// <summary>
    /// AppContext 인터페이스
    /// </summary>
    public interface IAppContext
    {
        /// <summary>
        /// 장애인Ui여부
        /// </summary>
        bool IsDisabledUi { get; set; }
        /// <summary>
        /// 관리자 로그인 여부
        /// </summary>
        bool IsLogin { get; set; }
        /// <summary>
        /// 케이스 오픈 여부
        /// </summary>
        bool IsOpenCase { get; set; }
        /// <summary>
        /// 키오스크 상태
        /// </summary>
        StatusEnum KioskStatus { get; set; }
        /// <summary>
        /// 매장 이용 여부 false이면 포장
        /// </summary>
        bool IsEatIn { get; set; }
    }
}