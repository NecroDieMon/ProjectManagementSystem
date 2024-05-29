using System.Windows;

namespace ProjectManagementSystem
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            OpenAdminWindow.Visibility = Visibility.Hidden;
            WatchAndEditCard.Visibility = Visibility.Hidden;
        }

        private void WatchAndEditTasks_Click(object sender, RoutedEventArgs e)
        {
            TasksEditorWindow tasksEditor = new TasksEditorWindow();
            tasksEditor.Show();
            this.Close();
        }

        private void WatchAndEditCard_Click(object sender, RoutedEventArgs e)
        {
            CardEditorWindow cardEditor = new CardEditorWindow();
            cardEditor.Show();
            this.Close();
        }

        private void OpenAdminWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}
