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

namespace QuanLyKhoNhaHang.QLHoaDonNhapNguyenLieu
{
    public partial class FormQLHoaDonNhapNguyenLieu : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormQLHoaDonNhapNguyenLieu()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemHoaDon f = new FormThemHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaHoaDon f = new FormSuaHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FormXoaHoaDon f = new FormXoaHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormQLHoaDonNhapNguyenLieu_Load(object sender, EventArgs e)
        {
            List<HoaDonNhapNL> DSHoaDon = db.HoaDonNhapNLs.ToList();
            foreach (HoaDonNhapNL hd in DSHoaDon)
            {
                ListViewItem list = new ListViewItem(hd.MaHDN.ToString());
                list.SubItems.Add(hd.MaPDNL.ToString());
                list.SubItems.Add(hd.NgayLap.ToString());
                list.SubItems.Add(hd.MaHDN.ToString());

                listHoaDon.Items.Add(list);
            }
        }

        private void listHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
