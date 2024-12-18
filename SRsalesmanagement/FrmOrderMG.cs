using System;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace SRsalesmanagement
{
    public partial class FrmOrderMG : Form
    {
        private decimal productPrice = 0;

        public FrmOrderMG()
        {
            InitializeComponent();
            InitializeListView();
            LoadOrderData();
            PopulateCustomerComboBox();
            PopulateProductComboBox();
            PopulateStatusComboBox();
        }

        private void FrmOrderMG_Load(object sender, EventArgs e)
        {
            lvOrders.SelectedIndexChanged += lvOrders_SelectedIndexChanged;
            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // Attach the TextChanged event for dynamic searching
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        // 1. Setup ListView Columns
        private void InitializeListView()
        {
            lvOrders.View = View.Details;
            lvOrders.FullRowSelect = true;

            lvOrders.Columns.Add("Order ID", 100, HorizontalAlignment.Left);
            lvOrders.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            lvOrders.Columns.Add("Product Name", 200, HorizontalAlignment.Left);
            lvOrders.Columns.Add("Quantity", 100, HorizontalAlignment.Right);
            lvOrders.Columns.Add("Status", 100, HorizontalAlignment.Left);
            lvOrders.Columns.Add("Total Amount", 120, HorizontalAlignment.Right);
            lvOrders.Columns.Add("Order Date", 150, HorizontalAlignment.Left);
        }

        // 2. Load Order Data from Database
        private void LoadOrderData()
        {
            lvOrders.Items.Clear();

            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            string query = @"
                SELECT o.Order_ID, c.Customer_Name, p.Product_Name, od.Quantity, o.Status, 
                       (od.Quantity * p.Price) AS TotalAmount, o.Order_Date
                FROM Orders o
                INNER JOIN Customers c ON o.Customer_ID = c.Customer_ID
                INNER JOIN Order_Detail od ON o.Order_ID = od.Order_ID
                INNER JOIN Product p ON od.Product_ID = p.Product_ID
                ORDER BY o.Order_Date DESC";  // Sắp xếp theo Order_Date

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string orderID = reader["Order_ID"].ToString();
                                string customerName = reader["Customer_Name"].ToString();
                                string productName = reader["Product_Name"].ToString();
                                int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                                string status = reader["Status"].ToString();
                                decimal totalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount"));
                                DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("Order_Date"));

                                var item = new ListViewItem(orderID);
                                item.SubItems.Add(customerName);
                                item.SubItems.Add(productName);
                                item.SubItems.Add(quantity.ToString());
                                item.SubItems.Add(status);
                                item.SubItems.Add(totalAmount.ToString("#,0", CultureInfo.InvariantCulture) + " VND");
                                item.SubItems.Add(orderDate.ToString("dd/MM/yyyy"));

                                lvOrders.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Populate Customer ComboBox
        private void PopulateCustomerComboBox()
        {
            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            string query = "SELECT Customer_Name FROM Customers";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cboCustomer.Items.Clear();
                            while (reader.Read())
                            {
                                cboCustomer.Items.Add(reader["Customer_Name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Populate Product ComboBox
        private void PopulateProductComboBox()
        {
            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            string query = "SELECT Product_Name FROM Product";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cboProduct.Items.Clear();
                            while (reader.Read())
                            {
                                cboProduct.Items.Add(reader["Product_Name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Populate Status ComboBox with predefined status values
        private void PopulateStatusComboBox()
        {
            cboStatus.Items.AddRange(new object[] { "Pending", "Completed", "Cancelled" });
            cboStatus.SelectedIndex = 0; // Set default status to "Pending"
        }

        // 6. Handle ListView Item Selection
        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOrders.SelectedItems.Count > 0)
            {
                var selectedItem = lvOrders.SelectedItems[0];
                txtOrderID.Text = selectedItem.SubItems[0].Text;

                cboCustomer.SelectedItem = selectedItem.SubItems[1].Text;
                cboProduct.SelectedItem = selectedItem.SubItems[2].Text;
                txtQuantity.Text = selectedItem.SubItems[3].Text;
                cboStatus.SelectedItem = selectedItem.SubItems[4].Text;
                txtTotalAmount.Text = selectedItem.SubItems[5].Text;
            }
        }

        // 7. Handle Product ComboBox selection change event to update the product price
        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedItem != null)
            {
                string selectedProduct = cboProduct.SelectedItem.ToString();
                productPrice = GetProductPrice(selectedProduct);
                UpdateTotalAmount();
            }
        }

        // 8. Handle Quantity TextBox change event to update the Total Amount
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        // 9. Update the Total Amount field based on the product price and quantity
        private void UpdateTotalAmount()
        {
            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                decimal totalAmount = productPrice * quantity;
                txtTotalAmount.Text = totalAmount.ToString("#,0", CultureInfo.InvariantCulture) + " VND";
            }
            else
            {
                txtTotalAmount.Clear(); // Clear if quantity is not valid
            }
        }

        // 10. Handle "Add" Button Click (Add a new order)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(txtOrderID.Text) || string.IsNullOrEmpty(cboCustomer.Text) ||
                string.IsNullOrEmpty(cboProduct.Text) || string.IsNullOrEmpty(txtQuantity.Text) ||
                string.IsNullOrEmpty(cboStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderID = int.Parse(txtOrderID.Text);  // Get Order_ID from the TextBox
            string customerName = cboCustomer.Text;
            string productName = cboProduct.Text;
            int quantity = int.Parse(txtQuantity.Text);
            string status = cboStatus.Text;
            DateTime orderDate = DateTime.Now;  // Get current system time as order date
            decimal totalAmount = productPrice * quantity;

            // Start SQL transaction
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True"))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Check if the Order_ID already exists in the Orders table
                    string checkOrderIDQuery = "SELECT COUNT(*) FROM Orders WHERE Order_ID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(checkOrderIDQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("The Order ID already exists. Please enter a unique Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop execution if Order ID already exists
                        }
                    }

                    // 2. Insert into Orders table with the provided Order_ID
                    string orderQuery = @"
                        INSERT INTO Orders (Order_ID, Customer_ID, Status, Order_Date)
                        VALUES (@OrderID, (SELECT Customer_ID FROM Customers WHERE Customer_Name = @CustomerName), 
                                @Status, @OrderDate)";

                    using (SqlCommand cmd = new SqlCommand(orderQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@OrderDate", orderDate);

                        cmd.ExecuteNonQuery();
                    }

                    // 3. Insert into Order_Detail table using the provided Order_ID
                    string detailQuery = @"
                        INSERT INTO Order_Detail (Order_ID, Product_ID, Quantity)
                        VALUES (@OrderID, (SELECT Product_ID FROM Product WHERE Product_Name = @ProductName), @Quantity)";

                    using (SqlCommand cmd = new SqlCommand(detailQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        cmd.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();

                    // Reload order data to update the ListView
                    LoadOrderData();
                    MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    MessageBox.Show($"Error adding order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Retrieve product price from the database
        private decimal GetProductPrice(string productName)
        {
            decimal price = 0;
            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            string query = "SELECT Price FROM Product WHERE Product_Name = @ProductName";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        price = (decimal)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving product price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return price;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            // Validate input fields
            if (string.IsNullOrEmpty(txtOrderID.Text) || string.IsNullOrEmpty(cboCustomer.Text) ||
                string.IsNullOrEmpty(cboProduct.Text) || string.IsNullOrEmpty(txtQuantity.Text) ||
                string.IsNullOrEmpty(cboStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get data from the form controls
            int orderID = int.Parse(txtOrderID.Text);
            string customerName = cboCustomer.Text;
            string productName = cboProduct.Text;
            int quantity = int.Parse(txtQuantity.Text);
            string status = cboStatus.Text;
            DateTime orderDate = DateTime.Now;  // Get current system time as order date
            decimal totalAmount = productPrice * quantity;

            // Start SQL transaction
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True"))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Check if the Order exists in the Orders table
                    string checkOrderQuery = "SELECT COUNT(*) FROM Orders WHERE Order_ID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(checkOrderQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        int count = (int)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("The Order ID does not exist. Please enter a valid Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop execution if Order ID doesn't exist
                        }
                    }

                    // 2. Update the Orders table with the new data
                    string updateOrderQuery = @"
                UPDATE Orders 
                SET Customer_ID = (SELECT Customer_ID FROM Customers WHERE Customer_Name = @CustomerName),
                    Status = @Status,
                    Order_Date = @OrderDate
                WHERE Order_ID = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(updateOrderQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@OrderDate", orderDate);

                        cmd.ExecuteNonQuery();
                    }

                    // 3. Update the Order_Detail table with the new product and quantity
                    string updateDetailQuery = @"
                UPDATE Order_Detail 
                SET Product_ID = (SELECT Product_ID FROM Product WHERE Product_Name = @ProductName),
                    Quantity = @Quantity
                WHERE Order_ID = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(updateDetailQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        cmd.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();

                    // Reload order data to update the ListView
                    LoadOrderData();
                    MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }







        }

        // 12. Handle "Delete" Button Click (Delete an existing order)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate if an Order ID is selected or entered
            if (string.IsNullOrEmpty(txtOrderID.Text))
            {
                MessageBox.Show("Please enter a valid Order ID to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderID;
            if (!int.TryParse(txtOrderID.Text, out orderID))
            {
                MessageBox.Show("Invalid Order ID format. Please enter a valid numeric Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return; // User cancelled the deletion
            }

            // Start SQL transaction
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True"))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Delete from Order_Detail table
                    string deleteDetailQuery = "DELETE FROM Order_Detail WHERE Order_ID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(deleteDetailQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Delete from Orders table
                    string deleteOrderQuery = "DELETE FROM Orders WHERE Order_ID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(deleteOrderQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();

                    // Reload order data to update the ListView
                    LoadOrderData();
                    MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    MessageBox.Show($"Error deleting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event handler for the TextBox text change event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            SearchOrders(searchTerm);
        }
        // Search orders based on the search term and display results in the ListView
        private void SearchOrders(string searchTerm)
        {
            lvOrders.Items.Clear(); // Clear the existing data in the ListView

            // Connection string and SQL query
            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            string query = @"
        SELECT o.Order_ID, c.Customer_Name, p.Product_Name, od.Quantity, o.Status, 
               (od.Quantity * p.Price) AS TotalAmount, o.Order_Date
        FROM Orders o
        INNER JOIN Customers c ON o.Customer_ID = c.Customer_ID
        INNER JOIN Order_Detail od ON o.Order_ID = od.Order_ID
        INNER JOIN Product p ON od.Product_ID = p.Product_ID
        WHERE o.Order_ID LIKE @SearchTerm 
           OR c.Customer_Name LIKE @SearchTerm 
           OR p.Product_Name LIKE @SearchTerm
        ORDER BY o.Order_Date DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter for partial search
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate ListView with search results
                            while (reader.Read())
                            {
                                string orderID = reader["Order_ID"].ToString();
                                string customerName = reader["Customer_Name"].ToString();
                                string productName = reader["Product_Name"].ToString();
                                int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                                string status = reader["Status"].ToString();
                                decimal totalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount"));
                                DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("Order_Date"));

                                // Create a new ListView item
                                var item = new ListViewItem(orderID);
                                item.SubItems.Add(customerName);
                                item.SubItems.Add(productName);
                                item.SubItems.Add(quantity.ToString());
                                item.SubItems.Add(status);
                                item.SubItems.Add(totalAmount.ToString("#,0", CultureInfo.InvariantCulture) + " VND");
                                item.SubItems.Add(orderDate.ToString("dd/MM/yyyy"));

                                // Add the item to the ListView
                                lvOrders.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            txtOrderID.Clear();
            cboProduct.SelectedIndex = 0;
            cboCustomer.SelectedIndex = 0;
            txtTotalAmount.Clear();
            txtQuantity.Clear();
            cboStatus.SelectedIndex = 0;
        }

        private void lvOrders_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer sorter = lvOrders.ListViewItemSorter as ListViewItemComparer;

            if (sorter == null)
            {
                sorter = new ListViewItemComparer(e.Column);
                lvOrders.ListViewItemSorter = sorter;
            }
            if (e.Column == sorter.SortColumn)
            {
                sorter.Order = sorter.Order == Microsoft.Data.SqlClient.SortOrder.Ascending ? Microsoft.Data.SqlClient.SortOrder.Descending : Microsoft.Data.SqlClient.SortOrder.Ascending;
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = Microsoft.Data.SqlClient.SortOrder.Ascending;
            }
            lvOrders.Sort();
        }
        public class ListViewItemComparer : IComparer
        {
            public int SortColumn { get; set; }
            public Microsoft.Data.SqlClient.SortOrder Order { get; set; }

            public ListViewItemComparer(int column)
            {
                SortColumn = column;
                Order = Microsoft.Data.SqlClient.SortOrder.Ascending;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = x as ListViewItem;
                ListViewItem itemY = y as ListViewItem;

                string valueX = itemX.SubItems[SortColumn].Text;
                string valueY = itemY.SubItems[SortColumn].Text;

                int result;

                if (decimal.TryParse(valueX, out decimal decimalX) && decimal.TryParse(valueY, out decimal decimalY))
                {
                    result = decimalX.CompareTo(decimalY);
                }
                else
                {
                    result = string.Compare(valueX, valueY);
                }

                if (Order == Microsoft.Data.SqlClient.SortOrder.Descending)
                {
                    result = -result;
                }

                return result;
            }
        }
    }
}
