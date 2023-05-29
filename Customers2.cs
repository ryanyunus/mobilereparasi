using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobilereparasi
{
    public partial class Customers2 : Form
    {
        Functions Con;
        public Customers2()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCustomers();
            CustomerList.Columns["CustCode"].DisplayIndex = 0;
            CustomerList.Columns["CustName"].DisplayIndex = 1;
            CustomerList.Columns["CustPhone"].DisplayIndex = 2;
            CustomerList.Columns["CustAdd"].DisplayIndex = 3;
        }
        private void ShowCustomers()
        {
            string Query = "select * from CustomerTbl";
            CustomerList.DataSource = Con.GetData(Query);
        }

        private void SaveBtm_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;

                    string Query = "insert into CustomerTbl values ('{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);

                    int i = Con.SetData(Query);
                    MessageBox.Show("Customer Added !!!");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CustPhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustAddTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Customers2_Load(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;
                   // string Query = "update CustomerTbl set CostName = '{0}',CostPhone = '{1}',CostAdd = '{2}' where CustCode  = {3}";
                    string Query = "update CustomerTbl set CustName = '{1}', CustPhone = '{2}', CustAdd = '{3}' where CustCode = {0}";
                    Query = string.Format(Query,Key, CName, CPhone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Updated !!!");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Clear()
        {
            CustNameTb.Text = "";
            CustPhoneTb.Text = "";
            CustAddTb.Text = "";
            Key = 0;
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
           
            if (Key == 0)
            {
                MessageBox.Show("Select A Customer !!!");
            }
            else
            {
                try
                {
                    
                    // string Query = "update CustomerTbl set CostName = '{0}',CostPhone = '{1}',CostAdd = '{2}' where CustCode  = {3}";
                    string Query = "delete from CustomerTbl where CustCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Delete !!!");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        // Perubahan pada method CustomerList_CellContentClick
        
        private void CustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < CustomerList.Rows.Count)
            {
                DataGridViewRow row = CustomerList.Rows[e.RowIndex];
                CustNameTb.Text = row.Cells[1].Value.ToString();
                CustPhoneTb.Text = row.Cells[2].Value.ToString();
                CustAddTb.Text = row.Cells[3].Value.ToString();

                if (CustNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            Spares Obj = new Spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RepDateTb Obj = new RepDateTb();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers2 Obj = new Customers2();
            Obj.Show();
            this.Hide();
        }
    }
}
