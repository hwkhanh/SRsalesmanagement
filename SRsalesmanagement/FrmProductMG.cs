using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace SRsalesmanagement
{
    public partial class FrmProductMG : Form
    {
        // List to temporarily store product data
        private List<Product> productList = new List<Product>();

        public FrmProductMG()
        {
            InitializeComponent();
            InitializeListView();
            LoadProductData();
            PopulateCategoryComboBox();
            PopulateSortingComboBox();
        }

        private void FrmProductMG_Load(object sender, EventArgs e)
        {
            lvProduct.SelectedIndexChanged += lvProduct_SelectedIndexChanged;
            btnDelete.Click += btnDelete_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnAdd.Click += btnAdd_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
        }

        // 1. Setup ListView Columns
        private void InitializeListView()
        {
            lvProduct.View = View.Details;
            lvProduct.FullRowSelect = true;

            lvProduct.Columns.Add("Product ID", 100, HorizontalAlignment.Left);
            lvProduct.Columns.Add("Product Name", 200, HorizontalAlignment.Left);
            lvProduct.Columns.Add("Category", 150, HorizontalAlignment.Left);
            lvProduct.Columns.Add("Cost", 100, HorizontalAlignment.Right);
            lvProduct.Columns.Add("Price", 100, HorizontalAlignment.Right);
            lvProduct.Columns.Add("Stock", 100, HorizontalAlignment.Right);
        }

        // 2. Populate Category ComboBox
        private void PopulateCategoryComboBox()
        {
            cboCategory.Items.AddRange(new object[] {
                "Sea Fish", "River Fish", "Shellfish", "Mixed Products", "Premium Packs"
            });
            cboCategory.SelectedIndex = 0;
        }

        // 3. Populate Sorting ComboBox
        private void PopulateSortingComboBox()
        {
            cboSort.Items.Add("Price (Low to High)");
            cboSort.Items.Add("Price (High to Low)");
            cboSort.Items.Add("Stock (Low to High)");
            cboSort.Items.Add("Stock (High to Low)");
            cboSort.SelectedIndex = 0; // Default selection
        }

        // 4. Load Product Data from Database
        private void LoadProductData()
        {
            lvProduct.Items.Clear();
            productList.Clear();

            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            string query = @"SELECT p.Product_ID, p.Product_Name, c.Category_Name, p.Cost, p.Price, p.Stock
                             FROM Product p
                             INNER JOIN Category c ON p.Category_ID = c.Category_ID";

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
                                var product = new Product
                                {
                                    ProductID = reader["Product_ID"].ToString(),
                                    ProductName = reader["Product_Name"].ToString(),
                                    Category = reader["Category_Name"].ToString(),
                                    Cost = reader.GetDecimal(reader.GetOrdinal("Cost")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Stock = reader.GetInt32(reader.GetOrdinal("Stock"))
                                };
                                productList.Add(product);
                            }
                        }
                    }
                }

                // Populate ListView
                UpdateListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Update ListView
        private void UpdateListView()
        {
            // Clear existing items
            lvProduct.Items.Clear();

            // Populate ListView with product data
            foreach (var product in productList)
            {
                var item = new ListViewItem(product.ProductID);
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add(product.Category);
                item.SubItems.Add(product.Cost.ToString("#,0", CultureInfo.InvariantCulture) + " VND");
                item.SubItems.Add(product.Price.ToString("#,0", CultureInfo.InvariantCulture) + " VND");
                item.SubItems.Add(product.Stock.ToString());
                lvProduct.Items.Add(item);
            }
        }

        // 6. Handle ListView Item Selection
        private void lvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count > 0)
            {
                var selectedItem = lvProduct.SelectedItems[0];
                txtProductID.Text = selectedItem.SubItems[0].Text;
                txtProductName.Text = selectedItem.SubItems[1].Text;
                cboCategory.SelectedItem = selectedItem.SubItems[2].Text;
                txtCost.Text = selectedItem.SubItems[3].Text.Replace(" VND", "").Replace(",", "");
                txtPrice.Text = selectedItem.SubItems[4].Text.Replace(" VND", "").Replace(",", "");
                txtQuantity.Text = selectedItem.SubItems[5].Text;
            }
        }

        // 7. Add New Product
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = txtProductID.Text.Trim();
                string productName = txtProductName.Text.Trim();
                string category = cboCategory.SelectedItem.ToString();
                decimal cost = decimal.Parse(txtCost.Text.Trim(), CultureInfo.InvariantCulture);
                decimal price = decimal.Parse(txtPrice.Text.Trim(), CultureInfo.InvariantCulture);
                int stock = int.Parse(txtQuantity.Text.Trim());

                if (string.IsNullOrWhiteSpace(productID) || string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("Product ID and Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ExecuteNonQuery(
                    @"INSERT INTO Product (Product_ID, Product_Name, Category_ID, Cost, Price, Stock)
                      VALUES (@ProductID, @ProductName, 
                              (SELECT Category_ID FROM Category WHERE Category_Name = @CategoryName), 
                              @Cost, @Price, @Stock)",
                    new SqlParameter("@ProductID", productID),
                    new SqlParameter("@ProductName", productName),
                    new SqlParameter("@CategoryName", category),
                    new SqlParameter("@Cost", cost),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Stock", stock));

                LoadProductData();
                ClearInputFields();
                MessageBox.Show("Product added successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error");
            }
        }

        // 8. Update Existing Product
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = txtProductID.Text.Trim();
                string productName = txtProductName.Text.Trim();
                string category = cboCategory.SelectedItem.ToString();
                decimal cost = decimal.Parse(txtCost.Text.Trim(), CultureInfo.InvariantCulture);
                decimal price = decimal.Parse(txtPrice.Text.Trim(), CultureInfo.InvariantCulture);
                int stock = int.Parse(txtQuantity.Text.Trim());

                ExecuteNonQuery(
                    @"UPDATE Product 
                      SET Product_Name = @ProductName,
                          Category_ID = (SELECT Category_ID FROM Category WHERE Category_Name = @CategoryName),
                          Cost = @Cost, Price = @Price, Stock = @Stock
                      WHERE Product_ID = @ProductID",
                    new SqlParameter("@ProductID", productID),
                    new SqlParameter("@ProductName", productName),
                    new SqlParameter("@CategoryName", category),
                    new SqlParameter("@Cost", cost),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Stock", stock));

                LoadProductData();
                ClearInputFields();
                MessageBox.Show("Product updated successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error");
            }
        }

        // 9. Delete Product
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count == 0) return;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string productID = lvProduct.SelectedItems[0].SubItems[0].Text;

                ExecuteNonQuery("DELETE FROM Product WHERE Product_ID = @ProductID", new SqlParameter("@ProductID", productID));

                LoadProductData();
                ClearInputFields();

                MessageBox.Show("Product deleted successfully!", "Success");
            }
            else
            {
                MessageBox.Show("Delete operation canceled.", "Canceled");
            }
        }

        // 10. Utility: Execute Non-Query Commands
        private void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 11. Clear Input Fields
        private void ClearInputFields()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = 0;
        }

        // 12. Search Functionality
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.ToLower();
            foreach (ListViewItem item in lvProduct.Items)
            {
                bool match = false;
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(searchQuery))
                    {
                        match = true;
                        break;
                    }
                }

                item.Remove();
                if (match)
                {
                    lvProduct.Items.Add(item);
                }
            }
        }

        // 13. Sorting Handler
        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSort.SelectedItem.ToString())
            {
                case "Price (Low to High)":
                    productList.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
                    break;
                case "Price (High to Low)":
                    productList.Sort((p1, p2) => p2.Price.CompareTo(p1.Price));
                    break;
                case "Stock (Low to High)":
                    productList.Sort((p1, p2) => p1.Stock.CompareTo(p2.Stock));
                    break;
                case "Stock (High to Low)":
                    productList.Sort((p1, p2) => p2.Stock.CompareTo(p1.Stock));
                    break;
            }

            // Reload the ListView with sorted data
            UpdateListView();
        }

        // 14. Product Class
        private class Product
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal Cost { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = 0;
        }
    }
}
