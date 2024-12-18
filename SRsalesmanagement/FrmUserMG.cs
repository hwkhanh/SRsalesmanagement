using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SRsalesmanagement
{
    public partial class FrmUserMG : Form
    {
        // Chuỗi kết nối tới SQL Server
        string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";

        public FrmUserMG()
        {
            InitializeComponent();
            LoadDataToListView();
        }

        // Phương thức để tải dữ liệu lên ListView
        private void LoadDataToListView()
        {
            try
            {
                // Truy vấn SQL để JOIN bảng Users và Role
                string query = @"
                    SELECT 
                        U.User_ID, 
                        U.Full_Name, 
                        U.Username, 
                        U.Email, 
                        R.Role_Name
                    FROM Users U
                    INNER JOIN Role R ON U.Role_ID = R.Role_ID";

                // Tạo kết nối và command SQL
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    // Thực thi và đọc dữ liệu
                    SqlDataReader reader = command.ExecuteReader();

                    // Cấu hình ListView (nếu chưa cấu hình)
                    lvUser.View = View.Details;
                    lvUser.FullRowSelect = true;
                    lvUser.Clear();

                    // Thêm tiêu đề các cột
                    lvUser.Columns.Add("Role Name", 150);
                    lvUser.Columns.Add("User ID", 80);
                    lvUser.Columns.Add("Full Name", 150);
                    lvUser.Columns.Add("Username", 120);
                    lvUser.Columns.Add("Email", 200);

                    // Đổ dữ liệu từ reader vào ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Role_Name"].ToString());
                        item.SubItems.Add(reader["User_ID"].ToString());
                        item.SubItems.Add(reader["Full_Name"].ToString());
                        item.SubItems.Add(reader["Username"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());

                        lvUser.Items.Add(item);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
