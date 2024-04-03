//LABORATOR 3

using Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionareFerma
{
    class Program
    {
        static Animal[] animals = new Animal[10]; // Vector de obiecte Animal
        static int animalCount = 0;

        static Field[] fields = new Field[10]; // Vector de obiecte Field
        static int fieldCount = 0;
        static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("Meniu:");
                Console.WriteLine("1. Adăugare animal");
                Console.WriteLine("2. Adăugare câmp");
                Console.WriteLine("3. Afișare animale");
                Console.WriteLine("4. Afișare câmpuri");
                Console.WriteLine("5. Căutare animal după tip");
                Console.WriteLine("6. Căutare câmp după tip");
                Console.WriteLine("7. Ieșire");
                Console.Write("Alegeți opțiunea: ");
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            AddAnimal();
                            break;
                        case 2:
                            AddField();
                            break;
                        case 3:
                            DisplayAnimals();
                            break;
                        case 4:
                            DisplayFields();
                            break;
                        case 5:
                            SearchAnimalByType();
                            break;
                        case 6:
                            SearchFieldByType();
                            break;
                        case 7:
                            Console.WriteLine("La revedere!");
                            break;
                        default:
                            Console.WriteLine("Opțiune invalidă. Alegeți din nou.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opțiune invalidă. Alegeți din nou.");
                }

                Console.WriteLine();
            } while (option != 7);
        }

        static void AddAnimal()
        {
            Console.WriteLine("Adăugare animal:");

            Console.WriteLine("Selectați tipul de animal de fermă:");
            Console.WriteLine("1. Cow");
            Console.WriteLine("2. Horse");
            Console.WriteLine("3. Pig");
            Console.WriteLine("4. Chicken");
            Console.WriteLine("5. Sheep");
            Console.WriteLine("6. Goat");
            Console.Write("Opțiune: ");

            int inputType;
            if (!int.TryParse(Console.ReadLine(), out inputType) || inputType < 1 || inputType > 6)
            {
                Console.WriteLine("Opțiune invalidă. Animalul nu a fost adăugat.");
                return;
            }

            Animal.FarmAnimalType type = (Animal.FarmAnimalType)(inputType - 1);

            Console.Write("Vârstă: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Vârstă invalidă. Animalul nu a fost adăugat.");
                return;
            }

            Console.Write("Greutate (kg): ");
            double weight;
            if (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Greutate invalidă. Animalul nu a fost adăugat.");
                return;
            }

            // Meniu pentru alegerea rasei în funcție de tipul de animal
            string[] breedOptions;
            switch (type)
            {
                case Animal.FarmAnimalType.Cow:
                    Console.WriteLine("Selectați rasa pentru vacă:");
                    breedOptions = Enum.GetNames(typeof(Animal.CowBreed));
                    break;
                case Animal.FarmAnimalType.Horse:
                    Console.WriteLine("Selectați rasa pentru cal:");
                    breedOptions = Enum.GetNames(typeof(Animal.HorseBreed));
                    break;
                default:
                    Console.WriteLine("Introduceți rasa animalului:");
                    breedOptions = new string[] { "Other" };
                    break;
            }

            // Afișați opțiunile de rasă din meniu
            for (int i = 0; i < breedOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {breedOptions[i]}");
            }

            Console.Write("Opțiune: ");
            int breedOption;
            if (!int.TryParse(Console.ReadLine(), out breedOption) || breedOption < 1 || breedOption > breedOptions.Length)
            {
                Console.WriteLine("Opțiune invalidă. Animalul nu a fost adăugat.");
                return;
            }

            // Obțineți rasa selectată din meniu
            string selectedBreed = breedOptions[breedOption - 1];

            animals[animalCount] = new Animal(type, age, weight, selectedBreed);
            animalCount++;

            Console.WriteLine("Animalul a fost adăugat cu succes.");
        }




        static void AddField()
        {
            Console.WriteLine("Adăugare câmp:");

            Console.WriteLine("Selectați tipul de câmp:");
            Console.WriteLine("1. Wheat");
            Console.WriteLine("2. Corn");
            Console.WriteLine("3. Barley");
            Console.WriteLine("4. Soybean");
            Console.WriteLine("5. Oat");
            Console.Write("Opțiune: ");

            int fieldTypeInput;
            if (!int.TryParse(Console.ReadLine(), out fieldTypeInput) || fieldTypeInput < 1 || fieldTypeInput > 5)
            {
                Console.WriteLine("Opțiune invalidă. Câmpul nu a fost adăugat.");
                return;
            }

            Field.FieldType type = (Field.FieldType)(fieldTypeInput - 1);

            Console.Write("Suprafață (hectare): ");
            double area;
            if (!double.TryParse(Console.ReadLine(), out area) || area <= 0)
            {
                Console.WriteLine("Suprafață invalidă. Câmpul nu a fost adăugat.");
                return;
            }

            Console.WriteLine("Selectați tipul de sol:");
            Console.WriteLine("1. Clay");
            Console.WriteLine("2. Sand");
            Console.WriteLine("3. Loam");
            Console.WriteLine("4. Silt");
            Console.WriteLine("5. Peat");
            Console.Write("Opțiune: ");

            int soilTypeInput;
            if (!int.TryParse(Console.ReadLine(), out soilTypeInput) || soilTypeInput < 1 || soilTypeInput > 5)
            {
                Console.WriteLine("Opțiune invalidă. Câmpul nu a fost adăugat.");
                return;
            }

            Field.SoilType soil = (Field.SoilType)(soilTypeInput - 1);

            fields[fieldCount] = new Field(type, area, soil, Field.Actions.None);
            fieldCount++;

            Console.WriteLine("Câmpul a fost adăugat cu succes.");
        }



        static void DisplayAnimals()
        {
            Console.WriteLine("Afișare animale:");

            if (animalCount == 0)
            {
                Console.WriteLine("Nu există animale de afișat.");
                return;
            }

            for (int i = 0; i < animalCount; i++)
            {
                Console.WriteLine($"Animalul {i + 1}:");
                animals[i].DisplayAnimalInfo();
                Console.WriteLine();
            }
        }

        static void DisplayFields()
        {
            Console.WriteLine("Afișare câmpuri:");

            if (fieldCount == 0)
            {
                Console.WriteLine("Nu există câmpuri de afișat.");
                return;
            }

            for (int i = 0; i < fieldCount; i++)
            {
                Console.WriteLine($"Câmpul {i + 1}:");
                fields[i].DisplayFieldInfo();
                Console.WriteLine();
            }
        }

        static void SearchAnimalByType()
        {
            Console.WriteLine("Căutare câmp după tip:");

            Console.WriteLine("Introduceți tipul de căutat (1 - Cow, 2 - Horse, 3 - Pig, 4 - Chicken, 5 - Sheep, 6 - Goat): ");
            int searchType;
            if (!int.TryParse(Console.ReadLine(), out searchType) || searchType < 1 || searchType > 6)
            {
                Console.WriteLine("Opțiune invalidă.");
                return;
            }

            Animal.FarmAnimalType type = (Animal.FarmAnimalType)(searchType - 1);

            bool found = false;
            for (int i = 0; i < animalCount; i++)
            {
                if (animals[i].Type == type)
                {
                    Console.WriteLine($"Câmpul {i + 1}:");
                    animals[i].DisplayAnimalInfo();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Animalul nu a fost găsit.");
            }
        }

        static void SearchFieldByType()
        {
            Console.WriteLine("Căutare câmp după tip:");

            Console.WriteLine("Introduceți tipul de căutat (1 - Wheat, 2 - Corn, 3 - Barley, 4 - Soybean, 5 - Oat): ");
            int searchType;
            if (!int.TryParse(Console.ReadLine(), out searchType) || searchType < 1 || searchType > 5)
            {
                Console.WriteLine("Opțiune invalidă.");
                return;
            }

            Field.FieldType type = (Field.FieldType)(searchType - 1);

            bool found = false;
            foreach (Field field in fields)
            {
                if (field.Type == type)
                {
                    field.DisplayFieldInfo();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Câmpul nu a fost găsit.");
            }
        }
    }
}
