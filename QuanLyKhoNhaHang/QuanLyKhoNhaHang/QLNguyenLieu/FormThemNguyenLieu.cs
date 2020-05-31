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
    public partial class FormThemNguyenLieu : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormThemNguyenLieu()
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

        private void FormThemNguyenLieu_Load(object sender, EventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                NguyenLieu ThemNL = new NguyenLieu()
                {
                    MaNL = int.Parse(txtMaNL.Text),
                    TenNL = txtTenNL.Text.ToString(),
                    GiaTien = int.Parse(txtGiaTien.Text),
                    SoLuong = float.Parse(txtSoLuong.Text),
                    TenDonVi = txtTenDonVi.Text.ToString()
                   
                };
                db.NguyenLieux.Add(ThemNL);
                db.SaveChanges();

                ListViewItem list = new ListViewItem(ThemNL.MaNL.ToString());
           
                list.SubItems.Add(ThemNL.TenNL.ToString());
                list.SubItems.Add(ThemNL.LoaiTuoiKho.ToString());
                list.SubItems.Add(ThemNL.GiaTien.ToString());
                list.SubItems.Add(ThemNL.SoLuong.ToString());
                list.SubItems.Add(ThemNL.TenDonVi.ToString());


                listView1.Items.Add(list);
            }
            catch (Exception a)
            {
                MessageBox.Show("Có lỗi rồi!!!" + a.Message);
            }
        }
    }
}
