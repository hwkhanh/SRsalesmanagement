namespace SRsalesmanagement
{
    partial class FrmOrderMG
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
            lvOrders = new ListView();
            txtOrderID = new TextBox();
            cboStatus = new ComboBox();
            button1 = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            cboCustomer = new ComboBox();
            cboProduct = new ComboBox();
            txtTotalAmount = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            txtQuantity = new TextBox();
            txtSearch = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // lvOrders
            // 
            lvOrders.Location = new Point(2, 207);
            lvOrders.Name = "lvOrders";
            lvOrders.Size = new Size(984, 294);
            lvOrders.TabIndex = 0;
            lvOrders.UseCompatibleStateImageBehavior = false;
            lvOrders.ColumnClick += lvOrders_ColumnClick;
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(149, 12);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.Size = new Size(213, 27);
            txtOrderID.TabIndex = 1;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(524, 45);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(214, 28);
            cboStatus.TabIndex = 4;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(781, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(781, 43);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(781, 76);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(781, 111);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(66, 19);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 10;
            label1.Text = "Order ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 85);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 11;
            label2.Text = "Product Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 52);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 12;
            label3.Text = "Customer Name :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(440, 48);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 14;
            // 
            // cboCustomer
            // 
            cboCustomer.FormattingEnabled = true;
            cboCustomer.Location = new Point(149, 45);
            cboCustomer.Name = "cboCustomer";
            cboCustomer.Size = new Size(213, 28);
            cboCustomer.TabIndex = 15;
            // 
            // cboProduct
            // 
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(149, 79);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(213, 28);
            cboProduct.TabIndex = 16;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Location = new Point(524, 80);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(214, 27);
            txtTotalAmount.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(457, 53);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 18;
            label6.Text = "Status :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(404, 85);
            label7.Name = "label7";
            label7.Size = new Size(114, 20);
            label7.TabIndex = 19;
            label7.Text = "Total Amount :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(440, 19);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 13;
            label4.Text = "Quantity :";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(524, 12);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(214, 27);
            txtQuantity.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(149, 174);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(213, 27);
            txtSearch.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(80, 181);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 21;
            label8.Text = "Search :";
            // 
            // FrmOrderMG
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 543);
            Controls.Add(label8);
            Controls.Add(txtSearch);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtTotalAmount);
            Controls.Add(cboProduct);
            Controls.Add(cboCustomer);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(button1);
            Controls.Add(cboStatus);
            Controls.Add(txtQuantity);
            Controls.Add(txtOrderID);
            Controls.Add(lvOrders);
            Name = "FrmOrderMG";
            Text = "FrmOrderMG";
            Load += FrmOrderMG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvOrders;
        private TextBox txtOrderID;
        private ComboBox cboStatus;
        private Button button1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private ComboBox cboCustomer;
        private ComboBox cboProduct;
        private TextBox txtTotalAmount;
        private Label label6;
        private Label label7;
        private Label label4;
        private TextBox txtQuantity;
        private TextBox txtSearch;
        private Label label8;
    }
}