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
    public partial class Spares : Form
    {
        Functions Con;
        public Spares()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSpares();
        }
        private void ShowSpares()
        {
            string Query = "select * from SpareTbl";
            PartsList.DataSource = Con.GetData(Query);
        }
        private void Clear()
        {
            Partametb.Text = "";
            PartCostTb.Text = "";
            Key = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Partametb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string PName = Partametb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);

                    string Query = "insert into SpareTbl values ('{0}','{1}')";
                    Query = string.Format(Query, PName, Cost);
                    int i = Con.SetData(Query);
                    MessageBox.Show("Customer Added !!!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void PartsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < PartsList.Rows.Count)
            {
                DataGridViewRow row = PartsList.Rows[e.RowIndex];
                Partametb.Text = row.Cells[1].Value.ToString();
                PartCostTb.Text = row.Cells[2].Value.ToString();
           
                if (Partametb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (Partametb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string PName = Partametb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);

                    string Query = "update SpareTbl set Spname =  '{0}',spcost = {1} where spcode = {2} ";
                    Query = string.Format(Query, PName, Cost, Key);
                    int i = Con.SetData(Query);
                    MessageBox.Show("Customer Update !!!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string PName = Partametb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);

                    string Query = "delete from SpareTbl where spcode = {0} ";
                    Query = string.Format(Query, Key);
                    int i = Con.SetData(Query);
                    MessageBox.Show("Spare Update !!!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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
