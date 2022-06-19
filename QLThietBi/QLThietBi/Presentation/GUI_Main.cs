﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLThietBi;
using BLL_QLThietBi;

namespace QLThietBi.Presentation
{
    public partial class GUI_Main : Form
    {
        QL_LinhKienDataContext dbLinhKien = new QL_LinhKienDataContext();
        BLL_DMMangHinh bllDMMangHinh = new BLL_DMMangHinh();
        public GUI_Main()
        {
            InitializeComponent();
        }

        private void GUI_Main_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            int maNV = NVDangNhap.nv;
            loadMenuDangNhap(maNV);

            GUI_BanHang fr = new GUI_BanHang();
            fr.MdiParent = this;
            fr.Show();
        }
        
        void loadMenuDangNhap(int maNV)
        {            
            loadDanhSachMangHinh(maNV);
            if (maNV == -1)
                mnuDangNhap.Text = "Đăng Nhập";
            else
                mnuDangNhap.Text = "Đăng Xuất";
        }

        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }

        private void cơSơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_CoSo));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_CoSo fr = new GUI_CoSo();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_NhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_NhanVien fr = new GUI_NhanVien();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void loaiThiêtBiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_Loai));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_Loai fr = new GUI_Loai();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_KhachHang));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_KhachHang fr = new GUI_KhachHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void thiêtBiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_ThietBi));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_ThietBi fr = new GUI_ThietBi();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void hoaĐơnNhâpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_NhapHang));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_NhapHang fr = new GUI_NhapHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_PhanQuyen));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_PhanQuyen fr = new GUI_PhanQuyen();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            NVDangNhap.nv = -1;
            loadMenuDangNhap(NVDangNhap.nv);
            Form frm = kiemtratontai(typeof(GUI_DangNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_DangNhap fr = new GUI_DangNhap();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void hơnĐơnXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_DonHang));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_DonHang fr = new GUI_DonHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        void loadDanhSachMangHinh(int maNV)
        {
            List<DMMANGHINH> dsMangHinh = bllDMMangHinh.loadDMMangHinhTheoMaNV(maNV, false);
            foreach (var item in dsMangHinh)
            {
                var item2 = item;
                switch(item.TENMH)
                {
                    case "Màng Hình Nhân Viên":
                        {
                            if (item.CHON == false)
                                mnuNhanVien.Enabled = false;
                            break;
                        }
                    case "Màng Hình Khách Hàng":
                        {
                            if (item.CHON == false)
                                mnuKhachHang.Enabled = false;
                            break;
                        }
                    case "Màng Hình Thiết Bị":
                        {
                            if (item.CHON == false)
                                mnuThietBi.Enabled = false;
                            break;
                        }
                    case "Màng Hình Loại Thiết Bị":
                        {
                            if (item.CHON == false)
                                mnuLoaiTB.Enabled = false;
                            break;
                        }
                    case "Màng Hình Cơ Sở":
                        {
                            if (item.CHON == false)
                                mnuCoSo.Enabled = false;
                            break;
                        }
                    case "Màng Hình Đơn Nhập":
                        {
                            if (item.CHON == false)
                                mnuDonNhap.Enabled = false;
                            break;
                        }
                    case "Màng Hình Phân Quyền":
                        {
                            if (item.CHON == false)
                            {
                                mnuAdmin.Visible = false;
                                mnuPhanQuyen.Visible = false;                                
                            }
                                
                            break;
                        }
                    default: break;
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {            
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn thoát!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))            
                this.Visible = false;                            
        }

        

        

        
    }
}
