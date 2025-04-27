namespace Machine_Status_Control
{
    partial class StatusTypeForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private ListBox lstStatusTypes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lstStatusTypes = new ListBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(230, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Ekle";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(310, 20);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Güncelle";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(410, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Sil";
            btnDelete.Click += btnDelete_Click;
            // 
            // lstStatusTypes
            // 
            lstStatusTypes.ItemHeight = 15;
            lstStatusTypes.Location = new Point(20, 60);
            lstStatusTypes.Name = "lstStatusTypes";
            lstStatusTypes.Size = new Size(465, 64);
            lstStatusTypes.TabIndex = 4;
            lstStatusTypes.SelectedIndexChanged += lstStatusTypes_SelectedIndexChanged;
            // 
            // StatusTypeForm
            // 
            ClientSize = new Size(550, 400);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(lstStatusTypes);
            Name = "StatusTypeForm";
            Text = "Durum Türleri Yönetimi";
            Load += StatusTypeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
