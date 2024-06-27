using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SanelePoe
{
    /// <summary>
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private List<Ingredient> ingredients;
        private List<Step> steps;

        public AddRecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingredientWindow = new AddIngredientWindow();
            if (ingredientWindow.ShowDialog() == true)
            {
                var newIngredient = ingredientWindow.NewIngredient;
                ingredients.Add(newIngredient);
                IngredientsListBox.Items.Add(newIngredient.ToString());
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var stepWindow = new AddStepWindow();
            if (stepWindow.ShowDialog() == true)
            {
                var newStep = stepWindow.NewStep;
                steps.Add(new Step(newStep));
                StepsListBox.Items.Add(newStep);
            }
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (!string.IsNullOrEmpty(recipeName) && ingredients.Count > 0 && steps.Count > 0)
            {
                NewRecipe = new Recipe(recipeName);
                foreach (var ingredient in ingredients)
                {
                    NewRecipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
                }
                foreach (var step in steps)
                {
                    NewRecipe.AddStep(step.Description);
                }
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter all fields.");
            }
        }
    }
}