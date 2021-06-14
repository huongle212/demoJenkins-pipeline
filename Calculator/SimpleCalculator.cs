using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class SimpleCalculator : Form
    {
        public SimpleCalculator()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtNumM.Text = "";
            txtNumN.Text = "";
            txtResult.Text = "";
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int n = 0, m = 0;
            txtResult.Text = "";
            try
            {
                m = int.Parse(txtNumM.Text);
            }
            catch
            {
                MessageBox.Show("Detail: Invalid m! Please input a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumM.Focus();
                return;
            }
            try
            {
                n = int.Parse(txtNumN.Text);
            }
            catch
            {
                MessageBox.Show("Detail: Invalid n! Please input a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumN.Focus();
                return;
            }
            double rs = 0;
            if ((sender as Button).Text.Equals("+"))
                rs = (double)(m + n);
            else if ((sender as Button).Text.Equals("-"))
                rs = (double)(m - n);
            else if ((sender as Button).Text.Equals("*"))
                rs = (double)(m * n);
            else if (n == 0)
            {
                MessageBox.Show("Detail: Can not divide 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumN.Focus();
            }
            else
                rs = (double)m / n;
            txtResult.Text = rs.ToString();
        }
    }
}
