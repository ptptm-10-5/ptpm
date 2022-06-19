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
using System.IO;

namespace QLThietBi.Presentation
{
    public partial class GUI_BanHang : Form
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        BLL_NhanVien bllNhanVien = new BLL_NhanVien();
        BLL_LoaiThietBi bllLoai = new BLL_LoaiThietBi();
        BLL_ThietBi bllThietBi = new BLL_ThietBi();
        BLL_KhachHang bllKhachHang = new BLL_KhachHang();
        BLL_VIEW_GioHang bllGioHang = new BLL_VIEW_GioHang();
        BLL_DonHang bllDonHang = new BLL_DonHang();
        BLL_CTDonHang bllCTDonHang = new BLL_CTDonHang();

        public GUI_BanHang()
        {
            InitializeComponent();
        }        

        private void GUI_DonHang_Load(object sender, EventArgs e)
        {
            loadCbbLoai();
            loadGrbThietBi();
            loadCbbKhachHang();
            loadCbbGia();
        }

        void loadCbbLoai()
        {
            cbbLoai.DataSource = bllLoai.loadLoaiThietBi();
            cbbLoai.DisplayMember = "TENLOAI";
            cbbLoai.ValueMember = "MALOAI";
        }
        void loadGrbThietBi()
        {
            dtgSanPham.DataSource = bllThietBi.loadThietBi();
            dtgSanPham.Columns[0].Visible = false;
            dtgSanPham.Columns[5].Visible = false;
            dtgSanPham.Columns[6].Visible = false;
            dtgSanPham.Columns[7].Visible = false;
            dtgSanPham.Columns[8].Visible = false;
            dtgSanPham.Columns[9].Visible = false;
            dtgSanPham.Columns[1].Width = 250;
            dtgSanPham.Columns[3].DefaultCellStyle.Format = "#,#";
            dtgSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            
        }
        void loadCbbKhachHang()
        {
            cbbKH.DataSource = bllKhachHang.loadKhachHang();
            cbbKH.DisplayMember = "TENKH";
            cbbKH.ValueMember = "MAKH";
        }
        void loadCbbGia()
        {
            cbbGia.Items.Add("< 200,000");
            cbbGia.Items.Add("< 500,000");
            cbbGia.Items.Add("< 100,000");
            cbbGia.Items.Add("< 2,000,000");
            cbbGia.Items.Add("< 5,000,000");
            cbbGia.Items.Add("< 10,00,000");
            cbbGia.Items.Add("< 20,00,000");
            cbbGia.Items.Add("> 20,00,000");
        }
        

        void loadDgvDSChon(int pMaDH)
        {
            dgvDSChon.DataSource = bllGioHang.loadVIEWGioHangMaDH(pMaDH);
            dgvDSChon.Columns[0].Visible = false;
            dgvDSChon.Columns[1].Visible = false;            
            dgvDSChon.Columns[6].Visible = false;
            dgvDSChon.Columns[4].Width = 150;
            dgvDSChon.Columns[4].DefaultCellStyle.Format = "#,#";
            dgvDSChon.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;   
            dgvDSChon.Columns[5].Width = 150;
            dgvDSChon.Columns[5].DefaultCellStyle.Format = "#,#";
            dgvDSChon.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;   
        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maL = -1;
            try
            {
                 maL = int.Parse( cbbLoai.SelectedValue.ToString());
                 dtgSanPham.DataSource = bllThietBi.loadThietBiTheoMaLoai(maL);
            }
            catch { }            
        }

