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
    public class DAL_CTDonHang
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_CTDonHang()
        {

        }

        public List<CTDONHANG> loadCTDonHang()
        {
            return db_LinhKien.CTDONHANGs.Select(t => t).ToList();
        }
    }
}
