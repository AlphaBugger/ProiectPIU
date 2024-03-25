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

            Console.Write("Tip: ");
            string name = Console.ReadLine();

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

            Console.Write("Rasă: ");
            string breed = Console.ReadLine();

            animals[animalCount] = new Animal(name, age, weight, breed);
            animalCount++;

            Console.WriteLine("Animalul a fost adăugat cu succes.");
        }

        static void AddField()
        {
            Console.WriteLine("Adăugare câmp:");

            Console.Write("Tip: ");
            string type = Console.ReadLine();

            Console.Write("Suprafață (hectare): ");
            double area;
            if (!double.TryParse(Console.ReadLine(), out area))
            {
                Console.WriteLine("Suprafață invalidă. Câmpul nu a fost adăugat.");
                return;
            }

            Console.Write("Tip sol: ");
            string soilType = Console.ReadLine();

            fields[fieldCount] = new Field(type, area, soilType);
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

            Console.Write("Introduceți tipul de căutat: ");
            string searchType = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < animalCount; i++)
            {
                if (animals[i].Type.Equals(searchType, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Câmpul {i + 1}:");
                    animals[i].DisplayAnimalInfo();
                    found = true;
                    break;
                }


            }


        }
        static void SearchFieldByType()
        {

            Console.WriteLine("Căutare câmp după tip:");

            Console.Write("Introduceți tipul de căutat: ");
            string searchType = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < fieldCount; i++)
            {
                if (fields[i].Type.Equals(searchType, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Câmpul {i + 1}:");
                    fields[i].DisplayFieldInfo();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Nu s-a găsit niciun câmp cu tipul specificat.");
            }
        }
    }
} 
