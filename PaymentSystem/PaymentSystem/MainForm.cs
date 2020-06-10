using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PaymentSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //lets create a method to load the data
        private void LoadData()
        {
			//FOR FELLOW DEVELOPERS, JUST REPLACE THE CONNECTIONSTRING AND REBUILD THE PROJECT
            string ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=PaymentSystem;Data Source=.\SQLSERVER2016";
            string CommandText = "SELECT Id, Payer, Payee, Amount FROM tblTransactions";

            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlDataAdapter DataAdapter = new SqlDataAdapter(CommandText, Connection);

            DataSet Dataset = new DataSet();
            DataTable Datatable = new DataTable();

            //load to dataset
            DataAdapter.Fill(Dataset, "tblTransactions");
            Datatable = Dataset.Tables["tblTransactions"];

            dataGridView.DataSource = Datatable;
            dataGridView.AutoGenerateColumns = false;
        }

        //now lets call it on formload
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //reload the data once refresh button is clicked
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        //done
    }
}
