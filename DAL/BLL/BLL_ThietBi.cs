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
    public class BLL_ThietBi
    {
        DAL_ThietBi dalThietBi;

        public BLL_ThietBi()
        {
            dalThietBi = new DAL_ThietBi();
        }

        public List<THIETBI> loadThietBi()
        {
            return dalThietBi.loadThietBi();
        }
    }
}
