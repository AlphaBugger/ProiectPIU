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
        public string Type { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Breed { get; set; }

        // Constructor
        public Animal(string name, int age, double weight, string breed)
        {
            Type = name;
            Age = age;
            Weight = weight;
            Breed = breed;
        }

        // Metoda pentru a afișa informații despre animal
        public void DisplayAnimalInfo()
        {
            Console.WriteLine($"Nume: {Type}");
            Console.WriteLine($"Vârstă: {Age} ani");
            Console.WriteLine($"Greutate: {Weight} kg");
            Console.WriteLine($"Rasă: {Breed}");
        }
    }

    // Clasa Field
    public class Field
    {
        public string Type { get; set; }
        public double Area { get; set; }
        public string SoilType { get; set; }

        // Constructor
        public Field(string type, double area, string soilType)
        {
            Type = type;
            Area = area;
            SoilType = soilType;
        }

        // Metoda pentru a afișa informații despre câmp
        public void DisplayFieldInfo()
        {
            Console.WriteLine($"Tip: {Type}");
            Console.WriteLine($"Suprafață: {Area} hectare");
            Console.WriteLine($"Tip sol: {SoilType}");
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
