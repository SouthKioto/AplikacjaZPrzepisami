using AplikacjaZPrzepisami.Classes;
using System;
using System.Collections.Generic;
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
        public DetailPage(Recipe recipe)
        {
            InitializeComponent();
            Title = recipe.Title;
            imgrediends_label.Text = recipe.Ingredients;
            people_label.Text = recipe.Servings;
            instruction_label.Text = recipe.Instructions;
        }
    }
}