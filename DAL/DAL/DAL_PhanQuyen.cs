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
    public class DAL_PhanQuyen
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_PhanQuyen()
        {

        }

        public List<PHANQUYEN> loadPhanQuyen()
        {
            return db_LinhKien.PHANQUYENs.Select(t => t).ToList();
        }
    }
}
