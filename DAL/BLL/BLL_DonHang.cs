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
    public class BLL_DonHang
    {
        DAL_DonHang dalDonHang;

        public BLL_DonHang()
        {
            dalDonHang = new DAL_DonHang();
        }

        public List<DONHANG> loadDonHang()
        {
            return dalDonHang.loadDonHang();
        }
    }
}
