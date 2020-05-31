namespace QuanLyKhoNhaHang.QLHoaDonNhapNguyenLieu
{
    partial class FormXoaHoaDon
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
            this.btnTroLai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtMaPhieuDatNLCanXoa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listHoaDon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnTroLai
            // 
            this.btnTroLai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroLai.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnTroLai.Location = new System.Drawing.Point(2, 1);
            this.btnTroLai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTroLai.Name = "btnTroLai";
            this.btnTroLai.Size = new System.Drawing.Size(139, 54);
            this.btnTroLai.TabIndex = 53;
            this.btnTroLai.Text = "Trở Lại";
            this.btnTroLai.UseVisualStyleBackColor = true;
            this.btnTroLai.Click += new System.EventHandler(this.btnTroLai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThoat.Location = new System.Drawing.Point(145, 1);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 54);
            this.btnThoat.TabIndex = 52;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.Location = new System.Drawing.Point(426, 190);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(165, 63);
            this.btnXoa.TabIndex = 51;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // txtMaPhieuDatNLCanXoa
            // 
            this.txtMaPhieuDatNLCanXoa.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuDatNLCanXoa.Location = new System.Drawing.Point(417, 114);
            this.txtMaPhieuDatNLCanXoa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaPhieuDatNLCanXoa.Name = "txtMaPhieuDatNLCanXoa";
            this.txtMaPhieuDatNLCanXoa.Size = new System.Drawing.Size(262, 32);
            this.txtMaPhieuDatNLCanXoa.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "Mã Hóa Đơn Nhập Nguyên Liệu Cần Xóa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(289, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 40);
            this.label1.TabIndex = 48;
            this.label1.Text = "Xóa Phiếu Đặt Nguyên Liệu";
            // 
            // listHoaDon
            // 
            this.listHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listHoaDon.FullRowSelect = true;
            this.listHoaDon.GridLines = true;
            this.listHoaDon.HideSelection = false;
            this.listHoaDon.Location = new System.Drawing.Point(2, 328);
            this.listHoaDon.Name = "listHoaDon";
            this.listHoaDon.Size = new System.Drawing.Size(985, 247);
            this.listHoaDon.TabIndex = 54;
            this.listHoaDon.UseCompatibleStateImageBehavior = false;
            this.listHoaDon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Hóa Đơn Nhập";
            this.columnHeader1.Width = 222;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã Phiếu Đặt Nguyên Liệu";
            this.columnHeader2.Width = 238;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày Lập";
            this.columnHeader3.Width = 205;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã Nhân Viên";
            this.columnHeader4.Width = 527;
            // 
            // FormXoaHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(985, 575);
            this.Controls.Add(this.listHoaDon);
            this.Controls.Add(this.btnTroLai);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtMaPhieuDatNLCanXoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormXoaHoaDon";
            this.Text = "FormXoaHoaDon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTroLai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtMaPhieuDatNLCanXoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listHoaDon;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}