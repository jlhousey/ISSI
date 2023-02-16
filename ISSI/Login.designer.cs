namespace ISSI
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cbUserID = new System.Windows.Forms.ComboBox();
            this.opsPlannerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbi_installdbDataSet = new ISSI.sbi_installdbDataSet();
            this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbi_salesdbDataSet = new ISSI.sbi_salesdbDataSet();
            this.UsersTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.UsersTableAdapter();
            this.opsPlannerTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.OpsPlannerTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.opsPlannerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(98, 84);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(141, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(34, 47);
            this.UserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(29, 13);
            this.UserLabel.TabIndex = 2;
            this.UserLabel.Text = "User";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(24, 87);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(98, 116);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 31);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbUserID
            // 
            this.cbUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUserID.DataSource = this.opsPlannerBindingSource;
            this.cbUserID.DisplayMember = "Name";
            this.cbUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserID.FormattingEnabled = true;
            this.cbUserID.Location = new System.Drawing.Point(98, 41);
            this.cbUserID.Margin = new System.Windows.Forms.Padding(2);
            this.cbUserID.Name = "cbUserID";
            this.cbUserID.Size = new System.Drawing.Size(141, 21);
            this.cbUserID.TabIndex = 0;
            this.cbUserID.ValueMember = "OpsPlannerID";
            // 
            // opsPlannerBindingSource
            // 
            this.opsPlannerBindingSource.DataMember = "OpsPlanner";
            this.opsPlannerBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // sbi_installdbDataSet
            // 
            this.sbi_installdbDataSet.DataSetName = "sbi_installdbDataSet";
            this.sbi_installdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UsersBindingSource
            // 
            this.UsersBindingSource.DataMember = "Users";
            this.UsersBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // sbi_salesdbDataSet
            // 
            this.sbi_salesdbDataSet.DataSetName = "sbi_salesdbDataSet";
            this.sbi_salesdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UsersTableAdapter
            // 
            this.UsersTableAdapter.ClearBeforeFill = true;
            // 
            // opsPlannerTableAdapter
            // 
            this.opsPlannerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChecklistItemsTableAdapter = null;
            this.tableAdapterManager.CheckListlistTableAdapter = null;
            this.tableAdapterManager.ContactsTableAdapter = null;
            this.tableAdapterManager.DepartmentTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.HResourcesTableAdapter = null;
            this.tableAdapterManager.InstallScheduleTableAdapter = null;
            this.tableAdapterManager.JobDetailsTableAdapter = null;
            this.tableAdapterManager.JobKeyDatesTableAdapter = null;
            this.tableAdapterManager.JobTypesTableAdapter = null;
            this.tableAdapterManager.KeyDateListTableAdapter = null;
            this.tableAdapterManager.OpsPlannerTableAdapter = this.opsPlannerTableAdapter;
            this.tableAdapterManager.PurchasingAreasTableAdapter = null;
            this.tableAdapterManager.ReqHResourceTableAdapter = null;
            this.tableAdapterManager.ReqPurchasingTableAdapter = null;
            this.tableAdapterManager.ReqSubConTableAdapter = null;
            this.tableAdapterManager.SiteContactEventsTableAdapter = null;
            this.tableAdapterManager.SiteDetailsTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.SubConAreasTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WorkScheduleTableAdapter = null;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 198);
            this.Controls.Add(this.cbUserID);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.tbPassword);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opsPlannerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cbUserID;
        private sbi_salesdbDataSet sbi_salesdbDataSet;
        private System.Windows.Forms.BindingSource UsersBindingSource;
        private sbi_salesdbDataSetTableAdapters.UsersTableAdapter UsersTableAdapter;
        private sbi_installdbDataSet sbi_installdbDataSet;
        private System.Windows.Forms.BindingSource opsPlannerBindingSource;
        private sbi_installdbDataSetTableAdapters.OpsPlannerTableAdapter opsPlannerTableAdapter;
        private sbi_installdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}