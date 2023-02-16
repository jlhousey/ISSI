namespace ISSI
{
    partial class EditSite
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
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label address2Label;
            System.Windows.Forms.Label townLabel;
            System.Windows.Forms.Label countyLabel;
            System.Windows.Forms.Label postCodeLabel;
            System.Windows.Forms.Label clientIDLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSite));
            this.sbi_salesdbDataSet = new ISSI.sbi_salesdbDataSet();
            this.siteDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siteDetailsTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.SiteDetailsTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_salesdbDataSetTableAdapters.TableAdapterManager();
            this.clientTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.ClientTableAdapter();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.address1TextBox = new System.Windows.Forms.TextBox();
            this.address2TextBox = new System.Windows.Forms.TextBox();
            this.townTextBox = new System.Windows.Forms.TextBox();
            this.countyTextBox = new System.Windows.Forms.TextBox();
            this.postCodeTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jobBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jobTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.JobTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sbi_installdbDataSet = new ISSI.sbi_installdbDataSet();
            this.vInstallLineSummaryAllTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.vInstallLineSummaryAllTableAdapter();
            this.jobDetailsTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.JobDetailsTableAdapter();
            this.siteContactEventsTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.SiteContactEventsTableAdapter();
            this.siteDetailsTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.SiteDetailsTableAdapter();
            this.vInstallLineSummaryAllDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstallDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeeksAway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstallID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vInstallLineSummaryAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siteContactEventsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.opsPlannerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FollowUp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.siteContactEventsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.siteDetailsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oPSPlannerTableAdapter = new ISSI.sbi_salesdbDataSetTableAdapters.OPSPlannerTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.contactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactsTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.ContactsTableAdapter();
            this.contactsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.jobDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.siteDetailsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.siteDetailsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tableAdapterManager1 = new ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager();
            this.jobDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siteContactEventsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.installScheduleTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.InstallScheduleTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.keyDateListTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.KeyDateListTableAdapter();
            this.jobKeyDatesTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.JobKeyDatesTableAdapter();
            this.jobTypesTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.JobTypesTableAdapter();
            this.opsPlannerTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.OpsPlannerTableAdapter();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            nameLabel = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            address2Label = new System.Windows.Forms.Label();
            townLabel = new System.Windows.Forms.Label();
            countyLabel = new System.Windows.Forms.Label();
            postCodeLabel = new System.Windows.Forms.Label();
            clientIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInstallLineSummaryAllDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInstallLineSummaryAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteContactEventsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opsPlannerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteContactEventsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsDataGridView)).BeginInit();
            this.contactContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingNavigator)).BeginInit();
            this.siteDetailsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteContactEventsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(9, 103);
            nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(104, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Development Name:";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(337, 45);
            address1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(54, 13);
            address1Label.TabIndex = 3;
            address1Label.Text = "Address1:";
            // 
            // address2Label
            // 
            address2Label.AutoSize = true;
            address2Label.Location = new System.Drawing.Point(337, 65);
            address2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            address2Label.Name = "address2Label";
            address2Label.Size = new System.Drawing.Size(54, 13);
            address2Label.TabIndex = 5;
            address2Label.Text = "Address2:";
            // 
            // townLabel
            // 
            townLabel.AutoSize = true;
            townLabel.Location = new System.Drawing.Point(357, 86);
            townLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            townLabel.Name = "townLabel";
            townLabel.Size = new System.Drawing.Size(37, 13);
            townLabel.TabIndex = 7;
            townLabel.Text = "Town:";
            // 
            // countyLabel
            // 
            countyLabel.AutoSize = true;
            countyLabel.Location = new System.Drawing.Point(349, 109);
            countyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            countyLabel.Name = "countyLabel";
            countyLabel.Size = new System.Drawing.Size(43, 13);
            countyLabel.TabIndex = 9;
            countyLabel.Text = "County:";
            // 
            // postCodeLabel
            // 
            postCodeLabel.AutoSize = true;
            postCodeLabel.Location = new System.Drawing.Point(334, 134);
            postCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            postCodeLabel.Name = "postCodeLabel";
            postCodeLabel.Size = new System.Drawing.Size(59, 13);
            postCodeLabel.TabIndex = 11;
            postCodeLabel.Text = "Post Code:";
            // 
            // clientIDLabel
            // 
            clientIDLabel.AutoSize = true;
            clientIDLabel.Location = new System.Drawing.Point(10, 66);
            clientIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            clientIDLabel.Name = "clientIDLabel";
            clientIDLabel.Size = new System.Drawing.Size(50, 13);
            clientIDLabel.TabIndex = 13;
            clientIDLabel.Text = "Client ID:";
            // 
            // sbi_salesdbDataSet
            // 
            this.sbi_salesdbDataSet.DataSetName = "sbi_salesdbDataSet";
            this.sbi_salesdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // siteDetailsBindingSource
            // 
            this.siteDetailsBindingSource.DataMember = "SiteDetails";
            this.siteDetailsBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // siteDetailsTableAdapter
            // 
            this.siteDetailsTableAdapter.ClearBeforeFill = true;
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
            // nameTextBox
            // 
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(117, 101);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(209, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // address1TextBox
            // 
            this.address1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource, "Address1", true));
            this.address1TextBox.Location = new System.Drawing.Point(396, 45);
            this.address1TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.address1TextBox.Name = "address1TextBox";
            this.address1TextBox.Size = new System.Drawing.Size(172, 20);
            this.address1TextBox.TabIndex = 4;
            // 
            // address2TextBox
            // 
            this.address2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource, "Address2", true));
            this.address2TextBox.Location = new System.Drawing.Point(396, 67);
            this.address2TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.address2TextBox.Name = "address2TextBox";
            this.address2TextBox.Size = new System.Drawing.Size(172, 20);
            this.address2TextBox.TabIndex = 6;
            // 
            // townTextBox
            // 
            this.townTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource, "Town", true));
            this.townTextBox.Location = new System.Drawing.Point(396, 90);
            this.townTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.townTextBox.Name = "townTextBox";
            this.townTextBox.Size = new System.Drawing.Size(172, 20);
            this.townTextBox.TabIndex = 8;
            // 
            // countyTextBox
            // 
            this.countyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource, "County", true));
            this.countyTextBox.Location = new System.Drawing.Point(396, 114);
            this.countyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.countyTextBox.Name = "countyTextBox";
            this.countyTextBox.Size = new System.Drawing.Size(172, 20);
            this.countyTextBox.TabIndex = 10;
            // 
            // postCodeTextBox
            // 
            this.postCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource, "PostCode", true));
            this.postCodeTextBox.Location = new System.Drawing.Point(396, 134);
            this.postCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.postCodeTextBox.Name = "postCodeTextBox";
            this.postCodeTextBox.Size = new System.Drawing.Size(172, 20);
            this.postCodeTextBox.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.siteDetailsBindingSource, "ClientID", true));
            this.comboBox1.DataSource = this.clientBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 66);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.ValueMember = "ClientID";
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.sbi_salesdbDataSet;
            // 
            // jobBindingSource
            // 
            this.jobBindingSource.DataMember = "SiteDetails_Job";
            this.jobBindingSource.DataSource = this.siteDetailsBindingSource;
            this.jobBindingSource.Sort = "SOPID DESC";
            // 
            // jobTableAdapter
            // 
            this.jobTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Jobs on Development";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Development Details";
            // 
            // sbi_installdbDataSet
            // 
            this.sbi_installdbDataSet.DataSetName = "sbi_installdbDataSet";
            this.sbi_installdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vInstallLineSummaryAllTableAdapter
            // 
            this.vInstallLineSummaryAllTableAdapter.ClearBeforeFill = true;
            // 
            // jobDetailsTableAdapter
            // 
            this.jobDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // siteContactEventsTableAdapter
            // 
            this.siteContactEventsTableAdapter.ClearBeforeFill = true;
            // 
            // siteDetailsTableAdapter1
            // 
            this.siteDetailsTableAdapter1.ClearBeforeFill = true;
            // 
            // vInstallLineSummaryAllDataGridView
            // 
            this.vInstallLineSummaryAllDataGridView.AllowUserToAddRows = false;
            this.vInstallLineSummaryAllDataGridView.AllowUserToDeleteRows = false;
            this.vInstallLineSummaryAllDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vInstallLineSummaryAllDataGridView.AutoGenerateColumns = false;
            this.vInstallLineSummaryAllDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.vInstallLineSummaryAllDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vInstallLineSummaryAllDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn18,
            this.InstallDate,
            this.WeeksAway,
            this.RAG,
            this.Status,
            this.InstallID,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.JobType,
            this.dataGridViewTextBoxColumn34,
            this.Notes});
            this.vInstallLineSummaryAllDataGridView.DataSource = this.vInstallLineSummaryAllBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vInstallLineSummaryAllDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.vInstallLineSummaryAllDataGridView.Location = new System.Drawing.Point(20, 572);
            this.vInstallLineSummaryAllDataGridView.Name = "vInstallLineSummaryAllDataGridView";
            this.vInstallLineSummaryAllDataGridView.Size = new System.Drawing.Size(1429, 196);
            this.vInstallLineSummaryAllDataGridView.TabIndex = 19;
            this.vInstallLineSummaryAllDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vInstallLineSummaryAllDataGridView_CellContentClick);
            this.vInstallLineSummaryAllDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vInstallLineSummaryAllDataGridView_CellDoubleClick);
            this.vInstallLineSummaryAllDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.vInstallLineSummaryAllDataGridView_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "SOPID";
            this.dataGridViewTextBoxColumn26.Frozen = true;
            this.dataGridViewTextBoxColumn26.HeaderText = "SOPID";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 65;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Developer";
            this.dataGridViewTextBoxColumn1.HeaderText = "Developer";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Client";
            this.dataGridViewTextBoxColumn4.HeaderText = "Client";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 58;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "HouseType";
            this.dataGridViewTextBoxColumn27.Frozen = true;
            this.dataGridViewTextBoxColumn27.HeaderText = "HouseType";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 87;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "PlotNumber";
            this.dataGridViewTextBoxColumn28.HeaderText = "PlotNumber";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 87;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Product";
            this.dataGridViewTextBoxColumn23.HeaderText = "Product";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 69;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Site";
            this.dataGridViewTextBoxColumn15.HeaderText = "Site";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 50;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "SiteID";
            this.dataGridViewTextBoxColumn16.HeaderText = "SiteID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 61;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "OpsPlannerID";
            this.dataGridViewTextBoxColumn18.HeaderText = "OpsPlannerID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 98;
            // 
            // InstallDate
            // 
            this.InstallDate.DataPropertyName = "InstallDate";
            this.InstallDate.HeaderText = "InstallDate";
            this.InstallDate.Name = "InstallDate";
            this.InstallDate.Width = 82;
            // 
            // WeeksAway
            // 
            this.WeeksAway.DataPropertyName = "WeeksAway";
            this.WeeksAway.HeaderText = "Weeks";
            this.WeeksAway.Name = "WeeksAway";
            this.WeeksAway.ReadOnly = true;
            this.WeeksAway.Width = 66;
            // 
            // RAG
            // 
            this.RAG.DataPropertyName = "RAG";
            this.RAG.HeaderText = "RAG";
            this.RAG.Name = "RAG";
            this.RAG.Width = 55;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 62;
            // 
            // InstallID
            // 
            this.InstallID.DataPropertyName = "InstallID";
            this.InstallID.HeaderText = "InstallID";
            this.InstallID.Name = "InstallID";
            this.InstallID.Width = 70;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "DAM";
            this.dataGridViewTextBoxColumn17.HeaderText = "DAM";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 56;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "SAM";
            this.dataGridViewTextBoxColumn24.HeaderText = "SAM";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 55;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "OpsPlanner";
            this.dataGridViewTextBoxColumn25.HeaderText = "OpsPlanner";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 87;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Bedrooms";
            this.dataGridViewTextBoxColumn29.HeaderText = "Bedrooms";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Visible = false;
            this.dataGridViewTextBoxColumn29.Width = 79;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Storeys";
            this.dataGridViewTextBoxColumn30.HeaderText = "Storeys";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Visible = false;
            this.dataGridViewTextBoxColumn30.Width = 67;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "StatusID";
            this.dataGridViewTextBoxColumn31.HeaderText = "StatusID";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Visible = false;
            this.dataGridViewTextBoxColumn31.Width = 73;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "JobID";
            this.dataGridViewTextBoxColumn32.HeaderText = "JobID";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Visible = false;
            this.dataGridViewTextBoxColumn32.Width = 60;
            // 
            // JobType
            // 
            this.JobType.DataPropertyName = "JobType";
            this.JobType.HeaderText = "JobType";
            this.JobType.Name = "JobType";
            this.JobType.ReadOnly = true;
            this.JobType.Visible = false;
            this.JobType.Width = 73;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "ClientID";
            this.dataGridViewTextBoxColumn34.HeaderText = "ClientID";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Visible = false;
            this.dataGridViewTextBoxColumn34.Width = 69;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // vInstallLineSummaryAllBindingSource
            // 
            this.vInstallLineSummaryAllBindingSource.DataMember = "vInstallLineSummaryAll";
            this.vInstallLineSummaryAllBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // siteContactEventsDataGridView
            // 
            this.siteContactEventsDataGridView.AllowUserToAddRows = false;
            this.siteContactEventsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.siteContactEventsDataGridView.AutoGenerateColumns = false;
            this.siteContactEventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.siteContactEventsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn37,
            this.CEventID,
            this.dataGridViewTextBoxColumn35,
            this.FollowUp});
            this.siteContactEventsDataGridView.DataSource = this.siteContactEventsBindingSource1;
            this.siteContactEventsDataGridView.Location = new System.Drawing.Point(20, 818);
            this.siteContactEventsDataGridView.Name = "siteContactEventsDataGridView";
            this.siteContactEventsDataGridView.ReadOnly = true;
            this.siteContactEventsDataGridView.Size = new System.Drawing.Size(1289, 194);
            this.siteContactEventsDataGridView.TabIndex = 30;
            this.siteContactEventsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.siteContactEventsDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "ContactDate";
            this.dataGridViewTextBoxColumn36.HeaderText = "ContactDate";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "OpsPlannerID";
            this.dataGridViewTextBoxColumn38.DataSource = this.opsPlannerBindingSource;
            this.dataGridViewTextBoxColumn38.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn38.HeaderText = "OpsPlannerID";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn38.ValueMember = "OpsPlannerID";
            // 
            // opsPlannerBindingSource
            // 
            this.opsPlannerBindingSource.DataMember = "OpsPlanner";
            this.opsPlannerBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "ContactID";
            this.dataGridViewTextBoxColumn39.HeaderText = "ContactID";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Visible = false;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn37.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn37.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // CEventID
            // 
            this.CEventID.DataPropertyName = "CEventID";
            this.CEventID.HeaderText = "CEventID";
            this.CEventID.Name = "CEventID";
            this.CEventID.ReadOnly = true;
            this.CEventID.Visible = false;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "SiteID";
            this.dataGridViewTextBoxColumn35.HeaderText = "SiteID";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Visible = false;
            // 
            // FollowUp
            // 
            this.FollowUp.DataPropertyName = "FollowUp";
            this.FollowUp.HeaderText = "FollowUp";
            this.FollowUp.Name = "FollowUp";
            this.FollowUp.ReadOnly = true;
            // 
            // siteContactEventsBindingSource1
            // 
            this.siteContactEventsBindingSource1.DataMember = "FK_SiteContactEvents_SiteDetails";
            this.siteContactEventsBindingSource1.DataSource = this.siteDetailsBindingSource1;
            this.siteContactEventsBindingSource1.Sort = "ContactDate DESC";
            // 
            // siteDetailsBindingSource1
            // 
            this.siteDetailsBindingSource1.DataMember = "SiteDetails";
            this.siteDetailsBindingSource1.DataSource = this.sbi_installdbDataSet;
            // 
            // oPSPlannerTableAdapter
            // 
            this.oPSPlannerTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1315, 981);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 31);
            this.button2.TabIndex = 31;
            this.button2.Text = "Contact Site";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.siteDetailsBindingSource1, "Notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(1073, 177);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(390, 161);
            this.notesTextBox.TabIndex = 32;
            // 
            // contactsBindingSource
            // 
            this.contactsBindingSource.DataMember = "FK_Contacts_SiteDetails";
            this.contactsBindingSource.DataSource = this.siteDetailsBindingSource1;
            // 
            // contactsTableAdapter
            // 
            this.contactsTableAdapter.ClearBeforeFill = true;
            // 
            // contactsDataGridView
            // 
            this.contactsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.contactsDataGridView.AutoGenerateColumns = false;
            this.contactsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewTextBoxColumn42,
            this.Email1,
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewTextBoxColumn49});
            this.contactsDataGridView.ContextMenuStrip = this.contactContext;
            this.contactsDataGridView.DataSource = this.contactsBindingSource;
            this.contactsDataGridView.Location = new System.Drawing.Point(589, 32);
            this.contactsDataGridView.Name = "contactsDataGridView";
            this.contactsDataGridView.Size = new System.Drawing.Size(874, 122);
            this.contactsDataGridView.TabIndex = 32;
            this.contactsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contactsDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn41.FillWeight = 200F;
            this.dataGridViewTextBoxColumn41.HeaderText = "Name";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn41.Width = 175;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.DataPropertyName = "JobTitle";
            this.dataGridViewTextBoxColumn48.FillWeight = 200F;
            this.dataGridViewTextBoxColumn48.HeaderText = "JobTitle";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.Width = 175;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "Tel1";
            this.dataGridViewTextBoxColumn44.FillWeight = 200F;
            this.dataGridViewTextBoxColumn44.HeaderText = "Tel1";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.Width = 150;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "ContactID";
            this.dataGridViewTextBoxColumn42.HeaderText = "ContactID";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            // 
            // Email1
            // 
            this.Email1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email1.DataPropertyName = "Email1";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.Email1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Email1.HeaderText = "Email1";
            this.Email1.Name = "Email1";
            this.Email1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "SiteID";
            this.dataGridViewTextBoxColumn43.HeaderText = "SiteID";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.Visible = false;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Tel2";
            this.dataGridViewTextBoxColumn45.HeaderText = "Tel2";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.Visible = false;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "Email2";
            this.dataGridViewTextBoxColumn47.HeaderText = "Email2";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.Visible = false;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn49.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn49.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.Visible = false;
            // 
            // contactContext
            // 
            this.contactContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToTopToolStripMenuItem});
            this.contactContext.Name = "contactContext";
            this.contactContext.Size = new System.Drawing.Size(142, 26);
            this.contactContext.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // moveToTopToolStripMenuItem
            // 
            this.moveToTopToolStripMenuItem.Name = "moveToTopToolStripMenuItem";
            this.moveToTopToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.moveToTopToolStripMenuItem.Text = "Move to end";
            this.moveToTopToolStripMenuItem.Click += new System.EventHandler(this.moveToTopToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 551);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Installs on Development";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(586, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Site Contacts";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 787);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "Contact Events";
            // 
            // jobDataGridView
            // 
            this.jobDataGridView.AllowUserToAddRows = false;
            this.jobDataGridView.AllowUserToDeleteRows = false;
            this.jobDataGridView.AutoGenerateColumns = false;
            this.jobDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.HouseType,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.JobID});
            this.jobDataGridView.DataSource = this.jobBindingSource;
            this.jobDataGridView.Location = new System.Drawing.Point(22, 175);
            this.jobDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.jobDataGridView.Name = "jobDataGridView";
            this.jobDataGridView.ReadOnly = true;
            this.jobDataGridView.RowTemplate.Height = 24;
            this.jobDataGridView.Size = new System.Drawing.Size(1033, 163);
            this.jobDataGridView.TabIndex = 15;
            this.jobDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SOPID";
            this.dataGridViewTextBoxColumn2.HeaderText = "SOPID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // HouseType
            // 
            this.HouseType.DataPropertyName = "HouseType";
            this.HouseType.HeaderText = "HouseType";
            this.HouseType.Name = "HouseType";
            this.HouseType.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PlotNumber";
            this.dataGridViewTextBoxColumn8.HeaderText = "PlotNumber";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SiteID";
            this.dataGridViewTextBoxColumn3.HeaderText = "SiteID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Bedrooms";
            this.dataGridViewTextBoxColumn5.HeaderText = "Bedrooms";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Storeys";
            this.dataGridViewTextBoxColumn6.HeaderText = "Storeys";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SqFt";
            this.dataGridViewTextBoxColumn7.HeaderText = "SqFt";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ClientBudget";
            this.dataGridViewTextBoxColumn9.HeaderText = "ClientBudget";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Designer";
            this.dataGridViewTextBoxColumn10.HeaderText = "Designer";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Furniture";
            this.dataGridViewTextBoxColumn11.HeaderText = "Furniture";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PasteUp";
            this.dataGridViewTextBoxColumn12.HeaderText = "PasteUp";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Lostto";
            this.dataGridViewTextBoxColumn13.HeaderText = "Lostto";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Reason";
            this.dataGridViewTextBoxColumn14.HeaderText = "Reason";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // JobID
            // 
            this.JobID.DataPropertyName = "JobID";
            this.JobID.HeaderText = "JobID";
            this.JobID.Name = "JobID";
            this.JobID.ReadOnly = true;
            this.JobID.Visible = false;
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // siteDetailsBindingNavigatorSaveItem
            // 
            this.siteDetailsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("siteDetailsBindingNavigatorSaveItem.Image")));
            this.siteDetailsBindingNavigatorSaveItem.Name = "siteDetailsBindingNavigatorSaveItem";
            this.siteDetailsBindingNavigatorSaveItem.Size = new System.Drawing.Size(82, 24);
            this.siteDetailsBindingNavigatorSaveItem.Text = "Save Data";
            this.siteDetailsBindingNavigatorSaveItem.Click += new System.EventHandler(this.siteDetailsBindingNavigatorSaveItem_Click);
            // 
            // siteDetailsBindingNavigator
            // 
            this.siteDetailsBindingNavigator.AddNewItem = null;
            this.siteDetailsBindingNavigator.BindingSource = this.siteDetailsBindingSource;
            this.siteDetailsBindingNavigator.CountItem = null;
            this.siteDetailsBindingNavigator.DeleteItem = null;
            this.siteDetailsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.siteDetailsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.siteDetailsBindingNavigatorSaveItem});
            this.siteDetailsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.siteDetailsBindingNavigator.MoveFirstItem = null;
            this.siteDetailsBindingNavigator.MoveLastItem = null;
            this.siteDetailsBindingNavigator.MoveNextItem = null;
            this.siteDetailsBindingNavigator.MovePreviousItem = null;
            this.siteDetailsBindingNavigator.Name = "siteDetailsBindingNavigator";
            this.siteDetailsBindingNavigator.PositionItem = null;
            this.siteDetailsBindingNavigator.Size = new System.Drawing.Size(1495, 27);
            this.siteDetailsBindingNavigator.TabIndex = 0;
            this.siteDetailsBindingNavigator.Text = "bindingNavigator1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1070, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Site Notes:";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1361, 781);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 29);
            this.button3.TabIndex = 47;
            this.button3.Text = "Batch Move";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.CausesTableAdapter = null;
            this.tableAdapterManager1.ChecklistItemsTableAdapter = null;
            this.tableAdapterManager1.CheckListlistTableAdapter = null;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.ContactsTableAdapter = null;
            this.tableAdapterManager1.DepartmentTableAdapter = null;
            this.tableAdapterManager1.EmployeeTableAdapter = null;
            this.tableAdapterManager1.HResourcesTableAdapter = null;
            this.tableAdapterManager1.ImpactsTableAdapter = null;
            this.tableAdapterManager1.InstallScheduleTableAdapter = null;
            this.tableAdapterManager1.IssuesTableAdapter = null;
            this.tableAdapterManager1.JobDetailsTableAdapter = null;
            this.tableAdapterManager1.JobKeyDatesTableAdapter = null;
            this.tableAdapterManager1.JobTypesTableAdapter = null;
            this.tableAdapterManager1.KeyDateListTableAdapter = null;
            this.tableAdapterManager1.MovementCodesTableAdapter = null;
            this.tableAdapterManager1.MovementsTableAdapter = null;
            this.tableAdapterManager1.OpsPlannerTableAdapter = null;
            this.tableAdapterManager1.PurchasingAreasTableAdapter = null;
            this.tableAdapterManager1.ReqHResourceTableAdapter = null;
            this.tableAdapterManager1.ReqPurchasingTableAdapter = null;
            this.tableAdapterManager1.ReqSubConTableAdapter = null;
            this.tableAdapterManager1.SiteContactEventsTableAdapter = null;
            this.tableAdapterManager1.SiteDetailsTableAdapter = null;
            this.tableAdapterManager1.SMSLinesTableAdapter = null;
            this.tableAdapterManager1.StatusTableAdapter = null;
            this.tableAdapterManager1.SubConAreasTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.WorkScheduleTableAdapter = null;
            // 
            // jobDetailsBindingSource
            // 
            this.jobDetailsBindingSource.DataMember = "JobDetails";
            this.jobDetailsBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // siteContactEventsBindingSource
            // 
            this.siteContactEventsBindingSource.DataMember = "SiteContactEvents";
            this.siteContactEventsBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // installScheduleTableAdapter1
            // 
            this.installScheduleTableAdapter1.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1254, 781);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 48;
            this.button1.Text = "Generate Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 369);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1441, 170);
            this.dataGridView1.TabIndex = 49;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 349);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 50;
            this.label7.Text = "Build Program";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1287, 545);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 22);
            this.button4.TabIndex = 51;
            this.button4.Text = "View Purchasing";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // keyDateListTableAdapter1
            // 
            this.keyDateListTableAdapter1.ClearBeforeFill = true;
            // 
            // jobKeyDatesTableAdapter1
            // 
            this.jobKeyDatesTableAdapter1.ClearBeforeFill = true;
            // 
            // jobTypesTableAdapter1
            // 
            this.jobTypesTableAdapter1.ClearBeforeFill = true;
            // 
            // opsPlannerTableAdapter1
            // 
            this.opsPlannerTableAdapter1.ClearBeforeFill = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(1410, 981);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 31);
            this.button5.TabIndex = 52;
            this.button5.Text = "Refresh";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(1133, 781);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(109, 28);
            this.button6.TabIndex = 53;
            this.button6.Text = "Clone Install";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(1009, 781);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(109, 28);
            this.button7.TabIndex = 54;
            this.button7.Text = "Filter Live";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // EditSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1495, 1024);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.contactsDataGridView);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.siteContactEventsDataGridView);
            this.Controls.Add(this.vInstallLineSummaryAllDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jobDataGridView);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(clientIDLabel);
            this.Controls.Add(postCodeLabel);
            this.Controls.Add(this.postCodeTextBox);
            this.Controls.Add(countyLabel);
            this.Controls.Add(this.countyTextBox);
            this.Controls.Add(townLabel);
            this.Controls.Add(this.townTextBox);
            this.Controls.Add(address2Label);
            this.Controls.Add(this.address2TextBox);
            this.Controls.Add(address1Label);
            this.Controls.Add(this.address1TextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.siteDetailsBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditSite";
            this.Text = "EditSite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditSite_FormClosing);
            this.Load += new System.EventHandler(this.EditSite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_salesdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInstallLineSummaryAllDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInstallLineSummaryAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteContactEventsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opsPlannerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteContactEventsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsDataGridView)).EndInit();
            this.contactContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jobDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDetailsBindingNavigator)).EndInit();
            this.siteDetailsBindingNavigator.ResumeLayout(false);
            this.siteDetailsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteContactEventsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sbi_salesdbDataSet sbi_salesdbDataSet;
        private System.Windows.Forms.BindingSource siteDetailsBindingSource;
        private sbi_salesdbDataSetTableAdapters.SiteDetailsTableAdapter siteDetailsTableAdapter;
        private sbi_salesdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox address1TextBox;
        private System.Windows.Forms.TextBox address2TextBox;
        private System.Windows.Forms.TextBox townTextBox;
        private System.Windows.Forms.TextBox countyTextBox;
        private System.Windows.Forms.TextBox postCodeTextBox;
        private sbi_salesdbDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.BindingSource jobBindingSource;
        private sbi_salesdbDataSetTableAdapters.JobTableAdapter jobTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private sbi_installdbDataSet sbi_installdbDataSet;
        private System.Windows.Forms.BindingSource vInstallLineSummaryAllBindingSource;
        private sbi_installdbDataSetTableAdapters.vInstallLineSummaryAllTableAdapter vInstallLineSummaryAllTableAdapter;
        private sbi_installdbDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridView vInstallLineSummaryAllDataGridView;
        private sbi_installdbDataSetTableAdapters.JobDetailsTableAdapter jobDetailsTableAdapter;
        private System.Windows.Forms.BindingSource jobDetailsBindingSource;
        private sbi_installdbDataSetTableAdapters.SiteContactEventsTableAdapter siteContactEventsTableAdapter;
        private System.Windows.Forms.BindingSource siteContactEventsBindingSource;
        private System.Windows.Forms.DataGridView siteContactEventsDataGridView;
        private sbi_salesdbDataSetTableAdapters.OPSPlannerTableAdapter oPSPlannerTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource siteDetailsBindingSource1;
        private sbi_installdbDataSetTableAdapters.SiteDetailsTableAdapter siteDetailsTableAdapter1;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.BindingSource contactsBindingSource;
        private sbi_installdbDataSetTableAdapters.ContactsTableAdapter contactsTableAdapter;
        private System.Windows.Forms.DataGridView contactsDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView jobDataGridView;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton siteDetailsBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator siteDetailsBindingNavigator;
        private System.Windows.Forms.BindingSource siteContactEventsBindingSource1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private sbi_installdbDataSetTableAdapters.InstallScheduleTableAdapter installScheduleTableAdapter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.Button button4;
        private sbi_installdbDataSetTableAdapters.KeyDateListTableAdapter keyDateListTableAdapter1;
        private sbi_installdbDataSetTableAdapters.JobKeyDatesTableAdapter jobKeyDatesTableAdapter1;
        private sbi_installdbDataSetTableAdapters.JobTypesTableAdapter jobTypesTableAdapter1;
        private System.Windows.Forms.BindingSource opsPlannerBindingSource;
        private sbi_installdbDataSetTableAdapters.OpsPlannerTableAdapter opsPlannerTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ContextMenuStrip contactContext;
        private System.Windows.Forms.ToolStripMenuItem moveToTopToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FollowUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstallDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeeksAway;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstallID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}