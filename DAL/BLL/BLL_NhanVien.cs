using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Windows.Forms;
using System.Data.Linq;

namespace BLL
{    
    public class BLL_NhanVien
    {
        DAL_NhanVien dalNhanVien;
                        
        public BLL_NhanVien()
        {
            dalNhanVien = new DAL_NhanVien();
        }

        public List<NHANVIEN> loadNhanVien()
        {
            return dalNhanVien.loadNhanVien();
        }
        public NHANVIEN timNhanVienTheoSDT(string pSDT, string pMatKhau)
        {            
            return dalNhanVien.timNhanVienTheoSDT(pSDT, pMatKhau);
        }
    }
}
