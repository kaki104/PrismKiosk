using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.Commons
{
    /// <summary>
    /// 키오스크 상태
    /// </summary>
    public enum StatusEnum
    {
        /// <summary>
        /// 인트로
        /// </summary>
        KioskIntro,
        /// <summary>
        /// 주문 구분(시작)
        /// </summary>
        OrderStart,
        /// <summary>
        /// 메뉴 선택
        /// </summary>
        SelectMenu,
        /// <summary>
        /// 결제
        /// </summary>
        Payment
    }
}
