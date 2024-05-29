using ProjectManagementSystem.DataBase;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementSystem
{
    public partial class CardEditorWindow : Window
    {
        public int IDUser { get; set; } = 2;

        private int _IDEmploye;

        ProjectManagementDataBase dataBase = new ProjectManagementDataBase();
        public CardEditorWindow()
        {
            InitializeComponent();
            CardsLoad();
            UsersLoad();
        }

        public void CardsLoad()
        {
            ProjectsGrid.ItemsSource = dataBase.Card.ToList();
        }

        public void UsersLoad()
        {
            UsersGrid.ItemsSource = dataBase.Users.Where(p => p.idRole == 3).ToList();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card card = new Card()
                {
                    idUser = IDUser,
                    ThemeProject = YourThemeProject.Text,
                    TaskForEmployee = YourTaskForProject.Text,
                    idEmployee = int.Parse(idYourEmployee.Text)
                };
                dataBase.Card.Add(card);
                dataBase.SaveChanges();
                MessageBox.Show("Карточка проекта успешно длбавлена!");
                CardsLoad();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении :(");
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var delete = ProjectsGrid.SelectedItem as Card;
                dataBase.Card.Remove(delete);
                dataBase.SaveChanges();
                CardsLoad();
                MessageBox.Show("Карточка успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при удалении :(");
            }
        }

        private void UpdateProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var update = ProjectsGrid.SelectedItem as Card;
                update.ThemeProject = YourThemeProject.Text;
                update.TaskForEmployee = YourTaskForProject.Text;
                update.idEmployee = int.Parse(idYourEmployee.Text);
                dataBase.Card.AddOrUpdate(update);
                dataBase.SaveChanges();
                CardsLoad();
                MessageBox.Show("Карточка успешно обновлена!");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при обновлении :(");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            mainMenu.Show();
            this.Hide();
        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users users = UsersGrid.SelectedItem as Users;
            _IDEmploye = users.idUser;
            idYourEmployee.Text = _IDEmploye.ToString();
        }

        private void ProjectsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Card select = ProjectsGrid.SelectedItem as Card;
                YourThemeProject.Text = select.ThemeProject;
                YourTaskForProject.Text = select.TaskForEmployee;
                idYourEmployee.Text = select.idEmployee.ToString();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
    }
}
