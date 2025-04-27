namespace Machine_Status_Control
{
    partial class MachineStatusForm
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

        private void InitializeComponent()
        {
            lblMachineName = new Label();
            lblMachineCode = new Label();
            lblMachineLocation = new Label();
            cmbShifts = new ComboBox();
            dtpNewDate = new DateTimePicker();
            btnFilterByShift = new Button();
            dtpDate = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            btnFilterByDateTime = new Button();
            lvMachineStatuses = new ListView();
            colDate = new ColumnHeader();
            colTime = new ColumnHeader();
            colStatus = new ColumnHeader();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            btnTotalWorkingTime = new Button();
            SuspendLayout();
            // 
            // lblMachineName
            // 
            lblMachineName.AutoSize = true;
            lblMachineName.Location = new Point(30, 20);
            lblMachineName.Name = "lblMachineName";
            lblMachineName.Size = new Size(70, 15);
            lblMachineName.TabIndex = 0;
            lblMachineName.Text = "Makine Adı:";
            // 
            // lblMachineCode
            // 
            lblMachineCode.AutoSize = true;
            lblMachineCode.Location = new Point(30, 50);
            lblMachineCode.Name = "lblMachineCode";
            lblMachineCode.Size = new Size(80, 15);
            lblMachineCode.TabIndex = 1;
            lblMachineCode.Text = "Makine Kodu:";
            // 
            // lblMachineLocation
            // 
            lblMachineLocation.AutoSize = true;
            lblMachineLocation.Location = new Point(30, 80);
            lblMachineLocation.Name = "lblMachineLocation";
            lblMachineLocation.Size = new Size(109, 15);
            lblMachineLocation.TabIndex = 2;
            lblMachineLocation.Text = "Makine Lokasyonu:";
            // 
            // cmbShifts
            // 
            cmbShifts.FormattingEnabled = true;
            cmbShifts.Location = new Point(30, 110);
            cmbShifts.Name = "cmbShifts";
            cmbShifts.Size = new Size(200, 23);
            cmbShifts.TabIndex = 3;
            // 
            // dtpNewDate
            // 
            dtpNewDate.Location = new Point(250, 110);
            dtpNewDate.Name = "dtpNewDate";
            dtpNewDate.Size = new Size(200, 23);
            dtpNewDate.TabIndex = 4;
            // 
            // btnFilterByShift
            // 
            btnFilterByShift.Location = new Point(470, 110);
            btnFilterByShift.Name = "btnFilterByShift";
            btnFilterByShift.Size = new Size(150, 25);
            btnFilterByShift.TabIndex = 5;
            btnFilterByShift.Text = "Vardiyaya Göre Filtrele";
            btnFilterByShift.UseVisualStyleBackColor = true;
            btnFilterByShift.Click += btnFilterByShift_Click;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(30, 150);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 6;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(250, 150);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(100, 23);
            dtpStartTime.TabIndex = 7;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(360, 150);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(100, 23);
            dtpEndTime.TabIndex = 8;
            // 
            // btnFilterByDateTime
            // 
            btnFilterByDateTime.Location = new Point(470, 150);
            btnFilterByDateTime.Name = "btnFilterByDateTime";
            btnFilterByDateTime.Size = new Size(150, 25);
            btnFilterByDateTime.TabIndex = 9;
            btnFilterByDateTime.Text = "Tarihe Göre Filtrele";
            btnFilterByDateTime.UseVisualStyleBackColor = true;
            btnFilterByDateTime.Click += btnFilterByDateTime_Click;
            // 
            // lvMachineStatuses
            // 
            lvMachineStatuses.Columns.AddRange(new ColumnHeader[] { colDate, colTime, colStatus });
            lvMachineStatuses.FullRowSelect = true;
            lvMachineStatuses.GridLines = true;
            lvMachineStatuses.Location = new Point(30, 190);
            lvMachineStatuses.Name = "lvMachineStatuses";
            lvMachineStatuses.Size = new Size(590, 250);
            lvMachineStatuses.TabIndex = 10;
            lvMachineStatuses.UseCompatibleStateImageBehavior = false;
            lvMachineStatuses.View = View.Details;
            // 
            // colDate
            // 
            colDate.Text = "Tarih";
            colDate.Width = 150;
            // 
            // colTime
            // 
            colTime.Text = "Saat";
            colTime.Width = 100;
            // 
            // colStatus
            // 
            colStatus.Text = "Durum";
            colStatus.Width = 150;
            // 
            // btnTotalWorkingTime
            // 
            btnTotalWorkingTime.Location = new Point(470, 459);
            btnTotalWorkingTime.Name = "btnTotalWorkingTime";
            btnTotalWorkingTime.Size = new Size(150, 25);
            btnTotalWorkingTime.TabIndex = 11;
            btnTotalWorkingTime.Text = "Çalışma Süresi Hesapla";
            btnTotalWorkingTime.UseVisualStyleBackColor = true;
            btnTotalWorkingTime.Click += btnTotalWorkingTime_Click;
            // 
            // MachineStatusForm
            // 
            ClientSize = new Size(692, 515);
            Controls.Add(btnTotalWorkingTime);
            Controls.Add(lvMachineStatuses);
            Controls.Add(btnFilterByDateTime);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(dtpDate);
            Controls.Add(btnFilterByShift);
            Controls.Add(dtpNewDate);
            Controls.Add(cmbShifts);
            Controls.Add(lblMachineLocation);
            Controls.Add(lblMachineCode);
            Controls.Add(lblMachineName);
            Name = "MachineStatusForm";
            Text = "Makine Durumları";
            Load += MachineStatusForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblMachineCode;
        private System.Windows.Forms.Label lblMachineLocation;
        private System.Windows.Forms.ComboBox cmbShifts;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.Button btnFilterByShift;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Button btnFilterByDateTime;
        private System.Windows.Forms.ListView lvMachineStatuses;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colStatus;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button btnTotalWorkingTime;
    }
}
