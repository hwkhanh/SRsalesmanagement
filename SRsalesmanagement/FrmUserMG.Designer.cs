namespace SRsalesmanagement
{
    partial class FrmUserMG
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
            lvUser = new ListView();
            cboRole = new ComboBox();
            txtUserID = new TextBox();
            txtFullName = new TextBox();
            txtUserName = new TextBox();
            txtEmail = new TextBox();
            textBox5 = new TextBox();
            btnNew = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // lvUser
            // 
            lvUser.Location = new Point(0, 240);
            lvUser.Name = "lvUser";
            lvUser.Size = new Size(973, 294);
            lvUser.TabIndex = 0;
            lvUser.UseCompatibleStateImageBehavior = false;
            lvUser.View = View.Details;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(158, 20);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(214, 28);
            cboRole.TabIndex = 1;
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(158, 73);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(214, 27);
            txtUserID.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(158, 127);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(214, 27);
            txtFullName.TabIndex = 3;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(622, 25);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(219, 27);
            txtUserName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(622, 73);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 27);
            txtEmail.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(94, 207);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(207, 27);
            textBox5.TabIndex = 6;
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.Location = new Point(511, 127);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 7;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(646, 127);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(769, 127);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(91, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(879, 127);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 33);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 11;
            label1.Text = "Role :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(64, 136);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 12;
            label2.Text = "Full Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(83, 80);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 13;
            label3.Text = "User ID :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 211);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 14;
            label4.Text = "Search :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(528, 28);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 15;
            label5.Text = "Username :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(561, 80);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 16;
            label6.Text = "Email :";
            // 
            // FrmUserMG
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 566);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnNew);
            Controls.Add(textBox5);
            Controls.Add(txtEmail);
            Controls.Add(txtUserName);
            Controls.Add(txtFullName);
            Controls.Add(txtUserID);
            Controls.Add(cboRole);
            Controls.Add(lvUser);
            Name = "FrmUserMG";
            Text = "FrmUserMG";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvUser;
        private ComboBox cboRole;
        private TextBox txtUserID;
        private TextBox txtFullName;
        private TextBox txtUserName;
        private TextBox txtEmail;
        private TextBox textBox5;
        private Button btnNew;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}