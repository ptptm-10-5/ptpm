using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThietBi
{
    public partial class GUI_Main : Form
    {
        public GUI_Main()
        {
            InitializeComponent();
        }

        private void GUI_Main_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }

        private void cơSơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(GUI_CoSo));
            if (frm != null)
                frm.Activate();
            else
            {
                GUI_CoSo fr = new GUI_CoSo();
                fr.MdiParent = this;
                fr.Show();
            }
        }

       
    }
}
