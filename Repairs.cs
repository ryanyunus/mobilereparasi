using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace mobilereparasi
{
    public partial class RepDateTb : Form
    {
        Functions Con;
        public RepDateTb()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
            GetCustomer();
            GetCSpare();
            ListRepair.CellContentClick += ListRepair_CellContentClick;

        }
        private void GetCost()
        {
            string Query = "Select * from SpareTbl where SpCode = {0}";
            Query = string.Format(Query, SpareCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCost"].ToString();
            }
           // MessageBox.Show("Hello");
        }
        private void GetCustomer()
        {
            
          //  string Query = "Select * form CustomerTbl";
            string Query = "Select * from CustomerTbl";

            CustTb.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            CustTb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustTb.DataSource = Con.GetData(Query);
        }
        private void GetCSpare()
        {

            //  string Query = "Select * form CustomerTbl";
            string Query = "Select * from SpareTbl";

            SpareCb.DisplayMember = Con.GetData(Query).Columns["Spname"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);
        }
        private void ShowRepairs()
        {
            string Query = "select * from RepairTbl";
           // RepairList.DataSource = Con.GetData(Query);
            ListRepair.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustTb.SelectedIndex == -1 || PhoneTb.Text == "" || DeviceNameTbl.Text == "" || DModelTb.Text == "" || ProblemTb.Text == "" || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == "" || TotalCostTb.Text == "")
            {
                MessageBox.Show("Data yang kurang !!!");
            }
            else
            {
                try
                {
                    //string Rdate= RepDateTbls.Value.Date.ToString();
                    //string Rdate = RepDateTbls.Value.Date.ToString("yyyy-MM-dd");
                    string Rdate = RepDateTbls.Value.Date.ToString("MM-dd-yyyy");

                    int Customer = Convert.ToInt32(CustTb.SelectedValue.ToString());
                    string CPhone = PhoneTb.Text;
                    string DeviceName = DeviceNameTbl.Text;
                    string DeviceModel = DModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalCostTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = "insert into RepairTbl values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, Rdate,Customer, CPhone, DeviceName, DeviceModel, Problem, Spare, GrdTotal);
                   
                    Con.SetData(Query);
                    MessageBox.Show("Perbaikan Ditambahkan !!!");
                    ShowRepairs();
                    //Clear();
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
                MessageBox.Show("Select a Repair Data !!!");
            }
            else
            {
                try
                {
                    
                    string Query = "delete from RepairTbl where RepCode  =  {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Delete !!!");
                    ShowRepairs();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SpareCb_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void SpareCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
        }

        private void RepairCostTb_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        int Key = 0;
       
       private void RepairList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Key = Convert.ToInt32(RepairList.SelectedRows[0].Cells[0].Value.ToString());
        }


        private void RepairList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (RepairList.SelectedRows.Count > 0)
            {
                Key = Convert.ToInt32(RepairList.SelectedRows[0].Cells[0].Value.ToString());
                // Bagian kode lainnya
            }
           
        }
                */

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
        int Key = 0;
        private void ListRepair_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Pastikan baris yang diklik valid
            {
                Key = Convert.ToInt32(ListRepair.Rows[e.RowIndex].Cells[0].Value.ToString());
                // Bagian kode lainnya
            }
            else
            {
                Key = 0; // Set Key ke 0 jika tidak ada baris yang dipilih
            }
        }


    }
}
