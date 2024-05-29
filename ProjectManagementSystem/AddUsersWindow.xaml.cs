using ProjectManagementSystem.DataBase;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementSystem
{
    public partial class AddUsersWindow : Window
    {
        private int _indexRole;
        public AddUsersWindow()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            ProjectManagementDataBase dataBase = new ProjectManagementDataBase();

            try
            {
                Users users = new Users()
                {
                    idRole = _indexRole,
                    Login = UserName.Text,
                    Password = PasswordUser.Text
                };
                dataBase.Users.Add(users);
                dataBase.SaveChanges();
                MessageBox.Show("Пользователь добавлен!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Hide();
        }

        private void RolesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _indexRole = RolesBox.SelectedIndex + 1;
        }
    }
}
