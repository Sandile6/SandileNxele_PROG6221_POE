using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanelePoe
{
    public class Recipe 
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Step> Steps { get; private set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            var ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            Ingredients.Add(ingredient);
        }

        public void AddStep(string description)
        {
            Steps.Add(new Step(description));
        }

        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}