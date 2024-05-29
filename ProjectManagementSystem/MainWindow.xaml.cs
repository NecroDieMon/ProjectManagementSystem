using ProjectManagementSystem.DataBase;
using System.Linq;
using System.Windows;

namespace ProjectManagementSystem
{
    public partial class MainWindow : Window
    {
        MainMenuWindow mainMenu = new MainMenuWindow();
        ProjectManagementDataBase projectManagementDataBase = new ProjectManagementDataBase();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var reque = projectManagementDataBase.Users.Where(x => x.Login == YourLogin.Text && x.Password == YourPassword.Password).ToList();

            if (reque != null)
            {
                try
                {
                    if (reque[0].idRole == 1)
                    {
                        this.Close();
                        mainMenu.OpenAdminWindow.Visibility = Visibility.Visible;
                        mainMenu.WatchAndEditTasks.Visibility = Visibility.Hidden;
                        mainMenu.Show();
                    }
                    else if (reque[0].idRole == 2)
                    {
                        CardEditorWindow cardEditor = new CardEditorWindow();
                        cardEditor.IDUser = reque[0].idUser;
                        this.Close();
                        mainMenu.WatchAndEditCard.Visibility = Visibility.Visible;
                        mainMenu.WatchAndEditTasks.Visibility = Visibility.Hidden;
                        mainMenu.Show();
                    }
                    else if (reque[0].idRole == 3)
                    {
                        this.Close();
                        TasksEditorWindow tasksEditor = new TasksEditorWindow();
                        tasksEditor.IDEmploye = reque[0].idUser;
                        mainMenu.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Пользователь не найден!");
                }
            }
        }
    }
}
