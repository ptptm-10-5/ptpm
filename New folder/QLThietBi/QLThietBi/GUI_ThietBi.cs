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

namespace QLThietBi
{
    public partial class GUI_ThietBi : Form
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        BLL_ThietBi bllThietBi = new BLL_ThietBi();
        BLL_LoaiThietBi bllLoaiTB = new BLL_LoaiThietBi();
        BLL_NhaCungCap bllNhaCC = new BLL_NhaCungCap();

        public GUI_ThietBi()
        {
            InitializeComponent();
        }

        private void GUI_ThietBi_Load(object sender, EventArgs e)
        {
            loadThietBi();
            loadCbbLoai();
            loadCbbNCC();
        }
        void loadThietBi()
        {
            dtgThietBi.DataSource = bllThietBi.loadThietBi();
            chinhSuaDtgThietBi();
        }
        void chinhSuaDtgThietBi()
        {
            dtgThietBi.Columns[0].Width = 60;
            dtgThietBi.Columns[1].Width = 200;
            dtgThietBi.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgThietBi.Columns[2].Width = 120;
            dtgThietBi.Columns[3].Width = 100;
            dtgThietBi.Columns[4].Width = 120;
            dtgThietBi.Columns[5].Width = 300;
            dtgThietBi.Columns[6].Width = 60;
            dtgThietBi.Columns[7].Width = 60;
            dtgThietBi.Columns[8].Visible = false;
            dtgThietBi.Columns[9].Visible = false;
        }
        void loadCbbLoai()
        {
            cbbLoai.DataSource = bllLoaiTB.loadLoaiThietBi();
            cbbLoai.DisplayMember = "TENLOAI";
            cbbLoai.ValueMember = "MALOAI";
        }
        void loadCbbNCC()
        {
            cbbNCC.DataSource = bllNhaCC.loadNhaCungCap();
            cbbNCC.DisplayMember = "TENNCC";
            cbbNCC.ValueMember = "MANCC";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }



        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void dtgThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dtgThietBi.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dtgThietBi.CurrentRow.Cells[1].Value.ToString();
            //dtpNgaySinh.Text = dtgThietBi.CurrentRow.Cells[2].Value.ToString();  Hình Ảnh
            int gia = int.Parse(dtgThietBi.CurrentRow.Cells[3].Value.ToString());
            txtGia.Text = gia.ToString("#,#");
            txtSL.Value = int.Parse(dtgThietBi.CurrentRow.Cells[4].Value.ToString());
            txtMoTa.Text = dtgThietBi.CurrentRow.Cells[5].Value.ToString();
            string maLoai = dtgThietBi.CurrentRow.Cells[6].Value.ToString();    // Sau này set Combobox cho datagridview luôn
            string maNCC = dtgThietBi.CurrentRow.Cells[7].Value.ToString();
            cbbLoai.SelectedValue = maLoai;
            cbbNCC.SelectedValue = maNCC;
        }


    }
}
