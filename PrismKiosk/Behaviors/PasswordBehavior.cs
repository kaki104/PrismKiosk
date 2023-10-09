using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace PrismKiosk.Behaviors
{
    /// <summary>
    /// PasswordBox Behavior
    /// </summary>
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        private bool _isWork;

        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        private void AssociatedObject_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isWork)
            {
                return;
            }
            _isWork = true;
            BindingPassword = AssociatedObject.Password;
            _isWork = false;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
        }

        public string BindingPassword
        {
            get { return (string)GetValue(BindingPasswordProperty); }
            set { SetValue(BindingPasswordProperty, value); }
        }

        /// <summary>
        /// 바인딩 패스워드
        /// </summary>
        public static readonly DependencyProperty BindingPasswordProperty =
            DependencyProperty.Register(nameof(BindingPassword), typeof(string), typeof(PasswordBehavior), new PropertyMetadata(null));
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.Property.Name)
            {
                case nameof(BindingPassword):
                    if (_isWork)
                    {
                        return;
                    }
                    _isWork = true;
                    AssociatedObject.Password = BindingPassword;
                    _isWork = false;
                    break;
            }
            base.OnPropertyChanged(e);
        }
    }
}
