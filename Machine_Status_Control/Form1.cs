using Business.Abstract;
using Business.Abstracts;
using Entities.Concretes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Machine_Status_Control
{
    public partial class Form1 : Form
    {
        private readonly IMachineService _machineService;
        private readonly IMachineStatusService _machineStatusService;
        private readonly IStatusTypeService _statusTypeService;
        private readonly IShiftService _shiftService; // Add the IShiftService

        public Form1(IMachineService machineService, IMachineStatusService machineStatusService, IStatusTypeService statusTypeService, IShiftService shiftService)
        {
            _machineService = machineService;
            _machineStatusService = machineStatusService;
            _statusTypeService = statusTypeService;
            _shiftService = shiftService; // Initialize the IShiftService
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnProfile.Click += (s, args) => MessageBox.Show("Profil Butonuna Týklandý");
            btnSettings.Click += (s, args) =>
            {
                var form = new StatusTypeForm(_statusTypeService);
                form.ShowDialog();  // Show it as a modal dialog
            };
            btnLogout.Click += (s, args) => MessageBox.Show("Çýkýþ Butonuna Týklandý");

            btnManageShifts.Click += (s, args) =>
            {
                // Open ShiftForm to manage shifts
                var shiftForm = new ShiftForm(_shiftService);
                shiftForm.ShowDialog();
            };

            flowLayoutPanelMachines.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            var result = _machineService.GetAll();

            if (result.Success)
            {
                foreach (var machine in result.Data)
                {
                    var card = new Panel
                    {
                        Width = 200,
                        Height = 160,
                        BackColor = Color.White,
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(10)
                    };

                    var lblName = new Label
                    {
                        Text = $"Ýsim: {machine.Name}",
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    var lblCode = new Label
                    {
                        Text = $"Kod: {machine.Description}",
                        Location = new Point(10, 40),
                        AutoSize = true
                    };

                    var lblLocation = new Label
                    {
                        Text = $"Lokasyon: {machine.Location}",
                        Location = new Point(10, 70),
                        AutoSize = true
                    };

                    var btnDetails = new Button
                    {
                        Text = "Ayrýntýlar",
                        Location = new Point(10, 100),
                        Width = 180,
                        Height = 30,
                        BackColor = Color.Blue,
                        ForeColor = Color.White
                    };

                    btnDetails.Click += (s, e) => ShowMachineDetails(machine);

                    card.Controls.Add(lblName);
                    card.Controls.Add(lblCode);
                    card.Controls.Add(lblLocation);
                    card.Controls.Add(btnDetails);

                    flowLayoutPanelMachines.Controls.Add(card);
                }
            }
            else
            {
                MessageBox.Show(result.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMachineDetails(Machine machine)
        {
            var form = new MachineStatusForm(machine, _machineStatusService);
            form.Show();
        }

        private void btnManageShifts_Click(object sender, EventArgs e)
        {

        }
    }
}
