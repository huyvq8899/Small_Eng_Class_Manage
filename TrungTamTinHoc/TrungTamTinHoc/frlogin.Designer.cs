namespace TrungTamTinHoc
{
    partial class frlogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdnguoiql = new System.Windows.Forms.RadioButton();
            this.rdhocvien = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmk);
            this.groupBox1.Controls.Add(this.txtten);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdnguoiql);
            this.groupBox1.Controls.Add(this.rdhocvien);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn quyền đăng nhập";
            // 
            // txtmk
            // 
            this.txtmk.Location = new System.Drawing.Point(100, 96);
            this.txtmk.Name = "txtmk";
            this.txtmk.PasswordChar = '*';
            this.txtmk.Size = new System.Drawing.Size(100, 20);
            this.txtmk.TabIndex = 5;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(100, 70);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(100, 20);
            this.txtten.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên :";
            // 
            // rdnguoiql
            // 
            this.rdnguoiql.AutoSize = true;
            this.rdnguoiql.Location = new System.Drawing.Point(147, 39);
            this.rdnguoiql.Name = "rdnguoiql";
            this.rdnguoiql.Size = new System.Drawing.Size(74, 17);
            this.rdnguoiql.TabIndex = 1;
            this.rdnguoiql.TabStop = true;
            this.rdnguoiql.Text = "Nhân viên";
            this.rdnguoiql.UseVisualStyleBackColor = true;
            this.rdnguoiql.CheckedChanged += new System.EventHandler(this.rdnguoiql_CheckedChanged);
            // 
            // rdhocvien
            // 
            this.rdhocvien.AutoSize = true;
            this.rdhocvien.Location = new System.Drawing.Point(23, 39);
            this.rdhocvien.Name = "rdhocvien";
            this.rdhocvien.Size = new System.Drawing.Size(62, 17);
            this.rdhocvien.TabIndex = 0;
            this.rdhocvien.TabStop = true;
            this.rdhocvien.Text = "Kế toán";
            this.rdhocvien.UseVisualStyleBackColor = true;
            this.rdhocvien.CheckedChanged += new System.EventHandler(this.rdhocvien_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "ĐĂNG NHẬP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "THOÁT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 205);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frlogin";
            this.Text = "frlogin";
            this.Load += new System.EventHandler(this.frlogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdnguoiql;
        private System.Windows.Forms.RadioButton rdhocvien;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}