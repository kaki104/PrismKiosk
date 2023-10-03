using Prism.Mvvm;
using PrismKiosk.Commons;
using System;

namespace PrismKiosk.Models
{
    /// <summary>
    /// 상품
    /// </summary>
    public class Product : BindableBase
    {
        /// <summary>
        /// 상품 카테고리
        /// </summary>
        public ProductCategory Category { get; set; }
        private string _name;
        /// <summary>
        /// 상품명
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private int _price;
        /// <summary>
        /// 단가
        /// </summary>
        public int Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
        private Uri _imageUri;
        /// <summary>
        /// 이미지
        /// </summary>
        public Uri ImageUri
        {
            get { return _imageUri; }
            set { SetProperty(ref _imageUri, value); }
        }
    }
}
