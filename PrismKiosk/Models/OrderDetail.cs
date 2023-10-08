using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismKiosk.Models
{
    /// <summary>
    /// 주문 상세
    /// </summary>
    public class OrderDetail : BindableBase
    {
        /// <summary>
        /// 오더 아이디
        /// </summary>
        public Guid OrderId { get; set; }
        private int _sortOrder;
        /// <summary>
        /// 순서
        /// </summary>
        public int SortOrder
        {
            get { return _sortOrder; }
            set { SetProperty(ref _sortOrder, value); }
        }
        private string _productName;
        /// <summary>
        /// 상품명
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }
        private int _unitPrice;
        /// <summary>
        /// 단가
        /// </summary>
        public int UnitPrice
        {
            get { return _unitPrice; }
            set { SetProperty(ref _unitPrice, value, () => RaisePropertyChanged(nameof(Amount))); }
        }
        private int _quantity;
        /// <summary>
        /// 수량
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value, () => RaisePropertyChanged(nameof(Amount))); }
        }
        /// <summary>
        /// 금액
        /// </summary>
        public int Amount
        {
            get { return Quantity * UnitPrice; }
        }

    }
}
