using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLThietBi;
using System.Data;
using System.Windows.Forms;
using System.Data.Linq;

namespace DAL_QLThietBi
{
    public class DAL_CTDonNhap
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_CTDonNhap()
        {

        }
        //public List<View_CTNhap> loadCTDonNhapMa(int pMaNhap)
        //{
        //    List<CTDONHAP> lst = db_LinhKien.CTDONHAPs.Where(t => t.MADN == pMaNhap).ToList<CTDONHAP>();
        //    var kq = lst.ConvertAll(l => new View_CTNhap()
        //    {

        //    });
        //    return kq.ToList<View_CTNhap>();

        //}
        public List<View_CTNhap> loadCTDonNhapMa(int pMa)
        {
            return db_LinhKien.View_CTNhaps.Where(t => t.MADN == pMa).ToList();
        }
        public List<View_CTNhap> loadCTDonNhap()
        {
            return db_LinhKien.View_CTNhaps.Select(t => t).ToList();
        }
        public int themCTDonNhap(CTDONHAP ctdn)
        {
            try
            {
                db_LinhKien.CTDONHAPs.InsertOnSubmit(ctdn);
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int xoaCTDonNhap(CTDONHAP ctdn)
        {
            try
            {
                db_LinhKien.CTDONHAPs.DeleteOnSubmit(ctdn);
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int suaCTDonNhap(CTDONHAP pCTDN)
        {
            try
            {
                CTDONHAP ctdn = db_LinhKien.CTDONHAPs.Where(t => t.MADN == pCTDN.MADN && t.MATB == pCTDN.MATB).FirstOrDefault();
                ctdn = pCTDN;
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int luuCTDonNhap()
        {
            try
            {
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public CTDONHAP timCTDonNhapTheoMa(int pMaCTDH)
        {
            try
            {
                return db_LinhKien.CTDONHAPs.Select(t => t).Where(t => t.MADN == pMaCTDH).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
