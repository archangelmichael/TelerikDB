using System.Windows;

namespace WPFMongoChat
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
            SendButton.Visibility = Visibility.Hidden;
            //var db = new MongoClient(Connections.Default.MongoCloud).GetServer().GetDatabase("mongochat");
            //var messages = db.GetCollection<BsonDocument>("Messages");

            

            //while (true)
            //{
            //    Console.Write("> ");
            //    string input = Console.ReadLine();

            //    if (!string.IsNullOrWhiteSpace(input))
            //        messages.Insert(
            //            new BsonDocument { { "Author", username }, { "Text", input }, { "Time", DateTime.Now } });

            //    var formattedMessages = messages
            //        .FindAll()
            //        .Select(m => string.Format("[{0}] {1}: {2}", m["Time"].ToLocalTime(), m["Author"], m["Text"]));

            //    Console.WriteLine(string.Join(Environment.NewLine, formattedMessages));
            //}
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string input =  UsernameInput.Text;
            if (!string.IsNullOrEmpty(input))
            {
                username = input;
                ShowUser.Text = username;
                UsernameInput.Visibility = Visibility.Hidden;
                LogInButton.Visibility = Visibility.Hidden;
                LogOutButton.Visibility = Visibility.Visible;
                SendButton.Visibility = Visibility.Visible;
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
