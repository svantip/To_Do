using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace To_Do
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private readonly dbAppContext _context = new dbAppContext();
        private CollectionViewSource taskViewSource;
        public Add()
        {
            InitializeComponent();
            taskViewSource = (CollectionViewSource)FindResource(nameof(taskViewSource));
        }

        private void chkBoxCostumCategory_Checked(object sender, RoutedEventArgs e)
        {
            if (chkBoxCostumCategory.IsChecked == true)
            {
                cmbBoxCategory.IsEnabled = false;
                txtBoxTaskCategory.IsEnabled = true;
            }
        }

        private void chkBoxCostumCategory_Unchecked(object sender, RoutedEventArgs e)
        {

            if (chkBoxCostumCategory.IsChecked == false)
            {
                cmbBoxCategory.IsEnabled = true;
                txtBoxTaskCategory.IsEnabled = false;
            }

        }

        private void btnAddAdd_Click(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            if (txtBoxTaskName.Text == "" || txtBoxTaskDescription.Text == "" )
            {
                MessageBox.Show("Fields can't be left empty!");
            }
            else
            {
                
                if((chkBoxCostumCategory.IsChecked == true && cmbBoxCategory.IsEnabled == false) || (chkBoxCostumCategory.IsChecked == false && cmbBoxCategory.IsEnabled == true))
                {
                    string taskCategory;
                    string taskName = txtBoxTaskName.Text;
                    if (chkBoxCostumCategory.IsChecked == true)
                    {
                        taskCategory = txtBoxTaskCategory.Text;
                    }
                    else
                    {
                        taskCategory = cmbBoxCategory.Text;
                    }
                    string taskDescription = txtBoxTaskDescription.Text;
                    _context.Add(new Task { taskName = taskName, taskDescription = taskDescription, taskCategory = taskCategory });
                    _context.SaveChanges();
                    
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Fields can't be left empty!");
                }
            }
        }
    }
}
