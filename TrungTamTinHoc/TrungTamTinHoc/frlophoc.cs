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
    public partial class frlophoc : Form
    {
        public frlophoc()
        {
            InitializeComponent();
        }
        Classqlttth obj = new Classqlttth();
        //int vitri = 0;
        DataTable mtblhv = new DataTable();
        //string str = "";


        void clearall()
        {
            
           
            txtml.Clear();
           
            //txtbu.Clear();
            txtml.Focus();
        }
        private void GanDuLieuTuRowVaoText(DataTable tbl, int vitri)
        {
            DataRow drw;
            drw = tbl.Rows[vitri];
          
           txtml.Text = drw["malop"].ToString();
           //txtbu.Text = drw["buoihoc"].ToString();
          //cbbuoihoc.Text = drw["buoihoc"].ToString();
          cbkh.Text = drw["makh"].ToString();                      
            cbgv.Text = drw["magv"].ToString();
            cbp.Text = drw["maphong"].ToString();
            dateTimePicker1.Text = drw["ngaybatdau"].ToString();
            dateTimePicker2.Text = drw["ngayketthuc"].ToString();
           cbcahoc.Text = drw["cahoc"].ToString();
          
        }
        void ht()
        {
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select makh from khoahoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "khoahoc");
            cbkh.DataSource= ds.Tables["khoahoc"];
            cbkh.DisplayMember = "makh";
            cbkh.ValueMember = "makh";
        }
        void ht1()
        {
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select magv from giaovien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "giaovien");
            cbgv.DataSource = ds.Tables["giaovien"];
            cbgv.DisplayMember = "magv";
            cbgv.ValueMember = "magv";
        }
        void ht2()
        {
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select maphong from phong where dacdiem='con trong'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "phong");
            cbp.DataSource= ds.Tables["phong"];
            cbp.DisplayMember = "maphong";
            cbp.ValueMember = "maphong";
        }
        private void frlophoc_Load(object sender, EventArgs e)
        {
           // mtblhv = obj.getDataTable("lophoc");
           // GanDuLieuTuRowVaoText(mtblhv, vitri);
           // DataSet ds = new DataSet();
           // ds = obj.getDataSet("lophoc");
           //dglh.DataSource = ds.Tables[0];
            string sql;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            sql = "select * from lophoc ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "lophoc");
           dglh.DataSource = ds.Tables["lophoc"];
            bttluu.Enabled = false;
            //txtml.Enabled = false;
            //setText();
            ht();
            ht1();
            ht2();
        }
        //--------kiem tra du lieu hop le--------------//
        public bool kiemtradulieulophoc()
        {
            if (cbp.Text==""||cbkh.Text==""||cbgv.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return false;
            }
            else
            {
                if (obj.kiemtratrungtkb(cbp.Text,cbcahoc.Text))
                {
                    MessageBox.Show(" Trùng phòng học và ca học!");
                    return false;
                }
                return true;
            }
        }
        public int AutoMa()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            //Khoi tao 1 doi tuong DataTable
            DataTable tbl = new DataTable();
            string strSql = "select right(rtrim(malop),2) from lophoc";
            tbl = obj.FillDataTable(strSql);
            SqlDataAdapter dataad = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            dataad.Fill(ds);
            //Duyet tung hang va dua du lieu vao trong bang
            int max = 0;
            foreach (DataRow dr in tbl.Rows)
            {
                int tg = int.Parse(dr[0].ToString());
                if (max < tg)
                    max = tg;
                //return max + 1;
            }
            return max + 1;
        }
        void setText()
        {
            txtml.Text = "TH" + "-" + AutoMa().ToString("00");
           cbkh.Text = "";
            cbp.Text = "";
           cbgv.Text = "";
            
            //cbbuoihoc.Text = "";
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (bttsua.Enabled == false)
            {

                bool kt;
                //=====================
                if (kiemtradulieulophoc() == false)
                {

                    return;
                }
                else
                {
                    string mlop,mkh,mp,mgv,nbd,nkt,ca;
                   
                    //txtml.Text = "TH" + "-" + AutoMa().ToString("00000");
                    mlop = txtml.Text;
                    mkh = cbkh.Text;
                    mp = cbp.Text;
                    mgv = cbgv.Text;
                    nbd =  dateTimePicker1.Value.ToShortDateString(); 
                    nkt =  dateTimePicker2.Value.ToShortDateString(); 
                    //bu = cbbuoihoc.Text;
                    ca = cbcahoc.Text;
                    kt = obj.luulophoc(mlop,mp,mgv,mkh,ca,nbd,nkt);
                    if (kt == false)
                    {
                        MessageBox.Show("Ban Chua Them Duoc!");
                        return;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = obj.lophoc();
                        dglh.DataSource = ds.Tables[0];
                        MessageBox.Show("Ban Them Thanh Cong !");
                        clearall();
                        bttluu.Enabled = false;
                        bttsua.Enabled = true;
                        bttnhapmoi.Text = "NHẬP MỚI";
                       
                        
                    }
                }
            }
            else
            {
                bool kt;
                //=====================               
                string mlop, mkh, mp, mgv, nbd, nkt,ca;
                //txtml.Text = "TH" + "-" + AutoMa().ToString("00000");
                mlop = txtml.Text;
                mkh = cbkh.Text;
                mp = cbp.Text;
                mgv = cbgv.Text;
                nbd = dateTimePicker1.Value.ToShortDateString();
                nkt = dateTimePicker2.Value.ToShortDateString(); 
                //bu = cbbuoihoc.Text;
                ca = cbcahoc.Text;
              mlop = dglh.CurrentCell.Value.ToString();
              kt = obj.suathongtinlophoc(mlop,mkh,mgv,mp,ca,nbd,nkt);
                if (kt == false)
                {
                    MessageBox.Show("Ban Chua sua Duoc!");
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = obj.lophoc();
                  dglh.DataSource = ds.Tables[0];
                    MessageBox.Show("Ban da sua Thanh Cong !");
                    //ClearAll();
                    bttluu.Enabled = false;
                    bttsua.Enabled = true;
                    bttnhapmoi.Enabled = true;
                    
                    bttsua.Text = "SỬA";
                }

            }           
        }

        private void btnhapmoi_Click(object sender, EventArgs e)
        {
            clearall();
            setText();
         
            if (bttnhapmoi.Text == "NHẬP MỚI")
            {

                bttnhapmoi.Text = "HUỶ NHẬP";
                bttsua.Enabled = false;
               
                bttluu.Enabled = true;
            }
            else
            {

                bttluu.Enabled = false;
                bttnhapmoi.Text = "NHẬP MỚI";
                bttsua.Enabled = true;
               

            }               
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (bttsua.Text == "SỬA")
            {

              txtml.Enabled = false;
                bttnhapmoi.Enabled = false;
               
                bttsua.Text = "HUỶ SỬA";
                bttluu.Enabled = true;

            }
            else
            {
               txtml.Enabled = true;
                bttluu.Enabled = false;
                bttsua.Text = "SỬA";
                bttnhapmoi.Enabled = true;
               

            }          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
       

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}