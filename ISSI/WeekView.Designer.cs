namespace ISSI
{
    partial class WeekView
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
            this.tlpHolding = new System.Windows.Forms.TableLayoutPanel();
            this.wcPicker = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnFwd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sbi_installdbDataSet = new ISSI.sbi_installdbDataSet();
            this.tableAdapterManager = new ISSI.sbi_installdbDataSetTableAdapters.TableAdapterManager();
            this.JobTypesTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.JobTypesTableAdapter();
            this.vInstallLineSummaryInstallOnlyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vInstallLineSummaryInstallOnlyTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.vInstallLineSummaryInstallOnlyTableAdapter();
            this.tlpWeekLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFri = new System.Windows.Forms.Label();
            this.lblTue = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblWed = new System.Windows.Forms.Label();
            this.lblThur = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInstallLineSummaryInstallOnlyBindingSource)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpHolding
            // 
            this.tlpHolding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpHolding.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpHolding.ColumnCount = 1;
            this.tlpHolding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tlpHolding.Location = new System.Drawing.Point(1482, 120);
            this.tlpHolding.Name = "tlpHolding";
            this.tlpHolding.RowCount = 26;
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpHolding.Size = new System.Drawing.Size(310, 65535);
            this.tlpHolding.TabIndex = 1;
            this.tlpHolding.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel2_MouseClick);
            // 
            // wcPicker
            // 
            this.wcPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wcPicker.Location = new System.Drawing.Point(105, 13);
            this.wcPicker.Name = "wcPicker";
            this.wcPicker.Size = new System.Drawing.Size(200, 26);
            this.wcPicker.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(323, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(113, 43);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFwd
            // 
            this.btnFwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFwd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFwd.Font = new System.Drawing.Font("Wingdings 3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnFwd.Location = new System.Drawing.Point(933, 18);
            this.btnFwd.Name = "btnFwd";
            this.btnFwd.Size = new System.Drawing.Size(45, 37);
            this.btnFwd.TabIndex = 7;
            this.btnFwd.Text = "";
            this.btnFwd.UseVisualStyleBackColor = true;
            this.btnFwd.Click += new System.EventHandler(this.btnFwd_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBack.Font = new System.Drawing.Font("Wingdings 3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBack.Location = new System.Drawing.Point(12, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(43, 41);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.saveChanges_Click);
            // 
            // sbi_installdbDataSet
            // 
            this.sbi_installdbDataSet.DataSetName = "sbi_installdbDataSet";
            this.sbi_installdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // JobTypesTableAdapter
            // 
            this.JobTypesTableAdapter.ClearBeforeFill = true;
            // 
            // vInstallLineSummaryInstallOnlyBindingSource
            // 
            this.vInstallLineSummaryInstallOnlyBindingSource.DataMember = "vInstallLineSummaryInstallOnly";
            this.vInstallLineSummaryInstallOnlyBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // vInstallLineSummaryInstallOnlyTableAdapter
            // 
            this.vInstallLineSummaryInstallOnlyTableAdapter.ClearBeforeFill = true;
            // 
            // tlpWeekLayout
            // 
            this.tlpWeekLayout.AllowDrop = true;
            this.tlpWeekLayout.AutoScroll = true;
            this.tlpWeekLayout.AutoSize = true;
            this.tlpWeekLayout.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tlpWeekLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpWeekLayout.ColumnCount = 5;
            this.tlpWeekLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tlpWeekLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tlpWeekLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tlpWeekLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tlpWeekLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tlpWeekLayout.Location = new System.Drawing.Point(18, 120);
            this.tlpWeekLayout.Name = "tlpWeekLayout";
            this.tlpWeekLayout.RowCount = 26;
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpWeekLayout.Size = new System.Drawing.Size(1471, 10687);
            this.tlpWeekLayout.TabIndex = 0;
            this.tlpWeekLayout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.tableLayoutPanel3.Controls.Add(this.lblFri, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTue, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblMon, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblWed, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblThur, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(18, 75);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1439, 39);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // lblFri
            // 
            this.lblFri.AutoSize = true;
            this.lblFri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFri.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFri.Location = new System.Drawing.Point(1143, 0);
            this.lblFri.Name = "lblFri";
            this.lblFri.Size = new System.Drawing.Size(293, 39);
            this.lblFri.TabIndex = 13;
            this.lblFri.Text = "Fri";
            this.lblFri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFri.UseMnemonic = false;
            // 
            // lblTue
            // 
            this.lblTue.AutoSize = true;
            this.lblTue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTue.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTue.Location = new System.Drawing.Point(288, 0);
            this.lblTue.Name = "lblTue";
            this.lblTue.Size = new System.Drawing.Size(279, 39);
            this.lblTue.TabIndex = 8;
            this.lblTue.Text = "Tues";
            this.lblTue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTue.UseMnemonic = false;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMon.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.Location = new System.Drawing.Point(3, 0);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(279, 39);
            this.lblMon.TabIndex = 7;
            this.lblMon.Text = "Mon";
            this.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMon.UseMnemonic = false;
            // 
            // lblWed
            // 
            this.lblWed.AutoSize = true;
            this.lblWed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWed.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWed.Location = new System.Drawing.Point(573, 0);
            this.lblWed.Name = "lblWed";
            this.lblWed.Size = new System.Drawing.Size(279, 39);
            this.lblWed.TabIndex = 9;
            this.lblWed.Text = "Wed";
            this.lblWed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWed.UseMnemonic = false;
            // 
            // lblThur
            // 
            this.lblThur.AutoSize = true;
            this.lblThur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThur.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThur.Location = new System.Drawing.Point(858, 0);
            this.lblThur.Name = "lblThur";
            this.lblThur.Size = new System.Drawing.Size(279, 39);
            this.lblThur.TabIndex = 10;
            this.lblThur.Text = "Thur";
            this.lblThur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThur.UseMnemonic = false;
            this.lblThur.Click += new System.EventHandler(this.label4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(453, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 43);
            this.button2.TabIndex = 9;
            this.button2.Text = "Unlock Layout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WeekView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1901, 1054);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tlpWeekLayout);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.btnFwd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tlpHolding);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.wcPicker);
            this.Name = "WeekView";
            this.Text = "Week To View";
            this.TransparencyKey = System.Drawing.Color.Indigo;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WeekView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInstallLineSummaryInstallOnlyBindingSource)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpHolding;
        private System.Windows.Forms.DateTimePicker wcPicker;
        private System.Windows.Forms.Button btnLoad;
        private sbi_installdbDataSet sbi_installdbDataSet;
        private sbi_installdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnFwd;
        private System.Windows.Forms.Button btnBack;
        private sbi_installdbDataSetTableAdapters.JobTypesTableAdapter JobTypesTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource vInstallLineSummaryInstallOnlyBindingSource;
        private sbi_installdbDataSetTableAdapters.vInstallLineSummaryInstallOnlyTableAdapter vInstallLineSummaryInstallOnlyTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tlpWeekLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblFri;
        private System.Windows.Forms.Label lblTue;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblWed;
        private System.Windows.Forms.Label lblThur;
        private System.Windows.Forms.Button button2;
    }
}

