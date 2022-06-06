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
//using System.Windows.Forms.l
namespace QLThietBi
{
    public partial class frDonNhapHang : Form
    {
        QL_LinhKienDataContext qllk = new QL_LinhKienDataContext();
        BLL_DonNhap blldonnhap = new BLL_DonNhap();
        BLL_NhaCungCap bllcungcap = new BLL_NhaCungCap();
        BLL_NhanVien bllnhanvien = new BLL_NhanVien();
        BLL_ThietBi bllthietbi = new BLL_ThietBi();

        public frDonNhapHang()
        {
            InitializeComponent();
            loadCMB();
        }
        void loadCMB()
        {
            
            cboNCC.DataSource = bllcungcap.loadNhaCungCap();
            cboNCC.DisplayMember = "MANCC";
            cboNCC.ValueMember = "MANCC";
            
            cboNV.DataSource = bllnhanvien.loadNhanVien();
            cboNV.DisplayMember = "MANV";
            cboNV.ValueMember = "MANV";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
             DialogResult h = MessageBox.Show
            ("Bạn có chắc muốn thêm đơn nhập hàng này không?", "Thông báo", MessageBoxButtons.OKCancel);
             if (h == DialogResult.OK)
             {
                 if (txtTongTien.Text == "" || !char.IsDigit(txtTongTien.Text.ToString(), 0))
                 {
                     errorProvider1.SetError(txtTongTien, "Không được để trống đơn giá");
                     txtTongTien.Focus();
                     return;
                 }
                 else
                 {
                     DONNHAP nh = new DONNHAP();

                     nh.MANCC = int.Parse(cboNCC.SelectedValue.ToString());
                     nh.MANV = int.Parse(cboNV.SelectedValue.ToString());
                     nh.NGAYLAP = dateTimePicker1.Value;
                     nh.TONGTIEN = int.Parse(txtTongTien.Text);


                     qllk.DONNHAPs.InsertOnSubmit(nh);
                     qllk.SubmitChanges();

                     MessageBox.Show("Thêm đơn nhập hàng thành công !!");
                 }
             }
        }

        private void frDonNhapHang_Load(object sender, EventArgs e)
        {

        }
    }
}
