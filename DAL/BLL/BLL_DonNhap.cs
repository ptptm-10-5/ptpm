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
    public class BLL_DonNhap
    {
        DAL_DonNhap dalDonNhap;

        public BLL_DonNhap()
        {
            dalDonNhap = new DAL_DonNhap();
        }

        public List<DONNHAP> loadDonNhap()
        {
            return dalDonNhap.loadDonNhap();
        }
    }
}
