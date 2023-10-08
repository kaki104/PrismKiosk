﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.Models
{
    /// <summary>
    /// 주문
    /// </summary>
    public class Order : BindableBase
    {
        /// <summary>
        /// 주문 아이디
        /// </summary>
        public Guid OrderId { get; set; }
        private int _totalQuantity;
        /// <summary>
        /// 총 수량
        /// </summary>
        public int TotalQuantity
        {
            get { return _totalQuantity; }
            set { SetProperty(ref _totalQuantity, value); }
        }
        private int _totalAmount;
        /// <summary>
        /// 총 금액
        /// </summary>
        public int TotalAmount
        {
            get { return _totalAmount; }
            set { SetProperty(ref _totalAmount, value, () => RaisePropertyChanged(nameof(Change))); }
        }
        private int _receivedAmount;
        /// <summary>
        /// 받은 금액
        /// </summary>
        public int ReceivedAmount
        {
            get { return _receivedAmount; }
            set { SetProperty(ref _receivedAmount, value, () => RaisePropertyChanged(nameof(Change))); }
        }
        /// <summary>
        /// 거스름돈
        /// </summary>
        public int Change
        {
            get { return ReceivedAmount - TotalAmount < 0 ? 0 : ReceivedAmount - TotalAmount; }
        }
        /// <summary>
        /// 아이템들
        /// </summary>
        public IList<OrderDetail> Items { get; set; } = new ObservableCollection<OrderDetail>();
        /// <summary>
        /// 프로퍼티 업데이트
        /// </summary>
        public void UpdateProperties()
        {
            TotalQuantity = Items.Sum(x => x.Quantity);
            TotalAmount = Items.Sum(x => x.Amount);
        }
    }
}
