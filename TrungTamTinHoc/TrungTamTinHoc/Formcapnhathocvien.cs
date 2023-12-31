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
    public partial class Formcapnhathocvien : Form
    {
        public Formcapnhathocvien()
        {
            InitializeComponent();
        }
        Classqlttth obj = new Classqlttth();
        int vitri = 0;
        DataTable mtblhv = new DataTable();
        //string str = "";


        void clearall()
        {
            txtns.Clear();
            txtdc.Clear();
            txtthv.Clear();
            txtmssv.Clear();          
            txttt.Clear();
            txtmhv.Clear();
            txtmhv.Focus();
        }

      
        void GanDuLieu()
        {
            //===========Doc du lieu vao combo ma lop====
            DataTable tbl = new DataTable();
            tbl = obj.getDataTable("lophoc");
            cblop.DisplayMember = "malop";
            cblop.ValueMember = "malop";
            cblop.DataSource = tbl;
            //====================================

        }
        private void GanDuLieuTuRowVaoText(DataTable tbl, int vitri)
        {
            DataRow drw;
            drw = tbl.Rows[vitri];
            txtmhv.Text = drw["mahv"].ToString();
            txtmssv.Text = drw["mssv"].ToString();
            dateTimePicker1.Text = drw["namsinh"].ToString();            
            cblop.Text = drw["malop"].ToString();
            txtthv.Text = drw["hoten"].ToString();
            txtdc.Text = drw["diachi"].ToString();
            txtns.Text = drw["nghenghiep"].ToString();
            txttt.Text = drw["tinhtrang"].ToString();
          txtsobl.Text = drw["sobl"].ToString();
           txthp.Text = drw["hocphi"].ToString();

        }
        public int AutoMa()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-LT17KAQ\\THANGNGUYEN;Initial Catalog=ngoaingu;Persist Security Info=True;User ID=sa;Password=123456@a";
            con.Open();
            //Khoi tao 1 doi tuong DataTable
            DataTable tbl = new DataTable();
            string strSql = "select right(rtrim(sobl),2) from hocvien";
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
           txtsobl.Text = "BL" + "-" + AutoMa().ToString("00");
            txtmhv.Text="";
            txthp.Text = "";
            txtmssv.Text="";
            txtns.Text="";
            txtthv.Text="";
            txttt.Text="";
            txtdc.Text="";
        }
        private void Formcapnhathocvien_Load(object sender, EventArgs e)
        {

           // string sql;
           // //SqlConnection con = new SqlConnection();
           // //con.ConnectionString = "server=DHTH3LTT-BF631B;database=QLTrungTamTinHoc;uid=sa;pwd=;";
           // //con.Open();
           // sql = "select * from hocvien ";
           // //SqlDataAdapter da = new SqlDataAdapter(sql, con);
           // //DataSet ds = new DataSet();
           // obj.getDataSetSQL(sql, "hocvien");
           // da.Fill(ds, "hocvien");
           // dgrhocvien.DataSource = ds.Tables["hocvien"];
           //btluu.Enabled= false;
            mtblhv = obj.getDataTable("hocvien");
            GanDuLieuTuRowVaoText(mtblhv, vitri);
           DataSet ds = new DataSet();
           ds = obj.getDataSet("hocvien");
           dgrhocvien.DataSource = ds.Tables[0];
           btluu.Enabled = false;
           GanDuLieu();
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhapmoi_Click(object sender, EventArgs e)
        {
           
        }
        //--------kiem tra du lieu hop le--------------//
        public bool kiemtradulieuhocvien()
        {
            if (txtmhv.Text == "" || txtthv.Text == "" || txtdc.Text == "" || cblop.Text == "" || txtmssv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return false;
            }
            else
            {
                if (obj.kiemtatrungkhoahocvien(txtmhv.Text))
                {
                    MessageBox.Show(" Mã học viên này đã tồn tại !");
                    return false;
                }
                return true;
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
          
            if (btsua.Enabled == false)
            {

                bool kt;
                //=====================
                
                if (kiemtradulieuhocvien() == false)
                {
                   
                    return;
                }
                else
                {
                    string _mahv, _tenhv, _ns, _malop, _dc, _nghenghiep, _tinhtrang,_mssv,bl,hp;
                    _mahv = txtmhv.Text;
                    _malop = cblop.Text;
                    _mssv = txtmssv.Text;
                    _nghenghiep = txtns.Text;
                    _tenhv = txtthv.Text;
                    _tinhtrang = txttt.Text;
                    _dc = txtdc.Text;
                    _ns = dateTimePicker1.Value.ToShortDateString();
                    bl = txtsobl.Text;
                    hp = txthp.Text;
                    kt = obj.luuhocvien( _mahv,  _mssv, _malop,  _tenhv,  _ns, _dc,_nghenghiep,_tinhtrang,bl,hp);
                    if (kt == false)
                    {
                        MessageBox.Show("Ban Chua Them Duoc!");
                        return;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = obj.hocvien();
                        dgrhocvien.DataSource = ds.Tables[0];
                        MessageBox.Show("Ban Them Thanh Cong !");
                        clearall();
                       btluu.Enabled = false;
                        btsua.Enabled = true;
                       btnhapmoi.Text = "Nhập mới";

                       
                    }
                }
            }
            else
            {
                bool kt;
                //=====================               
                string _mhv, _tenhv, _ns, _ml, _dc, _nn, _tt, _massv,bl,hp;
               
                _ml = cblop.Text;
                _massv = txtmssv.Text;
                _nn = txtns.Text;
                _tenhv = txtthv.Text;
                _tt = txttt.Text;
                _dc = txtdc.Text;
                _ns = dateTimePicker1.Value.ToShortDateString();
                _mhv = dgrhocvien.CurrentCell.Value.ToString();
                bl = txtsobl.Text;
                hp = txthp.Text;
                kt = obj.suathongtinhocvien( _mhv,  _massv,  _ml,  _tenhv,  _ns,  _dc,  _nn,  _tt,bl,hp);
                if (kt == false)
                {
                    MessageBox.Show("Ban Chua sua Duoc!");
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = obj.hocvien();
                    dgrhocvien.DataSource = ds.Tables[0];
                    MessageBox.Show("Ban da sua Thanh Cong !");
                    //ClearAll();
                    btluu.Enabled = false;
                   btsua.Enabled = true;
                   btnhapmoi.Enabled = true;
                   
                   btsua.Text = "Sửa";
                }

            }           
        }

        private void btnhapmoi_Click_1(object sender, EventArgs e)
        {
            clearall();
            setText();

            if (btnhapmoi.Text == "Nhập mới")
            {

                btnhapmoi.Text = "Huỷ Nhập";
                btsua.Enabled = false;
                
                btluu.Enabled = true;
            }
            else
            {

                btluu.Enabled = false;
                btnhapmoi.Text = "Nhập mới";
                btsua.Enabled = true;
                

            }               

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            clearall();
            if (btsua.Text == "Sửa")
            {
                
                txtmhv.Enabled = false;
                btnhapmoi.Enabled= false;
                cblop.Enabled = false;
                txtsobl.Enabled = false;
               btsua.Text = "Huỷ sửa";
               btluu.Enabled = true;

            }
            else
            {
               txtmhv.Enabled = true;
               btluu.Enabled= false;
              btsua.Text= "Sửa";
               btnhapmoi.Enabled = true;
              
            }          
        }

       

        private void bttk_Click(object sender, EventArgs e)
        {
            string str = "hocvien";
            if (radioButton1.Checked == true)
            {
                string ma = "mahv";
                bool kt;
                kt = obj.timkiemall(str, ma, txttk.Text);
                if (kt == false)
                {
                    MessageBox.Show("Dữ liệu bạn cần không tìm thấy !");
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = obj.gettimkiemAll(str, ma, txttk.Text);
                    dgrhocvien.DataSource = ds.Tables[0];
                }
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    string ma = "hoten";
                    bool kt;
                    kt = obj.timkiemall(str, ma, txttk.Text);
                    if (kt == false)
                    {
                        MessageBox.Show("Dữ liệu bạn cần không tìm thấy !");
                        return;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = obj.gettimkiemAll(str, ma,txttk.Text);
                        dgrhocvien.DataSource = ds.Tables[0];
                    }
                }
           
               else
                        {
                            MessageBox.Show("Hay chon cach tim kiem");
                        }
                    
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vitri = 0;

            GanDuLieuTuRowVaoText(mtblhv, vitri);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            vitri -= 1;

            if (vitri < 0)
                vitri = mtblhv.Rows.Count - 1;

            GanDuLieuTuRowVaoText(mtblhv, vitri);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vitri += 1;
            if (vitri > mtblhv.Rows.Count - 1)
                vitri = 0;
            GanDuLieuTuRowVaoText(mtblhv, vitri);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            vitri = mtblhv.Rows.Count - 1;
            GanDuLieuTuRowVaoText(mtblhv, vitri);
        }                   
        
    }
}