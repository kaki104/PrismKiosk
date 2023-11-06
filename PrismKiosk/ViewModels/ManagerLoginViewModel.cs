using Prism.Commands;
using Prism.Ioc;
using System.Windows;
using System.Windows.Input;

namespace PrismKiosk.ViewModels
{
    /// <summary>
    /// 관리자 로그인 뷰모델
    /// </summary>
    public class ManagerLoginViewModel : ViewModelBase
    {
        private string _id;
        /// <summary>
        /// 로그인 아이디
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _password;
        /// <summary>
        /// 비밀번호 - 비밀번호를 문자열로 가지고 있는 것은 좋은 방법은 아닙니다.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        /// <summary>
        /// 로그인 커맨드
        /// </summary>
        public ICommand LoginCommand { get; set; }

        public ManagerLoginViewModel()
        {
        }
        public ManagerLoginViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            Init();
        }

        private void Init()
        {
            LoginCommand = new DelegateCommand(OnLogin);
        }

        private void OnLogin()
        {
            if (Id.ToLower() != "admin" || Password != "p")
            {
                MessageBox.Show("아이디와 비밀번호를 확인하시기 바랍니다.");
                return;
            }
            AppContext.IsLogin = true;
            RegionManager.RequestNavigate("ManagerContentRegion", "Deadline");
        }
    }
}
