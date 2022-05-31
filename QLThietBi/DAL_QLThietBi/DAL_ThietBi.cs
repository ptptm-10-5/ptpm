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
        public int themThietBi(THIETBI tb)
        {
            try
            {
                db_LinhKien.THIETBIs.InsertOnSubmit(tb);
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int xoaThietBi(THIETBI tb)
        {
            try
            {
                db_LinhKien.THIETBIs.DeleteOnSubmit(tb);
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int suaThietBi(THIETBI pTB)
        {
            try
            {
                THIETBI tb = db_LinhKien.THIETBIs.Where(t => t.MATB == pTB.MATB).FirstOrDefault();
                tb = pTB;
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int luuThietBi()
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
        public THIETBI timThietBiTheoMa(int pMaTB)
        {
            try
            {
                return db_LinhKien.THIETBIs.Select(t => t).Where(t => t.MATB == pMaTB).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
