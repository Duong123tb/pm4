using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing.Text;
using Application = System.Windows.Forms.Application;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.LinkLabel;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using OfficeOpenXml; // Thêm namespace EPPlus

namespace PM4MAto
{
    public partial class Frm_Main : Form
    {
        List<Control[]> controlmatrix = new List<Control[]>();
        private System.Windows.Forms.Timer clockTimer;
        private SerialPort serialPort;
        private string scannedCode = "";  // Mã CODE nhận từ thiết bị
        private List<string[]> data_user = new List<string[]>(); // Danh sách dữ liệu từ Excel
        public Frm_Main()
        {
            InitializeComponent();

            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000; // 1 giây
            clockTimer.Tick += ClockTimer_Tick;

            string filePath_user = Path.Combine(Application.StartupPath, "DATA",
            FrmLogin.LuuThongTin.calam == "Sang" ? "DSCaA.xlsx" :
            FrmLogin.LuuThongTin.calam == "Chieu" ? "DSCaB.xlsx" :
            FrmLogin.LuuThongTin.calam == "CaHC" ? "DSCaHC.xlsx" : "DSCaDem.xlsx");

            if (File.Exists(filePath_user))
                loadExcelFile(filePath_user); // Gọi hàm đọc file Excel
            else
                MessageBox.Show("File không tồn tại: " + filePath_user);

            UpdateSubCount(data_user);
            UpdateNghiViecvsChuyenViTri(data_user);
            // them data vao matran control
            controlmatrix.Add(new Control[] { lb_vtri1, lb_vtri2, lb_vtri3, lb_vtri4, lb_vtri5, lb_vtri6, lb_vtri7, lb_vtri9, lb_vtri9, lb_vtri10, lb_vtri11, lb_vtri12, lb_vtri13, lb_vtri14, lb_vtri15, lb_vtri16, lb_vtri17, lb_vtri18, lb_vtri19, lb_vtri20, lb_vtri21, lb_vtri22, lb_vtri23, lb_vtri24, lb_vtri25, lb_vtri26, lb_vtri27, lb_vtri28, lb_vtri29, lb_vtri30, lb_vtri31, lb_vtri32, lb_vtri33, lb_vtri34, lb_vtri35, lb_vtri36, lb_vtri37, lb_vtri38, lb_vtri39, lb_vtri40, lb_vtri41, lb_vtri42, lb_vtri43, lb_vtri44, lb_vtri45, lb_vtri46, lb_vtri47, lb_vtri48, lb_vtri49, lb_vtri50, lb_vtri51, lb_vtri52, lb_vtri53, lb_vtri54, lb_vtri55, lb_vtri56, lb_vtri57, lb_vtri58, lb_vtri59, lb_vtri60, lb_vtri61, lb_vtri62, lb_vtri63, lb_vtri64, lb_vtri72, lb_vtri66, lb_vtri67, lb_vtri68, lb_vtri69, lb_vtri70, lb_vtri71, lb_vtri72, lb_vtri73, lb_vtri74, lb_vtri75, lb_vtri76, lb_vtri77, lb_vtri78 });
            controlmatrix.Add(new Control[] { code1, code2, code3, code4, code5, code6, code7, code8, code9, code10, code11, code12, code13, code14, code15, code16, code17, code18, code19, code20, code21, code22, code23, code24, code25, code26, code27, code28, code29, code30, code31, code32, code33, code34, code35, code36, code37, code38, code39, code40, code41, code42, code43, code44, code42, code43, code44, code48, code49, code50, code51, code52, code53, code54, code55, code56, code57, code58, code59, code60, code61, code62, code63, code64, code72, code66, code67, code68, code69, code70, code71, code72, code73, code74, code75, code76, code77, code78 });
            controlmatrix.Add(new Control[] { name1, name2, name3, name4, name5, name6, name7, name8, name9, name10, name11, name12, name13, name14, name15, name16, name17, name18, name19, name20, name21, name22, name23, name24, name25, name26, name27, name28, name29, name30, name31, name32, name33, name34, name35, name36, name37, name38, name39, name40, name41, name42, name43, name44, name45, name46, name47, name48, name49, name50, name51, name52, name53, name54, name55, name56, name57, name58, name59, name60, name61, name62, name63, name64, name65, name66, name67, name68, name69, name70, name71, name72, name73, name74, name75, name76, name77, name78 });

            // Khởi tạo cổng Serial
            InitializeSerialPort();
        }
        private void CheckThongBaoDacBiet()
        {
            // Lấy số lượng từ txtTOTALTong
            if (int.TryParse(txtTOTALTong.Text, out int soNguoiNghi) && soNguoiNghi > 5)
            {
                // Hiển thị thông báo nếu số người nghỉ lớn hơn 5
                lbThongBaoDacBiet.Text = "CHUYỀN QUẢN LÝ ĐẶC BIỆT\n 特別管理ライン \nNGƯỜI NGHỈ NHIỀU\n 欠勤人数が多い";
                lbThongBaoDacBiet.ForeColor = Color.White;
                lbThongBaoDacBiet.BackColor = Color.Red;
            }
            else
            {
                // Quay về trạng thái mặc định nếu số người nghỉ không vượt quá 5
                lbThongBaoDacBiet.Text = "";
                lbThongBaoDacBiet.ForeColor = Color.Black;
                lbThongBaoDacBiet.BackColor = Color.Transparent;
            }
        }

