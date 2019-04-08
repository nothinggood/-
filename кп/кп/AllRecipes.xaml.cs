using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AllRecipes.xaml
    /// </summary>
    public partial class AllRecipes : UserControl
    {
        static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";

        public AllRecipes()
        {
            InitializeComponent();
            datagrid_recipes.IsReadOnly = true;
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            string q = "SELECT RECIPE_NAME [Рецепт] from RECIPE_INFO ";
            SqlCommand com = new SqlCommand(q, con);
            com.ExecuteNonQuery();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
            DataTable dataTable = new DataTable("RECIPES_INFO");
            dataAdapter.Fill(dataTable);
            datagrid_recipes.ItemsSource = dataTable.DefaultView;
        }
        public string rec;

        private void datagrid_recipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = datagrid_recipes.SelectedValue as DataRowView;
            rec = rowView[0].ToString();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            name_of_recipe.Content = rec; //название рецепта в лэйбл
            string count = "select COUNT(INGRED) FROM RECIPES where REC_NAME=@rec";
            SqlCommand sqlCommand = new SqlCommand(count, con);
            sqlCommand.Parameters.Add("@rec", SqlDbType.NVarChar).Value = rec;
            object ch = sqlCommand.ExecuteScalar();
            if (ch != null)
            {
                ing.Items.Clear();
                weight.Items.Clear();
                int col_rec = Convert.ToInt16(ch.ToString());
                SqlCommand info = new SqlCommand("select CALORICITY_RECIPE, FATS, PROTEINS, CARBO FROM RECIPE_INFO WHERE RECIPE_NAME=N'" + rec + "'", con);
                SqlDataReader read = info.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(read);
                DataRow row = dataTable.Rows[0];
                string calorii = row.Field<double>("CALORICITY_RECIPE").ToString();
                string fat = row.Field<double>("FATS").ToString();
                string carb = row.Field<double>("CARBO").ToString();
                string prot = row.Field<double>("PROTEINS").ToString();
                string q = "SELECT RECIPE_TEXT  from RECIPE_INFO WHERE RECIPE_NAME=@rec";
                SqlCommand com = new SqlCommand(q, con);
                com.Parameters.Add("@rec", SqlDbType.NVarChar).Value = rec;
                object res = com.ExecuteScalar();
                text_recipe.Text = res.ToString() + "\n Калорийность на 100 грамм " 
                    + calorii+ " ккал.\nБелки " +prot +"\nЖиры " +fat + "\nУглеводы " + carb  ; //текст рецепта в текстбОКС
                List<string> ingr = new List<string>();
                List<double> w = new List<double>();
                string ingredients = "select INGRED, WEIGHT FROM RECIPES WHERE REC_NAME=@rec";
                SqlCommand sqlcom = new SqlCommand(ingredients, con);
                sqlcom.Parameters.Add("@rec", SqlDbType.NVarChar).Value = rec;
                SqlDataReader reader = sqlcom.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(reader);
                for (int i = 0; i < col_rec; i++)
                {
                    DataRow drow = data.Rows[i];
                    string ingred = drow.Field<string>("INGRED");
                    double weight = drow.Field<double>("WEIGHT");
                    ingr.Add(ingred);
                    w.Add(weight);
                }

                for (int i = 0; i < w.Count; i++)
                {
                    ing.Items.Add(ingr[i]);
                    weight.Items.Add(w[i]);
                }
            }
            else MessageBox.Show("Произошла ошибка, попробуйте ещё раз.");
        }
    }
}
