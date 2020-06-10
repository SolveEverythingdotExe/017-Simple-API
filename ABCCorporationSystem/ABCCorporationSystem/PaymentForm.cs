using PaymentAPI;
using System;
using System.Windows.Forms;

namespace ABCCorporationSystem
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPayer.Clear();
            txtAmount.Clear();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            const string Payee = "ABC Corporation";

            //instantiate the class of the API
            SecurePayment payment = new SecurePayment();

            if (payment.ProcessPayment(txtPayer.Text, Payee, double.Parse(txtAmount.Text)))
            {
                MessageBox.Show("Payment Successful!");
                txtPayer.Clear();
                txtAmount.Clear();
            }
            else
                MessageBox.Show("Something went wrong!");
        }
        //It works
    }
}
