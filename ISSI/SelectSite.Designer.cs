namespace ISSI
{
    partial class SelectSite
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
            System.Windows.Forms.Label nameLabel1;
            System.Windows.Forms.Label clientIDLabel1;
            System.Windows.Forms.Label nameLabel2;
            this.button1 = new System.Windows.Forms.Button();
            this.sbi_salesdbDataSet = new ISSI.sbi_salesdbDataSet();
            this.developerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.developerTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager();
            this.clientTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.ClientTableAdapter();
            this.siteDetailsTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.SiteDetailsTableAdapter();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siteDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            nameLabel1 = new System.Windows.Forms.Label();
            clientIDLabel1 = new System.Windows.Forms.Label();
            nameLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel1
            // 
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(9, 22);
            nameLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel1.Name = "nameLabel1";
            nameLabel1.Size = new System.Drawing.Size(73, 13);
            nameLabel1.TabIndex = 7;
            nameLabel1.Text = "Developer ID:";
            // 
            // clientIDLabel1
            // 
            clientIDLabel1.AutoSize = true;
            clientIDLabel1.Location = new System.Drawing.Point(31, 54);
            clientIDLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            clientIDLabel1.Name = "clientIDLabel1";
            clientIDLabel1.Size = new System.Drawing.Size(50, 13);
            clientIDLabel1.TabIndex = 8;
            clientIDLabel1.Text = "Client ID:";
            // 
            // nameLabel2
            // 
            nameLabel2.AutoSize = true;
            nameLabel2.Location = new System.Drawing.Point(42, 94);
            nameLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel2.Name = "nameLabel2";
            nameLabel2.Size = new System.Drawing.Size(38, 13);
            nameLabel2.TabIndex = 9;
            nameLabel2.Text = "Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 117);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sbi_salesdbDataSet
            // 
            this.sbi_salesdbDataSet.DataSetName = "sbi_salesdbDataSet";
            this.sbi_salesdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // developerBindingSource
            // 
            this.developerBindingSource.DataMember = "Developer";
            this.developerBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // developerTableAdapter
            // 
            this.developerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AreaTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.ClientTableAdapter = this.clientTableAdapter;
            this.tableAdapterManager.DAMTableAdapter = null;
            this.tableAdapterManager.DeveloperTableAdapter = this.developerTableAdapter;
            this.tableAdapterManager.InstallScheduleTableAdapter = null;
            this.tableAdapterManager.JobTableAdapter = null;
            this.tableAdapterManager.LineTableAdapter = null;
            this.tableAdapterManager.OITargetTableAdapter = null;
            this.tableAdapterManager.OPSPlannerTableAdapter = null;
            this.tableAdapterManager.ProductTypeTableAdapter = null;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.SalesTargetTableAdapter = null;
            this.tableAdapterManager.SAMTableAdapter = null;
            this.tableAdapterManager.SiteDetailsTableAdapter = this.siteDetailsTableAdapter;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.TeamTargetTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // siteDetailsTableAdapter
            // 
            this.siteDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "FK_Developer_Client";
            this.clientBindingSource.DataSource = this.developerBindingSource;
            // 
            // siteDetailsBindingSource
            // 
            this.siteDetailsBindingSource.DataMember = "Client_SiteDetails";
            this.siteDetailsBindingSource.DataSource = this.clientBindingSource;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.clientBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 54);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.ValueMember = "ClientID";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.siteDetailsBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(86, 94);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(177, 21);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.ValueMember = "SiteID";
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.developerBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(86, 22);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(84, 21);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.ValueMember = "DevID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(268, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 21);
            this.button2.TabIndex = 13;
            this.button2.Text = "All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 156);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(nameLabel2);
            this.Controls.Add(clientIDLabel1);
            this.Controls.Add(nameLabel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectSite";
            this.ShowIcon = false;
            this.Text = "SelectSite";
            this.Load += new System.EventHandler(this.SelectSite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private sbi_salesdbDataSet sbi_salesdbDataSet;
        private System.Windows.Forms.BindingSource developerBindingSource;
        private sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter developerTableAdapter;
        private sbi_salesdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private sbi_salesdbDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private sbi_salesdbDataSetTableAdapters.SiteDetailsTableAdapter siteDetailsTableAdapter;
        private System.Windows.Forms.BindingSource siteDetailsBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button2;
    }
}