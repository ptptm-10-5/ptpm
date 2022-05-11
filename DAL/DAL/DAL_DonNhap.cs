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
    public class DAL_DonNhap
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_DonNhap()
        {

        }

        public List<DONNHAP> loadDonNhap()
        {
            return db_LinhKien.DONNHAPs.Select(t => t).ToList();
        }
    }
}
