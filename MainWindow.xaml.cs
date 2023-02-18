using Microsoft.EntityFrameworkCore;
using SQLitePCL;
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


namespace To_Do
{
    public partial class MainWindow : Window
    {
        private readonly dbAppContext _context = new dbAppContext();
        private CollectionViewSource taskViewSource;
        private CollectionViewSource taskViewSourceWork; 
        private CollectionViewSource taskViewSourceHome;
        private CollectionViewSource taskViewSourceSchool;
        private CollectionViewSource taskViewSourceShopping;
        private CollectionViewSource taskViewSourceOther;
        public MainWindow()
        {
            InitializeComponent();
            taskViewSource = (CollectionViewSource)FindResource(nameof(taskViewSource));
            taskViewSourceWork = (CollectionViewSource)FindResource(nameof(taskViewSourceWork));
            taskViewSourceHome = (CollectionViewSource)FindResource(nameof(taskViewSourceHome));
            taskViewSourceSchool = (CollectionViewSource)FindResource(nameof(taskViewSourceSchool));
            taskViewSourceShopping = (CollectionViewSource)FindResource(nameof(taskViewSourceShopping));
            taskViewSourceOther = (CollectionViewSource)FindResource(nameof(taskViewSourceOther));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Task.Load();
            taskViewSource.Source = _context.Task.Local.ToObservableCollection();
            foreach (var item in _context.Task)
            {
                if(item.taskCategory == "Work")
                {
                    dataGridWork.Items.Add(item);
                }
                else if(item.taskCategory == "Home")
                {
                    dataGridHome.Items.Add(item);
                }
                else if(item.taskCategory == "School")
                {
                    dataGridSchool.Items.Add(item);
                }
                else if(item.taskCategory == "Shopping")
                {
                    dataGridShopping.Items.Add(item);
                }
                if(item.taskCategory != "Home" && item.taskCategory != "Work" && item.taskCategory != "School" && item.taskCategory != "Shopping")
                {
                    dataGridOther.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add a = new Add();
            a.ShowDialog();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Task task = (Task)dataGridAll.SelectedItem;
            _context.Remove(task);
            _context.SaveChanges();
        }

        private void _window_Activated(object sender, EventArgs e)
        {
            _context.Task.Load();
        }

        private void _window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
