using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;
using System.Data.Linq;

namespace DAL
{
    public class DAL_NhanVien
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_NhanVien()
        {

        }

        public List<NHANVIEN> loadNhanVien()
        {
            return db_LinhKien.NHANVIENs.Select(t => t).ToList();
        }
        
        public NHANVIEN timNhanVienTheoSDT(string pSDT, string pMatKhau)
        {            
            try
            {
                return db_LinhKien.NHANVIENs.Where(t => t.SDT == pSDT && t.MATKHAU == pMatKhau).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }            
        }
    }
}
