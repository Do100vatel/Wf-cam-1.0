using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;

namespace TimeTracker
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;
        private HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            httpClient = new HttpClient();
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnClear.Click += BtnClear_Click;
            btnSettings.Click += BtnSettings_Click;
            LoadCategories();
        }

        private async void LoadCategories()
        {
            try
            {
                var response = await httpClient.GetStringAsync("http://localhost:3000/categories");
                var categories = JsonSerializer.Deserialize<List<string>>(response);
                cmbCategory.Items.Clear();
                foreach (var category in categories)
                {
                    cmbCategory.Items.Add(category);
                }
                if (categories.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}");
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            TimerUpdate();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            SaveTimeEntry();
        }

        private async void SaveTimeEntry()
        {
            if(cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category before stopping the timer.");
                return;
            }
            var category = cmbCategory.SelectedItem.ToString();
            var timeSpent = stopwatch.Elapsed.TotalSeconds;
            var timeEntry = new { category, timeSpent };

            var content = new StringContent(JsonSerializer.Serialize(timeEntry), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:3000/saveTime", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Time entry saved successfully.");
            }
            else
            {
                MessageBox.Show("Failed to save time entry.");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            lblTimer.Text = "00:00:00";
            ClearTimeEntries();
        }

        private async void ClearTimeEntries()
        {
            try
            {
                var response = await httpClient.DeleteAsync("http://localhost:3000/clearTimeEntries");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Time entries cleard successfully");
                }
                else
                {
                    MessageBox.Show("Failed to clear time entries");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to clear time entries: {ex.Message}");
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
        }

        private async void TimerUpdate()
        {
            while (stopwatch.IsRunning)
            {
                lblTimer.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
                await Task.Delay(1000);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
