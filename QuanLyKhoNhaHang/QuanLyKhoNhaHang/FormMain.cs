using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoNhaHang.model;
using QuanLyKhoNhaHang.QLNguyenLieu;
using QuanLyKhoNhaHang.QLPhieuDatNguyenLieu;

namespace QuanLyKhoNhaHang
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQLNguyenLieu_Click(object sender, EventArgs e)
        {
            FormQLNguyenLieu f = new FormQLNguyenLieu();
            f.Show();
            this.Hide();
        }

        private void btnQLPhieuDatNL_Click(object sender, EventArgs e)
        {
            FormQLPhieuDatNL f = new FormQLPhieuDatNL();
            f.Show();
            this.Hide();
        }
    }
}
