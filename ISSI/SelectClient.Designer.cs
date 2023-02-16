namespace ISSI
{
    partial class SelectClient
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
            System.Windows.Forms.Label devIDLabel;
            System.Windows.Forms.Label nameLabel;
            this.sbi_salesdbDataSet = new ISSI.sbi_salesdbDataSet();
            this.developerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.developerTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.ClientTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            devIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.tableAdapterManager.SiteDetailsTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.TeamTargetTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // devIDLabel
            // 
            devIDLabel.AutoSize = true;
            devIDLabel.Location = new System.Drawing.Point(22, 41);
            devIDLabel.Name = "devIDLabel";
            devIDLabel.Size = new System.Drawing.Size(54, 17);
            devIDLabel.TabIndex = 1;
            devIDLabel.Text = "Dev ID:";
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "FK_Developer_Client";
            this.clientBindingSource.DataSource = this.developerBindingSource;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(27, 84);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(49, 17);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Name:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.developerBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "DevID";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.clientBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(283, 24);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.ValueMember = "ClientID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 175);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(devIDLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectClient";
            this.Text = "SelectClient";
            this.Load += new System.EventHandler(this.SelectClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sbi_salesdbDataSet sbi_salesdbDataSet;
        private System.Windows.Forms.BindingSource developerBindingSource;
        private sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter developerTableAdapter;
        private sbi_salesdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private sbi_salesdbDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
    }
}