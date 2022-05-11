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
    public class BLL_PhanQuyen
    {
        DAL_PhanQuyen dalPhanQuyen;

        public BLL_PhanQuyen()
        {
            dalPhanQuyen = new DAL_PhanQuyen();
        }

        public List<PHANQUYEN> loadPhanQuyen()
        {
            return dalPhanQuyen.loadPhanQuyen();
        }
    }
}
