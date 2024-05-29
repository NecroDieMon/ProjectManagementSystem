using ProjectManagementSystem.DataBase;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementSystem
{
    public partial class AllCardsEditorWindow : Window
    {
        ProjectManagementDataBase dataBase = new ProjectManagementDataBase();
        public AllCardsEditorWindow()
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
            UsersGrid.ItemsSource = dataBase.Users.ToList();
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
                update.idUser = int.Parse(idYourManager.Text);
                update.ThemeProject = YourThemeProject.Text;
                update.TaskForEmployee = TaskForProject.Text;
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
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Hide();
        }

        private void ProjectsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Card select = ProjectsGrid.SelectedItem as Card;
                YourThemeProject.Text = select.ThemeProject;
                TaskForProject.Text = select.TaskForEmployee;
                idYourManager.Text = select.idUser.ToString();
                idYourEmployee.Text = select.idEmployee.ToString();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card card = new Card()
                {
                    idUser = int.Parse(idYourManager.Text),
                    ThemeProject = YourThemeProject.Text,
                    TaskForEmployee = TaskForProject.Text,
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
    }
}
