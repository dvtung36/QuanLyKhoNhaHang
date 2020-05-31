using QuanLyKhoNhaHang.model;
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
    public partial class FormThemHoaDon : Form
    {
        MyDBcontext db = new MyDBcontext();
        public FormThemHoaDon()
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

        private void FormThemHoaDon_Load(object sender, EventArgs e)
        {
            List<HoaDonNhapNL> DSHoaDon = db.HoaDonNhapNLs.ToList();
            foreach(HoaDonNhapNL hd in DSHoaDon)
            {
                ListViewItem list = new ListViewItem(hd.MaHDN.ToString());
                list.SubItems.Add(hd.MaPDNL.ToString());
                list.SubItems.Add(hd.NgayLap.ToString());
                list.SubItems.Add(hd.MaHDN.ToString());
        
               

                listHoaDon.Items.Add(list);
            }
            comboBox1.DataSource = db.NhanViens.ToList();
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "MaNV";
           

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonNhapNL ThemHD = new HoaDonNhapNL()
                {
                    MaHDN = int.Parse(txtMaHDN.Text),
                    MaPDNL = int.Parse(txtMaPhieuDatNL.Text),
                    NgayLap = dateTimePicker1.Value,
                    MaNV = int.Parse(comboBox1.SelectedValue.ToString())
                };
                db.HoaDonNhapNLs.Add(ThemHD);
                db.SaveChanges();

                ListViewItem list = new ListViewItem(ThemHD.MaHDN.ToString());
                list.SubItems.Add(ThemHD.MaPDNL.ToString());
                list.SubItems.Add(ThemHD.NgayLap.ToString());
                list.SubItems.Add(ThemHD.MaHDN.ToString());
                list.SubItems.Add(ThemHD.MaNV.ToString());

                listHoaDon.Items.Add(list);
            }  
            catch(Exception a)
            {
                MessageBox.Show("Có lỗi rồi!!!" + a.Message);
            }
        }
    }
}
