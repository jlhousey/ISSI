namespace ISSI
{
    partial class EditDeveloper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDeveloper));
            this.sbi_salesdbDataSet = new ISSI.sbi_salesdbDataSet();
            this.developerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.developerTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager();
            this.clientTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.ClientTableAdapter();
            this.developerBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.developerBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dAMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regionTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.RegionTableAdapter();
            this.dAMTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.DAMTableAdapter();
            this.clientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.clientDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            nameLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingNavigator)).BeginInit();
            this.developerBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel1
            // 
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(21, 58);
            nameLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel1.Name = "nameLabel1";
            nameLabel1.Size = new System.Drawing.Size(38, 13);
            nameLabel1.TabIndex = 7;
            nameLabel1.Text = "Name:";
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
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // developerBindingNavigator
            // 
            this.developerBindingNavigator.AddNewItem = null;
            this.developerBindingNavigator.BindingSource = this.developerBindingSource;
            this.developerBindingNavigator.CountItem = null;
            this.developerBindingNavigator.DeleteItem = null;
            this.developerBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.developerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.developerBindingNavigatorSaveItem});
            this.developerBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.developerBindingNavigator.MoveFirstItem = null;
            this.developerBindingNavigator.MoveLastItem = null;
            this.developerBindingNavigator.MoveNextItem = null;
            this.developerBindingNavigator.MovePreviousItem = null;
            this.developerBindingNavigator.Name = "developerBindingNavigator";
            this.developerBindingNavigator.PositionItem = null;
            this.developerBindingNavigator.Size = new System.Drawing.Size(740, 27);
            this.developerBindingNavigator.TabIndex = 0;
            this.developerBindingNavigator.Text = "bindingNavigator1";
            // 
            // developerBindingNavigatorSaveItem
            // 
            this.developerBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("developerBindingNavigatorSaveItem.Image")));
            this.developerBindingNavigatorSaveItem.Name = "developerBindingNavigatorSaveItem";
            this.developerBindingNavigatorSaveItem.Size = new System.Drawing.Size(82, 24);
            this.developerBindingNavigatorSaveItem.Text = "Save Data";
            this.developerBindingNavigatorSaveItem.Click += new System.EventHandler(this.developerBindingNavigatorSaveItem_Click);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember = "Region";
            this.regionBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // dAMBindingSource
            // 
            this.dAMBindingSource.DataMember = "DAM";
            this.dAMBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill = true;
            // 
            // dAMTableAdapter
            // 
            this.dAMTableAdapter.ClearBeforeFill = true;
            // 
            // clientBindingSource1
            // 
            this.clientBindingSource1.DataMember = "FK_Developer_Client";
            this.clientBindingSource1.DataSource = this.developerBindingSource;
            // 
            // clientDataGridView
            // 
            this.clientDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientDataGridView.AutoGenerateColumns = false;
            this.clientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.clientDataGridView.DataSource = this.clientBindingSource1;
            this.clientDataGridView.Location = new System.Drawing.Point(22, 88);
            this.clientDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientDataGridView.Name = "clientDataGridView";
            this.clientDataGridView.RowTemplate.Height = 24;
            this.clientDataGridView.Size = new System.Drawing.Size(708, 217);
            this.clientDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ClientID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ClientID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RegionID";
            this.dataGridViewTextBoxColumn3.DataSource = this.regionBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "RegionID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "RegionID";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DAMID";
            this.dataGridViewTextBoxColumn4.DataSource = this.dAMBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "DAMID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "DAMID";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DeveloperID";
            this.dataGridViewTextBoxColumn5.HeaderText = "DeveloperID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SAGEID";
            this.dataGridViewTextBoxColumn6.HeaderText = "SAGEID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Tier";
            this.dataGridViewTextBoxColumn7.HeaderText = "Tier";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 54);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add New Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.developerBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(62, 54);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(174, 20);
            this.nameTextBox.TabIndex = 8;
            // 
            // EditDeveloper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 401);
            this.Controls.Add(nameLabel1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clientDataGridView);
            this.Controls.Add(this.developerBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditDeveloper";
            this.Text = "Edit Group";
            this.Load += new System.EventHandler(this.EditDeveloper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingNavigator)).EndInit();
            this.developerBindingNavigator.ResumeLayout(false);
            this.developerBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sbi_salesdbDataSet sbi_salesdbDataSet;
        private System.Windows.Forms.BindingSource developerBindingSource;
        private sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter developerTableAdapter;
        private sbi_salesdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator developerBindingNavigator;
        private System.Windows.Forms.ToolStripButton developerBindingNavigatorSaveItem;
        private sbi_salesdbDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private sbi_salesdbDataSetTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.BindingSource dAMBindingSource;
        private sbi_salesdbDataSetTableAdapters.DAMTableAdapter dAMTableAdapter;
        private System.Windows.Forms.BindingSource clientBindingSource1;
        private System.Windows.Forms.DataGridView clientDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}