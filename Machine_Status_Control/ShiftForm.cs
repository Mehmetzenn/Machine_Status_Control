using Business.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Machine_Status_Control
{
    public partial class ShiftForm : Form
    {
        private readonly IShiftService _shiftService;

        public ShiftForm(IShiftService shiftService)
        {
            _shiftService = shiftService;
            InitializeComponent();
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            LoadShifts();
        }

        private void LoadShifts()
        {
            listShifts.Items.Clear();  // Clear the list before reloading
            var result = _shiftService.GetAll();
            if (result.Success)
            {
                foreach (var shift in result.Data)
                {
                    // İlk sütunda shift adı
                    var listItem = new ListViewItem(shift.Name);

                    // Diğer sütunlarda başlangıç ve bitiş saatleri
                    listItem.SubItems.Add(shift.StartTime.ToString());
                    listItem.SubItems.Add(shift.EndTime.ToString());

                    // Shift ID'yi gizli olarak ekleyelim (Tag özelliği ile)
                    listItem.Tag = shift.Id;

                    // Listeye ekle
                    listShifts.Items.Add(listItem);
                }
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddShift_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShiftName.Text))
            {
                MessageBox.Show("Shift name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var shift = new Shift
            {
                Name = txtShiftName.Text,
                StartTime = dtpStartTime.Value.TimeOfDay, // Convert DateTime to TimeSpan
                EndTime = dtpEndTime.Value.TimeOfDay      // Convert DateTime to TimeSpan
            };

            var result = _shiftService.Add(shift);
            if (result.Success)
            {
                MessageBox.Show("Shift added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadShifts();  // Reload the list after adding a shift
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateShift_Click(object sender, EventArgs e)
        {
            if (listShifts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir şift seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçilen öğeyi al
            var selectedItem = listShifts.SelectedItems[0];

            // Güncellenmiş değerleri al
            string updatedShiftName = txtShiftName.Text;  // Şift adı metin olarak al
            TimeSpan updatedStartTime = dtpStartTime.Value.TimeOfDay; // Başlangıç saati
            TimeSpan updatedEndTime = dtpEndTime.Value.TimeOfDay;     // Bitiş saati

            // Seçilen öğeden ID'yi al
            int shiftId = (int)selectedItem.Tag;

            // Güncellenmiş Shift nesnesi oluştur
            var updatedShift = new Shift
            {
                Id = shiftId,
                Name = updatedShiftName,
                StartTime = updatedStartTime,
                EndTime = updatedEndTime
            };

            // Şift güncelleme servisini çağır
            var result = _shiftService.Update(updatedShift);

            if (result.Success)
            {
                // UI'yi güncelle
                selectedItem.SubItems[0].Text = updatedShiftName;  // Shift Name
                selectedItem.SubItems[1].Text = updatedStartTime.ToString(@"hh\:mm");  // Start Time
                selectedItem.SubItems[2].Text = updatedEndTime.ToString(@"hh\:mm");   // End Time

                // Kullanıcıya başarılı mesajını göster
                MessageBox.Show("Şift başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Hata durumunda kullanıcıya mesaj göster
                MessageBox.Show(result.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            // Seçilen öğeyi kontrol et
            if (listShifts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir şift seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçilen öğeyi al
            var selectedItem = listShifts.SelectedItems[0];

            // ID'yi Tag üzerinden al
            int shiftId = (int)selectedItem.Tag;

            // IShiftService üzerinden silme işlemini yap
            var shift = new Shift { Id = shiftId };
            var result = _shiftService.Delete(shift);

            if (result.Success)
            {
                listShifts.Items.Remove(selectedItem);
                MessageBox.Show("Şift başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
