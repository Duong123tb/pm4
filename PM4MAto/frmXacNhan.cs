using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PM4MAto
{
    public partial class frmXacNhan : Form
    {
        public frmXacNhan()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            Frm_Main.LuuThongTin.vitri =  cbViTri.Text.ToString();
            Frm_Main.LuuThongTin.so = int.Parse(txtSo.Text);
            base.Close();
        }
    }
}
