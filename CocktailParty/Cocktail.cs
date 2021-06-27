using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }
        // max number of ingredients
        public int MaxAlcoholLevel { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel 
        { 
            get
            {
                int alkoholSum = 0;
                foreach (var ingredient in Ingredients)
                {
                    alkoholSum += ingredient.Alcohol;
                }
                return alkoholSum;
            }


        }
        public void Add(Ingredient ingredient)
        {
            if(!Ingredients.Any(x =>x.Name == ingredient.Name && ingredient.Quantity <= Capacity && ingredient.Alcohol <= MaxAlcoholLevel))
            {
                Ingredients.Add(ingredient);
                Capacity -= ingredient.Quantity;
                MaxAlcoholLevel -= ingredient.Alcohol;
            }
        }
        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                Ingredient ingredientToBeRemoved = Ingredients.FirstOrDefault(x => x.Name == name);
                MaxAlcoholLevel += ingredientToBeRemoved.Alcohol;
                Capacity += ingredientToBeRemoved.Quantity;
                Ingredients.Remove(ingredientToBeRemoved);

                return true;
            }
            else
            {
                return false;
            }
        }
        public Ingredient FindIngredient(string name)
        {
            if(Ingredients.Any(x => x.Name == name))
            {
                return Ingredients.FirstOrDefault(x => x.Name == name);
            }
            else
            {
                return null;
            }
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder cocktailInfo = new StringBuilder();

            cocktailInfo.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                cocktailInfo.AppendLine(ingredient.ToString());
            }

            return cocktailInfo.ToString().TrimEnd();
        }



    }
} 