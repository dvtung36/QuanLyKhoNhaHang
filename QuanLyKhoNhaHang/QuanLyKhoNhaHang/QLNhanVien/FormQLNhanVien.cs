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

namespace QuanLyKhoNhaHang.QLNhanVien
{
    public partial class FormQLNhanVien : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormQLNhanVien()
        {
            InitializeComponent();
        }

        private void FormQLNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVien> DsNV = db.NhanViens.ToList();
            foreach (NhanVien nv in DsNV)
            {
                ListViewItem item = new ListViewItem(nv.MaNV.ToString());
                item.SubItems.Add(nv.HoTen.ToString());
                item.SubItems.Add(nv.NgaySinh.ToString());
                item.SubItems.Add(nv.DiaChi.ToString());
                item.SubItems.Add(nv.SDT.ToString());

                listDsNV.Items.Add(item);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.Show();
            this.Hide();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien()
                {
                    MaNV = int.Parse(txtMaNV.Text),
                    HoTen = txtHoTen.Text,
                    NgaySinh = dateTimePicker1.Value,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                };
                db.NhanViens.Add(nv);
                db.SaveChanges();
                MessageBox.Show("them thanh cong");
                FormQLNhanVien_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Them That bai. Chi tiet loi: " + ex.Message);
            }
        }

        private void listDsNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDsNV.SelectedItems.Count > 0)
            {
                ListViewItem itemSelected = listDsNV.SelectedItems[0];
                txtMaNV.Text = itemSelected.SubItems[0].Text;
                txtHoTen.Text = itemSelected.SubItems[1].Text;
                dateTimePicker1.Text = itemSelected.SubItems[2].Text;
                txtDiaChi.Text = itemSelected.SubItems[3].Text;
                txtSDT.Text = itemSelected.SubItems[4].Text;


            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = db.NhanViens.Find(int.Parse(txtMaNV.Text));
                nv.HoTen = txtHoTen.Text;
                nv.NgaySinh = dateTimePicker1.Value;
                nv.DiaChi = txtDiaChi.Text;
                nv.SDT = txtSDT.Text;

                db.SaveChanges();
                MessageBox.Show("Sua thanh cong");
                FormQLNhanVien_Load(sender, e);
                ListViewItem item = new ListViewItem(nv.MaNV.ToString());
                item.SubItems.Add(nv.HoTen.ToString());
                item.SubItems.Add(nv.NgaySinh.ToString());
                item.SubItems.Add(nv.DiaChi.ToString());
                item.SubItems.Add(nv.SDT.ToString());

                listDsNV.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = db.NhanViens.Find(int.Parse(txtMaNV.Text));
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                MessageBox.Show("Xóa Thành Công");
                FormQLNhanVien_Load(sender, e);
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message); }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            FormTimKiemNV f = new FormTimKiemNV();
            f.Show();
            this.Hide();
        }
    }
}
