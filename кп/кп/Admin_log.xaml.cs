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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace кп
{
    /// <summary>
    /// Логика взаимодействия для Admin_log.xaml
    /// </summary>

    public partial class Admin_log : Window
    {

        public Admin_log() 
        {

            InitializeComponent();
            
        }

        private void add_prod_Click(object sender, RoutedEventArgs e)
        {

                grid.Children.Clear();
                grid.Children.Add(menu);
                кп.Add_productUC add_Product = new кп.Add_productUC();
                grid.Children.Add(add_Product);

        }


        private void recipes_Click(object sender, RoutedEventArgs e)
        {
                grid.Children.Clear();
                grid.Children.Add(menu);
                кп.UsersUC recipes = new кп.UsersUC();
                grid.Children.Add(recipes);

        }

        private void edit_users_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            grid.Children.Add(menu);
            UsersInfo usersInfo = new UsersInfo();
            grid.Children.Add(usersInfo);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            this.Close();
            log.Show();

        }
        }

    }

