using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PM4MAto
{
    public partial class c : Form
    {
        public c()
        {
            InitializeComponent();
            txtMaNvMoi.Text = Frm_Main.LuuThongTin.manv;
        }
        private void btnNguoiMoi_Click(object sender, EventArgs e)
        {
            //LuuThongTin.manv = txtMaNvMoi.Text;
            Frm_Main.LuuThongTin.tennv = txtTenNvMoi.Text;
            int a = int.TryParse(cbChonCongDoan.SelectedValue?.ToString(), out int result) ? result : 0;
            Frm_Main.LuuThongTin.tt = a;
            Frm_Main.LuuThongTin.vitri = cbChonNguoi.Text;
            this.Close();
        }
        // Lớp dữ liệu cho ComboBox
        class ComboBoxItem
        {
            public int Value { get; set; }
            public string Display { get; set; }
        }
        private void FrmNguoiMoi_Load(object sender, EventArgs e)
        {
            // Tạo danh sách dữ liệu
            List<ComboBoxItem> items = new List<ComboBoxItem>
            {

                new ComboBoxItem { Value =  1   , Display = "	LINECHOU	"},
                new ComboBoxItem { Value =  2   , Display = "	LQC 1	"},
                new ComboBoxItem { Value =  3   , Display = "	LQC 2	"},
                new ComboBoxItem { Value =  4   , Display = "	SETTA 1	"},
                new ComboBoxItem { Value =  5   , Display = "	SETTA 2	"},
                new ComboBoxItem { Value =  6   , Display = "	KANBAN	"},
                new ComboBoxItem { Value =  7   , Display = "	BUHIN 1	"},
                new ComboBoxItem { Value =  8   , Display = "	BUHIN 2	"},
                new ComboBoxItem { Value =  9   , Display = "	OFFLINE 1	"},
                new ComboBoxItem { Value =  10  , Display = "	OFFLINE 2	"},
                new ComboBoxItem { Value =  11  , Display = "	OFFLINE 3	"},
                new ComboBoxItem { Value =  12  , Display = "	OFFLINE 4	"},
                new ComboBoxItem { Value =  13  , Display = "	OFFLINE 5	"},
                new ComboBoxItem { Value =  14  , Display = "	OFFLINE 6	"},
                new ComboBoxItem { Value =  15  , Display = "	CHECKA 1	"},
                new ComboBoxItem { Value =  16  , Display = "	CHECKA 2	"},
                new ComboBoxItem { Value =  17  , Display = "	CHECKA 3	"},
                new ComboBoxItem { Value =  18  , Display = "	CHECKA 4	"},
                new ComboBoxItem { Value =  19  , Display = "	SHIAGE 1	"},
                new ComboBoxItem { Value =  20  , Display = "	SHIAGE 2	"},
                new ComboBoxItem { Value =  21  , Display = "	SHIAGE 3	"},
                new ComboBoxItem { Value =  22  , Display = "	SHIAGE 4	"},
                new ComboBoxItem { Value =  23  , Display = "	SHIAGE 5	"},
                new ComboBoxItem { Value =  24  , Display = "	GAIKAN 1	"},
                new ComboBoxItem { Value =  25  , Display = "	GAIKAN 2	"},
                new ComboBoxItem { Value =  26  , Display = "	GAIKAN 3	"},
                new ComboBoxItem { Value =  27  , Display = "	GAIKAN 4	"},
                new ComboBoxItem { Value =  28  , Display = "	PACKING	"},
                new ComboBoxItem { Value =  29  , Display = "	TAPE 1	"},
                new ComboBoxItem { Value =  30  , Display = "	TAPE 2	"},
                new ComboBoxItem { Value =  31  , Display = "	TAPE 3	"},
                new ComboBoxItem { Value =  32  , Display = "	TAPE 4	"},
                new ComboBoxItem { Value =  33  , Display = "	TAPE 5	"},
                new ComboBoxItem { Value =  34  , Display = "	TAPE 6	"},
                new ComboBoxItem { Value =  35  , Display = "	TAPE 7	"},
                new ComboBoxItem { Value =  36  , Display = "	TAPE 8	"},
                new ComboBoxItem { Value =  37  , Display = "	TAPE 9	"},
                new ComboBoxItem { Value =  38  , Display = "	TAPE 10	"},
                new ComboBoxItem { Value =  39  , Display = "	TAPE 11	"},
                new ComboBoxItem { Value =  40  , Display = "	TAPE 12	"},
                new ComboBoxItem { Value =  41  , Display = "	TAPE 13	"},
                new ComboBoxItem { Value =  42  , Display = "	TAPE 14	"},
                new ComboBoxItem { Value =  43  , Display = "	TAPE 15	"},
                new ComboBoxItem { Value =  44  , Display = "	TAPE 16	"},
                new ComboBoxItem { Value =  45  , Display = "	LAYOUT 1	"},
                new ComboBoxItem { Value =  46  , Display = "	LAYOUT 2	"},
                new ComboBoxItem { Value =  47  , Display = "	LAYOUT 3	"},
                new ComboBoxItem { Value =  48  , Display = "	LAYOUT 4	"},
                new ComboBoxItem { Value =  49  , Display = "	LAYOUT 5	"},
                new ComboBoxItem { Value =  50  , Display = "	LAYOUT 6	"},
                new ComboBoxItem { Value =  51  , Display = "	LAYOUT 7	"},
                new ComboBoxItem { Value =  52  , Display = "	LAYOUT 8	"},
                new ComboBoxItem { Value =  53  , Display = "	LAYOUT 9	"},
                new ComboBoxItem { Value =  54  , Display = "	SUB 1	"},
                new ComboBoxItem { Value =  55  , Display = "	SUB 2	"},
                new ComboBoxItem { Value =  56  , Display = "	SUB 3	"},
                new ComboBoxItem { Value =  57  , Display = "	SUB 4	"},
                new ComboBoxItem { Value =  58  , Display = "	SUB 5	"},
                new ComboBoxItem { Value =  59  , Display = "	SUB 6	"},
                new ComboBoxItem { Value =  60  , Display = "	SUB 7	"},
                new ComboBoxItem { Value =  61  , Display = "	SUB 8	"},
                new ComboBoxItem { Value =  62  , Display = "	SUB 9	"},
                new ComboBoxItem { Value =  63  , Display = "	SUB 10	"},
                new ComboBoxItem { Value =  64  , Display = "	SUB 11	"},
                new ComboBoxItem { Value =  65  , Display = "	SUB 12	"},
                new ComboBoxItem { Value =  66  , Display = "	SUB13-SUB	"},
                new ComboBoxItem { Value =  67  , Display = "	SUB13-TAPE	"},
                new ComboBoxItem { Value =  68  , Display = "	SUB 14	"},
                new ComboBoxItem { Value =  69  , Display = "	SUB 15	"},
                new ComboBoxItem { Value =  70  , Display = "	SUB 16	"},
                new ComboBoxItem { Value =  78  , Display = "	OSUB 17	"},
                new ComboBoxItem { Value =  71  , Display = "	OSUB 1	"},
                new ComboBoxItem { Value =  72  , Display = "	OSUB 2	"},
                new ComboBoxItem { Value =  73  , Display = "	OSUB 3	"},
                new ComboBoxItem { Value =  74  , Display = "	OSUB 4	"},
                new ComboBoxItem { Value =  75  , Display = "	OSUB 5	"},
                new ComboBoxItem { Value =  76  , Display = "	OSUB 6.7.8	"},
                new ComboBoxItem { Value =  77  , Display = "	OSUB 9	"},
                





            };
            // Gán danh sách vào ComboBox
            cbChonCongDoan.DataSource = items;
            cbChonCongDoan.DisplayMember = "Display";  // Hiển thị
            cbChonCongDoan.ValueMember = "Value";  // Giá trị thực tế

        }
    }
}
