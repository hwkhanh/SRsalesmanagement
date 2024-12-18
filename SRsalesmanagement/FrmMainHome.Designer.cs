namespace SRsalesmanagement
{
    partial class FrmMainHome
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
            cmbSortByPrice = new ComboBox();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnProductMG = new Button();
            btnOrderMG = new Button();
            btnUserMG = new Button();
            btnCustomerMG = new Button();
            btnReport = new Button();
            SuspendLayout();
            // 
            // lvProduct
            // 
            lvProduct.FullRowSelect = true;
            lvProduct.GridLines = true;
            lvProduct.Location = new Point(383, 114);
            lvProduct.Name = "lvProduct";
            lvProduct.Size = new Size(578, 332);
            lvProduct.TabIndex = 0;
            lvProduct.UseCompatibleStateImageBehavior = false;
            lvProduct.View = View.Details;
            // 
            // cmbSortByPrice
            // 
            cmbSortByPrice.FormattingEnabled = true;
            cmbSortByPrice.Location = new Point(796, 80);
            cmbSortByPrice.Name = "cmbSortByPrice";
            cmbSortByPrice.Size = new Size(165, 28);
            cmbSortByPrice.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(449, 81);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(214, 27);
            txtSearch.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(383, 88);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 3;
            label1.Text = "Search :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(747, 88);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 4;
            label2.Text = "Sort :";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(361, 9);
            label3.Name = "label3";
            label3.Size = new Size(299, 50);
            label3.TabIndex = 5;
            label3.Text = "Steadfast River";
            // 
            // btnProductMG
            // 
            btnProductMG.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProductMG.Location = new Point(30, 127);
            btnProductMG.Name = "btnProductMG";
            btnProductMG.Size = new Size(226, 47);
            btnProductMG.TabIndex = 6;
            btnProductMG.Text = "Product Management";
            btnProductMG.UseVisualStyleBackColor = true;
            btnProductMG.Click += btnProductMG_Click;
            // 
            // btnOrderMG
            // 
            btnOrderMG.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrderMG.Location = new Point(30, 180);
            btnOrderMG.Name = "btnOrderMG";
            btnOrderMG.Size = new Size(226, 40);
            btnOrderMG.TabIndex = 7;
            btnOrderMG.Text = "Order Management";
            btnOrderMG.UseVisualStyleBackColor = true;
            btnOrderMG.Click += btnOrderMG_Click;
            // 
            // btnUserMG
            // 
            btnUserMG.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUserMG.Location = new Point(30, 226);
            btnUserMG.Name = "btnUserMG";
            btnUserMG.Size = new Size(226, 38);
            btnUserMG.TabIndex = 8;
            btnUserMG.Text = "User Management";
            btnUserMG.UseVisualStyleBackColor = true;
            btnUserMG.Click += btnUserMG_Click;
            // 
            // btnCustomerMG
            // 
            btnCustomerMG.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomerMG.Location = new Point(30, 270);
            btnCustomerMG.Name = "btnCustomerMG";
            btnCustomerMG.Size = new Size(226, 40);
            btnCustomerMG.TabIndex = 9;
            btnCustomerMG.Text = "Customer Management";
            btnCustomerMG.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReport.Location = new Point(30, 316);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(226, 34);
            btnReport.TabIndex = 10;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // FrmMainHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 570);
            Controls.Add(btnReport);
            Controls.Add(btnCustomerMG);
            Controls.Add(btnUserMG);
            Controls.Add(btnOrderMG);
            Controls.Add(btnProductMG);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(cmbSortByPrice);
            Controls.Add(lvProduct);
            Name = "FrmMainHome";
            Text = "FrmMainHome";
            Load += FrmMainHome_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvProduct;
        private ComboBox cmbSortByPrice;
        private TextBox txtSearch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnProductMG;
        private Button btnOrderMG;
        private Button btnUserMG;
        private Button btnCustomerMG;
        private Button btnReport;
    }
}