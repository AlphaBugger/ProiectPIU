using FileSaver;
using AnimalClass;
using FieldClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GestionareFermaGUI
{
    public partial class Form1 : Form
    {

        DataFileManager dataManagerAnimal;
        DataFileManager dataManagerField;
        


        //Animals
        private Label InformatiiAnimal;
        private Label TypeAnimal;
        private Label AgeAnimal;
        private Label WeightAnimal;
        private Label BreedAnimal;

        private Label[] lblsTypeAnimal;
        private Label[] lblsAgeAnimal;
        private Label[] lblsWeightAnimal;
        private Label[] lblsBreedAnimal;

        //Fields
        private Label InformatiiField;
        private Label TypeField;
        private Label AreaField;
        private Label SoilField;

        private Label[] lblsTypeField;
        private Label[] lblsAreaField;
        private Label[] lblsSoilField;

        //Buttons
        private Button btnSubmit;

        //Constants
        private const int LATIME_CONTROL = 100;
        
        private const int DIMENSIUNE_PAS_X = 120;
        
        private const int PADDING = 20;
        private const int LATIME_CONTROL_TITLE = (LATIME_CONTROL + PADDING) * 4 - PADDING;
        private const int LATIME_CONTROL_3 = (LATIME_CONTROL_TITLE) / 3 - PADDING*2/3;
        private const int WINDOW_TAB = 300; 
        private const int DIMENSIUNE_PAS_Y = 30+WINDOW_TAB+PADDING;





        public Form1()
        {
            Console.WriteLine(LATIME_CONTROL_TITLE.ToString());
            InitializeComponent();
            string numeFisierAnimal = ConfigurationManager.AppSettings["FileNameAnimal"];
            string numeFisierField = ConfigurationManager.AppSettings["FileNameField"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(locatieFisierSolutie, "Data");
            string caleCompletaFisierAnimal = dataFolderPath + "\\" + numeFisierAnimal;
            string caleCompletaFisierField = dataFolderPath + "\\" + numeFisierField;

            dataManagerAnimal = new DataFileManager(caleCompletaFisierAnimal);
            dataManagerField = new DataFileManager(caleCompletaFisierField);

            int nrAnimals = 0;
            int nrFields = 0;


            Animal[] animals = dataManagerAnimal.GetObjects<Animal>(out nrAnimals);
            Field[] fields = dataManagerField.GetObjects<Field>(out nrFields);

            this.Size = new Size(LATIME_CONTROL_TITLE * 2 - PADDING+WINDOW_TAB, 400);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Text = "Informatii ferma";


            //Animals Labels

            InformatiiAnimal = new Label()
            {
                Width = LATIME_CONTROL_TITLE,
                Text = "Informatii Animal",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_Y,
                Top = PADDING,
                BackColor = Color.Gray
            };


            TypeAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Tip",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_Y,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height + PADDING,
                BackColor = Color.Red
            };

            BreedAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Rasa",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = TypeAnimal.Left + TypeAnimal.Width + PADDING,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height + PADDING,
                BackColor = Color.Gray
            };

            AgeAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Varsta",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = BreedAnimal.Left + BreedAnimal.Width + PADDING,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height + PADDING,
                BackColor = Color.Gray
            };

            WeightAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Greutate",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = AgeAnimal.Left + AgeAnimal.Width + PADDING,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height + PADDING,
                BackColor = Color.Gray
            };





            //Field Labels
            InformatiiField = new Label()
            {
                Width = LATIME_CONTROL_TITLE,
                Text = "Informatii Field",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InformatiiAnimal.Left + InformatiiAnimal.Width + PADDING,
                Top = PADDING,
                BackColor = Color.Gray
            };


            TypeField = new Label()
            {
                Width = LATIME_CONTROL_3,
                Text = "Greutate",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InformatiiField.Left,
                Top = InformatiiField.Top + InformatiiField.Height + PADDING,
                BackColor = Color.Gray
            };

            AreaField = new Label()
            {
                Width = LATIME_CONTROL_3,
                Text = "Greutate",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = TypeField.Left + TypeField.Width + PADDING,
                Top = InformatiiField.Top + InformatiiField.Height + PADDING,
                BackColor = Color.Gray
            };

            SoilField = new Label()
            {
                Width = LATIME_CONTROL_3,
                Text = "Greutate",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = AreaField.Left + AreaField.Width + PADDING,
                Top = InformatiiField.Top + InformatiiField.Height + PADDING,
                BackColor = Color.Gray
            };




            this.Controls.Add(InformatiiAnimal);
            this.Controls.Add(InformatiiField);
            this.Controls.Add(TypeAnimal);
            this.Controls.Add(BreedAnimal);
            this.Controls.Add(AgeAnimal);
            this.Controls.Add(WeightAnimal);
            this.Controls.Add(TypeField);
            this.Controls.Add(AreaField);
            this.Controls.Add(SoilField);


        }

        private void LoadForm(object sender, EventArgs e)
        {
            AfiseazaInformatii();
        }

        private void AfiseazaInformatii()
        {
            Animal[] animals =  dataManagerAnimal.GetObjects<Animal>(out int nrAnimals);
            Field[] fields = dataManagerField.GetObjects<Field>(out int nrFields);

            lblsTypeAnimal = new Label[nrAnimals];
            lblsBreedAnimal = new Label[nrAnimals];
            lblsAgeAnimal = new Label[nrAnimals];
            lblsWeightAnimal = new Label[nrAnimals];

            lblsTypeField = new Label[nrFields];
            lblsAreaField = new Label[nrFields];
            lblsSoilField = new Label[nrFields];

            int i = 0;
            foreach (Animal animal in animals) {
                lblsTypeAnimal[i] = new Label()
                {
                    Width = LATIME_CONTROL,
                    Text = Enum.GetName(typeof(FarmAnimalType), animal.Type),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = DIMENSIUNE_PAS_Y,
                    Top = (TypeAnimal.Top+TypeAnimal.Height)+PADDING*(i+1) 
                };
                lblsBreedAnimal[i] = new Label()
                {
                    Width = LATIME_CONTROL,
                    Text = animal.Breed.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = lblsTypeAnimal[i].Left + lblsTypeAnimal[i].Width + PADDING,
                    Top = (TypeAnimal.Top + TypeAnimal.Height) + PADDING * (i + 1)
                    
                };
                lblsAgeAnimal[i] = new Label()
                {
                    Width = LATIME_CONTROL,
                    Text = animal.Age.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = lblsBreedAnimal[i].Left + lblsBreedAnimal[i].Width + PADDING,
                    Top = (TypeAnimal.Top + TypeAnimal.Height) + PADDING * (i + 1)
                    
                };
                lblsWeightAnimal[i] = new Label()
                {
                    Width = LATIME_CONTROL,
                    Text = animal.Weight.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = lblsAgeAnimal[i].Left + lblsAgeAnimal[i].Width + PADDING,
                    Top = (TypeAnimal.Top + TypeAnimal.Height) + PADDING * (i + 1),
                    BackColor = Color.Red

                };
                this.Controls.Add(lblsTypeAnimal[i]);
                this.Controls.Add(lblsBreedAnimal[i]);
                this.Controls.Add(lblsAgeAnimal[i]);
                this.Controls.Add(lblsWeightAnimal[i]);
                i++;    
            }
            i = 0;
            foreach(Field field in fields)
            {
                lblsTypeField[i] = new Label()
                {
                    Width = LATIME_CONTROL_3,
                    Text = field.Type.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = TypeField.Left,
                    Top = (TypeField.Top + TypeField.Height) + PADDING * (i + 1),
                    BackColor = Color.Red
                };
                lblsAreaField[i] = new Label()
                {
                    Width = LATIME_CONTROL_3,
                    Text = field.Area.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = lblsTypeField[i].Left + lblsTypeField[i].Width + PADDING,
                    Top = (TypeField.Top + TypeField.Height) + PADDING * (i + 1)

                };
                lblsSoilField[i] = new Label()
                {
                    Width = LATIME_CONTROL_3,
                    Text = field.Soil.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = lblsAreaField[i].Left + lblsAreaField[i].Width + PADDING,
                    Top = (TypeField.Top + TypeField.Height) + PADDING * (i + 1)

                };
                this.Controls.Add(lblsTypeField[i]);
                this.Controls.Add(lblsAreaField[i]);
                this.Controls.Add(lblsSoilField[i]);
                i++;
            }
        }
    }
}
