using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoNhaHang.QLPhieuDatNguyenLieu;
using QuanLyKhoNhaHang.model;


namespace QuanLyKhoNhaHang.QLPhieuDatNguyenLieu
{
    public partial class FormSuaPhieuDatNL : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormSuaPhieuDatNL()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            FormQLPhieuDatNL f = new FormQLPhieuDatNL();
            f.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormSuaPhieuDatNL_Load(object sender, EventArgs e)
        {
            List<PhieuDatNL> DS = db.PhieuDatNLs.ToList();
            foreach (PhieuDatNL nl in DS)
            {
                ListViewItem list = new ListViewItem(nl.MaPDNL.ToString());
                list.SubItems.Add(nl.NgayLap.ToString());
                list.SubItems.Add(nl.MaNCC.ToString());
                list.SubItems.Add(nl.MaNV.ToString());

                listView1.Items.Add(list);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuDatNL ThemNL = new PhieuDatNL()
                {
                    MaPDNL = int.Parse(txtMaPhieuDatNLCanSua.Text),

                    MaNCC = int.Parse(txtMaNCC.Text),
                    MaNV = int.Parse(txtMaNV.Text),
                  
                };
              //  db.PhieuDatNLs.Remove()
                db.PhieuDatNLs.Add(ThemNL);
                db.SaveChanges();

                ListViewItem list = new ListViewItem();
                list.SubItems.Add(ThemNL.MaPDNL.ToString());
                list.SubItems.Add(ThemNL.MaNCC.ToString());
                list.SubItems.Add(ThemNL.MaNV.ToString());
                listView1.Items.Add(list);
            }
            catch (Exception a)
            {
                MessageBox.Show("Có lỗi rồi!!!" + a.Message);
            }
        }
    }
}
