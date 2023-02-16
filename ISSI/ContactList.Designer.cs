namespace ISSI
{
    partial class ContactList
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
            this.sbi_installdbDataSet = new ISSI.sbi_installdbDataSet();
            this.vContactDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vContactDetailsTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.vContactDetailsTableAdapter();
            this.tableAdapterManager = new ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager();
            this.vContactDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vContactDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vContactDetailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sbi_installdbDataSet
            // 
            this.sbi_installdbDataSet.DataSetName = "sbi_installdbDataSet";
            this.sbi_installdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vContactDetailsBindingSource
            // 
            this.vContactDetailsBindingSource.DataMember = "vContactDetails";
            this.vContactDetailsBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // vContactDetailsTableAdapter
            // 
            this.vContactDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CausesTableAdapter = null;
            this.tableAdapterManager.ChecklistItemsTableAdapter = null;
            this.tableAdapterManager.CheckListlistTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ContactsTableAdapter = null;
            this.tableAdapterManager.DepartmentTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.HResourcesTableAdapter = null;
            this.tableAdapterManager.ImpactsTableAdapter = null;
            this.tableAdapterManager.InstallScheduleTableAdapter = null;
            this.tableAdapterManager.IssuesTableAdapter = null;
            this.tableAdapterManager.JobDetailsTableAdapter = null;
            this.tableAdapterManager.JobKeyDatesTableAdapter = null;
            this.tableAdapterManager.JobTypesTableAdapter = null;
            this.tableAdapterManager.KeyDateListTableAdapter = null;
            this.tableAdapterManager.MovementCodesTableAdapter = null;
            this.tableAdapterManager.MovementsTableAdapter = null;
            this.tableAdapterManager.OpsPlannerTableAdapter = null;
            this.tableAdapterManager.PurchasingAreasTableAdapter = null;
            this.tableAdapterManager.ReqHResourceTableAdapter = null;
            this.tableAdapterManager.ReqPurchasingTableAdapter = null;
            this.tableAdapterManager.ReqSubConTableAdapter = null;
            this.tableAdapterManager.SiteContactEventsTableAdapter = null;
            this.tableAdapterManager.SiteDetailsTableAdapter = null;
            this.tableAdapterManager.SMSLinesTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.SubConAreasTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WorkScheduleTableAdapter = null;
            // 
            // vContactDetailsDataGridView
            // 
            this.vContactDetailsDataGridView.AllowUserToAddRows = false;
            this.vContactDetailsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vContactDetailsDataGridView.AutoGenerateColumns = false;
            this.vContactDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vContactDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.SiteID});
            this.vContactDetailsDataGridView.DataSource = this.vContactDetailsBindingSource;
            this.vContactDetailsDataGridView.Location = new System.Drawing.Point(12, 23);
            this.vContactDetailsDataGridView.Name = "vContactDetailsDataGridView";
            this.vContactDetailsDataGridView.Size = new System.Drawing.Size(694, 441);
            this.vContactDetailsDataGridView.TabIndex = 1;
            this.vContactDetailsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vContactDetailsDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Client";
            this.dataGridViewTextBoxColumn1.HeaderText = "Client";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SiteName";
            this.dataGridViewTextBoxColumn2.HeaderText = "SiteName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "JobTitle";
            this.dataGridViewTextBoxColumn7.HeaderText = "JobTitle";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Tel1";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tel1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Email1";
            this.dataGridViewTextBoxColumn6.HeaderText = "Email1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn8.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // SiteID
            // 
            this.SiteID.DataPropertyName = "SiteID";
            this.SiteID.HeaderText = "SiteID";
            this.SiteID.Name = "SiteID";
            this.SiteID.Visible = false;
            // 
            // ContactList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 486);
            this.Controls.Add(this.vContactDetailsDataGridView);
            this.KeyPreview = true;
            this.Name = "ContactList";
            this.Text = "ContactList";
            this.Load += new System.EventHandler(this.ContactList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContactList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vContactDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vContactDetailsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sbi_installdbDataSet sbi_installdbDataSet;
        private System.Windows.Forms.BindingSource vContactDetailsBindingSource;
        private sbi_installdbDataSetTableAdapters.vContactDetailsTableAdapter vContactDetailsTableAdapter;
        private sbi_installdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView vContactDetailsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteID;
    }
}