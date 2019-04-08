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
using System.Data;
using System.Data.SqlClient;

namespace кп
{
    /// <summary>
    /// Логика взаимодействия для add_meal.xaml
    /// </summary>
    public partial class add_meal : UserControl
    {
        static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";

        public string user_name;
        public add_meal(string k)
        {
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            string count = " select COUNT(RECIPE_NAME) from RECIPE_INFO";
            SqlCommand sq = new SqlCommand(count, con);
            object v = sq.ExecuteScalar();
            int counter = Convert.ToInt16(v.ToString());
            user_name = k;
            InitializeComponent();
            string g = "select RECIPE_NAME FROM RECIPE_INFO";
            SqlCommand command = new SqlCommand(g, con);
            SqlDataReader dataReader = command.ExecuteReader();
            List<String> bluda = new List<String>();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            for(int i = 0; i < counter; i++)
            {
                DataRow dr = dt.Rows[i];
                String names = dr.Field<String>("RECIPE_NAME");
                bluda.Add(names);
                list_rec.Items.Add(bluda[i]);
            }
            string count_prod = " select COUNT(НАЗВАНИЕ) from Products";
            SqlCommand c = new SqlCommand(count_prod, con);
            object ch = c.ExecuteScalar();
            int n_prod = Convert.ToInt16(ch.ToString());
            string l = "select НАЗВАНИЕ FROM Products";
            SqlCommand sqlcom = new SqlCommand(l, con);
            SqlDataReader dataread = sqlcom.ExecuteReader();
            List<String> product = new List<String>();
            DataTable dat = new DataTable();
            dat.Load(dataread);
            for(int i = 0; i <n_prod; i++)
            {
                DataRow drows = dat.Rows[i];
                String names = drows.Field<String>("НАЗВАНИЕ");
                product.Add(names);
                list_ofproducts.Items.Add(product[i]);
            }
        }

        private void addmeal_Click(object sender, RoutedEventArgs e)
        {

            string rec = list_rec.SelectedItem.ToString();
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                bool flag = true;
              
                foreach (char ch in weight_meal.Text)
                {
                    if (!((int)ch >= 49 && (int)ch <= 57))
                        flag = false;
                }
                if (flag == false)
                {
                   MessageBox.Show("Данные неверного формата");
                    weight_meal.Text = "";
                }
                else {
                    DateTime date = DateTime.Today;
                    string sqlformatter = date.ToString("yyyy-MM-dd");
                    string select = "Select CALORICITY_RECIPE from RECIPE_INFO WHERE RECIPE_NAME=@rec";
                    SqlCommand com = new SqlCommand(select, connection);
                    com.Parameters.Add("@rec", SqlDbType.NVarChar).Value = rec;
                    SqlDataReader reader = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    DataRow row = dt.Rows[0];
                    Double calor = row.Field<Double>("CALORICITY_RECIPE");
                    com.ExecuteNonQuery();
                    string n = this.user_name;
                    string INSERT = "INSERT into" +
                        " Трекерпитания_рецепты(NAME_USER, data_entry,RECIPE_NAME, " +
                        "weight_rec,caloricity_recipe) values(N'" + n + "','" + sqlformatter + "', N'" + rec + "'," + weight_meal.Text + "," + calor + ")";
                    SqlCommand sql = new SqlCommand(INSERT, connection);
                    sql.ExecuteNonQuery();
                }
               
            }
            else MessageBox.Show("что-то пошло не так, попробуйте ещё ");
        }

        private void add_prod_meal_Click(object sender, RoutedEventArgs e)
        {

            string prod = list_ofproducts.SelectedItem.ToString();
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                bool flag = true;

                foreach (char ch in weight_meal.Text)
                {
                    if (!((int)ch >= 49 && (int)ch <= 57))
                        flag = false;
                }
                if (flag == false)
                {
                    MessageBox.Show("Данные неверного формата");
                    weight_meal.Text = "";
                }
                else
                {
                    DateTime date = DateTime.Today;
                    string sqlformatter = date.ToString("yyyy-MM-dd");
                    string select = "Select КАЛОРИЙНОСТЬ from Products WHERE НАЗВАНИЕ=@prod";
                    SqlCommand com = new SqlCommand(select, connection);
                    com.Parameters.Add("@prod", SqlDbType.NVarChar).Value = prod;
                    SqlDataReader reader = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    DataRow row = dt.Rows[0];
                    int calor = row.Field<int>("КАЛОРИЙНОСТЬ");
                    com.ExecuteNonQuery();
                    string n = this.user_name;
                    string INSERT = "INSERT into" +
                    " Трекерпитания_продукты(NAME_USER, data_entry,product, " +
                    "weight_prod,caloricity_prod) values(N'" + n + "','" + sqlformatter + "', N'" + prod + "'," + weight_prod.Text + "," + calor + ")";
                    SqlCommand sql = new SqlCommand(INSERT, connection);
                    sql.ExecuteNonQuery();
                }
            }
            else MessageBox.Show("не удалось внести данные");
        }
    }
}
