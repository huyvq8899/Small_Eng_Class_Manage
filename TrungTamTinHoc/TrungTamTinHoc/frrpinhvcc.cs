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
    public partial class frrpinhvcc : Form
    {
        public frrpinhvcc()
        {
            InitializeComponent();
        }

        private void frrpinhvcc_Load(object sender, EventArgs e)
        {
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select malop from viewchungchi";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "viewchungchi");
            cblop.DataSource = ds.Tables["viewchungchi"];
            cblop.DisplayMember = "malop";
            cblop.ValueMember = "malop";
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
            sql = "select * from viewchungchi where malop='" + ma + "'";
            //sql = "select * from viewdiem where malop='" + mal + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "viewchungchi");
            dgdiem.DataSource = ds.Tables["viewchungchi"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}