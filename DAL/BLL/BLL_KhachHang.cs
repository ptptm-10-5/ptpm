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
    public class BLL_KhachHang
    {
        DAL_KhachHang dalKhachHang;

        public BLL_KhachHang()
        {
            dalKhachHang = new DAL_KhachHang();
        }

        public List<KHACHHANG> loadKhachHang()
        {
            return dalKhachHang.loadKhachHang();
        }
    }
}
