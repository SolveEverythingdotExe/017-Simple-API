using System.Data;
using System.Data.SqlClient;

namespace PaymentAPI
{
    public class SecurePayment
    {
        //lets create a function to process the payment
        public bool ProcessPayment(string Payer, string Payee, double Amount)
        {
            bool TransactionSuccessful = false;

			//FOR FELLOW DEVELOPERS, JUST REPLACE THE CONNECTIONSTRING AND REBUILD THE PROJECT
            string ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=PaymentSystem;Data Source=.\SQLSERVER2016";
            string CommandText = "INSERT INTO tblTransactions(Payer, Payee, Amount) VALUES(@Payer, @Payee, @Amount)";

            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command = new SqlCommand();

            //set the command
            Command.Connection = Connection;
            Command.CommandText = CommandText;
            Command.CommandType = CommandType.Text;

            //lets now save the transaction
            try
            {
                Connection.Open();

                //set the parameters
                Command.Parameters.AddWithValue("@Payer", Payer);
                Command.Parameters.AddWithValue("@Payee", Payee);
                Command.Parameters.AddWithValue("@Amount", Amount);

                //execute the command
                TransactionSuccessful = Command.ExecuteNonQuery() != 0;
            }
            finally
            {
                //make sure to close the connection
                Connection.Close();
            }

            return TransactionSuccessful;
        }
        //lets build it and its done
    }
}
