﻿using PrismKiosk.Commons;
using System.Collections.Generic;

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
        /// <summary>
        /// 현재 진행 중인 주문
        /// </summary>
        Order CurrentOrder { get; set; }
        /// <summary>
        /// 결제 완료 된 주문 목록 - 일반적으로는 결제 완료 후 바로 database에 저장하고, 메모리에 들고 있지는 않음
        /// </summary>
        IList<Order> Orders { get; set; }
    }
}