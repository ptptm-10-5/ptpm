using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QLThietBi;
using DTO_QLThietBi;
using System.IO;
namespace QLThietBi
{
    public partial class frmNhapHang : Form
    {
        BLL_DonNhap blldonnhap = new BLL_DonNhap();
        BLL_NhaCungCap bllcungcap = new BLL_NhaCungCap();
        BLL_NhanVien bllnhanvien = new BLL_NhanVien();
        BLL_ThietBi bllthietbi = new BLL_ThietBi();
        BLL_CTDonNhap bllctdonnhap = new BLL_CTDonNhap();
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            loadDonNhap();
            loadCB();
            loadCT();
        }
        public void loadCT()
        {
            if (cboMaDonNhap.SelectedValue.ToString() != "DTO.DONNHAP")
            {
                int manhap = ((View_Nhap)cboMaDonNhap.SelectedValue).MADN; //int.Parse(cboMaDonNhap.SelectedValue.ToString());
                dtCTDonNhap.DataSource = bllctdonnhap.loadCTDonNhapMa(manhap);
            }
        }
        public void loadCB()
        {
            cboMaDonNhap.DataSource = blldonnhap.loadViewDonNhap(); //.Select(x=>x.MADN).ToList()
            cboMaDonNhap.DisplayMember = "MADN";
            //cboMaDonNhap.ValueMember = "MADN";
           // cboMaDonNhap. 
            cboNhaCungCap.DataSource = bllcungcap.loadNhaCungCap();
            cboNhaCungCap.DisplayMember = "TENNCC";
            cboNhaCungCap.ValueMember = "TENNCC";
            cboTenNV.DataSource = bllnhanvien.loadNhanVien();
            cboTenNV.DisplayMember = "TENNV";
            cboTenNV.ValueMember = "TENNV";
            cboThietBi.DataSource = bllthietbi.loadThietBi();
            cboThietBi.DisplayMember = "TENTB";
            cboThietBi.ValueMember = "TENTB";

        }
       
        void loadDonNhap()
        {
            dtDonNhap.DataSource = blldonnhap.loadViewDonNhap();
        }
        private void dtDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMaDonNhap.Text = dtDonNhap.CurrentRow.Cells[0].Value.ToString();
            cboTenNV.Text = dtDonNhap.CurrentRow.Cells[1].Value.ToString();
            cboNhaCungCap.Text = dtDonNhap.CurrentRow.Cells[2].Value.ToString();
            txtTongTien.Text = dtDonNhap.CurrentRow.Cells[4].Value.ToString();
            dateNgayLap.Text = dtDonNhap.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            int madn = ((View_Nhap)cboMaDonNhap.SelectedValue).MADN; ;
            DONNHAP dn = blldonnhap.timDonNhapTheoMa(madn);
            if (dn == null)
            {
                MessageBox.Show("Không tìm thấy cơ sở có mã:" + madn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                int kq = blldonnhap.xoaDonNhap(dn);
                if (kq == 1)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDonNhap();
                }
            }    
        }

        private void dtCTDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            txtGia.Text = dtCTDonNhap.CurrentRow.Cells[5].Value.ToString();
            txtSoLuong.Text = dtCTDonNhap.CurrentRow.Cells[4].Value.ToString();
            
            pictureBox3.Image = Image.FromFile(projectPath + "\\HinhAnhSP\\" +
                dtCTDonNhap.CurrentRow.Cells[3].Value.ToString());
            txtMaTB.Text = dtCTDonNhap.CurrentRow.Cells[1].Value.ToString();
            txtTenTB.Text = dtCTDonNhap.CurrentRow.Cells[2].Value.ToString();
            txtSLTB.Text = dtCTDonNhap.CurrentRow.Cells[4].Value.ToString();
            txtGia.Text = dtCTDonNhap.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnThemDH_Click(object sender, EventArgs e)
        {
            new frDonNhapHang().Show();
        }

        private void cboMaDonNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCT();

        }

        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            loadDonNhap();
        }

        private void btnSXTang_Click(object sender, EventArgs e)
        {
            dtDonNhap.DataSource = blldonnhap.loadViewDonNhap().OrderByDescending(x=>x.NGAYLAP).ToList();
        }

        private void btnSXGiam_Click(object sender, EventArgs e)
        {
            dtDonNhap.DataSource = blldonnhap.loadViewDonNhap().OrderBy(x => x.NGAYLAP).ToList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //var date = (DateTime)sender.Value;
            dtDonNhap.DataSource = blldonnhap.loadViewDonNhap().Where(x => 
                x.NGAYLAP.HasValue && x.NGAYLAP.Value.Date == dateTimePicker1.Value.Date).ToList();
        }

    }
}
