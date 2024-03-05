using BahiKitab.Model;
using BahiKitab.ViewModel;
using MahApps.Metro.Controls;
using System.Windows;

namespace BahiKitab.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MetroWindow
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(this);
        }
    }
}
