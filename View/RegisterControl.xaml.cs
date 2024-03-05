using BahiKitab.Model;
using BahiKitab.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace BahiKitab.View
{
    /// <summary>
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {

        public RegisterControl()
        {
            InitializeComponent();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UserModel.Instance.Password = Password.Password;
        }
    }
}
