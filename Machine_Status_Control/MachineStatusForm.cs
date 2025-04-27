using Business.Abstract;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Machine_Status_Control
{
    public partial class MachineStatusForm : Form
    {
        private readonly Machine _machine;
        private readonly IMachineStatusService _machineStatusService;
        private readonly IShiftService _shiftService;
        private readonly List<Shift> _shifts;


        public MachineStatusForm(Machine machine, IMachineStatusService machineStatusService)
        {
            InitializeComponent();

            _machine = machine ?? throw new ArgumentNullException(nameof(machine));
            _machineStatusService = machineStatusService ?? throw new ArgumentNullException(nameof(machineStatusService));
            _shiftService = new ShiftManager(new EfShiftDal());
            _shifts = _shiftService.GetAll().Data;

            // ComboBox'a vardiyaları yükle
            cmbShifts.DataSource = _shifts;
            cmbShifts.DisplayMember = "Name";
            cmbShifts.ValueMember = "Id";

            // Makine bilgilerini yükle
            lblMachineName.Text = _machine.Name ?? "Bilgi Yok";
            lblMachineCode.Text = _machine.Description ?? "Bilgi Yok";
            lblMachineLocation.Text = _machine.Location ?? "Bilgi Yok";
        }

        private void MachineStatusForm_Load(object sender, EventArgs e)
        {
            var statuses = _machineStatusService.GetLastStatusByMachineId(_machine.Id)?.Data;

            if (statuses != null)
            {
                FillListView(statuses);
            }
            else
            {
                MessageBox.Show("Makine durumu bulunamadı.");
            }
        }

        private void btnFilterByShift_Click(object sender, EventArgs e)
        {
            if (cmbShifts.SelectedItem is not Shift selectedShift)
            {
                MessageBox.Show("Lütfen bir vardiya seçin.");
                return;
            }

            if (dtpNewDate == null)
            {
                MessageBox.Show("Tarih seçici bulunamadı.");
                return;
            }

            DateTime selectedDate = dtpNewDate.Value.Date;
            TimeSpan selectedTime = selectedShift.StartTime;

            var form = new MachineStatusByShiftForm(_machine.Id, selectedTime, selectedDate, _machineStatusService);
            form.Show();
        }








        private void btnFilterByDateTime_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDate.Value.Date;
            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            TimeSpan endTime = dtpEndTime.Value.TimeOfDay;

            DateTime startDateTime = selectedDate + startTime;
            DateTime endDateTime = selectedDate + endTime;

            if (startDateTime >= endDateTime)
            {
                MessageBox.Show("Başlangıç saati, bitiş saatinden küçük olmalıdır.");
                return;
            }

            var statuses = _machineStatusService.GetLastStatusByMachineId(_machine.Id)?.Data;

            if (statuses != null)
            {
                var filtered = statuses
                    .Where(s => s.Date + s.Time >= startDateTime && s.Date + s.Time <= endDateTime)
                    .OrderByDescending(s => s.Date)
                    .ThenByDescending(s => s.Time)
                    .ToList();

                FillListView(filtered);
            }
            else
            {
                MessageBox.Show("Makine durumu bulunamadı.");
            }
        }

        private void btnTotalWorkingTime_Click(object sender, EventArgs e)
        {
            var statuses = _machineStatusService.GetLastStatusByMachineId(_machine.Id)?.Data;

            if (statuses == null || statuses.Count == 0)
            {
                MessageBox.Show("Makine durumu verisi bulunamadı.");
                return;
            }

            var result = _machineStatusService.CalculateWorkingTime(statuses);

            if (result.Success)
            {
                TimeSpan calismaSuresi = result.Data;
                string saat = ((int)calismaSuresi.TotalHours).ToString("00");
                string dakika = calismaSuresi.Minutes.ToString("00");

                MessageBox.Show($"Toplam çalışma süresi: {saat}:{dakika}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hesaplama sırasında bir hata oluştu: " + result.Message);
            }
        }

        private void FillListView(List<MachineStatus> statuses)
        {
            lvMachineStatuses.Items.Clear();

            if (statuses == null || statuses.Count == 0)
            {
                lvMachineStatuses.Items.Add(new ListViewItem("Sonuç bulunamadı."));
                return;
            }

            foreach (var status in statuses)
            {
                var item = new ListViewItem(status.Date.ToString("dd.MM.yyyy"))
                {
                    SubItems =
                    {
                        status.Time.ToString(@"hh\:mm"),
                        status.StatusId == 1 ? "Aktif" : "Pasif"
                    }
                };

                lvMachineStatuses.Items.Add(item);
            }
        }

        private void dgvMachineStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