        private void dtgSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSL.Value = 1;
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            pcbAnhTB.Image = Image.FromFile(projectPath + "\\Resources\\" +
                dtgSanPham.CurrentRow.Cells[2].Value.ToString());
        }

        int maDH = -1;
        private void btnDat_Click(object sender, EventArgs e)
        {
            
            int maKH = int.Parse(cbbKH.SelectedValue.ToString());
            int maNV = NVDangNhap.nv;
            int sl = int.Parse(txtSL.Value.ToString());

            if(dtgSanPham.SelectedRows.Count < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo");
            }
            else
            {
                if(sl < 1)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo");
                    txtSL.Focus();
                    return;
                }
                KHACHHANG kh = bllKhachHang.timKhachHangTheoMa(maKH);
                if (kh == null)
                {
                    if(DialogResult.Yes == MessageBox.Show("Không tìm thấy khách hàng: " + cbbKH.SelectedItem.ToString() 
                            + "\n\n Bạn có muốn thêm khách hàng mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        GUI_KhachHang frm = new GUI_KhachHang();
                        frm.ShowDialog();
                        cbbKH.Focus();
                    }
                    return;
                }
                    
                DONHANG dh = new DONHANG();
                dh.MAKH = maKH;
                dh.MANV = maNV;
                dh.NGAYLAP = DateTime.Now;
                dh.HINHTHUCTT = "THANH TOÁN";
                if(chkTraGop.Checked == true)
                    dh.HINHTHUCTT = "TRẢ GÓP";
                dh.TONGTIEN = 0;
                dh.TINHTRANG = "CHƯA THANH TOÁN";

                int kq = bllDonHang.themDonHang(dh);

                if(kq == 0)
                {
                    MessageBox.Show("Thất bại!", "Thông báo");
                    return;
                }
                else
                {                    
                    maDH = dh.MADH;
                    CTDONHANG ct = new CTDONHANG();
                    ct.MADH = maDH;
                    ct.MATB = int.Parse( dtgSanPham.CurrentRow.Cells[0].Value.ToString());

                    THIETBI tb = bllThietBi.timThietBiTheoMa(ct.MATB);

                    ct.GIABAN = tb.GIA;
                    ct.SOLUONG = int.Parse( txtSL.Value.ToString());
                    ct.THANHTIEN = ct.GIABAN * ct.SOLUONG;

                    kq = bllCTDonHang.themCTDonHang(ct);
                    if(kq == 1)
                    {
                        MessageBox.Show("Thành công!", "Thông báo");
                        loadDgvDSChon(maDH);
                        loadThanhTien();
                    }                        
                    else
                    {
                        MessageBox.Show("Thất bại!", "Thông báo");
                        bllDonHang.xoaDonHang(dh);
                        maDH = -1;
                        loadDgvDSChon(maDH);
                        loadThanhTien();
                    }
                        
                }
            }

        }       

        void loadThanhTien()
        {
            txtThanhTien.Text = bllCTDonHang.tinhTongCTDonHang(maDH).ToString("#,#");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DONHANG dh = bllDonHang.timDonHangTheoMa(maDH);

            if (dh == null)
                return;

            int kq = bllDonHang.thanhToanDonHang(dh);
            if (kq == 1)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                loadDgvDSChon(maDH);
                loadThanhTien();
                maDH = -1;
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
                loadDgvDSChon(maDH);
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            DONHANG dh = bllDonHang.timDonHangTheoMa(maDH);

            if (dh == null)
                return;

            int kq = bllDonHang.xoaDonHang(dh);
            if (kq == 1)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                loadDgvDSChon(maDH);
                loadThanhTien();
                maDH = -1;
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
                loadDgvDSChon(maDH);
            }
        }

        private void btnHuyCTDonHang_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse( dgvDSChon.CurrentRow.Cells[1].Value.ToString());
            CTDONHANG ct = bllCTDonHang.timCTDonHangTheoMaSP(maDH, maSP);

            if (ct == null)
                return;

            int kq = bllCTDonHang.xoaCTDonHang(ct);
            if (kq == 1)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                loadDgvDSChon(maDH);
                loadThanhTien();
                maDH = -1;
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
                loadDgvDSChon(maDH);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtgSanPham.DataSource = bllThietBi.loadThietBiTheoTen(txtTimKiem.Text);
        }

        private void cbbGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int giaT = int.MaxValue;
            int giaD = 0;
            int index = cbbGia.SelectedIndex;
            if (index == 0)
            {
                giaD = 0;
                giaT = 200000;
            }                
            else if (index == 1)
                {
                    giaD = 200000;
                    giaT = 500000;
                }                 
            else if (index == 2)
                {
                    giaD = 500000;
                    giaT = 1000000;
                }                 
            else if (index == 3)
                {
                    giaD = 1000000;
                    giaT = 2000000;
                }                 
            else if (index == 4)
                {
                    giaD = 2000000;
                    giaT = 5000000;
                } 
            else if (index == 5)
                {
                    giaD = 5000000;
                    giaT = 10000000;
                } 
            else if (index == 6)
                {
                    giaD = 10000000;
                    giaT = 20000000;
                }
            else if (index == 7)
                {
                    giaD = 20000000;
                    giaT = int.MaxValue;
                }     
            dtgSanPham.DataSource = bllThietBi.loadThietBiTheoGia(giaD,giaT);

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }
        
    }
}
