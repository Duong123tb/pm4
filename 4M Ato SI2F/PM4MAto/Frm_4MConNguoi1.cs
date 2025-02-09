using OfficeOpenXml;
using System;
using System.IO;
using System.Windows.Forms;

namespace PM4MAto
{
    public partial class Frm_4MConNguoi : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSave;

        public Frm_4MConNguoi()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.btnSave = new Button();

            // TableLayoutPanel Settings
            this.tableLayoutPanel1.ColumnCount = 17;  // 17 cột dựa theo mẫu trong hình
            this.tableLayoutPanel1.RowCount = 10;    // 10 dòng (tùy nhu cầu)
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.AutoSize = true;

            // Thêm các tiêu đề cột (theo mẫu hình)
            string[] columnHeaders = new string[]
            {
                "Ngày", "Công đoạn", "Mã hàng", "Người xác nhận trước", "MNV trước",
                "Người thay thế", "MNV thay thế", "Xác nhận chỉ thị", "Kết quả kiểm tra",
                "Theo dõi", "Lot1", "Lot2", "Lot3", "Lot4", "Người quản lý", "Phân đoạn"
            };

            // Thêm các tiêu đề vào TableLayoutPanel
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                Label label = new Label();
                label.Text = columnHeaders[i];
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(label, i, 0);  // Thêm tiêu đề vào hàng đầu tiên
            }

            // Thêm các TextBox vào TableLayoutPanel
            for (int i = 0; i < 17; i++)  // 17 cột
            {
                for (int j = 1; j < 10; j++)  // 9 dòng (vì dòng đầu là tiêu đề)
                {
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(textBox, i, j);
                }
            }

            // Nút lưu dữ liệu vào Excel
            this.btnSave.Text = "Lưu vào Excel";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            // Đặt vị trí và kích thước cho nút lưu
            this.btnSave.Dock = DockStyle.Bottom; // Đặt nút ở dưới cùng của form
            this.btnSave.Height = 40;

            // Thêm controls vào Form
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void SaveToExcel()
        {
            // Xác định đường dẫn thư mục lưu file
            string directoryPath = Path.Combine(Application.StartupPath, "DATA", "HISTORY", "4MConNguoi");

            // Kiểm tra và tạo thư mục nếu chưa có
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath); // Tạo thư mục nếu chưa có
            }

            // Đặt tên file Excel với ngày giờ hiện tại
            string filePath = Path.Combine(directoryPath, "HISTORY_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");

            // Đặt LicenseContext cho EPPlus
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            try
            {
                // Tạo gói Excel
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Tạo sheet mới trong Excel
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Điền dữ liệu từ TableLayoutPanel vào Excel
                    for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                    {
                        for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                        {
                            var control = tableLayoutPanel1.GetControlFromPosition(col, row);
                            if (control is TextBox textBox)
                            {
                                worksheet.Cells[row + 1, col + 1].Value = textBox.Text; // Lấy dữ liệu từ TextBox
                            }
                            else if (control is Label label)
                            {
                                worksheet.Cells[row + 1, col + 1].Value = label.Text; // Điền tiêu đề cột vào Excel
                            }
                        }
                    }

                    // Lưu file Excel
                    package.Save();
                    MessageBox.Show("Đã lưu file Excel thành công tại: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file Excel: " + ex.Message);
            }
        }
    }
}