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
    public class DAL_BaoCao
    {
        QL_LinhKienDataContext db_LinhKien = new QL_LinhKienDataContext();
        public DAL_BaoCao()
        {

        }
        public List<BAOCAO> loadBaoCao()
        {
            return db_LinhKien.BAOCAOs.Select(t => t).ToList();
        }
        public int themBaoCao(BAOCAO bc)
        {
            try
            {
                db_LinhKien.BAOCAOs.InsertOnSubmit(bc);
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int xoaBaoCao(BAOCAO bc)
        {
            try
            {
                db_LinhKien.BAOCAOs.DeleteOnSubmit(bc);
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int suaBaoCao(BAOCAO pNV)
        {
            try
            {
                BAOCAO bc = db_LinhKien.BAOCAOs.Where(t => t.MANV == pNV.MANV).FirstOrDefault();
                bc = pNV;
                db_LinhKien.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int luuBaoCao()
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
        public BAOCAO timBaoCaoTheoMa(int pMaBC)
        {
            try
            {
                return db_LinhKien.BAOCAOs.Select(t => t).Where(t => t.MANV == pMaBC).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
