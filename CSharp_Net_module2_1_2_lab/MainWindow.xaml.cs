using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

namespace CSharp_Net_module2_1_2_lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlDataAdapter adapter;
        private DataTable dt;
        // 15) Declare objects DataSet, DataAdapter and others
        public MainWindow()
        {
           
            InitializeComponent();
            FirstBtn.Background = Brushes.Gray;
            FirstBtn.Foreground = Brushes.Black;
            // 9) Set Background for button; use Brushes
            
            string connectionString = "Data Source=ASUS-VIVOBOOK-P\\SASHASQLSERVER;Initial Catalog=main;Integrated Security=True";
            string sqlCommand = "Select * from Flights";
            SqlCommandBuilder commandBuilder;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(sqlCommand, conn);
                commandBuilder = new SqlCommandBuilder(adapter);
                dt = new DataTable("Flights");
                adapter.Fill(dt);
                DataGridView.AutoGenerateColumns = true;
                //DataGridView.SetValue(, dt.Rows[0]);
                DataGridView.DataContext = dt.DefaultView;
            }
            // 16) Set DataAdapter and DataSet
            // Note: Don't forget to use connection string

            // 17) Add datacontext of datagrid with code:
            // dataGridView.DataContext = da.Tables[“MyTable"];
            // Where 
            // dataGridView – name (object) of used datagrind
            // da – object of DataSet
            // “MyTable” – table name

        }

        private void FirstBtn_Click(object sender, RoutedEventArgs e)
        {
            PictureWindow pictureWindow = new PictureWindow();
            pictureWindow.ShowDialog();
        }
        private void SecondBtn_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dt);
        }
        // 11) Add event handler on button click (for colored button)

        // 12) Add new window to project
        // In new window add XAML to show backgroud image

        // 13) invoke method ShowDialig() for new window


        // 18) Add event handler on button click (for 2nd button)

        // 19) invoke method Update() of DataAdapter to update data

    }
}
