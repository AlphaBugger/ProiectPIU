//LABORATOR 3

using AnimalClass;
using FieldClass;
using FileSaver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionareFerma
{
    class GestionareFerma
    {


        static List<Animal> animals = new List<Animal>();
        static List<Field> fields = new List<Field>();
        static void Main(string[] args)
        {
            int option;

            string numeFisierAnimal = ConfigurationManager.AppSettings["FileNameAnimal"];
            string numeFisierField = ConfigurationManager.AppSettings["FileNameField"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(locatieFisierSolutie, "Data");
            string caleCompletaFisierAnimal = dataFolderPath + "\\" + numeFisierAnimal;
            string caleCompletaFisierField = dataFolderPath + "\\" + numeFisierField;

            DataFileManager dataManagerAnimal = new DataFileManager(caleCompletaFisierAnimal);
            DataFileManager dataManagerField = new DataFileManager(caleCompletaFisierField);

            Animal animalNou = new Animal();
            Field fieldNou = new Field();

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
                            animalNou = AddAnimal();
                            break;
                        case 2:
                            fieldNou = AddField();
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
                        case 8:
                            dataManagerAnimal.AddToFile(animalNou);
                            break;
                        case 9:
                            dataManagerField.AddToFile(fieldNou);
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

        static Animal AddAnimal()
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
            while (!int.TryParse(Console.ReadLine(), out inputType) || inputType < 1 || inputType > 6)
            {
                Console.WriteLine("Opțiune invalidă.");
            }

            FarmAnimalType type = (FarmAnimalType)(inputType - 1);

            Console.Write("Vârstă: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Vârstă invalidă.");
            }

            Console.Write("Greutate (kg): ");
            double weight;
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Greutate invalidă.");
            }

            // Meniu pentru alegerea rasei în funcție de tipul de animal
            string[] breedOptions;
            switch (type)
            {
                case FarmAnimalType.Cow:
                    Console.WriteLine("Selectați rasa pentru vacă:");
                    breedOptions = Enum.GetNames(typeof(CowBreed));
                    break;
                case FarmAnimalType.Horse:
                    Console.WriteLine("Selectați rasa pentru cal:");
                    breedOptions = Enum.GetNames(typeof(HorseBreed));
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
            while (!int.TryParse(Console.ReadLine(), out breedOption) || breedOption < 1 || breedOption > breedOptions.Length)
            {
                Console.WriteLine("Opțiune invalidă.");
            }

            // Obțineți rasa selectată din meniu
            string selectedBreed = breedOptions[breedOption - 1];

            Animal animal= new Animal(type, age, weight, selectedBreed);
            animals.Add(animal);

            Console.WriteLine("Animalul a fost adăugat cu succes.");
            return animal;
        }




        static Field AddField()
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
            while (!int.TryParse(Console.ReadLine(), out fieldTypeInput) || fieldTypeInput < 1 || fieldTypeInput > 5)
            {
                Console.WriteLine("Opțiune invalidă. Câmpul nu a fost adăugat.");
            }

            FieldType type = (FieldType)(fieldTypeInput - 1);

            Console.Write("Suprafață (hectare): ");
            double area;
            while (!double.TryParse(Console.ReadLine(), out area) || area <= 0)
            {
                Console.WriteLine("Suprafață invalidă. Câmpul nu a fost adăugat.");
            }

            Console.WriteLine("Selectați tipul de sol:");
            Console.WriteLine("1. Clay");
            Console.WriteLine("2. Sand");
            Console.WriteLine("3. Loam");
            Console.WriteLine("4. Silt");
            Console.WriteLine("5. Peat");
            Console.Write("Opțiune: ");

            int soilTypeInput;
            while (!int.TryParse(Console.ReadLine(), out soilTypeInput) || soilTypeInput < 1 || soilTypeInput > 5)
            {
                Console.WriteLine("Opțiune invalidă. Câmpul nu a fost adăugat.");
            }

            SoilType soil = (SoilType)(soilTypeInput - 1);

            Field field = new Field(type, area, soil, Actions.None);
            fields.Add(field);

            Console.WriteLine("Câmpul a fost adăugat cu succes.");
            return field;
        }



        static void DisplayAnimals()
        {
            Console.WriteLine("Afișare animale:");

            if (animals.Count == 0)
            {
                Console.WriteLine("Nu există animale de afișat.");
                return;
            }

            foreach (Animal animal in animals)
            {
                animal.DisplayAnimalInfo();
                Console.WriteLine();
            }
        }


        static void DisplayFields()
        {
            Console.WriteLine("Afișare câmpuri:");

            if (fields.Count == 0)
            {
                Console.WriteLine("Nu există câmpuri de afișat.");
                return;
            }

            foreach (Field field in fields)
            {
                field.DisplayFieldInfo();
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

            FarmAnimalType type = (FarmAnimalType)(searchType - 1);

            bool found = false;
            foreach (Animal animal in animals)
            {
                if (animal.Type == type)
                {
                    animal.DisplayAnimalInfo();
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

            FieldType type = (FieldType)(searchType - 1);

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
