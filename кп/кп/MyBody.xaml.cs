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
using System.Data.SqlClient;
using System.Data;
using кп;
namespace кп
{
    /// <summary>
    /// Логика взаимодействия для MyBody.xaml
    /// </summary>
    public partial class MyBody : UserControl
    {
        static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";

        public string name_user;
        public MyBody(string z)
        {
            name_user = z;
            InitializeComponent();
        }
        
        private void save_weight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int l;
                DateTime date = DateTime.Today;
                string sqlformatter = date.ToString("yyyy-MM-dd");
                SqlConnection connection = new SqlConnection(strconnect);
                connection.Open();
                SqlCommand sql = new SqlCommand("select count(data_entry) from Трекервеса where data_entry=N'" + sqlformatter + "' and name_us=N'" + this.name_user + "' ", connection);
                l = Convert.ToInt16(sql.ExecuteScalar());
                bool flag = true;
                foreach (char ch in myweight.Text)
                {
                    if (!((int)ch >= 49 && (int)ch <= 57))
                        flag = false;
                }
                if (connection.State == System.Data.ConnectionState.Open && l == 0 && !flag)
                {
                    string k = myweight.Text;
                    string n = this.name_user;
                    string ins = "insert into Трекервеса(name_us, data_entry, weight_us) values (N'" + n.ToString() + "' , '" + sqlformatter + "'," + k + ")";
                    SqlCommand com = new SqlCommand(ins, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно внесены");
                }
                else
                {
                    MessageBox.Show("Внесенные данные имеют неверный формат");
                }
            }
            catch
            {
                MessageBox.Show("Данные уже внесены");
            }

         
        }
    }
}
