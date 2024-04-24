using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClass
{
    public class Animal : FileHandling
    {
        private int FileTYPE = 0;
        private int FileAGE = 2;
        private int FileWEIGHT = 3;
        private int FileBREED = 1;


        // Definiți și celelalte rase pentru tipurile de animale lipsă (Chicken, Sheep, Goat, etc.)

        public FarmAnimalType Type { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        // Rasa va fi determinată în funcție de tipul animalului
        public object Breed { get; set; }

        // Constructor

        public Animal()
        {
            Type = FarmAnimalType.Other;
            Age = 0;
            Weight = 0;
            Breed = string.Empty;
        }
        public Animal(FarmAnimalType type, int age, double weight, object breed)
        {
            Type = type;
            Age = age;
            Weight = weight;
            Breed = breed;

        }

        public Animal(string lineFromFile)
        {
            string[] fileData = lineFromFile.Split('$');


            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.Type = (FarmAnimalType)Enum.Parse(typeof(FarmAnimalType), fileData[FileTYPE]);
            this.Age = Convert.ToInt32(fileData[FileAGE]);
            this.Weight = Convert.ToDouble(fileData[FileWEIGHT]);
            this.Breed = fileData[FileBREED];

        }
        public void DisplayAnimalInfo()
        {
            Console.WriteLine($"Tip: {Type}");
            Console.WriteLine($"Vârstă: {Age} ani");
            Console.WriteLine($"Greutate: {Weight} kg");
            Console.WriteLine($"Rasă: {Breed}");
        }

        public string ConvertToFileString()
        {
            string stringFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                "$",
                (Type.ToString() ?? "NECUNOSCUT"),
                (Breed ?? " NECUNOSCUT "),
                (Age.ToString() ?? " NECUNOSCUT "),
                (Weight.ToString() ?? " NECUNOSCUT ")
                );

            return stringFisier;
        }

    }
}