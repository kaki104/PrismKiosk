using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using PrismKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 메뉴 선택 뷰 모델
    /// </summary>
    public class SelectMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// 한 페이지에 노출할 상품 수
        /// </summary>
        private const int _pageSize = 4;

        private int _currentPage;
        /// <summary>
        /// 현재 페이지 인덱스
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set { SetProperty(ref _currentPage, value); }
        }

        /// <summary>
        /// 전체 페이지 수
        /// </summary>
        private int _totalPages;
        /// <summary>
        /// 전체 상품 목록
        /// </summary>
        private List<Product> _allCoffes;

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
        /// 이전 상품
        /// </summary>
        public ICommand PreviousCommand { get; set; }
        /// <summary>
        /// 다음 상품
        /// </summary>
        public ICommand NextCommand { get; set; }
        /// <summary>
        /// 상품 수량 추가
        /// </summary>
        public ICommand AddCommand { get; set; }
        /// <summary>
        /// 상품 수량 제거
        /// </summary>
        public ICommand RemoveCommand { get; set; }
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
            _allCoffes = new List<Product>
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
            PreviousCommand = new DelegateCommand(OnPrevious, () => CurrentPage > 0)
                                .ObservesProperty(() => CurrentPage);
            NextCommand = new DelegateCommand(OnNext, () => CurrentPage < _totalPages)
                                .ObservesProperty(() => CurrentPage);
            AddCommand = new DelegateCommand<OrderDetail>(OnAdd);
            RemoveCommand = new DelegateCommand<OrderDetail>(OnRemove);
            //전체 페이지
            _totalPages = _allCoffes.Count / _pageSize - 1;
            DisplayProducts(CurrentPage);
        }
        /// <summary>
        /// 상품 삭제
        /// </summary>
        /// <param name="orderDetail"></param>
        private void OnRemove(OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return;
            }
            orderDetail.Quantity--;
        }
        /// <summary>
        /// 상품 추가
        /// </summary>
        /// <param name="orderDetail"></param>
        private void OnAdd(OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return;
            }
            orderDetail.Quantity++;
        }

        /// <summary>
        /// 상품 목록 출력
        /// </summary>
        /// <param name="pageIndex"></param>
        private void DisplayProducts(int pageIndex)
        {
            CurrentPage = pageIndex;
            Coffees = _allCoffes.Skip(CurrentPage * _pageSize).Take(_pageSize).ToList();
        }
        /// <summary>
        /// 다음 페이지 상품 목록 조회
        /// </summary>
        private void OnNext()
        {
            if (CurrentPage < _totalPages)
            {
                DisplayProducts(CurrentPage + 1);
            }
        }
        /// <summary>
        /// 이전 페이지 상품 목록 조회
        /// </summary>
        private void OnPrevious()
        {
            if (CurrentPage > 0)
            {
                DisplayProducts(CurrentPage - 1);
            }
        }

        /// <summary>
        /// 결제 완료 화면으로 이동
        /// </summary>
        private void OnPayment()
        {
            RegionManager.RequestNavigate("KioskContentRegion", "Payment");
        }
        /// <summary>
        /// 상품 선택
        /// </summary>
        /// <param name="product"></param>
        private void OnSelectProduct(Product product)
        {
            //이미 등록된 상품이라면 수량을 +1함
            var existItem = AppContext.CurrentOrder.Items.FirstOrDefault(od => od.ProductName == product.Name);
            if (existItem != null)
            {
                //추가
                existItem.Quantity++;
            }
            else
            {
                //신규
                AppContext.CurrentOrder.Items.Insert(0,
                    new OrderDetail
                    {
                        OrderId = AppContext.CurrentOrder.OrderId,
                        ProductName = product.Name,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
            }
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
