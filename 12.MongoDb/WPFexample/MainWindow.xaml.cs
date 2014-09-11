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
using MongoDB.Bson;
using MongoDB;

namespace WPFexample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;

        public MainWindow()
        {
            InitializeComponent();
            LogOutButton.Visibility = Visibility.Hidden;
            UsernameShow.Visibility = Visibility.Hidden;
            SendMessageButton.Visibility = Visibility.Hidden;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string user = UsernameInput.Text;
            if (!string.IsNullOrEmpty(user) && user.Length > 4)
            {
                username = user;
                LogOutButton.Visibility = Visibility.Visible;
                UsernameShow.Visibility = Visibility.Visible;
                UsernameShow.Text = username;
                SendMessageButton.Visibility = Visibility.Visible;
                LogInButton.Visibility = Visibility.Hidden;
                UsernameInput.Visibility = Visibility.Hidden;
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            username = string.Empty;
            SendMessageButton.Visibility = Visibility.Hidden;
            LogOutButton.Visibility = Visibility.Hidden;
            LogInButton.Visibility = Visibility.Visible;
            UsernameInput.Visibility = Visibility.Visible;
            UsernameShow.Visibility = Visibility.Hidden;
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = NewMessageInput.Text;
            var allMessages = MongoDatabaseProvider.SendMessage(username, message);
            var messages = allMessages
                .Select(m => string.Format("{0} [{1}] /n Message: {2} ", m.User, m.Date, m.Text));
            MessagesBox.ItemsSource = messages;
        }
    }
}
