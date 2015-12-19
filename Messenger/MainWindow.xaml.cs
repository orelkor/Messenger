using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using Messenger.Views;
using Messenger.Core.Concrete;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            AuthBrowser.Navigate(Authorization.url);            
        }

        private void AuthBrowser_LoadedCompleted(object sender, NavigationEventArgs e)
        {
            string url = AuthBrowser.Source.ToString();
            string l = url.Split('#')[1];
            if (l[0] == 'a')
            {
                Authorization.token = l.Split('&')[0].Split('=')[1];
                Authorization.id = l.Split('=')[3];
                Authorization.IsAuthorized = true;
            }

            if (Authorization.IsAuthorized == true)
            {
                ClientView clientView = new ClientView();
                Hide();
                clientView.Show();
               
            }
        }
    }
}
