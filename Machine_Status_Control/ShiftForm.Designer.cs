namespace Machine_Status_Control
{
    partial class ShiftForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listShifts = new System.Windows.Forms.ListView();
            this.colShiftName = new System.Windows.Forms.ColumnHeader();
            this.colStartTime = new System.Windows.Forms.ColumnHeader();
            this.colEndTime = new System.Windows.Forms.ColumnHeader();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddShift = new System.Windows.Forms.Button();
            this.btnUpdateShift = new System.Windows.Forms.Button();
            this.btnDeleteShift = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // listShifts
            this.listShifts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShiftName,
            this.colStartTime,
            this.colEndTime});
            this.listShifts.FullRowSelect = true;
            this.listShifts.HideSelection = false;
            this.listShifts.Location = new System.Drawing.Point(12, 12);
            this.listShifts.Name = "listShifts";
            this.listShifts.Size = new System.Drawing.Size(360, 200);
            this.listShifts.TabIndex = 0;
            this.listShifts.UseCompatibleStateImageBehavior = false;
            this.listShifts.View = System.Windows.Forms.View.Details;

            // colShiftName
            this.colShiftName.Text = "Shift Name";
            this.colShiftName.Width = 120;

            // colStartTime
            this.colStartTime.Text = "Start Time";
            this.colStartTime.Width = 120;

            // colEndTime
            this.colEndTime.Text = "End Time";
            this.colEndTime.Width = 120;

            // txtShiftName
            this.txtShiftName.Location = new System.Drawing.Point(12, 228);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(180, 20);
            this.txtShiftName.TabIndex = 1;

            // dtpStartTime
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(12, 254);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(180, 20);
            this.dtpStartTime.TabIndex = 2;

            // dtpEndTime
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(12, 280);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(180, 20);
            this.dtpEndTime.TabIndex = 3;

            // btnAddShift
            this.btnAddShift.Location = new System.Drawing.Point(198, 228);
            this.btnAddShift.Name = "btnAddShift";
            this.btnAddShift.Size = new System.Drawing.Size(75, 23);
            this.btnAddShift.TabIndex = 4;
            this.btnAddShift.Text = "Add Shift";
            this.btnAddShift.UseVisualStyleBackColor = true;
            this.btnAddShift.Click += new System.EventHandler(this.btnAddShift_Click);

            // btnUpdateShift
            this.btnUpdateShift.Location = new System.Drawing.Point(198, 254);
            this.btnUpdateShift.Name = "btnUpdateShift";
            this.btnUpdateShift.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateShift.TabIndex = 5;
            this.btnUpdateShift.Text = "Update Shift";
            this.btnUpdateShift.UseVisualStyleBackColor = true;
            this.btnUpdateShift.Click += new System.EventHandler(this.btnUpdateShift_Click);

            // btnDeleteShift
            this.btnDeleteShift.Location = new System.Drawing.Point(198, 280);
            this.btnDeleteShift.Name = "btnDeleteShift";
            this.btnDeleteShift.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteShift.TabIndex = 6;
            this.btnDeleteShift.Text = "Delete Shift";
            this.btnDeleteShift.UseVisualStyleBackColor = true;
            this.btnDeleteShift.Click += new System.EventHandler(this.btnDeleteShift_Click);

            // ShiftForm
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.btnDeleteShift);
            this.Controls.Add(this.btnUpdateShift);
            this.Controls.Add(this.btnAddShift);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.listShifts);
            this.Name = "ShiftForm";
            this.Text = "Shift Management";
            this.Load += new System.EventHandler(this.ShiftForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView listShifts;
        private System.Windows.Forms.ColumnHeader colShiftName;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colEndTime;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Button btnAddShift;
        private System.Windows.Forms.Button btnUpdateShift;
        private System.Windows.Forms.Button btnDeleteShift;
    }
}
