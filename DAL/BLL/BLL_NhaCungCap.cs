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
    public class BLL_NhaCungCap
    {
        DAL_NhaCungCap dalNhaCungCap;

        public BLL_NhaCungCap()
        {
            dalNhaCungCap = new DAL_NhaCungCap();
        }

        public List<NHACC> loadNhaCungCap()
        {
            return dalNhaCungCap.loadNhaCungCap();
        }
    }
}
