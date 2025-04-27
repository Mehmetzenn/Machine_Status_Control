using Business.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Machine_Status_Control
{
    public partial class MachineStatusByShiftForm : Form
    {
        private readonly int _machineId;
        private readonly TimeSpan _shiftStartTime;
        private readonly DateTime _date;
        private readonly IMachineStatusService _machineStatusService;

        public MachineStatusByShiftForm(int machineId, TimeSpan shiftStartTime, DateTime date, IMachineStatusService machineStatusService)
        {
            InitializeComponent();
            _machineId = machineId;
            _shiftStartTime = shiftStartTime;
            _date = date;
            _machineStatusService = machineStatusService;
        }

        private void MachineStatusByShiftForm_Load(object sender, EventArgs e)
        {
            // Önce API'den veri alınmalı
            var result = _machineStatusService.GetByMachineIdAndShift(_machineId, _shiftStartTime, _date);

            // Veriler alındıktan sonra grafik çizimi yapılır
            if (result.Success)
            {
                FillListView(result.Data);
                DrawChart(result.Data);  // Bu kısmı buraya taşıdık
            }
            else
            {
                MessageBox.Show("Veri alınamadı: " + result.Message);
            }
        }


        private void FillListView(List<MachineStatus> statuses)
        {
            lvMachineStatuses.Items.Clear();

            if (statuses == null || statuses.Count == 0)
            {
                lvMachineStatuses.Items.Add(new ListViewItem("Veri bulunamadı."));
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
        private void DrawChart(List<MachineStatus> statuses)
        {
            chartStatusTimeline.Series.Clear();
            chartStatusTimeline.ChartAreas.Clear();

            var chartArea = new ChartArea("MainArea");
            chartStatusTimeline.ChartAreas.Add(chartArea);

            var series = new Series("Durum")
            {
                ChartType = SeriesChartType.StepLine,
                BorderWidth = 3,
                XValueType = ChartValueType.String
            };

            chartStatusTimeline.Series.Add(series);

            var orderedStatuses = statuses.OrderBy(s => s.Time).ToList();
            if (orderedStatuses.Count == 0)
                return;

            foreach (var status in orderedStatuses)
            {
                string time = status.Time.ToString(@"hh\:mm");
                double yValue = (status.StatusId == 1) ? 1 : 0;

                int index = series.Points.AddXY(time, yValue);

                // Nokta nokta renkleme: Aktif = Yeşil, Pasif = Kırmızı
                series.Points[index].Color = (status.StatusId == 1) ? Color.Green : Color.Red;
            }

            // Y Ekseni ayarları
            chartStatusTimeline.ChartAreas[0].AxisY.Minimum = 0;
            chartStatusTimeline.ChartAreas[0].AxisY.Maximum = 1;
            chartStatusTimeline.ChartAreas[0].AxisY.Interval = 1;
            chartStatusTimeline.ChartAreas[0].AxisY.Title = "Durum (0 = Pasif, 1 = Aktif)";

            // X Ekseni ayarları
            chartStatusTimeline.ChartAreas[0].AxisX.Title = "Saat";
            chartStatusTimeline.ChartAreas[0].AxisX.Interval = 1;
            chartStatusTimeline.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }






        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeader_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
