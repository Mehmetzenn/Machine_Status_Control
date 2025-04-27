using Business.Abstract;
using Entities.Concretes;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Machine_Status_Control
{
    public partial class StatusTypeForm : Form
    {
        private readonly IStatusTypeService _statusTypeService;
        private StatusType _selectedStatusType;

        public StatusTypeForm(IStatusTypeService statusTypeService)
        {
            _statusTypeService = statusTypeService;
            InitializeComponent();
        }

        private void StatusTypeForm_Load(object sender, EventArgs e)
        {
            LoadStatusTypes();
        }

        private void LoadStatusTypes()
        {
            var result = _statusTypeService.GetAll();
            if (result.Success)
            {
                lstStatusTypes.DataSource = result.Data;
                lstStatusTypes.DisplayMember = "Name";
                lstStatusTypes.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show(result.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtName.Clear();
            _selectedStatusType = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;

            var newStatusType = new StatusType { Name = txtName.Text };
            var result = _statusTypeService.Add(newStatusType);

            MessageBox.Show(result.Message);
            LoadStatusTypes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStatusType == null || string.IsNullOrWhiteSpace(txtName.Text)) return;

            _selectedStatusType.Name = txtName.Text;
            var result = _statusTypeService.Update(_selectedStatusType);

            MessageBox.Show(result.Message);
            LoadStatusTypes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStatusType == null) return;

            var result = _statusTypeService.Delete(_selectedStatusType);
            MessageBox.Show(result.Message);
            LoadStatusTypes();
        }

        private void lstStatusTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStatusTypes.SelectedItem is StatusType selected)
            {
                _selectedStatusType = selected;
                txtName.Text = selected.Name;
            }
        }
    }
}
