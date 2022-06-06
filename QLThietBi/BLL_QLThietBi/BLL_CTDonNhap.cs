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
    public class BLL_CTDonNhap
    {
        DAL_CTDonNhap dalCTDonNhap;

        public BLL_CTDonNhap()
        {
            dalCTDonNhap = new DAL_CTDonNhap();
        }
        public List<View_CTNhap> loadCTDonNhapMa(int map)
        {
            return dalCTDonNhap.loadCTDonNhapMa(map);
        }
        public List<View_CTNhap> loadCTDonNhap()
        {
            return dalCTDonNhap.loadCTDonNhap();
        }
        public int themCTDonNhap(CTDONHAP ctdn)
        {
            return dalCTDonNhap.themCTDonNhap(ctdn);
        }
        public int xoaCTDonNhap(CTDONHAP pCTDonNhap)
        {
            return dalCTDonNhap.xoaCTDonNhap(pCTDonNhap);
        }
        public int suaCTDonNhap(CTDONHAP ctdn)
        {
            return dalCTDonNhap.suaCTDonNhap(ctdn);
        }
        public int luuCTDonNhap()
        {
            return dalCTDonNhap.luuCTDonNhap();
        }
        public CTDONHAP timCTDonNhapTheoMa(int pMactdn)
        {
            return dalCTDonNhap.timCTDonNhapTheoMa(pMactdn);
        }
    }
}
