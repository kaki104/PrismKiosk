using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using PrismKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 메뉴 선택 뷰 모델
    /// </summary>
    public class SelectMenuViewModel : ViewModelBase
    {
        private IList<Product> _coffees;
        /// <summary>
        /// 커피 목록
        /// </summary>
        public IList<Product> Coffees
        {
            get { return _coffees; }
            set { SetProperty(ref _coffees, value); }
        }
        private IList<Product> _frappuccinos;
        /// <summary>
        /// 프라프치노 목록
        /// </summary>
        public IList<Product> Frappuccinos
        {
            get { return _frappuccinos; }
            set { SetProperty(ref _frappuccinos, value); }
        }
        /// <summary>
        /// 메뉴 선택 커맨드
        /// </summary>
        public ICommand SelectProductCommand { get; set; }
        /// <summary>
        /// 결제 커맨드
        /// </summary>
        public ICommand PaymentCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public SelectMenuViewModel()
        {
            Coffees = new List<Product>
            {
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "아이스 아메리카노", Price = 1500 },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "아메리카노", Price = 1500 },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "아이스 바닐라 라떼", Price = 3500 },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "바닐라 라떼", Price = 3500 },
            };
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public SelectMenuViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }

        private void Init()
        {
            Coffees = new List<Product>
            {
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "아이스 아메리카노", Price = 1500, ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg") },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "아메리카노", Price = 1500, ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg") },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "아이스 바닐라 라떼", Price = 3500, ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg") },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "바닐라 라떼", Price = 3500, ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg") },
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "페이지2-1", Price = 1500 , ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg")},
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "페이지2-2", Price = 1500 , ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg")},
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "페이지2-3", Price = 3500 , ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg")},
                new Product{ Category = Commons.ProductCategory.Coffee, Name = "페이지2-4", Price = 3500 , ImageUri = new Uri("pack://application:,,,/Assets/Images/delicious-ice-cream-in-studio.jpg")},
            };
            SelectProductCommand = new DelegateCommand<Product>(OnSelectProduct);
            PaymentCommand = new DelegateCommand(OnPayment);
        }
        /// <summary>
        /// 결제 완료 화면으로 이동
        /// </summary>
        private void OnPayment()
        {
            RegionManager.RequestNavigate("KioskContentRegion", "Payment");
        }

        private void OnSelectProduct(Product product)
        {
            AppContext.CurrentOrder.Items.Insert(0, 
                new OrderDetail 
                {
                    OrderId = AppContext.CurrentOrder.OrderId,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = 1,
                    Amount = product.Price * 1
                });
            AppContext.CurrentOrder.UpdateProperties();
        }
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //클리어할 것 있으면 함
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            AppContext.KioskStatus = Commons.StatusEnum.SelectMenu;
            AppContext.CurrentOrder = new Order();
            AppContext.CurrentOrder.OrderId = Guid.NewGuid();
        }
    }
}
