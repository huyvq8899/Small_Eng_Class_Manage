using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrungTamTinHoc
{
    public partial class frtimkiemhocvien : Form
    {
        public frtimkiemhocvien()
        {
            InitializeComponent();
        }
        DataTable hocvien = new DataTable();
        Classqlttth obj = new Classqlttth();
        private void frtimkiemhocvien_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             string str = "hocvien";
            if (rdma.Checked == true)
            {
               
                string ma = "mahv";
                bool kt;
                kt = obj.timkiemhv(str,ma,txttimkiem.Text);
                if (kt == false)
                {
                    MessageBox.Show("Dữ liệu bạn cần không tìm thấy !");
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = obj.gettimkiem(str, ma,txttimkiem.Text);
                   dgtimkiem.DataSource = ds.Tables[0];                    
                }
            }
            //else
            //{
                if (rdten.Checked == true)
                {
                   
                    string ma = "hoten";
                    bool kt;
                    kt = obj.timkiemhv(str, ma,txttimkiem.Text);
                    if (kt == false)
                    {
                        MessageBox.Show("Dữ liệu bạn cần không tìm thấy !");
                        return;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = obj.gettimkiem(str, ma,txttimkiem.Text);
                        dgtimkiem.DataSource = ds.Tables[0];        
                    }
                }
               //---------
                    if (rdthilai.Checked==true)
                    {
                        txttimkiem.Text = "";
                
                bool kt;
                kt = obj.hvthilai();
                if (kt == false)
                {
                    MessageBox.Show("Dữ liệu bạn cần không tìm thấy !");
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = obj.gettimkiemhvthilai();
                   dgtimkiem.DataSource = ds.Tables[0];                    
                }
            }
            //else
            //{
                if (rddat.Checked == true)
                {
                    txttimkiem.Text = "";
                    //string ma = "hoten";
                    bool kt;
                    kt = obj.hvdat();
                    if (kt == false)
                    {
                        MessageBox.Show("Dữ liệu bạn cần không tìm thấy !");
                        return;
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = obj.gettimkiemhvdat();
                        dgtimkiem.DataSource = ds.Tables[0];        
                    }
                }
               
                        //else                       
                        //{
                        //    MessageBox.Show("Hay chon cach tim kiem");
                        //}
                    //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frhuongdantkhv frm = new frhuongdantkhv();
            frm.ShowDialog();
        }

        private void rdma_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rddat_CheckedChanged(object sender, EventArgs e)
        {

        }
                }
    }

