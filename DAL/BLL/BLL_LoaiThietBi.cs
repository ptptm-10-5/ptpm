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
    public class BLL_LoaiThietBi
    {
        DAL_LoaiThietBi dalLoaiThietBi;

        public BLL_LoaiThietBi()
        {
            dalLoaiThietBi = new DAL_LoaiThietBi();
        }

        public List<LOAITB> loadLoaiThietBi()
        {
            return dalLoaiThietBi.loadLoaiThietBi();
        }
    }
}