        private void txtTOTALTong_TextChanged(object sender, EventArgs e)
        {
            CheckThongBaoDacBiet();
        }
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            lbdatetime.Text = currentTime.ToString("dd-MM-yyyy" + " | HH:mm:ss");
        }
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            clockTimer.Start();
            UpdateDanhSachVịTriNghi();
        }

        private void loadExcelFile(string filePath)
        {
            data_user.Clear(); // Xóa dữ liệu cũ trước khi nạp mới

            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                MessageBox.Show("File không tồn tại: " + filePath);
                return;
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Cấu hình license miễn phí

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                int rowCount = worksheet.Dimension.Rows; // Số dòng
                int colCount = worksheet.Dimension.Columns; // Số cột

                for (int row = 1; row <= rowCount; row++) // Lặp qua từng dòng
                {
                    List<string> rowData = new List<string>();
                    for (int col = 1; col <= colCount; col++) // Lặp qua từng cột
                    {
                        var cellValue = worksheet.Cells[row, col].Text.Trim(); // Lấy giá trị ô
                        rowData.Add(cellValue);
                    }
                    data_user.Add(rowData.ToArray()); // Thêm vào danh sách
                }
            }
        }

        // Hàm khởi tạo cổng Serial
        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            serialPort.DataReceived += (sender, e) =>
            {
                scannedCode = serialPort.ReadLine().Trim();  // Đọc mã CODE
                this.Invoke(new Action(() => ProcessScannedCode()));  // Cập nhật giao diện
            };
            serialPort.Open();
        }

        public class LuuThongTin
        {
            public static string manv = "";
            public static string tennv = "";
            public static int tt;
            public static string vitri = "";
            public static string congdoan = "";
        }
        private void UpdateSubCount(List<string[]> dataUser)
        {
            // Đếm số lượng các giá trị trong cột thứ 5 (chỉ số cột 6)
            int subCount = dataUser.Count(row => row.Length > 6 && row[6] == "SUB");
            int settaCount = dataUser.Count(row => row.Length > 6 && row[6] == "SETTA");
            int buhinCount = dataUser.Count(row => row.Length > 6 && row[6] == "BUHIN");
            int tapeCount = dataUser.Count(row => row.Length > 6 && row[6] == "TAPE");
            int checkaCount = dataUser.Count(row => row.Length > 6 && row[6] == "CHECKA");
            int gaikanCount = dataUser.Count(row => row.Length > 6 && row[6] == "GAIKAN");
            int packingCount = dataUser.Count(row => row.Length > 6 && row[6] == "PACKING");
            int kaibanCount = dataUser.Count(row => row.Length > 6 && row[6] == "KANBAN");
            int offlineCount = dataUser.Count(row => row.Length > 6 && row[6] == "OFFLINE");
            int shiageCount = dataUser.Count(row => row.Length > 6 && row[6] == "SHIAGE");
            int layoutCount = dataUser.Count(row => row.Length > 6 && row[6] == "LAYOUT");
            int osubCount = dataUser.Count(row => row.Length > 6 && row[6] == "OSUB");
            int leaderCount = dataUser.Count(row => row.Length > 6 && row[6] == "QL");
            int doiungCount = dataUser.Count(row => row.Length > 6 && row[6] == "DoiUng");
            int totalCount = subCount + settaCount + buhinCount + tapeCount + checkaCount + gaikanCount + packingCount + leaderCount+ offlineCount + shiageCount + layoutCount + osubCount + kaibanCount + doiungCount;

            // Hiển thị kết quả trong TextBox
            txtSUBTong.Text = subCount.ToString();
            txtSETTATong.Text = settaCount.ToString();
            txtBUHINTong.Text = buhinCount.ToString();
            txtTAPETong.Text = tapeCount.ToString();
            txtCHECKATong.Text = checkaCount.ToString();
            txtGAIKANTong.Text = gaikanCount.ToString();
            txtPACKINGTong.Text = packingCount.ToString();
            txtLEADERTong.Text = leaderCount.ToString();
            txtOFFLINETong.Text = offlineCount.ToString();
            txtSHIAGETong.Text = shiageCount.ToString();
            txtLAYOUTTong.Text = layoutCount.ToString();
            txtKANBANTong.Text = kaibanCount.ToString();
            txtOSUBTong.Text = osubCount.ToString();
            txtDOIUNGTong.Text = doiungCount.ToString();
            txtTOTALTong.Text = totalCount.ToString();
        }
        private void UpdateNghiViecvsChuyenViTri(List<string[]> dataUser)
        {
            string cacvitringhiviecvachuyenvt = "";
            foreach (var row in dataUser)
            {
                if (row.Length > 8 && (row[8] == "Nghi Viec" || row[8] == "Chuyen VT"))
                {
                    cacvitringhiviecvachuyenvt += row[4]+ " ,";
                }
            }
            lb_ChuaCoNguoiHoc.Text = cacvitringhiviecvachuyenvt;

        }

        private void UpdateDanhSachVịTriNghi(string maNhanVienQuetThe = null)
        {
            // Kiểm tra xem danh sách data_user có dữ liệu không
            if (data_user == null || data_user.Count == 0)
            {
                MessageBox.Show("Danh sách dữ liệu trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách mã nhân viên từ cột 2 (chỉ số 1), bỏ qua 4 dòng đầu (dòng đầu tiên chứa tiêu đề)
            var danhSachMaNhanVien = data_user
                .Skip(4)  // Bỏ qua 4 dòng đầu
                .Where(u => u.Length > 1)  // Đảm bảo có ít nhất 2 cột (mã nhân viên và vị trí)
                .Select(u => u[1].Trim())  // Lấy mã nhân viên từ cột 2 (chỉ số 1)
                .Distinct()
                .ToList();

            // Lọc vị trí từ cột 5 (chỉ số 4) dựa vào mã nhân viên, bỏ qua 4 dòng đầu
            var danhSachViTri = data_user
                .Skip(4)  // Bỏ qua 4 dòng đầu
                .Where(u => u.Length > 4 && danhSachMaNhanVien.Contains(u[1].Trim())) // Kiểm tra mã nhân viên ở cột 2
                .Select(u => new { MaNhanVien = u[1].Trim(), ViTri = u[4].Trim() }) // Lấy mã nhân viên và vị trí từ cột 5
                .Where(v => !string.IsNullOrWhiteSpace(v.ViTri)) // Loại bỏ vị trí rỗng
                .Distinct()
                .ToList();

            // Kiểm tra mã nhân viên đã quẹt thẻ và loại bỏ vị trí của họ
            if (!string.IsNullOrEmpty(maNhanVienQuetThe))
            {
                // Loại bỏ mã nhân viên đã quẹt thẻ khỏi danh sách (loại bỏ vị trí của nhân viên này)
                danhSachViTri = danhSachViTri
                    .Where(v => v.MaNhanVien != maNhanVienQuetThe) // Loại bỏ nhân viên đã quẹt thẻ
                    .ToList();
            }

            // Cập nhật danh sách vị trí lên lb_NghiTrongNgay (chỉ hiển thị các vị trí chưa quẹt thẻ, mỗi vị trí cách nhau dấu ",")
            lb_NghiTrongNgay.Text = string.Join(", ", danhSachViTri.Select(v => v.ViTri));

            // Hiển thị tổng số vị trí còn lại
            //txtTOTALTong.Text = danhSachViTri.Count.ToString();
        }
        // Hàm xử lý mã CODE khi quẹt thẻ
        // Khai báo biến scanCounts để lưu trữ số lượng quẹt thẻ tại các vị trí
        Dictionary<string, int> scanCounts = new Dictionary<string, int>()
            {
                { "SUB", 0 },
                { "OSUB", 0 },
                { "SETTA", 0 },
                { "KANBAN", 0 },
                { "BUHIN", 0 },
                { "LAYOUT", 0 },
                { "TAPE", 0 },
                { "OFFLINE", 0 },
                { "CHECKA", 0 },
                { "SHIAGE", 0 },
                { "GAIKAN", 0 },
                { "PACKING", 0 },
                { "LEADER", 0 },
                { "DOIUNG", 0 },
                { "TOTAL", 0 }  // Tổng số quẹt
            };
        string ViTriHoTro = "";
        private void ProcessScannedCode()
        {

            // Kiểm tra nếu mã quẹt có đúng 7 ký tự và bắt đầu bằng 'V'
            if (scannedCode.Length != 7 || !scannedCode.StartsWith("V"))
            {
                MessageBox.Show("Mã nhân viên chưa chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Dừng lại không tiếp tục xử lý
            }

            // Bắt đầu từ dòng thứ 5 (index 4) và tìm thông tin nhân viên từ data_user
            var user = data_user.Skip(4).FirstOrDefault(u => u.Length > 1 && u[1].Trim() == scannedCode);

            if (user != null)
            {
                try
                {
                    int TT = int.Parse(user[0]) - 1; // Lấy số thứ tự từ cột đầu tiên
                    string code = user[1]; // Mã quẹt (cột 2)
                    string name = user[2]; // Tên nhân viên (cột 3)
                    string position = user[5]; // Vị trí của nhân viên (cột 6)

                    // Cập nhật giao diện
                    UpdateDuLieuLenDanhSach(TT, code, name);

                    // Gọi hàm để cập nhật số lượng quẹt thẻ cho vị trí
                    UpdateScanCountAndDisplay(position);

                    // Cập nhật vị trí đã quẹt thẻ
                    UpdateDanhSachVịTriNghi(scannedCode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xử lý dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Xử lý nếu mã không tìm thấy trong danh sách (mã mới hoặc người ngoài danh sách)
                LuuThongTin.manv = scannedCode;
                c FrmNguoiMoi = new c();
                FrmNguoiMoi.ShowDialog();

                int TT = LuuThongTin.tt - 1;
                string code = LuuThongTin.manv;
                string name = LuuThongTin.tennv;
                string vitri = LuuThongTin.vitri;
                string congdoan = LuuThongTin.congdoan;
                

                // Cập nhật dữ liệu cho các trường hợp người mới
                switch (vitri)
                {
                    case "Người hỗ trợ":
                        UpdateDuLieuNguoiHoTro(TT, code, name);
                        ViTriHoTro += congdoan + " ,";
                        ViTiHoTroNguoiHoTro(ViTriHoTro);
                        break;
                    case "Người thay thế":
                        UpdateDuLieuNguoithaythe(TT, code, name);
                        break;
                    case "Người mới học vị trí":
                        UpdateDuLieuNguoimoihocvitri(TT, code, name);
                        break;
                    case "Người cũ học vị trí":
                        UpdateDuLieuNguoicuhocvitri(TT, code, name);
                        break;
                    case "Người thay thế + Người hỗ trợ":
                        UpdateDuLieuNguoithaythevahotro(TT, code);
                        break;
                    case "Người thay thế quản lý":
                        UpdateDuLieuQuanLyNghi(TT, code, name);
                        break;
                }

                //switch (vitri)
                //{
                //    case "Quản lý":
                //        scanCounts["QL"]++; // Tăng đếm cho QL
                //        string QL = scanCounts["QL"].ToString(); // Cập nhật txtLEADER
                //        if (txtLEADER.InvokeRequired)
                //        {
                //            txtLEADER.Invoke(new Action(() => txtLEADER.Text = QL));
                //        }
                //        else
                //        {
                //            txtLEADER.Text = QL;
                //        }
                //        break;
                string position = "";
                if (TT <3)
                {
                    position = "LEADER";
                }
                else if(TT <5)
                {
                    position = "SETTA";
                }
                // Cập nhật số lượng quẹt thẻ cho vị trí mới và người ngoài danh sách
                UpdateScanCountAndDisplay(position);
            }
        }
        public void UpdateScanCountAndDisplay(string vitri)
        {
            // Kiểm tra nếu vị trí hợp lệ
            if (string.IsNullOrEmpty(vitri)) return;

            // Tăng số lần quẹt cho vị trí tương ứng
            if (scanCounts.ContainsKey(vitri))
            {
                scanCounts[vitri]++;  // Tăng số lần quẹt cho vị trí tương ứng
            }
            else
            {
                // Nếu vị trí không tồn tại trong từ điển, thêm vào và khởi tạo số quẹt = 1
                scanCounts[vitri] = 1;
            }

            // Cập nhật tổng số quẹt
            int totalScanCount = scanCounts.Values.Sum();

            // Cập nhật hiển thị trên giao diện cho từng vị trí
            this.Invoke(new Action(() =>
            {
                txtSUBCoMat.Text = scanCounts["SUB"].ToString();
                txtOSUBCoMat.Text = scanCounts["OSUB"].ToString();
                txtSETTACoMat.Text = scanCounts["SETTA"].ToString();
                txtKANBANCoMat.Text = scanCounts["KANBAN"].ToString();
                txtBUHINCoMat.Text = scanCounts["BUHIN"].ToString();
                txtLAYOUTCoMat.Text = scanCounts["LAYOUT"].ToString();
                txtTAPECoMat.Text = scanCounts["TAPE"].ToString();
                txtOFFLINECoMat.Text = scanCounts["OFFLINE"].ToString();
                txtCHECKACoMat.Text = scanCounts["CHECKA"].ToString();
                txtSHIAGECoMat.Text = scanCounts["SHIAGE"].ToString();
                txtGAIKANCoMat.Text = scanCounts["GAIKAN"].ToString();
                txtPACKINGCoMat.Text = scanCounts["PACKING"].ToString();
                txtLEADERCoMat.Text = scanCounts["LEADER"].ToString();
                txtDOIUNGCoMat.Text = scanCounts["DOIUNG"].ToString();
                txtTOTALCoMat.Text = totalScanCount.ToString();  // Cập nhật tổng số quẹt
            }));
        }

        // Cập nhật mã CODE lên control trong danh sách
        private void UpdateDuLieuLenDanhSach(int TT, string code, string name)
        {
            this.Invoke(new Action(() =>
            {
                controlmatrix[1][TT].Text = code;
                controlmatrix[1][TT].BackColor = Color.Blue;
                controlmatrix[2][TT].Text = name;
                controlmatrix[2][TT].BackColor = Color.Blue;
            }));
        }
        // Cập nhật mã CODE lên control trong ngoài sách
        private void UpdateDuLieuNguoiHoTro(int TT, string code, string name)
        {
            this.Invoke(new Action(() =>
            {

                controlmatrix[1][TT].Text = code;
                controlmatrix[1][TT].BackColor = Color.Yellow;
                controlmatrix[2][TT].Text = name;
                controlmatrix[2][TT].BackColor = Color.Yellow;
            }));
        }
        private void ViTiHoTroNguoiHoTro(string ViTriHoTro)
        {
            this.Invoke(new Action(() =>
            {
                lb_ViTriHoTro.Text = ViTriHoTro;
            }));
        }
        private void UpdateDuLieuNguoithaythe(int TT, string code, string name)
        {
            this.Invoke(new Action(() =>
            {
                controlmatrix[1][TT].Text = code;
                controlmatrix[1][TT].BackColor = Color.Lime;
                controlmatrix[2][TT].Text = name;
                controlmatrix[2][TT].BackColor = Color.Lime;
            }));
        }
        private void UpdateDuLieuNguoimoihocvitri(int TT, string code, string name)
        {
            this.Invoke(new Action(() =>
            {

                controlmatrix[1][TT].Text = code;
                controlmatrix[1][TT].BackColor = Color.Violet;
                controlmatrix[2][TT].Text = name;
                controlmatrix[2][TT].BackColor = Color.Violet;
            }));
        }
        private void UpdateDuLieuNguoicuhocvitri(int TT, string code, string name)
        {
            this.Invoke(new Action(() =>
            {

                controlmatrix[1][TT].Text = code;
                controlmatrix[1][TT].BackColor = Color.Cyan;
                controlmatrix[2][TT].Text = name;
                controlmatrix[2][TT].BackColor = Color.Cyan;
            }));
        }
        private void UpdateDuLieuQuanLyNghi(int TT, string code, string name)
        {
            this.Invoke(new Action(() =>
            {

                controlmatrix[1][TT].Text = code;
                controlmatrix[1][TT].BackColor = Color.Orange;
                controlmatrix[2][TT].Text = name;
                controlmatrix[2][TT].BackColor = Color.Orange;
            }));
        }
        private void UpdateDuLieuNguoithaythevahotro(int TT, string code)
        {
            this.Invoke(new Action(() =>
            {
                controlmatrix[2][TT].Refresh();
                controlmatrix[2][TT].Text = code;
                controlmatrix[2][TT].BackColor = Color.Yellow;
            }));
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh";
                openFileDialog.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                // Thiết lập thư mục mặc định
                string defaultPath = Path.Combine(Application.StartupPath, "PICTURE");
                if (Directory.Exists(defaultPath))
                {
                    openFileDialog.InitialDirectory = defaultPath;
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                    }
                }
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận thoát",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy việc đóng form
            }
        }

        private void btnDungChuyen_Click(object sender, EventArgs e)
        {
            DateTime GioDungChuyen = DateTime.Now;
            string GioDungChuyenString = GioDungChuyen.ToString("HH:mm:ss"); // Format giờ dễ đọc

            // Thêm hàng mới vào DataGridView
            dataGridView1.Rows.Add(GioDungChuyenString);

        }

    }
}
 
