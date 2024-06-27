using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SanelePoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window or dialog to enter a new recipe.
            var addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                var newRecipe = addRecipeWindow.NewRecipe;
                recipes.Add(newRecipe);
                UpdateRecipeList();
            }
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredientFilter = IngredientFilterTextBox.Text;
            string foodGroupFilter = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string maxCaloriesText = MaxCaloriesTextBox.Text;

            int maxCalories = string.IsNullOrEmpty(maxCaloriesText) ? int.MaxValue : int.Parse(maxCaloriesText);

            var filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(ingredientFilter) || r.Ingredients.Any(i => i.Name.Contains(ingredientFilter, StringComparison.OrdinalIgnoreCase))) &&
                (foodGroupFilter == "Any" || r.Ingredients.Any(i => i.FoodGroup.Equals(foodGroupFilter, StringComparison.OrdinalIgnoreCase))) &&
                r.CalculateTotalCalories() <= maxCalories
            ).ToList();

            RecipesListBox.ItemsSource = filteredRecipes.Select(r => r.Name).ToList();
        }

        private void UpdateRecipeList()
        {
            RecipesListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }
    }
}