namespace Machine_Status_Control
{
    partial class MachineStatusByShiftForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvMachineStatuses;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatusTimeline;
        private System.Windows.Forms.Label lblMachineInfo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelChart;

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
            components = new System.ComponentModel.Container();

            lvMachineStatuses = new System.Windows.Forms.ListView();
            chDate = new System.Windows.Forms.ColumnHeader();
            chTime = new System.Windows.Forms.ColumnHeader();
            chStatus = new System.Windows.Forms.ColumnHeader();
            lblMachineInfo = new System.Windows.Forms.Label();
            panelHeader = new System.Windows.Forms.Panel();
            panelChart = new System.Windows.Forms.Panel();
            chartStatusTimeline = new System.Windows.Forms.DataVisualization.Charting.Chart();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartStatusTimeline)).BeginInit();
            SuspendLayout();

            // 
            // lvMachineStatuses
            // 
            lvMachineStatuses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                chDate, chTime, chStatus
            });
            lvMachineStatuses.FullRowSelect = true;
            lvMachineStatuses.GridLines = true;
            lvMachineStatuses.Location = new System.Drawing.Point(12, 70);
            lvMachineStatuses.Name = "lvMachineStatuses";
            lvMachineStatuses.Size = new System.Drawing.Size(532, 440);
            lvMachineStatuses.TabIndex = 0;
            lvMachineStatuses.UseCompatibleStateImageBehavior = false;
            lvMachineStatuses.View = System.Windows.Forms.View.Details;

            // 
            // chDate
            // 
            chDate.Text = "Tarih";
            chDate.Width = 100;

            // 
            // chTime
            // 
            chTime.Text = "Saat";
            chTime.Width = 100;

            // 
            // chStatus
            // 
            chStatus.Text = "Durum";
            chStatus.Width = 100;

            // 
            // lblMachineInfo
            // 
            lblMachineInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            lblMachineInfo.Location = new System.Drawing.Point(12, 10);
            lblMachineInfo.Name = "lblMachineInfo";
            lblMachineInfo.Size = new System.Drawing.Size(400, 50);
            lblMachineInfo.TabIndex = 0;
            lblMachineInfo.Text = "Makine: [Makine Adı] | Durum: [Aktif/Pasif]";
            lblMachineInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblMachineInfo);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1013, 70);
            panelHeader.TabIndex = 2;
            panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(panelHeader_Paint_1);

            // 
            // panelChart
            // 
            panelChart.Dock = System.Windows.Forms.DockStyle.Right;
            panelChart.Location = new System.Drawing.Point(543, 70);
            panelChart.Name = "panelChart";
            panelChart.Size = new System.Drawing.Size(470, 440);
            panelChart.TabIndex = 1;

            // chartStatusTimeline
            chartStatusTimeline = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartStatusTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            chartStatusTimeline.Name = "chartStatusTimeline";
            panelChart.Controls.Add(chartStatusTimeline);


            // 
            // MachineStatusByShiftForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1013, 510);
            Controls.Add(lvMachineStatuses);
            Controls.Add(panelChart);
            Controls.Add(panelHeader);
            Name = "MachineStatusByShiftForm";
            Text = "Vardiyaya Göre Makine Durumu";
            Load += new System.EventHandler(MachineStatusByShiftForm_Load);

            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(chartStatusTimeline)).EndInit();
            ResumeLayout(false);
        }
    }
}
