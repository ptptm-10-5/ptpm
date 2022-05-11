﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class GUI_DangNhap : Form
    {
        QL_LinhKienDataContext dbLinhKien;
        BLL_NhanVien bllNhanVien;
        public GUI_DangNhap()
        {
            InitializeComponent();
        }

        private void GUI_DangNhap_Load(object sender, EventArgs e)
        {
            dbLinhKien = new QL_LinhKienDataContext();
            bllNhanVien = new BLL_NhanVien();
        }

 
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Không được bỏ trống tên  tài khoảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtTenTK.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Không được bỏ trống mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtMatKhau.Focus();
                return;
            }
            string tenDN = txtTenTK.Text.ToString().Trim();
            string matKhau = txtMatKhau.Text.ToString().Trim();
            NHANVIEN nv = bllNhanVien.timNhanVienTheoSDT(tenDN, matKhau);
            if(nv == null)
            {
                MessageBox.Show("Tài khoảng hoặc mật khẩu không chính xác!/n/nVui lòng nhập đúng thông tin tài khoảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtTenTK.Focus();
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
