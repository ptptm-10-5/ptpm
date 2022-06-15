using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLThietBi;
using DTO_QLThietBi;
using System.Data;
using System.Windows.Forms;
using System.Data.Linq;
namespace BLL_QLThietBi
{
    public class BLL_BaoCao
    {
        DAL_BaoCao dalBaocao;

        public BLL_BaoCao()
        {
            dalBaocao = new DAL_BaoCao();
        }

        public List<BAOCAO> loadBaoCao()
        {
            return dalBaocao.loadBaoCao();
        }
        public int themBaocao(BAOCAO bc)
        {
            return dalBaocao.themBaoCao(bc);
        }
        public int xoaBaoCao(BAOCAO pBaoCao)
        {
            return dalBaocao.xoaBaoCao(pBaoCao);
        }
        public int suaBaoCao(BAOCAO bc)
        {
            return dalBaocao.suaBaoCao(bc);
        }
        public int luuBaoCao()
        {
            return dalBaocao.luuBaoCao();
        }
        public BAOCAO timBaocaoTheoMa(int pMaBC)
        {
            return dalBaocao.timBaoCaoTheoMa(pMaBC);
        }
    }
}
