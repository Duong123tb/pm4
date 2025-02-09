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
    public partial class FrmLogin : Form
    {
        private Frm_Main frmMain;

        // Biến theo dõi trạng thái mở form Ca Sáng, Ca Chiều, Ca HC, Ca Đêm
        private bool isCaSangOpen = false;
        private bool isCaChieuOpen = false;
        private bool isCaHCOpen = false;
        private bool isCaDemOpen = false;

        public FrmLogin()
        {
            InitializeComponent();
        }

        public class LuuThongTin
        {
            public static string calam = "";
        }

        // Mở Ca Sáng
        private void btnCaSang_Click(object sender, EventArgs e)
        {
            // Lưu thông tin ca sáng
            LuuThongTin.calam = "Sang";

            // Kiểm tra xem Ca Sáng đã mở chưa
            if (isCaSangOpen)
            {
                MessageBox.Show("Ca Sáng đã được mở.");
                return;
            }

            // Kiểm tra các ca khác đã mở chưa
            if (isCaChieuOpen || isCaHCOpen || isCaDemOpen)
            {
                MessageBox.Show("Không thể mở Ca Sáng khi một ca khác đang mở.");
                return;
            }

            // Mở Frm_Main khi nhấn nút Ca Sáng
            if (frmMain == null || frmMain.IsDisposed)
            {
                frmMain = new Frm_Main();
                frmMain.FormClosed += FrmMain_FormClosed;  // Đăng ký sự kiện khi form đóng
                frmMain.Show();  // Mở Frm_Main
                isCaSangOpen = true;  // Đánh dấu rằng Ca Sáng đã được mở
            }
        }

        // Mở Ca Chiều
        private void btnCaChieu_Click(object sender, EventArgs e)
        {
            // Lưu thông tin ca chiều
            LuuThongTin.calam = "Chieu";

            // Kiểm tra xem Ca Chiều đã mở chưa
            if (isCaChieuOpen)
            {
                MessageBox.Show("Ca Chiều đã được mở.");
                return;
            }

            // Kiểm tra các ca khác đã mở chưa
            if (isCaSangOpen || isCaHCOpen || isCaDemOpen)
            {
                MessageBox.Show("Không thể mở Ca Chiều khi một ca khác đang mở.");
                return;
            }

            // Mở Frm_Main khi nhấn nút Ca Chiều
            if (frmMain == null || frmMain.IsDisposed)
            {
                frmMain = new Frm_Main();
                frmMain.FormClosed += FrmMain_FormClosed;  // Đăng ký sự kiện khi form đóng
                frmMain.Show();  // Mở Frm_Main
                isCaChieuOpen = true;  // Đánh dấu rằng Ca Chiều đã được mở
            }
        }

        // Mở Ca HC
        private void btnCaHC_Click(object sender, EventArgs e)
        {

        }

        // Mở Ca Đêm
        private void btnCaDem_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện này sẽ được gọi khi Frm_Main đóng
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cập nhật lại trạng thái khi form bị đóng
            if (sender == frmMain)
            {
                // Kiểm tra và cập nhật trạng thái form đã đóng
                if (LuuThongTin.calam == "Sang")
                {
                    isCaSangOpen = false;  // Đánh dấu rằng Ca Sáng đã đóng
                }
                else if (LuuThongTin.calam == "Chieu")
                {
                    isCaChieuOpen = false;  // Đánh dấu rằng Ca Chiều đã đóng
                }
                else if (LuuThongTin.calam == "HC")
                {
                    isCaHCOpen = false;  // Đánh dấu rằng Ca HC đã đóng
                }
                else if (LuuThongTin.calam == "Dem")
                {
                    isCaDemOpen = false;  // Đánh dấu rằng Ca Đêm đã đóng
                }

                // Giải phóng đối tượng form
                frmMain = null;
            }
        }
        private void btnOpenFrm4MConNguoi_Click(object sender, EventArgs e)
        {
            // Mở Frm_4MConNguoi khi nhấn nút mở Frm_4MConNguoi
            Frm_4MConNguoi frm4MConNguoi = new Frm_4MConNguoi();

            // Thiết lập lại kích thước của form nếu cần thiết
            frm4MConNguoi.ClientSize = new Size(1366, 768); // Kích thước bạn muốn

            // Mở Frm_4MConNguoi
            frm4MConNguoi.Show();  // Frm_4MConNguoi mở và FrmLogin không bị đóng
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}