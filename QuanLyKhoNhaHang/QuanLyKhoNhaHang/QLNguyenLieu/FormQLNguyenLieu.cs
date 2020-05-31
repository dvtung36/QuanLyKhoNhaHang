using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoNhaHang.QLNguyenLieu;
using QuanLyKhoNhaHang.model;

namespace QuanLyKhoNhaHang.QLNguyenLieu
{
    public partial class FormQLNguyenLieu : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormQLNguyenLieu()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemNguyenLieu f = new FormThemNguyenLieu();
            f.Show();
            this.Hide();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaNguyenLieu f = new FormSuaNguyenLieu();
            f.Show();
            this.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FormXoaNguyenLieu f = new FormXoaNguyenLieu();
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

        private void FormQLNguyenLieu_Load(object sender, EventArgs e)
        {

            List<NguyenLieu> DS = db.NguyenLieux.ToList();
            foreach (NguyenLieu nl in DS)
            {
                ListViewItem list = new ListViewItem(nl.MaNL.ToString());
                list.SubItems.Add(nl.TenNL.ToString());
                list.SubItems.Add(nl.LoaiTuoiKho.ToString());
                list.SubItems.Add(nl.GiaTien.ToString());
                list.SubItems.Add(nl.SoLuong.ToString());
                list.SubItems.Add(nl.TenDonVi.ToString());


                listView1.Items.Add(list);
            }
        }
    }
}
