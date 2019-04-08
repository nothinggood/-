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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";
        public login()
        {
            InitializeComponent();
        }

        private void log_in_account_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Today;
            string sqlformatter = date.ToString("yyyy-MM-dd");
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string k = log.Text;
                string p = password.Password;
                string ins = "select Id from USERS where  LOGIN=@k and PASSWORD=@p ";//, PASSWORD=@p; " ; //+ log.Text + "', PASSWORD='" + password.Password +"'";
                SqlCommand com = new SqlCommand(ins, connection);
                com.Parameters.Add("@p", SqlDbType.NVarChar).Value = p;
                com.Parameters.Add("@k", SqlDbType.NVarChar).Value = k;
                object res = com.ExecuteScalar();
                com.ExecuteNonQuery();
                string select = "select NAME_US from USERS where  LOGIN=@k and PASSWORD=@p ";
                SqlCommand command = new SqlCommand(select, connection);
                command.Parameters.Add("@p", SqlDbType.NVarChar).Value = p;
                command.Parameters.Add("@k", SqlDbType.NVarChar).Value = k;
                object sel = command.ExecuteScalar();
                command.ExecuteNonQuery();
                if (res!=null)
                    try {
                        if (res.ToString() == "1")
                        {
                            Admin_log adm = new Admin_log();
                            adm.Show();
                            this.Close();
                        }
                        if (res.ToString() != "1")
                        {
                            User_log us = new User_log(sel.ToString());
                            us.Show();
                            this.Close();
                        }
                    }
                    
                    catch {
                        log.Text = "";
                        password.Password = "";
                        MessageBox.Show("Все поля должны быть заполнены!");
                    }
                else MessageBox.Show("такого пользователя не существует");
            }
            else MessageBox.Show("Попробуйте ещё раз");
            }
        }
    }

