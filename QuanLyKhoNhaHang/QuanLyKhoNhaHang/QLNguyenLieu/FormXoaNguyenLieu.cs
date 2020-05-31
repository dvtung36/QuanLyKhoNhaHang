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

namespace QuanLyKhoNhaHang.QLNguyenLieu
{
    public partial class FormXoaNguyenLieu : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormXoaNguyenLieu()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            FormQLNguyenLieu f = new FormQLNguyenLieu();
            f.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormXoaNguyenLieu_Load(object sender, EventArgs e)
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // NguyenLieu nl = new NguyenLieu { MaNL = int.Parse(txtMaNLCanSua.Text) };
                NguyenLieu nl = db.NguyenLieux.Find(int.Parse(txtMaNLCanSua.Text));
                db.NguyenLieux.Remove(nl);
                db.SaveChanges();
                MessageBox.Show("Xóa Thành Công");
                FormXoaNguyenLieu_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }
        
        }
    }
}
