using AplikacjaZPrzepisami.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplikacjaZPrzepisami.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LikedRecipes : ContentPage
    {
        public List<Recipe> LikedRecipeList = new List<Recipe>();

        public LikedRecipes()
        {
            InitializeComponent();
            LoadLikedRecipes();
        }

        public void LoadLikedRecipes()
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "likedRecipes.json");

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    try
                    {
                        LikedRecipeList = JsonConvert.DeserializeObject<List<Recipe>>(json);

                        likedRecipes_list.ItemsSource = LikedRecipeList;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deserializing JSON: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading likedRecipes.json: " + ex.Message);
            }
        }

        private void CheckDetails(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Recipe recipe = (Recipe)button.BindingContext;

            DetailPage details = new DetailPage(recipe);
            Navigation.PushAsync(details);
        }

        private void RemoveFromJson(object sender, EventArgs e)
        {
            DisplayAlert("Info", "Opcja w budowie", "OK");
        }
    }
}
