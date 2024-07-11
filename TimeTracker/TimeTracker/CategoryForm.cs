using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker
{
    public partial class CategoryForm : Form
    {
        private HttpClient httpClient;

        public CategoryForm()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            LoadCategories();
            btnAddCategory.Click += BtnAddCategory_Click;
            btnRemoveCategory.Click += BtnRemoveCategory_Click;
        }

        private async void LoadCategories()
        {
            try
            {
                var response = await httpClient.GetStringAsync("http://localhost:3000/categories");
                var categories = JsonSerializer.Deserialize<List<string>>(response);
                lstCategories.Items.Clear();
                foreach (var category in categories)
                {
                    lstCategories.Items.Add(category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}");
            }
        }

        private async void BtnAddCategory_Click(object sender, EventArgs e)
        {
            var newCategory = txtNewCategory.Text;
            if (string.IsNullOrWhiteSpace(newCategory))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            var category = new { name = newCategory };
            var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:3000/addCategory", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Category added successfully!");
                LoadCategories();
                txtNewCategory.Clear();
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Failed to add category. {responseContent}");
            }
        }

        private async void BtnRemoveCategory_Click(object sender, EventArgs e)
        {
            if(lstCategories.SelectedItem == null)
            {
                MessageBox.Show("Please select a category to remove.");
                return;
            }

            var category = new { name = lstCategories.SelectedItem.ToString() };
            var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:3000/removeCategory"),
                Content = content
            };

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Category removed successfully!");
                LoadCategories();
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Failed to remove category. {responseContent}");
            }
        }
        
        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
