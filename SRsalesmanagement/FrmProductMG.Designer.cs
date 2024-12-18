namespace SRsalesmanagement
{
    partial class FrmProductMG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvProduct = new ListView();
            txtProductID = new TextBox();
            cboCategory = new ComboBox();
            txtProductName = new TextBox();
            txtCost = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtSearch = new TextBox();
            btnNew = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label7 = new Label();
            cboSort = new ComboBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lvProduct
            // 
            lvProduct.Location = new Point(1, 227);
            lvProduct.Name = "lvProduct";
            lvProduct.Size = new Size(957, 296);
            lvProduct.TabIndex = 0;
            lvProduct.UseCompatibleStateImageBehavior = false;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(133, 46);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(207, 27);
            txtProductID.TabIndex = 1;
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(133, 12);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(207, 28);
            cboCategory.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(133, 79);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(207, 27);
            txtProductName.TabIndex = 3;
            // 
            // txtCost
            // 
            txtCost.Location = new Point(533, 13);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(207, 27);
            txtCost.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(533, 53);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(207, 27);
            txtPrice.TabIndex = 5;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(533, 86);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(207, 27);
            txtQuantity.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(746, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 220);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 8;
            label1.Text = "Category :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 53);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 9;
            label2.Text = "Product ID :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 86);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 10;
            label3.Text = "Product name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(479, 20);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 11;
            label4.Text = "Cost :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(476, 60);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 12;
            label5.Text = "Price :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(451, 93);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 13;
            label6.Text = "Quantity :";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(81, 194);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(161, 27);
            txtSearch.TabIndex = 14;
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.Location = new Point(104, 133);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 15;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(256, 133);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(402, 133);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(546, 133);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 197);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 19;
            label7.Text = "Search :";
            // 
            // cboSort
            // 
            cboSort.FormattingEnabled = true;
            cboSort.Location = new Point(460, 189);
            cboSort.Name = "cboSort";
            cboSort.Size = new Size(151, 28);
            cboSort.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(402, 197);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 21;
            label8.Text = "Sort :";
            // 
            // FrmProductMG
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 565);
            Controls.Add(label8);
            Controls.Add(cboSort);
            Controls.Add(label7);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnNew);
            Controls.Add(txtSearch);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtCost);
            Controls.Add(txtProductName);
            Controls.Add(cboCategory);
            Controls.Add(txtProductID);
            Controls.Add(lvProduct);
            Name = "FrmProductMG";
            Text = "FrmProductMG";
            Load += FrmProductMG_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvProduct;
        private TextBox txtProductID;
        private ComboBox cboCategory;
        private TextBox txtProductName;
        private TextBox txtCost;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtSearch;
        private Button btnNew;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label7;
        private ComboBox cboSort;
        private Label label8;
    }
}