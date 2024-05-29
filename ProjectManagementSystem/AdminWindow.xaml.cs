using System.Windows;

namespace ProjectManagementSystem
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void OpenAddUsersWindow_Click(object sender, RoutedEventArgs e)
        {
            AddUsersWindow addUsers = new AddUsersWindow();
            addUsers.Show();
            this.Hide();
        }

        private void OpenEditorAllCardsWindow_Click(object sender, RoutedEventArgs e)
        {
            AllCardsEditorWindow allCardsEditor = new AllCardsEditorWindow();
            allCardsEditor.Show();
            this.Hide();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            mainMenu.Show();
            this.Hide();
        }
    }
}
