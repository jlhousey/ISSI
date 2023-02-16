namespace ISSI
{
    partial class EditClient
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label regionIDLabel;
            System.Windows.Forms.Label dAMIDLabel;
            System.Windows.Forms.Label developerIDLabel;
            System.Windows.Forms.Label sAGEIDLabel;
            System.Windows.Forms.Label tierLabel;
            System.Windows.Forms.Label clientIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClient));
            this.clientBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbi_salesdbDataSet = new ISSI.sbi_salesdbDataSet();
            this.clientBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.sAGEIDTextBox = new System.Windows.Forms.TextBox();
            this.tierTextBox = new System.Windows.Forms.TextBox();
            this.jobsByClientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jobsByClientDataGridView = new System.Windows.Forms.DataGridView();
            this.JobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.siteDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.ClientTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager();
            this.jobsByClientTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.JobsByClientTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regionTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.RegionTableAdapter();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dAMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dAMTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.DAMTableAdapter();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.developerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.developerTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter();
            this.siteDetailsTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.SiteDetailsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clientIDTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            regionIDLabel = new System.Windows.Forms.Label();
            dAMIDLabel = new System.Windows.Forms.Label();
            developerIDLabel = new System.Windows.Forms.Label();
            sAGEIDLabel = new System.Windows.Forms.Label();
            tierLabel = new System.Windows.Forms.Label();
            clientIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingNavigator)).BeginInit();
            this.clientBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobsByClientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobsByClientDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(148, 32);
            nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // regionIDLabel
            // 
            regionIDLabel.AutoSize = true;
            regionIDLabel.Location = new System.Drawing.Point(129, 84);
            regionIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            regionIDLabel.Name = "regionIDLabel";
            regionIDLabel.Size = new System.Drawing.Size(58, 13);
            regionIDLabel.TabIndex = 3;
            regionIDLabel.Text = "Region ID:";
            // 
            // dAMIDLabel
            // 
            dAMIDLabel.AutoSize = true;
            dAMIDLabel.Location = new System.Drawing.Point(299, 58);
            dAMIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dAMIDLabel.Name = "dAMIDLabel";
            dAMIDLabel.Size = new System.Drawing.Size(45, 13);
            dAMIDLabel.TabIndex = 5;
            dAMIDLabel.Text = "DAMID:";
            // 
            // developerIDLabel
            // 
            developerIDLabel.AutoSize = true;
            developerIDLabel.Location = new System.Drawing.Point(114, 58);
            developerIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            developerIDLabel.Name = "developerIDLabel";
            developerIDLabel.Size = new System.Drawing.Size(73, 13);
            developerIDLabel.TabIndex = 7;
            developerIDLabel.Text = "Developer ID:";
            // 
            // sAGEIDLabel
            // 
            sAGEIDLabel.AutoSize = true;
            sAGEIDLabel.Location = new System.Drawing.Point(293, 83);
            sAGEIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            sAGEIDLabel.Name = "sAGEIDLabel";
            sAGEIDLabel.Size = new System.Drawing.Size(50, 13);
            sAGEIDLabel.TabIndex = 9;
            sAGEIDLabel.Text = "SAGEID:";
            // 
            // tierLabel
            // 
            tierLabel.AutoSize = true;
            tierLabel.Location = new System.Drawing.Point(157, 109);
            tierLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            tierLabel.Name = "tierLabel";
            tierLabel.Size = new System.Drawing.Size(28, 13);
            tierLabel.TabIndex = 11;
            tierLabel.Text = "Tier:";
            // 
            // clientIDLabel
            // 
            clientIDLabel.AutoSize = true;
            clientIDLabel.Location = new System.Drawing.Point(776, 28);
            clientIDLabel.Name = "clientIDLabel";
            clientIDLabel.Size = new System.Drawing.Size(50, 13);
            clientIDLabel.TabIndex = 19;
            clientIDLabel.Text = "Client ID:";
            clientIDLabel.Visible = false;
            // 
            // clientBindingNavigator
            // 
            this.clientBindingNavigator.AddNewItem = null;
            this.clientBindingNavigator.BindingSource = this.clientBindingSource;
            this.clientBindingNavigator.CountItem = null;
            this.clientBindingNavigator.DeleteItem = null;
            this.clientBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.clientBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientBindingNavigatorSaveItem});
            this.clientBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.clientBindingNavigator.MoveFirstItem = null;
            this.clientBindingNavigator.MoveLastItem = null;
            this.clientBindingNavigator.MoveNextItem = null;
            this.clientBindingNavigator.MovePreviousItem = null;
            this.clientBindingNavigator.Name = "clientBindingNavigator";
            this.clientBindingNavigator.PositionItem = null;
            this.clientBindingNavigator.Size = new System.Drawing.Size(960, 27);
            this.clientBindingNavigator.TabIndex = 0;
            this.clientBindingNavigator.Text = "bindingNavigator1";
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // sbi_salesdbDataSet
            // 
            this.sbi_salesdbDataSet.DataSetName = "sbi_salesdbDataSet";
            this.sbi_salesdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientBindingNavigatorSaveItem
            // 
            this.clientBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("clientBindingNavigatorSaveItem.Image")));
            this.clientBindingNavigatorSaveItem.Name = "clientBindingNavigatorSaveItem";
            this.clientBindingNavigatorSaveItem.Size = new System.Drawing.Size(82, 24);
            this.clientBindingNavigatorSaveItem.Text = "Save Data";
            this.clientBindingNavigatorSaveItem.Click += new System.EventHandler(this.clientBindingNavigatorSaveItem_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(189, 30);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(232, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // sAGEIDTextBox
            // 
            this.sAGEIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "SAGEID", true));
            this.sAGEIDTextBox.Location = new System.Drawing.Point(345, 80);
            this.sAGEIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sAGEIDTextBox.Name = "sAGEIDTextBox";
            this.sAGEIDTextBox.Size = new System.Drawing.Size(76, 20);
            this.sAGEIDTextBox.TabIndex = 10;
            // 
            // tierTextBox
            // 
            this.tierTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Tier", true));
            this.tierTextBox.Location = new System.Drawing.Point(189, 106);
            this.tierTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.tierTextBox.Name = "tierTextBox";
            this.tierTextBox.Size = new System.Drawing.Size(76, 20);
            this.tierTextBox.TabIndex = 12;
            // 
            // jobsByClientBindingSource
            // 
            this.jobsByClientBindingSource.DataMember = "Client_JobsByClient";
            this.jobsByClientBindingSource.DataSource = this.clientBindingSource;
            // 
            // jobsByClientDataGridView
            // 
            this.jobsByClientDataGridView.AllowUserToAddRows = false;
            this.jobsByClientDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobsByClientDataGridView.AutoGenerateColumns = false;
            this.jobsByClientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobsByClientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.SOPID,
            this.SiteID,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.jobsByClientDataGridView.DataSource = this.jobsByClientBindingSource;
            this.jobsByClientDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.jobsByClientDataGridView.Location = new System.Drawing.Point(9, 141);
            this.jobsByClientDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.jobsByClientDataGridView.Name = "jobsByClientDataGridView";
            this.jobsByClientDataGridView.RowTemplate.Height = 24;
            this.jobsByClientDataGridView.Size = new System.Drawing.Size(942, 235);
            this.jobsByClientDataGridView.TabIndex = 13;
            this.jobsByClientDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobsByClientDataGridView_CellContentDoubleClick);
            this.jobsByClientDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobsByClientDataGridView_CellDoubleClick);
            // 
            // JobID
            // 
            this.JobID.DataPropertyName = "JobID";
            this.JobID.FillWeight = 40F;
            this.JobID.HeaderText = "JobID";
            this.JobID.Name = "JobID";
            this.JobID.Visible = false;
            this.JobID.Width = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ClientID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ClientID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Site Name (double click to edit)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // SOPID
            // 
            this.SOPID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SOPID.DataPropertyName = "SOPID";
            this.SOPID.FillWeight = 40F;
            this.SOPID.HeaderText = "SOPID";
            this.SOPID.Name = "SOPID";
            // 
            // SiteID
            // 
            this.SiteID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SiteID.DataPropertyName = "SiteID";
            this.SiteID.DataSource = this.siteDetailsBindingSource;
            this.SiteID.DisplayMember = "Name";
            this.SiteID.HeaderText = "SiteID";
            this.SiteID.Name = "SiteID";
            this.SiteID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SiteID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SiteID.ValueMember = "SiteID";
            this.SiteID.Visible = false;
            // 
            // siteDetailsBindingSource
            // 
            this.siteDetailsBindingSource.DataMember = "SiteDetails";
            this.siteDetailsBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "HouseType";
            this.dataGridViewTextBoxColumn6.HeaderText = "HouseType";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Bedrooms";
            this.dataGridViewTextBoxColumn7.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Bedrooms";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Storeys";
            this.dataGridViewTextBoxColumn8.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Storeys";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SqFt";
            this.dataGridViewTextBoxColumn9.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn9.HeaderText = "SqFt";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PlotNumber";
            this.dataGridViewTextBoxColumn10.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn10.HeaderText = "PlotNumber";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ClientBudget";
            this.dataGridViewTextBoxColumn11.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn11.HeaderText = "ClientBudget";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Designer";
            this.dataGridViewTextBoxColumn12.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Designer";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Furniture";
            this.dataGridViewTextBoxColumn13.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Furniture";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "PasteUp";
            this.dataGridViewTextBoxColumn14.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn14.HeaderText = "PasteUp";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Lostto";
            this.dataGridViewTextBoxColumn15.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn15.HeaderText = "Lostto";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Reason";
            this.dataGridViewTextBoxColumn16.FillWeight = 32.99492F;
            this.dataGridViewTextBoxColumn16.HeaderText = "Reason";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AreaTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.ClientTableAdapter = this.clientTableAdapter;
            this.tableAdapterManager.DAMTableAdapter = null;
            this.tableAdapterManager.DeveloperTableAdapter = null;
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
            // jobsByClientTableAdapter
            // 
            this.jobsByClientTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clientBindingSource, "RegionID", true));
            this.comboBox1.DataSource = this.regionBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(189, 80);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(76, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.ValueMember = "RegionID";
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember = "Region";
            this.regionBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clientBindingSource, "DAMID", true));
            this.comboBox2.DataSource = this.dAMBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(345, 56);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(76, 21);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.ValueMember = "DAMID";
            // 
            // dAMBindingSource
            // 
            this.dAMBindingSource.DataMember = "DAM";
            this.dAMBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // dAMTableAdapter
            // 
            this.dAMTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clientBindingSource, "DeveloperID", true));
            this.comboBox3.DataSource = this.developerBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(189, 56);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(76, 21);
            this.comboBox3.TabIndex = 16;
            this.comboBox3.ValueMember = "DevID";
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
            // siteDetailsTableAdapter
            // 
            this.siteDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(792, 101);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 24);
            this.button1.TabIndex = 17;
            this.button1.Text = "Add New Job";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Client Jobs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Client Details";
            // 
            // clientIDTextBox
            // 
            this.clientIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientID", true));
            this.clientIDTextBox.Location = new System.Drawing.Point(832, 25);
            this.clientIDTextBox.Name = "clientIDTextBox";
            this.clientIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientIDTextBox.TabIndex = 20;
            this.clientIDTextBox.Visible = false;
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 413);
            this.Controls.Add(clientIDLabel);
            this.Controls.Add(this.clientIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.jobsByClientDataGridView);
            this.Controls.Add(tierLabel);
            this.Controls.Add(this.tierTextBox);
            this.Controls.Add(sAGEIDLabel);
            this.Controls.Add(this.sAGEIDTextBox);
            this.Controls.Add(developerIDLabel);
            this.Controls.Add(dAMIDLabel);
            this.Controls.Add(regionIDLabel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.clientBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditClient";
            this.Text = "EditClient";
            this.Load += new System.EventHandler(this.EditClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingNavigator)).EndInit();
            this.clientBindingNavigator.ResumeLayout(false);
            this.clientBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobsByClientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobsByClientDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.developerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sbi_salesdbDataSet sbi_salesdbDataSet;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private sbi_salesdbDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private sbi_salesdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator clientBindingNavigator;
        private System.Windows.Forms.ToolStripButton clientBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox sAGEIDTextBox;
        private System.Windows.Forms.TextBox tierTextBox;
        private System.Windows.Forms.BindingSource jobsByClientBindingSource;
        private sbi_salesdbDataSetTableAdapters.JobsByClientTableAdapter jobsByClientTableAdapter;
        private System.Windows.Forms.DataGridView jobsByClientDataGridView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private sbi_salesdbDataSetTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource dAMBindingSource;
        private sbi_salesdbDataSetTableAdapters.DAMTableAdapter dAMTableAdapter;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.BindingSource developerBindingSource;
        private sbi_salesdbDataSetTableAdapters.DeveloperTableAdapter developerTableAdapter;
        private System.Windows.Forms.BindingSource siteDetailsBindingSource;
        private sbi_salesdbDataSetTableAdapters.SiteDetailsTableAdapter siteDetailsTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOPID;
        private System.Windows.Forms.DataGridViewComboBoxColumn SiteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.TextBox clientIDTextBox;
    }
}