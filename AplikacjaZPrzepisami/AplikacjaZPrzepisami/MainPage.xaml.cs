using AplikacjaZPrzepisami.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplikacjaZPrzepisami
{
    public partial class MainPage : ContentPage
    {
        static HttpClient client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private async void LoadRecipes()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://api.api-ninjas.com/v1/recipe?query=soup";

                    client.DefaultRequestHeaders.Add("X-Api-Key", "Pq16rcwdSrz4LGV5HcaBtA==Y3C4aADP0H00T3sP");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(jsonContent);

                        displayRecipes.ItemsSource = recipes;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Unable to fetch recipes", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void CheckDetails(object sender, EventArgs e)
        {

        }
    }
}
