using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoNhaHang.QLHoaDonNhapNguyenLieu
{
    public partial class FormXoaHoaDon : Form
    {
        public FormXoaHoaDon()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            FormQLHoaDonNhapNguyenLieu f = new FormQLHoaDonNhapNguyenLieu();
            f.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
