using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

namespace кп
{
    /// <summary>
    /// Логика взаимодействия для addrecipe.xaml
    /// </summary>
    public partial class addrecipe : UserControl
    {
        static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";
        public string NAME;
        public addrecipe(string K)
        {
            NAME = K;
            InitializeComponent();
            List<string> types = new List<string>();

            types.Add("Каши");
            types.Add("Безалкогольные напитки");
            types.Add("Мясо,птица");
            types.Add("Алкоголь");
            types.Add("Фрукты и ягоды");
            types.Add("Хлебобулочные изделия, мука");
            types.Add("Сладости");
            types.Add("Рыба");
            types.Add("Овощи");
            types.Add("Молочные продукты");
            types.Add("Жиры");
            types.Add("Яйца");
            for (int i = 0; i < types.Count; i++)
            {
                type_prod.Items.Add(types[i]);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ingred_list.Items.Clear();
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlCommand com = new SqlCommand("select Count(НАЗВАНИЕ)FROM Products where ТИП= N'" + type_prod.SelectedItem.ToString() + "'",connection);
            SqlCommand sqlCommand = new SqlCommand("select НАЗВАНИЕ FROM Products where ТИП= N'" + type_prod.SelectedItem.ToString() + "'", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<string> users = new List<string>();
            DataTable dt = new DataTable();
            dt.Load(reader);
            for (int i = 0; i < Convert.ToInt16(com.ExecuteScalar()); i++)
            {
                DataRow row = dt.Rows[i];
                ingred_list.Items.Add(row.Field<string>("НАЗВАНИЕ"));
            }
        }

        private void add_ingred_Click(object sender, RoutedEventArgs e)
        {
            create_recipe.IsEnabled = false;
            try
            {
                string ingr = ingred_list.SelectedItem.ToString();
                string type = type_prod.SelectedItem.ToString();
                double weight = Convert.ToDouble(weight_ingr.Text);
                SqlConnection con = new SqlConnection(strconnect);
                con.Open();
                SqlCommand sql = new SqlCommand("select КАЛОРИЙНОСТЬ, БЕЛКИ,ЖИРЫ, УГЛЕВОДЫ FROM Products where НАЗВАНИЕ=N'" + ingr + "'", con);
                SqlDataReader sqlDataReader = sql.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(sqlDataReader);
                DataRow row = data.Rows[0];
                double ingr_calor = (row.Field<int>("КАЛОРИЙНОСТЬ")) * weight / 100;
                double ingr_bel = (row.Field<double>("БЕЛКИ")) * weight / 100;
                double ingr_fat = (row.Field<double>("ЖИРЫ")) * weight / 100;
                double ingr_ugl = (row.Field<double>("УГЛЕВОДЫ")) * weight / 100;
                SqlCommand command = new SqlCommand("INSERT INTO RECIPES VALUES(N'" + NAME + "',N'" + rec_name.Text + "'," +
                    "N'" + ingr + "'," + Convert.ToDouble(weight).ToString("0.0", CultureInfo.InvariantCulture) + "," + Convert.ToDouble(ingr_calor).ToString("0.0", CultureInfo.InvariantCulture) + "," + Convert.ToDouble(ingr_fat).ToString("0.0", CultureInfo.InvariantCulture) + "," + Convert.ToDouble(ingr_bel).ToString("0.0", CultureInfo.InvariantCulture) + "," + Convert.ToDouble(ingr_ugl).ToString("0.0", CultureInfo.InvariantCulture) + ")", con);
                command.ExecuteNonQuery();
                create_recipe.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Ингредиент не добавлен, нужно заполнить все поля");
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            create_recipe.IsEnabled = true;
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                con.Open();
                SqlCommand sql = new SqlCommand("select SUM(WEIGHT) AS VES, SUM(CALORICITY) AS CALOR, SUM(БЕЛКИ) AS BELKI " +
                    ",SUM(ЖИРЫ) AS FATS, SUM(УГЛЕВОДЫ) AS UGL FROM RECIPES where REC_NAME=N'" + rec_name.Text + "'", con);
                SqlDataReader sqlDataReader = sql.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(sqlDataReader);
                DataRow row = data.Rows[0];
                double weight = row.Field<double>("VES");
                double rec_calorii = row.Field<double>("CALOR") * 100 / weight;
                double rec_fats = row.Field<double>("FATS") * 100 / weight;
                double rec_belki = row.Field<double>("BELKI") * 100 / weight;
                double rec_carbo = row.Field<double>("UGL") * 100 / weight;
                SqlCommand sqlcom = new SqlCommand("insert into RECIPE_INFO(RECIPE_NAME, CALORICITY_RECIPE,FATS,PROTEINS,CARBO) " +
                    "VALUES(N'" + rec_name.Text + "'," + Convert.ToDouble(rec_calorii).ToString("0.0", CultureInfo.InvariantCulture)
                    + "," + Convert.ToDouble(rec_fats).ToString("0.0", CultureInfo.InvariantCulture)
                    + "," + Convert.ToDouble(rec_belki).ToString("0.0", CultureInfo.InvariantCulture)
                    + ", " + Convert.ToDouble(rec_carbo).ToString("0.0", CultureInfo.InvariantCulture) + ")", con);
                sqlcom.ExecuteNonQuery();
                info_recipe.Text = "Энергетическая ценность на 100 грамм:" +
                    "Калорийность " + rec_calorii.ToString("0.0", CultureInfo.InvariantCulture) + ", Белки" + rec_belki.ToString("0.0", CultureInfo.InvariantCulture) + ", Жиры" + rec_fats.ToString("0.0", CultureInfo.InvariantCulture) +
                    ", Углеводы " + rec_carbo.ToString("0.0", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Не удается посчитать энергетическую ценность, проверьте заполненность всех полей");
            } 
        }

        private void create_recipe_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(strconnect); con.Open();
            try
            {
                SqlCommand exist = new SqlCommand("select count(INGRED) from RECIPES where USER_NAM = N'"+NAME +"' and REC_NAME = N'"+rec_name.Text +"'", con);
                object k = exist.ExecuteScalar();
                if (rec_name.Text != "" && prigotovlenie.Text != "" && k!=null && info_recipe.Text!="")
                {
                    SqlCommand insert = new SqlCommand("UPDATE RECIPE_INFO SET RECIPE_TEXT=N'" + prigotovlenie.Text + "' WHERE RECIPE_NAME=N'" + rec_name.Text + "'", con);
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Рецепт успешно создан!");
                }
                else
                {
                    MessageBox.Show("Рецепт не создан, ингредиенты не внесены");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, попробуйте ещё раз");
            }
        }
       
    }
}
