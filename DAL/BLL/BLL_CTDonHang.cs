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
    public class BLL_CTDonHang
    {
        DAL_CTDonHang dalCTDonHang;
        
        public BLL_CTDonHang()
        {
            dalCTDonHang = new DAL_CTDonHang();
        }

        public List<CTDONHANG> loadCTDonHang()
        {
            return dalCTDonHang.loadCTDonHang();
            
        }
    }
}
