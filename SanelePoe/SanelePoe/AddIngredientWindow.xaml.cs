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
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        public Ingredient NewIngredient { get; private set; }

        public AddIngredientWindow()
        {
            InitializeComponent();
        }

        private void SaveIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text;
            double quantity;
            double.TryParse(QuantityTextBox.Text, out quantity);
            string unit = UnitTextBox.Text;
            int calories;
            int.TryParse(CaloriesTextBox.Text, out calories);
            string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(unit) && calories > 0 && !string.IsNullOrEmpty(foodGroup))
            {
                NewIngredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter all fields.");
            }
        }
    }
}