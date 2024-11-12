using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOdyssey
{
    internal class Planet
    {
        public String Name;
        public Planet? Parent;
        public Planet[] Children;
        public int Generation;

        public int FoodQuantity;
        public int WaterQuantity;
        public int FuelQuantity;
        public int UsuryQuantity;

        public Planet(Planet? parent = null, int generation = 0)
        {
            Random rng = new();
            Name = "";
            int name_length = rng.Next(Settings.MIN_SYLLABLES_PLANET_COUNT, Settings.MAX_SYLLABLES_PLANET_COUNT);
            for (int i = 0; i < name_length; i++)
            {
                Name += Settings.PLANET_SYLLABLES[rng.Next(Settings.PLANET_SYLLABLES.Length)];
            }

            Parent = parent;
            Generation = generation;
            if (Generation >= Settings.MAX_TREE_GENERATION)
            {
                Children = [];
            }
            else
            {
                int children_count = rng.Next(Settings.MIN_NODE_CHILDREN, Settings.MAX_NODE_CHILDREN);
                Children = new Planet[children_count];
                for (int i = 0; i < children_count; i++)
                {
                    Children[i] = new Planet(this, Generation + 1);
                }
            }

            double ResourceProbability = rng.NextDouble();
            if (ResourceProbability <= Settings.RESOURCE_PROBABILITY)
            {
                FoodQuantity = rng.Next(Settings.MIN_FOOD_QUANTITY, Settings.MAX_FOOD_QUANTITY);
                WaterQuantity = rng.Next(Settings.MIN_WATER_QUANTITY, Settings.MAX_WATER_QUANTITY);
                FuelQuantity = rng.Next(Settings.MIN_FUEL_QUANTITY, Settings.MAX_FUEL_QUANTITY);
                UsuryQuantity = rng.Next(Settings.MIN_USURY_QUANTITY, Settings.MAX_USURY_QUANTITY);
            }
            else
            {
                FoodQuantity = 0;
                WaterQuantity = 0;
                FuelQuantity = 0;
                UsuryQuantity = 0;
            }
        }

        public int Display(Screen screen, int x, int y, Planet current)
        {
            string data = $"{String.Concat(Enumerable.Repeat(" ", Generation))} ({Generation}) {Name}";
            if (Generation == 0)
            {
                data += " (Planète d'origine)";
            }
            if (current == this)
            {
                data += " (x)";
            }
            screen.AddElements(data, x, y);
            y++;
            foreach (Planet child in Children)
            {
                y = child.Display(screen, x, y, current);
            }
            return y;
        }
    }
}
