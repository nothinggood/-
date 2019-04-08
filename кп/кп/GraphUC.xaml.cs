using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;
using System.Data;
using System.Collections.Generic;

namespace кп
{
    /// <summary>
    /// Логика взаимодействия для GraphUC.xaml
    /// </summary>
    public partial class GraphUC : UserControl
    {
        static string strconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\EDUCATION\\ООП\\4сем\\курсач\\kproject\\кп\\кп\\CN_database.mdf;Integrated Security=True";
        public string user;
        public GraphUC(string name)
        {
            user=name;  
            InitializeComponent();
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            #region
            string count = " select COUNT(data_entry) from Трекервеса where name_us=@user";
            SqlCommand sq = new SqlCommand(count, connection);
            sq.Parameters.Add("@user", SqlDbType.NVarChar).Value = user;
            object v= sq.ExecuteScalar();
            int counter = Convert.ToInt16(v.ToString());
            if (counter != 0)
            {
                string sel = "select data_entry,weight_us from Трекервеса where name_us=@user order by data_entry";
                SqlCommand com = new SqlCommand(sel, connection);
                com.Parameters.Add("@user", SqlDbType.NVarChar).Value = user;
                SqlDataReader reader = com.ExecuteReader();
                List<string> dates = new List<string>();
                List<Double> weights = new List<Double>();
                DataTable dt = new DataTable();
                dt.Load(reader);
                for (int i = 0; i < counter; i++)
                {
                    DataRow drow = dt.Rows[i];
                    DateTime values = drow.Field<DateTime>("data_entry");
                    Double w = drow.Field<Double>("weight_us");
                    dates.Add(values.ToShortDateString());
                    weights.Add(w);
                }

                reader.Close();
                ChartValues<Double> vs = new ChartValues<Double>();
                foreach (Double k in weights)
                {
                    vs.Add(Convert.ToDouble(k));
                }

                SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title ="Ваш вес",
                    Values = vs,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    Stroke=Brushes.Yellow,
                    StrokeThickness=1,
                    Foreground=Brushes.White
                }
            };
                Labels = dates.ToArray();
                DataContext = this;
            }
            else MessageBox.Show("Сначала внесите данные о своём весе");
            #endregion

            string count2 = " select COUNT(distinct data_entry) from Трекерпитания_продукты where NAME_USER=@user";
            SqlCommand sql = new SqlCommand(count2, connection);
            sql.Parameters.Add("@user", SqlDbType.NVarChar).Value = user;
            object value = sql.ExecuteScalar();
            int counter2 = Convert.ToInt16(value.ToString());
            if (counter2 != 0)
            {
                string count3 = "select data_entry, sum(caloricity) as sum from Трекерпитания_продукты  where NAME_USER=@user group by data_entry";
                SqlCommand comm = new SqlCommand(count3, connection);
                comm.Parameters.Add("@user", SqlDbType.NVarChar).Value = user;
                SqlDataReader read = comm.ExecuteReader();
                List<string> dates_prod = new List<string>();
                List<Double> calories = new List<Double>();
                DataTable dtt = new DataTable();
                dtt.Load(read);                
                for (int i = 0; i < counter2; i++)
                {
                    DataRow drow = dtt.Rows[i];
                    DateTime values = drow.Field<DateTime>("data_entry");
                    Double w = drow.Field<Double>("sum");
                    dates_prod.Add(values.ToShortDateString());
                    calories.Add(w);
                }

                read.Close();
                ChartValues<Double> chart = new ChartValues<Double>();
                foreach (Double k in calories)
                {
                    chart.Add(Convert.ToDouble(k));
                }

                Seriescalor = new SeriesCollection
            {
                new LineSeries
                {
                    Title ="Вы скушали(в ккал.)",
                    Values = chart,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    Stroke=Brushes.Magenta,
                    StrokeThickness=1,
                    Foreground=Brushes.White
                }
            };
                Labelscalor = dates_prod.ToArray();
            }
            else MessageBox.Show("Данные о приёмах пищи не внесены, попробуйте ещё раз");
           
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public SeriesCollection Seriescalor { get; set; }
        public string[] Labelscalor { get; set; }


    }
}

