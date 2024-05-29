using ProjectManagementSystem.DataBase;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementSystem
{
    public partial class TasksEditorWindow : Window
    {
        public int IDEmploye { get; set; }
        private int _IDStatus;

        public static TasksEditorWindow GetForm;

        ProjectManagementDataBase dataBase = new ProjectManagementDataBase();

        public TasksEditorWindow()
        {
            InitializeComponent();
            DataTasksLoad();
            DataStatusLoad();
            GetForm = this;
        }
        
        public void DataTasksLoad()
        {
              TasksGrid.ItemsSource = dataBase.Card.ToList();
        }

        public void DataStatusLoad()
        {
            StatusGrid.ItemsSource = dataBase.StatusProject.ToList();
        }

        private void UpdateStatusTask_Click(object sender, RoutedEventArgs e)
        {
            var update = TasksGrid.SelectedItem as Card;
            update.idStatus = Convert.ToInt32(_IDStatus);
            dataBase.Card.AddOrUpdate(update);
            dataBase.SaveChanges();
            DataTasksLoad();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            mainMenu.Show();
            this.Hide();
        }

        private void StatusGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatusProject status = StatusGrid.SelectedItem as StatusProject;
            _IDStatus = status.idStatus;
            IDStatusForTask.Text = _IDStatus.ToString();
        }
    }
}
