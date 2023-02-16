namespace ISSI
{
    partial class MovementDialog
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.movementCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbi_installdbDataSet = new ISSI.sbi_installdbDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.movementCodesTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.MovementCodesTableAdapter();
            this.movementsTableAdapter = new ISSI.sbi_installdbDataSetTableAdapters.MovementsTableAdapter();
            this.installScheduleTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.InstallScheduleTableAdapter();
            this.vEmailSitesTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.vEmailSitesTableAdapter();
            this.vEmailLinesTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.vEmailLinesTableAdapter();
            this.vEmailMovementsTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.vEmailMovementsTableAdapter();
            this.vEmailSubconTableAdapter1 = new ISSI.sbi_installdbDataSetTableAdapters.vEmailSubconTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.movementCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.movementCodesBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "MovementCode";
            // 
            // movementCodesBindingSource
            // 
            this.movementCodesBindingSource.DataMember = "MovementCodes";
            this.movementCodesBindingSource.DataSource = this.sbi_installdbDataSet;
            // 
            // sbi_installdbDataSet
            // 
            this.sbi_installdbDataSet.DataSetName = "sbi_installdbDataSet";
            this.sbi_installdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(337, 117);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Notes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Reason Code";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // movementCodesTableAdapter
            // 
            this.movementCodesTableAdapter.ClearBeforeFill = true;
            // 
            // movementsTableAdapter
            // 
            this.movementsTableAdapter.ClearBeforeFill = true;
            // 
            // installScheduleTableAdapter1
            // 
            this.installScheduleTableAdapter1.ClearBeforeFill = true;
            // 
            // vEmailSitesTableAdapter1
            // 
            this.vEmailSitesTableAdapter1.ClearBeforeFill = true;
            // 
            // vEmailLinesTableAdapter1
            // 
            this.vEmailLinesTableAdapter1.ClearBeforeFill = true;
            // 
            // vEmailMovementsTableAdapter1
            // 
            this.vEmailMovementsTableAdapter1.ClearBeforeFill = true;
            // 
            // vEmailSubconTableAdapter1
            // 
            this.vEmailSubconTableAdapter1.ClearBeforeFill = true;
            // 
            // MovementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 242);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "MovementDialog";
            this.Text = "Edit Install";
            this.Load += new System.EventHandler(this.MovementDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movementCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbi_installdbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private sbi_installdbDataSet sbi_installdbDataSet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource movementCodesBindingSource;
        private sbi_installdbDataSetTableAdapters.MovementCodesTableAdapter movementCodesTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private sbi_installdbDataSetTableAdapters.MovementsTableAdapter movementsTableAdapter;
        private sbi_installdbDataSetTableAdapters.InstallScheduleTableAdapter installScheduleTableAdapter1;
        private sbi_installdbDataSetTableAdapters.vEmailSitesTableAdapter vEmailSitesTableAdapter1;
        private sbi_installdbDataSetTableAdapters.vEmailLinesTableAdapter vEmailLinesTableAdapter1;
        private sbi_installdbDataSetTableAdapters.vEmailMovementsTableAdapter vEmailMovementsTableAdapter1;
        private sbi_installdbDataSetTableAdapters.vEmailSubconTableAdapter vEmailSubconTableAdapter1;
    }
}