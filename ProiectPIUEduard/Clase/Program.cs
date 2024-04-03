//LABORATOR 2 (creeare clase Animal, field si inventory)
//LABORATOR 3 (proprietati auto-implemented clasa Animal)
//LABORATOR 4 (-//- clasa Field)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase
{
    public class Animal
    {
        public enum FarmAnimalType
        {
            Cow,
            Horse,
            Pig,
            Chicken,
            Sheep,
            Goat,
            Other
        }

        public enum CowBreed
        {
            Holstein,
            Jersey,
            Angus,
            Hereford,
            Other
        }

        public enum HorseBreed
        {
            Thoroughbred,
            QuarterHorse,
            Arabian,
            Appaloosa,
            Other
        }

        public enum PigBreed
        {
            Berkshire,
            Duroc,
            Yorkshire,
            Hampshire,
            Other
        }

        // Definiți și celelalte rase pentru tipurile de animale lipsă (Chicken, Sheep, Goat, etc.)

        public FarmAnimalType Type { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        // Rasa va fi determinată în funcție de tipul animalului
        public object Breed { get; set; }

        // Constructor
        public Animal(FarmAnimalType type, int age, double weight, object breed)
        {
            Type = type;
            Age = age;
            Weight = weight;
            Breed = breed;

        }
        public void DisplayAnimalInfo()
        {
            Console.WriteLine($"Tip: {Type}");
            Console.WriteLine($"Vârstă: {Age} ani");
            Console.WriteLine($"Greutate: {Weight} kg");
            Console.WriteLine($"Rasă: {Breed}");
        }

    }
    // Clasa Field

    public class Field
    {
        public enum FieldType
        {
            Wheat,
            Corn,
            Barley,
            Soybean,
            Oat
        }

        public enum SoilType
        {
            Clay,
            Sand,
            Loam,
            Silt,
            Peat
        }

        [Flags]
        public enum Actions
        {
            None = 0,
            Watering = 1 << 0,
            PesticideApplication = 1 << 1,
            Fertilization = 1 << 2,
            Plowing = 1 << 3,
            Harvesting = 1 << 4
        }

        public FieldType Type { get; set; }
        public double Area { get; set; }
        public SoilType Soil { get; set; }
        public Actions FieldActions { get; set; }

        public Field(FieldType type, double area, SoilType soil, Actions actions)
        {
            Type = type;
            Area = area;
            Soil = soil;
            FieldActions = actions;
        }

        public void DisplayFieldInfo()
        {
            Console.WriteLine($"Crop Type: {Type}");
            Console.WriteLine($"Area: {Area} hectares");
            Console.WriteLine($"Soil Type: {Soil}");
            Console.WriteLine($"Actions: {FieldActions}");
        }
    }



    // Clasa Inventory
    public class Inventory
        {
            private Dictionary<string, int> items = new Dictionary<string, int>();

            // Metodă pentru adăugarea unui element în inventar
            public void AddItem(string itemName, int quantity)
            {
                if (items.ContainsKey(itemName))
                    items[itemName] += quantity;
                else
                    items[itemName] = quantity;
            }

            // Metodă pentru a afișa inventarul
            public void DisplayInventory()
            {
                Console.WriteLine("Inventar:");
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
