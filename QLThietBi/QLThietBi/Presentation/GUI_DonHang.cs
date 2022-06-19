using System;
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
    public partial class GUI_DonHang : Form
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        
        BLL_LoaiThietBi bllLoai = new BLL_LoaiThietBi();
        BLL_ThietBi bllThietBi = new BLL_ThietBi();
        BLL_KhachHang bllKhachHang = new BLL_KhachHang();
        BLL_NhanVien bllNhanVien = new BLL_NhanVien();
        BLL_DonHang bllDonHang = new BLL_DonHang();
        BLL_CTDonHang bllCTDonHang = new BLL_CTDonHang();

        public GUI_DonHang()
        {
            InitializeComponent();
        }

        private void GUI_DonHang_Load(object sender, EventArgs e)
        {
            loadCbbNhanVien();
            loadCbbKhachHang();
            loadCbbThietBi();
            loadCbbHinhThuc();
            loadCbbTrangThai();
        }
        void loadDgvDonHang()
        {
            dgvDonHang.DataSource = bllDonHang.loadDonHang();
            dgvDonHang.Columns[0].Visible = false;
            dgvDonHang.Columns[1].Width = 60;
            dgvDonHang.Columns[2].Width = 60;            
            dgvDonHang.Columns[3].Width = 150;
            dgvDonHang.Columns[4].Width = 100;
            dgvDonHang.Columns[4].DefaultCellStyle.Format = "#,#";
            dgvDonHang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDonHang.Columns[5].Width = 250;                        
            dgvDonHang.Columns[6].Width = 250;                        
        }        
        void loadDgvCTDonHang(int maDH)
        {
            dgvCTDonHang.DataSource = bllCTDonHang.loadCTDonHang();
            dgvCTDonHang.Columns[0].Visible = false;
            dgvCTDonHang.Columns[1].Width = 60;
            dgvCTDonHang.Columns[2].Width = 60; 
            dgvCTDonHang.Columns[3].Width = 100;
            dgvCTDonHang.Columns[3].DefaultCellStyle.Format = "#,#";
            dgvCTDonHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDonHang.Columns[4].Width = 100;
            dgvCTDonHang.Columns[4].DefaultCellStyle.Format = "#,#";
            dgvCTDonHang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        void loadCbbNhanVien()
        {
            cbbNhanVien.DataSource = bllNhanVien.loadNhanVien();
            cbbNhanVien.DisplayMember = "TENV";
            cbbNhanVien.ValueMember = "MANV";
        }
        void loadCbbKhachHang()
        {
            cbbKhachHang.DataSource = bllKhachHang.loadKhachHang();
            cbbKhachHang.DisplayMember = "TENKH";
            cbbKhachHang.ValueMember = "MAKH";
        }
        void loadCbbThietBi()
        {
            cbbSanPham.DataSource = bllThietBi.loadThietBi();
            cbbSanPham.DisplayMember = "TENSP";
            cbbSanPham.ValueMember = "MASP";
        }
        void loadCbbHinhThuc()
        {
            cbbHinhThuc.Items.Add("Trả góp");
            cbbHinhThuc.Items.Add("Thanh toán");
        }
        void loadCbbTrangThai()
        {
            cbbTinhTrang.Items.Add("Đã thanh toán");
            cbbTinhTrang.Items.Add("Chưa thanh toán");
        }

        int maDH = -1;
        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maDH = int.Parse( dgvDonHang.CurrentRow.Cells[0].Value.ToString());
            txtMa.Text = maDH.ToString();
            cbbKhachHang.SelectedValue = dgvDonHang.CurrentRow.Cells[1].Value.ToString();
            cbbNhanVien.SelectedValue = dgvDonHang.CurrentRow.Cells[2].Value.ToString();
            dtpNgayLap.Text = dgvDonHang.CurrentRow.Cells[3].Value.ToString();
            txtThanhTien.Text = dgvDonHang.CurrentRow.Cells[4].Value.ToString();
            cbbHinhThuc.SelectedValue = dgvDonHang.CurrentRow.Cells[5].Value.ToString();
            cbbTinhTrang.SelectedValue = dgvDonHang.CurrentRow.Cells[6].Value.ToString();
        }

        private void dgvCTDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbSanPham.SelectedValue = dgvCTDonHang.CurrentRow.Cells[1].Value.ToString();
            txtSL.Value = int.Parse( dgvCTDonHang.CurrentRow.Cells[2].Value.ToString());
            txtGiaBan.Text = int.Parse( dgvCTDonHang.CurrentRow.Cells[3].Value.ToString()).ToString("#,#");
            
        }
        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            DONHANG dh = bllDonHang.timDonHangTheoMa(maDH);

            if (dh == null)
                return;

            dgvCTDonHang.DataSource = bllCTDonHang.loadCTDonHangTheoMa(maDH);
            
        }

        private void btnThem_Click(object sender, EventArgs e)          /// Chưa xong
        {
            int maKH = -1;
            int maNV = NVDangNhap.nv;            

            KHACHHANG kh = bllKhachHang.timKhachHangTheoMa(maKH);
            if (kh == null)
            {
                if (DialogResult.Yes == MessageBox.Show("Không tìm thấy khách hàng: " + cbbKhachHang.SelectedItem.ToString()
                        + "\n\n Bạn có muốn thêm khách hàng mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    GUI_KhachHang frm = new GUI_KhachHang();
                    frm.ShowDialog();
                    cbbKhachHang.Focus();
                }
                return;
            }
            else
            {
                int maSP = int.Parse(cbbSanPham.SelectedValue.ToString());
                CTDONHANG ct = new CTDONHANG();
                ct.MADH = maDH;
                ct.MATB = maSP;
                ct.SOLUONG = int.Parse(txtSL.Value.ToString());
                ct.GIABAN = int.Parse(txtGiaBan.Text);
                ct.THANHTIEN = ct.SOLUONG * ct.GIABAN;

                int kq = bllCTDonHang.themCTDonHang(ct);
                if (kq == 1)
                {
                    MessageBox.Show("Thành công!", "Thông báo");
                    loadDgvCTDonHang(maDH);
                    loadThanhTien();
                }
                else
                {
                    MessageBox.Show("Thất bại!", "Thông báo");                    
                    maDH = -1;
                    loadDgvCTDonHang(maDH);
                    loadThanhTien();
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(cbbSanPham.SelectedValue.ToString());
            CTDONHANG ct = bllCTDonHang.timCTDonHangTheoMaSP(maDH, maSP);

            if (ct == null)
                return;

            int kq = bllCTDonHang.xoaCTDonHang(ct);
            if (kq == 1)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                loadDgvCTDonHang(maDH);
                loadThanhTien();
                maDH = -1;
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
                loadDgvCTDonHang(maDH);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(cbbSanPham.SelectedValue.ToString());
            CTDONHANG ct = bllCTDonHang.timCTDonHangTheoMaSP(maDH, maSP);
            ct.SOLUONG = int.Parse(txtSL.Value.ToString());

            int kq = bllCTDonHang.suaCTDonHang(ct);
            if (kq == 1)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                loadDgvCTDonHang(maDH);
                loadThanhTien();
                maDH = -1;
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
                loadDgvCTDonHang(maDH);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
        
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maSP = -1;
            try
            {
                maSP = int.Parse( cbbSanPham.SelectedValue.ToString());

                THIETBI tb = bllThietBi.timThietBiTheoMa(maSP);
                txtGiaBan.Text = tb.GIA.ToString();
            }catch(Exception ex)
            { }
        }

        void loadThanhTien()
        {
            txtThanhTien.Text = bllCTDonHang.tinhTongCTDonHang(maDH).ToString("#,#");
        }

        
    }
}
