using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace SRsalesmanagement
{
    public partial class FrmMainHome : Form
    {
        // List to hold product data (to perform sorting and searching on)
        private List<Product> productList = new List<Product>();

        public FrmMainHome()
        {
            InitializeComponent();
            LoadProductData();    // Load data from the database into the ListView
            cmbSortByPrice.SelectedIndexChanged += CmbSortByPrice_SelectedIndexChanged; // Handle ComboBox selection change
            txtSearch.TextChanged += TxtSearch_TextChanged; // Handle TextBox text change event
        }

        private void FrmMainHome_Load(object sender, EventArgs e)
        {
            lvProduct.View = View.Details; // Display in Details view mode
            lvProduct.Columns.Add("Product ID", 100, HorizontalAlignment.Left); // Column 1: Product ID
            lvProduct.Columns.Add("Product Name", 200, HorizontalAlignment.Left); // Column 2: Product Name
            lvProduct.Columns.Add("Price", 100, HorizontalAlignment.Right); // Column 3: Price
            lvProduct.Columns.Add("Quantity", 100, HorizontalAlignment.Right); // Column 4: Quantity

            // Add sorting options to ComboBox
            cmbSortByPrice.Items.Add("Ascending");
            cmbSortByPrice.Items.Add("Descending");
        }

        // Method to load product data from the SQL Server database into the ListView
        private void LoadProductData()
        {
            lvProduct.Items.Clear(); // Clear any existing data in the ListView
            productList.Clear(); // Clear the product list

            try
            {
                string connectionString = "Data Source=LAPTOP-TEMTTV4V;Initial Catalog=SalesManagementSR;Integrated Security=True";
                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection

                    // SQL query to retrieve product data
                    string query = "SELECT Product_ID, Product_Name, Price, Stock FROM Product";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute the query and get the result using SqlDataReader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read each row of data returned from the database
                            while (reader.Read())
                            {
                                // Create a new Product object and add it to the list
                                Product product = new Product
                                {
                                    ProductID = reader["Product_ID"].ToString(),
                                    ProductName = reader["Product_Name"].ToString(),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Stock = reader["Stock"].ToString()
                                };

                                productList.Add(product);
                            }
                        }
                    }
                }
                // Initially load products in the ListView
                LoadProductsToListView();
            }
            catch (Exception ex)
            {
                // Show an error message if there is a problem loading data
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to load products into the ListView from the productList
        private void LoadProductsToListView()
        {
            lvProduct.Items.Clear(); // Clear existing items in the ListView

            foreach (var product in productList)
            {
                ListViewItem item = new ListViewItem(product.ProductID); // Column 1: Product ID
                item.SubItems.Add(product.ProductName); // Column 2: Product Name
                item.SubItems.Add(product.Price.ToString("#,0", CultureInfo.InvariantCulture) + " VND"); // Column 3: Price (formatted as VND)
                item.SubItems.Add(product.Stock); // Column 4: Quantity

                lvProduct.Items.Add(item);
            }
        }

        // ComboBox SelectedIndexChanged event handler to sort by price
        private void CmbSortByPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSortByPrice.SelectedIndex == 0) // Ascending
            {
                var sortedList = productList.OrderBy(p => p.Price).ToList();
                productList = sortedList;
            }
            else if (cmbSortByPrice.SelectedIndex == 1) // Descending
            {
                var sortedList = productList.OrderByDescending(p => p.Price).ToList();
                productList = sortedList;
            }

            // Reload the sorted products to the ListView
            LoadProductsToListView();
        }

        // TextBox TextChanged event handler to filter products based on search text
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            // Filter the product list based on search text
            var filteredList = productList.Where(p =>
                p.ProductName.ToLower().Contains(searchText) ||
                p.ProductID.ToLower().Contains(searchText)).ToList();

            // Reload the filtered products to the ListView
            LoadFilteredProductsToListView(filteredList);
        }

        // Method to load the filtered products into the ListView
        private void LoadFilteredProductsToListView(List<Product> filteredList)
        {
            lvProduct.Items.Clear(); // Clear existing items in the ListView

            foreach (var product in filteredList)
            {
                ListViewItem item = new ListViewItem(product.ProductID); // Column 1: Product ID
                item.SubItems.Add(product.ProductName); // Column 2: Product Name
                item.SubItems.Add(product.Price.ToString("#,0", CultureInfo.InvariantCulture) + " VND"); // Column 3: Price (formatted as VND)
                item.SubItems.Add(product.Stock); // Column 4: Quantity

                lvProduct.Items.Add(item);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnProductMG_Click(object sender, EventArgs e)
        {
            FrmProductMG mainForm = new FrmProductMG();
            mainForm.Show();
        }

        private void btnOrderMG_Click(object sender, EventArgs e)
        {
            FrmOrderMG mainForm = new FrmOrderMG();
            mainForm.Show();
        }

        private void btnUserMG_Click(object sender, EventArgs e)
        {
            FrmUserMG mainForm = new FrmUserMG();
            mainForm.Show();
        }
    }

    // Product class to hold product data
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Stock { get; set; }
    }
}
