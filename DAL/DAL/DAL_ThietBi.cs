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
    public class DAL_ThietBi
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_ThietBi()
        {

        }

        public List<THIETBI> loadThietBi()
        {
            return db_LinhKien.THIETBIs.Select(t => t).ToList();
        }
    }
}
