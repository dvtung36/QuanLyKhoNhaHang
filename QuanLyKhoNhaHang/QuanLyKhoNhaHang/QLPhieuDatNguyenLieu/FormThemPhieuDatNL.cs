﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoNhaHang.QLPhieuDatNguyenLieu
{
    public partial class FormThemPhieuDatNL : Form
    {
        public FormThemPhieuDatNL()
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
    }
}