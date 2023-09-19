using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TrungTamTinHoc
{
    public partial class frrpinbl : Form
    {
        public frrpinbl()
        {
            InitializeComponent();
        }

        private void frrpinbl_Load(object sender, EventArgs e)
        {
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select mahv from hocvien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "hocvien");
            cblop.DataSource = ds.Tables["hocvien"];
            cblop.DisplayMember = "mahv";
            cblop.ValueMember = "mahv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma;
            ma = cblop.Text;
            //mal = comboBox1.Text;
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select * from Viewbienlai where mahv='" + ma + "'";
            //sql = "select * from viewdiem where malop='" + mal + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "hocvien");
            dgdiem.DataSource = ds.Tables["hocvien"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frbl hv = new frbl();
            hv.chuoiloc = "";
            hv.chuoiloc = "{Viewbienlai.mahv}='" + cblop.Text + "'";
            hv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}