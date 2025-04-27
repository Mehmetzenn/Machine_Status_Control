namespace Machine_Status_Control
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelMachines;
        private Panel pnlNavbar;
        private Label lblTitle;
        private Button btnProfile;
        private Button btnSettings;
        private Button btnLogout;
        private Button btnManageShifts;

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
            flowLayoutPanelMachines = new FlowLayoutPanel();
            pnlNavbar = new Panel();
            lblTitle = new Label();
            btnProfile = new Button();
            btnSettings = new Button();
            btnManageShifts = new Button();
            btnLogout = new Button();
            pnlNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelMachines
            // 
            flowLayoutPanelMachines.AutoScroll = true;
            flowLayoutPanelMachines.Location = new Point(10, 80);
            flowLayoutPanelMachines.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelMachines.Name = "flowLayoutPanelMachines";
            flowLayoutPanelMachines.Size = new Size(900, 392);
            flowLayoutPanelMachines.TabIndex = 0;
            // 
            // pnlNavbar
            // 
            pnlNavbar.BackColor = Color.FromArgb(28, 28, 28);
            pnlNavbar.Controls.Add(lblTitle);
            pnlNavbar.Controls.Add(btnProfile);
            pnlNavbar.Controls.Add(btnSettings);
            pnlNavbar.Controls.Add(btnManageShifts);
            pnlNavbar.Controls.Add(btnLogout);
            pnlNavbar.Dock = DockStyle.Top;
            pnlNavbar.Location = new Point(0, 0);
            pnlNavbar.Name = "pnlNavbar";
            pnlNavbar.Padding = new Padding(10);
            pnlNavbar.Size = new Size(1029, 60);
            pnlNavbar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Makine Durum Kontrol";
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.Transparent;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 10F);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(650, 15);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(80, 30);
            btnProfile.TabIndex = 1;
            btnProfile.Text = "Profil";
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(740, 15);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(80, 30);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Ayarlar";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnManageShifts
            // 
            btnManageShifts.BackColor = Color.Transparent;
            btnManageShifts.FlatStyle = FlatStyle.Flat;
            btnManageShifts.Font = new Font("Segoe UI", 10F);
            btnManageShifts.ForeColor = Color.White;
            btnManageShifts.Location = new Point(830, 15);
            btnManageShifts.Name = "btnManageShifts";
            btnManageShifts.Size = new Size(99, 30);
            btnManageShifts.TabIndex = 4;
            btnManageShifts.Text = "Vardiya Yönet";
            btnManageShifts.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(937, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(80, 30);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Çıkış";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            ClientSize = new Size(1029, 518);
            Controls.Add(flowLayoutPanelMachines);
            Controls.Add(pnlNavbar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Machine Status Control";
            Load += Form1_Load;
            pnlNavbar.ResumeLayout(false);
            pnlNavbar.PerformLayout();
            ResumeLayout(false);
        }
    }
}
