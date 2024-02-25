using AplikacjaZPrzepisami.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplikacjaZPrzepisami.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        protected string recipeTitle { get; set; }
        protected string recipeServings { get; set; }
        protected string recipeIngredients { get; set; }
        protected string recipeInstruction { get; set; }

        public DetailPage(Recipe recipe)
        {
            InitializeComponent();
            Title = recipeTitle = recipe.Title;
            imgrediends_label.Text = recipeIngredients = recipe.Ingredients;
            people_label.Text = recipeServings = recipe.Servings;
            instruction_label.Text = recipeInstruction = recipe.Instructions;
        }

        private void AddToLikedList(object sender, EventArgs e)
        {
            Recipe likedRecipe = new Recipe
            {
                Title = recipeTitle,
                Servings = recipeServings,
                Ingredients = recipeIngredients,
                Instructions = recipeInstruction
            };

            List<Recipe> likedRecipes = GetLikedRecipes();
            likedRecipes.Add(likedRecipe);
            SaveLikedRecipes(likedRecipes);

            DisplayAlert("Success", "Recipe added to Liked List", "OK");
        }

        private List<Recipe> GetLikedRecipes()
        {
            List<Recipe> likedRecipes = new List<Recipe>();

            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "likedRecipes.json");

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    likedRecipes = JsonConvert.DeserializeObject<List<Recipe>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading likedRecipes.json: " + ex.Message);
            }

            return likedRecipes;
        }

        private void SaveLikedRecipes(List<Recipe> likedRecipes)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "likedRecipes.json");

                string json = JsonConvert.SerializeObject(likedRecipes, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing likedRecipes.json: " + ex.Message);
            }
        }
    }
}