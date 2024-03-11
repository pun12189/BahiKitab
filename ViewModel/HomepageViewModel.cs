using BahiKitab.Command;
using BahiKitab.Helper;
using BahiKitab.Model;
using BahiKitab.RenderView;
using MahApps.Metro.IconPacks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MenuItem = BahiKitab.Model.MenuItem;

namespace BahiKitab.ViewModel
{
    class HomepageViewModel : INotifyPropertyChanged
    {
        #region Properties
        public Action CloseAction { get; set; }

        private Window window;

        public ICommand LogoutCommand { get; set; }

        private string _welcomeText;

        public string WelcomeText
        {
            get { return _welcomeText; }
            set
            {
                if (_welcomeText == value) return;
                _welcomeText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WelcomeText"));
            }
        }

        public ObservableCollection<MenuItem> Menu { get; }

        public ObservableCollection<MenuItem> OptionsMenu { get; }
        #endregion

        #region Constructor
        public HomepageViewModel(Window window)
        {
            this.window = window;
            LogoutCommand = new RelayCommand(LogoutCommandExecute);
            WelcomeText = UserModel.Instance.Email;
            this.Menu = new ObservableCollection<MenuItem>();
            this.OptionsMenu = new ObservableCollection<MenuItem>();

            // Build the menus
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserCircleRegular },
                Label = "Admin",
                NavigationType = typeof(AdminView),
                NavigationDestination = new Uri("RenderView/AdminView.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FileInvoiceSolid },
                Label = "Invoice",
                NavigationType = typeof(AdminView),
                NavigationDestination = new Uri("RenderView/AdminView.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CoffeeSolid },
                Label = "Inventory",
                NavigationType = typeof(InventoryView),
                NavigationDestination = new Uri("RenderView/InventoryView.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FontAwesomeBrands },
                Label = "Purchase",
                NavigationType = typeof(AdminView),
                NavigationDestination = new Uri("RenderView/AdminView.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FontAwesomeBrands },
                Label = "Procurement",
                NavigationType = typeof(AdminView),
                NavigationDestination = new Uri("RenderView/AdminView.xaml", UriKind.RelativeOrAbsolute)
            });

            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogSolid },
                Label = "Settings",
                NavigationType = typeof(AdminView),
                NavigationDestination = new Uri("RenderView/SettingsPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircleSolid },

                Label = "About",
                NavigationType = typeof(AdminView),
                NavigationDestination = new Uri("RenderView/AdminView.xaml", UriKind.RelativeOrAbsolute)
            });

            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.PowerOffSolid },
                Label = "LogOut",
                Command = LogoutCommand
            });
        }
        #endregion

        #region Private Methods
        private void LogoutCommandExecute()
        {
            var dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                var loginViewModel = new LoginViewModel(window);
                WindowManager.ChangeWindowContent(window, loginViewModel, Resources.LoginWindowTitle, Resources.LoginControlPath);
            }
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
