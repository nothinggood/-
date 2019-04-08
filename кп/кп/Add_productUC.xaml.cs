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
using System.Globalization;

namespace кп
{
    /// <summary>
    /// Логика взаимодействия для Add_productUC.xaml
    /// </summary>
    public partial class Add_productUC : UserControl
    {
       static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";

        public Add_productUC()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(strconnect);
            con.Open();
            List<string> types = new List<string>();
            #region
            types.Add("Каши");
            types.Add("Алкоголь");
            types.Add("Безалкогольные напитки");
            types.Add("Мясо,птица");
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
            #endregion

            string count = "select COUNT(НАЗВАНИЕ) FROM Products ";
            SqlCommand sqlCommand = new SqlCommand(count, con);
            int col_ingr = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());
            SqlCommand command = new SqlCommand("select НАЗВАНИЕ from Products", con);
            List<string> product = new List<string>();
            SqlDataReader sqlData = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(sqlData);
            for(int i = 0; i < col_ingr; i++)
            {
                DataRow row = data.Rows[i];
                product.Add(row.Field<string>("НАЗВАНИЕ"));
                products.Items.Add(product[i]);
            }
            save.IsEnabled = false;

        }
        public void add_pr_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            bool flag = true;
            bool fl = true, fl1=true, fl2=true, fl3=true;
            foreach (char ch in name_product.Text )
            {
                if (!((int)ch >= 1040 && (int)ch <= 1103))
                    flag = false;
            }
            foreach(char c in calorii.Text )
            {
                  if (!((int)c >= 49 && (int)c <= 57))
                        fl = false;
            }

            foreach (char c in fats.Text)
            {
                if (!((int)c >= 49 && (int)c <= 57))
                    fl1 = false;
            }
            foreach (char c in belki.Text)
            {
                if (!((int)c >= 49 && (int)c <= 57))
                    fl2 = false;
            }
            foreach (char c in ugl.Text)
            {
                if (!((int)c >= 49 && (int)c <= 57))
                    fl3 = false;
            }
            if (!flag || !fl || !fl1 || fl2 || fl3)
            {
                MessageBox.Show("В поле 'название' можно вводить только буквы, в остальные поля - только числа");
            }
            else
                try
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        string ins = "insert into Products(НАЗВАНИЕ, ТИП, КАЛОРИЙНОСТЬ, БЕЛКИ, ЖИРЫ, УГЛЕВОДЫ, СПИРТ) VALUES (N'" + name_product.Text + "',N'" + type_prod.SelectedItem + "', " + calorii.Text + ", " + belki.Text + "," + fats.Text + "," + ugl.Text + "," + spirt.Text + ");";
                        SqlCommand com = new SqlCommand(ins, connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Продукт добавлен");
                    }
                    else MessageBox.Show("не удалось подключиться");
                    name_product.Text = "";
                    calorii.Text = "";
                    belki.Text = "";
                    ugl.Text = "";
                    fats.Text = "";
                    save.IsEnabled = false;
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так, попробуйте ещё раз.");
                }
        }


        private void edit_Click(object sender, RoutedEventArgs e)
        {
            save.IsEnabled = true;
            add_pr.IsEnabled = false;
          
                    if (products.SelectedIndex != -1)
                    {
                        SqlConnection con = new SqlConnection(strconnect);
                        con.Open();
                        SqlCommand command = new SqlCommand("select ТИП from Products where НАЗВАНИЕ=N'" + products.SelectedItem.ToString() + "'", con);
                        command.ExecuteNonQuery();
                        type_prod.SelectedItem = command.ExecuteScalar().ToString();
                        name_product.Text = products.SelectedItem.ToString();
                        SqlCommand command2 = new SqlCommand("select КАЛОРИЙНОСТЬ, БЕЛКИ, ЖИРЫ, УГЛЕВОДЫ, СПИРТ from Products where НАЗВАНИЕ=N'" + products.SelectedItem.ToString() + "'", con);
                        command2.ExecuteNonQuery();
                        SqlDataReader sqlData = command2.ExecuteReader();
                        DataTable data = new DataTable();
                        data.Load(sqlData);
                        DataRow row = data.Rows[0];
                        calorii.Text = row.Field<int>("КАЛОРИЙНОСТЬ").ToString();
                        belki.Text = Math.Round(row.Field<double>("БЕЛКИ"), 1).ToString();
                        ugl.Text = Math.Round(row.Field<double>("УГЛЕВОДЫ"), 1).ToString();
                        fats.Text = Math.Round(row.Field<double>("ЖИРЫ"), 1).ToString();
                        spirt.Text = Math.Round(row.Field<double>("СПИРТ"), 1).ToString();

                    }
                    else MessageBox.Show("Продукт не выбран");
            
             
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
    bool flag = true;
    bool fl = true, fl1 = true, fl2 = true, fl3 = true;
    foreach (char ch in name_product.Text)
    {
        if (!((int)ch >= 1040 && (int)ch <= 1103))
            flag = false;
    }
    foreach (char c in calorii.Text)
    {
        if (!((int)c >= 49 && (int)c <= 57))
            fl = false;
    }

    foreach (char c in fats.Text)
    {
        if (!((int)c >= 49 && (int)c <= 57))
            fl1 = false;
    }
    foreach (char c in belki.Text)
    {
        if (!((int)c >= 49 && (int)c <= 57))
            fl2 = false;
    }
    foreach (char c in ugl.Text)
    {
        if (!((int)c >= 49 && (int)c <= 57))
            fl3 = false;
    }
    if (!flag || !fl || !fl1 || fl2 || fl3)
    {
        MessageBox.Show("В поле 'название' можно вводить только буквы, в остальные поля - только числа");
    }
    else
        try
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string ins = "update  Products set НАЗВАНИЕ=N'" + name_product.Text + "', ТИП=N'" + type_prod.SelectedItem + "' , КАЛОРИЙНОСТЬ" +
                    "=" + calorii.Text + ", БЕЛКИ=" + Convert.ToDouble(belki.Text).ToString("0.0", CultureInfo.InvariantCulture) + ", ЖИРЫ=" +
                    Convert.ToDouble(fats.Text).ToString("0.0", CultureInfo.InvariantCulture) +
                    ", УГЛЕВОДЫ=" + Convert.ToDouble(ugl.Text).ToString("0.0", CultureInfo.InvariantCulture)
                    + ", СПИРТ=" + Convert.ToDouble(spirt.Text).ToString("0.0", CultureInfo.InvariantCulture) + " where НАЗВАНИЕ=N'" + products.SelectedItem.ToString() + "'";
                SqlCommand com = new SqlCommand(ins, connection);
                com.ExecuteNonQuery();
                        MessageBox.Show("информация о продукте успешно изменена");
            }
            else MessageBox.Show("не удалось подключиться");
            name_product.Text = "";
            calorii.Text = "";
            belki.Text = "";
            ugl.Text = "";
            fats.Text = "";
        }
        catch
        {
            MessageBox.Show("Что-то пошло не так, попробуйте ещё раз.");
                }
      }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            if ( products.SelectedIndex != -1)
            {
                SqlConnection con = new SqlConnection(strconnect);
                con.Open();
                SqlCommand command = new SqlCommand("delete from Products where НАЗВАНИЕ=N'" + products.SelectedItem.ToString() + "'", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Продукт успешно удалён!");
            }
            else MessageBox.Show("Продукт не выбран");

        }
    }
}
