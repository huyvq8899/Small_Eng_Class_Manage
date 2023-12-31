using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrungTamTinHoc
{
    public partial class frphong : Form
    {
        public frphong()
        {
            InitializeComponent();
        }
        Classqlttth obj = new Classqlttth();
        int vitri = 0;
        DataTable mtblgv = new DataTable();
        //======//

        void clearall()
        {
            txtmap.Clear();
            txttenp.Clear();
            txtddp.Clear();
            txtmap.Focus();

        }
        //====//
        private void GanDuLieuTuRowVaoText(DataTable tbl, int vitri)
        {
            DataRow drw;
            drw = tbl.Rows[vitri];
            txtmap.Text = drw["maphong"].ToString();
           txttenp.Text = drw["tenphong"].ToString();
           txtddp.Text = drw["dacdiem"].ToString();
           
        }
        public bool kiemtradulieuphong()
        {
            if (txtmap.Text==""||txttenp.Text==""||txtddp.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return false;
            }
            else
            {
                if (obj.kiemtatrungkhoaphong(txtmap.Text))
                {
                    MessageBox.Show(" Mã phòng này đã tồn tại !");
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
                if (kiemtradulieuphong() == false)
                {

                    return;
                }
                else
                {
                    string mp,ten,dd;
                    mp = txtmap.Text;
                    ten = txttenp.Text;
                    dd = txtddp.Text;
                   

                    kt = obj.luuphong(mp,ten,dd);
                    if (kt == false)
                    {
                        MessageBox.Show("Ban Chua Them Duoc!");
                        return;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = obj.phong();
                        dgphong.DataSource = ds.Tables[0];
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
                string mp, ten, dd;
                mp = txtmap.Text;
                ten = txttenp.Text;
                dd = txtddp.Text;
               mp = dgphong.CurrentCell.Value.ToString();
               kt = obj.suathongtinphong(mp, ten, dd);
                if (kt == false)
                {
                    MessageBox.Show("Ban Chua sua Duoc!");
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = obj.phong();
                    dgphong.DataSource = ds.Tables[0];
                    MessageBox.Show("Ban da sua Thanh Cong !");
                    //ClearAll();
                    btluu.Enabled = false;
                    btsua.Enabled = true;
                    btnhapmoi.Enabled = true;

                    btsua.Text = "Sửa";
                }

            }           
        }

        private void btnhapmoi_Click(object sender, EventArgs e)
        {
            clearall();


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

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (btsua.Text == "Sửa")
            {

                txtmap.Enabled = false;
                btnhapmoi.Enabled = false;

                btsua.Text = "Huỷ sửa";
                btluu.Enabled = true;

            }
            else
            {
                txtmap.Enabled = true;
                btluu.Enabled = false;
                btsua.Text = "Sửa";
                btnhapmoi.Enabled = true;


            }          
        }

        private void frphong_Load(object sender, EventArgs e)
        {
            mtblgv = obj.getDataTable("phong");
            GanDuLieuTuRowVaoText(mtblgv, vitri);
            DataSet ds = new DataSet();
            ds = obj.getDataSet("phong");
            dgphong.DataSource = ds.Tables[0];
            btluu.Enabled = false;
            clearall();
        }

        private void dgphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}