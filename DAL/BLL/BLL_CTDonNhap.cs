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
    public class BLL_CTDonNhap
    {
        DAL_CTDonNhap dalCTDonNhap;

        public BLL_CTDonNhap()
        {
            dalCTDonNhap = new DAL_CTDonNhap();
        }

        public List<CTDONNHAP> loadCTDonNhap()
        {
            return dalCTDonNhap.loadCTDonNhap();

        }
    }
}
