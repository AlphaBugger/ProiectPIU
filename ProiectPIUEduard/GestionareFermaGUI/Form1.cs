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
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;
using System.Text.RegularExpressions;

namespace GestionareFermaGUI
{
    public partial class Form1 : Form
    {

        DataFileManager dataManagerAnimal;
        DataFileManager dataManagerField;

        static List<Animal> animals = new List<Animal>();
        static List<Field> fields = new List<Field>();



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

        private Label inputTypeAnimal;
        private Label inputAgeAnimal;
        private Label inputWeightAnimal;
        private Label inputBreedAnimal;

        private Label errorInputTypeAnimal;
        private Label errorInputAgeAnimal;
        private Label errorInputWeightAnimal;
        private Label errorInputBreedAnimal;

        private ComboBox txtTypeAnimal;
        private TextBox txtAgeAnimal;
        private TextBox txtWeightAnimal;
        private TextBox txtBreedAnimal;


        //Fields
        private Label InformatiiField;
        private Label TypeField;
        private Label AreaField;
        private Label SoilField;

        private Label[] lblsTypeField;
        private Label[] lblsAreaField;
        private Label[] lblsSoilField;

        private Label inputTypeField;
        private Label inputAreaField;
        private Label inputSoilField;

        private Label errorInputTypeField;
        private Label errorInputAreaField;
        private Label errorInputSoilField;



        private ComboBox txtTypeField;
        private TextBox txtAreaField;
        private ComboBox txtSoilField;

        //Buttons
        private Button btnSubmitAnimal;
        private Button btnSubmitField;

        //Constants
        private const int LATIME_CONTROL = 100;

        private const int DIMENSIUNE_PAS_X = 120;

        private const int PADDING = 20;
        private const int LATIME_CONTROL_TITLE = (LATIME_CONTROL + PADDING) * 4 - PADDING;
        private const int LATIME_CONTROL_3 = (LATIME_CONTROL_TITLE) / 3 - (PADDING * 2) / 3;
        private const int WINDOW_TAB = 300;
        private const int DIMENSIUNE_PAS_WINDOW2 = 30 + WINDOW_TAB + PADDING;
        private const int DIMENSIUNE_PAS_WINDOW = 30;






        public Form1()
        {
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

            this.Size = new Size(LATIME_CONTROL_TITLE * 2 - PADDING + WINDOW_TAB, 400);
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
                Left = DIMENSIUNE_PAS_WINDOW2,
                Top = PADDING,
                BackColor = Color.Gray
            };


            TypeAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Tip",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW2,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height,
                BackColor = Color.Gray
            };

            BreedAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Rasa",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = TypeAnimal.Left + TypeAnimal.Width + PADDING,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height,
                BackColor = Color.Gray
            };

            AgeAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Varsta",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = BreedAnimal.Left + BreedAnimal.Width + PADDING,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height,
                BackColor = Color.Gray
            };

            WeightAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Greutate",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = AgeAnimal.Left + AgeAnimal.Width + PADDING,
                Top = InformatiiAnimal.Top + InformatiiAnimal.Height,
                BackColor = Color.Gray
            };

            inputTypeAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Tip Animal",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = PADDING,
            };

            inputBreedAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Rasa Animal",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = inputTypeAnimal.Top + inputTypeAnimal.Height + PADDING,
            };

            inputAgeAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Varsta Animal",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = inputBreedAnimal.Top + PADDING + inputTypeAnimal.Height,
            };

            inputWeightAnimal = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Greutate Animal",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = inputAgeAnimal.Top + PADDING + inputTypeAnimal.Height,
            };



            txtTypeAnimal = new ComboBox() {
                Width = LATIME_CONTROL,
                Left = inputTypeAnimal.Left + inputTypeAnimal.Width + PADDING,
                Top = inputTypeAnimal.Top
            };
            txtTypeAnimal.Items.Add("Alegeti...");
            foreach (Enum value in Enum.GetValues(typeof(FarmAnimalType)))
            {
                txtTypeAnimal.Items.Add(value);
            }
            txtTypeAnimal.SelectedIndex = 0;

            //txtBreedAnimal = new ComboBox()
            //{
            //    Width = LATIME_CONTROL,
            //    Left = inputBreedAnimal.Left + inputBreedAnimal.Width + PADDING,
            //    Top = inputBreedAnimal.Top
            //};
            //txtBreedAnimal.Items.Add("Alegeti...");
            //this.Refresh();
            //Console.WriteLine(txtTypeAnimal.Text);
            //switch (txtTypeAnimal.Text)
            //{
            //    case "Cow":
            //        foreach (Enum value in Enum.GetValues(typeof(CowBreed)))
            //        {
            //            txtBreedAnimal.Items.Add(value);
            //        }
            //        break;
            //    case "Horse":
            //        foreach (Enum value in Enum.GetValues(typeof(HorseBreed)))
            //        {
            //            txtBreedAnimal.Items.Add(value);
            //        }
            //        break;
            //    case "Pig":
            //        foreach (Enum value in Enum.GetValues(typeof(PigBreed)))
            //        {
            //            txtBreedAnimal.Items.Add(value);
            //        }
            //        break;
            //    default:
            //        txtBreedAnimal.Items.Add("Other");
            //        break;
            //}



            //txtBreedAnimal.SelectedIndex = 0;
            txtBreedAnimal = new TextBox()
            {
                Width = LATIME_CONTROL,
                Left = inputBreedAnimal.Left + inputBreedAnimal.Width + PADDING,
                Top = inputBreedAnimal.Top
            };

            txtAgeAnimal = new TextBox()
            {
                Width = LATIME_CONTROL,
                Left = inputAgeAnimal.Left + inputAgeAnimal.Width + PADDING,
                Top = inputAgeAnimal.Top
            };
            txtWeightAnimal = new TextBox()
            {
                Width = LATIME_CONTROL,
                Left = inputWeightAnimal.Left + inputWeightAnimal.Width + PADDING,
                Top = inputWeightAnimal.Top
            };


            //Field Labels
            InformatiiField = new Label()
            {
                Width = LATIME_CONTROL_3 * 3 + PADDING * 2,
                Text = "Informatii Field",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InformatiiAnimal.Left + InformatiiAnimal.Width + PADDING,
                Top = PADDING,
                BackColor = Color.Gray
            };


            TypeField = new Label()
            {
                Width = LATIME_CONTROL_3,
                Text = "Tip",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InformatiiField.Left,
                Top = InformatiiField.Top + InformatiiField.Height,
                BackColor = Color.Gray
            };

            AreaField = new Label()
            {
                Width = LATIME_CONTROL_3,
                Text = "Arie",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = TypeField.Left + TypeField.Width + PADDING,
                Top = InformatiiField.Top + InformatiiField.Height,
                BackColor = Color.Gray
            };

            SoilField = new Label()
            {
                Width = LATIME_CONTROL_3,
                Text = "Tip Sol",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = AreaField.Left + AreaField.Width + PADDING,
                Top = InformatiiField.Top + InformatiiField.Height,
                BackColor = Color.Gray
            };

            btnSubmitAnimal = new Button()
            {
                Text = "Adauga Animal",
                Top = txtWeightAnimal.Top + txtWeightAnimal.Height + PADDING,
                Width = txtWeightAnimal.Width + PADDING + inputWeightAnimal.Width,
                Left = inputWeightAnimal.Left,
            };

            inputTypeField = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Tip Camp",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = btnSubmitAnimal.Top + btnSubmitAnimal.Height + PADDING,
            };

            inputAreaField = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Arie Camp",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = inputTypeField.Top + inputTypeField.Height + PADDING,
            };

            inputSoilField = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Tip Camp",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = inputAreaField.Top + PADDING + inputAreaField.Height,
            };


            txtTypeField = new ComboBox()
            {
                Width = LATIME_CONTROL,
                Left = inputTypeField.Left + inputTypeField.Width + PADDING,
                Top = inputTypeField.Top
            };
            txtTypeField.Items.Add("Alegeti...");
            foreach (Enum value in Enum.GetValues(typeof(FieldType)))
            {
                txtTypeField.Items.Add(value);
            }
            txtTypeField.SelectedIndex = 0;

            txtAreaField = new TextBox()
            {
                Width = LATIME_CONTROL,
                Left = inputAreaField.Left + inputAreaField.Width + PADDING,
                Top = inputAreaField.Top
            };

            txtSoilField = new ComboBox()
            {
                Width = LATIME_CONTROL,
                Left = inputSoilField.Left + inputSoilField.Width + PADDING,
                Top = inputSoilField.Top
            };
            txtSoilField.Items.Add("Alegeti...");
            foreach (Enum value in Enum.GetValues(typeof(SoilType)))
            {
                txtSoilField.Items.Add(value);
            }
            txtSoilField.SelectedIndex = 0;




            btnSubmitField = new Button()
            {
                Text = "Adauga Camp",
                Top = inputSoilField.Top + inputSoilField.Height + PADDING,
                Width = txtSoilField.Width + PADDING + inputSoilField.Width,
                Left = inputSoilField.Left,
            };

            btnSubmitAnimal.Click += AdaugaAnimal;
            btnSubmitAnimal.Click += LoadForm;

            btnSubmitField.Click += AdaugaCamp;
            btnSubmitField.Click += LoadForm;


            errorInputTypeAnimal = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtTypeAnimal.Left + txtTypeAnimal.Width,
                Top = txtTypeAnimal.Top,
                ForeColor = Color.Red
            };
            errorInputBreedAnimal = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtBreedAnimal.Left + txtBreedAnimal.Width,
                Top = txtBreedAnimal.Top,
                ForeColor = Color.Red
            };
            errorInputAgeAnimal = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtAgeAnimal.Left + txtAgeAnimal.Width,
                Top = txtAgeAnimal.Top,
                ForeColor = Color.Red
            };
            errorInputWeightAnimal = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtWeightAnimal.Left + txtWeightAnimal.Width,
                Top = txtWeightAnimal.Top,
                ForeColor = Color.Red
            };
            errorInputTypeField = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtTypeField.Left + txtTypeField.Width,
                Top = txtTypeField.Top,
                ForeColor = Color.Red
            };
            errorInputAreaField = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtAreaField.Left + txtAreaField.Width,
                Top = txtAreaField.Top,
                ForeColor = Color.Red
            };
            errorInputSoilField = new Label()
            {
                Text = "Eroare",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = txtSoilField.Left + txtSoilField.Width,
                Top = txtSoilField.Top,
                ForeColor = Color.Red
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
            this.Controls.Add(inputTypeAnimal);
            this.Controls.Add(inputBreedAnimal);
            this.Controls.Add(inputAgeAnimal);
            this.Controls.Add(inputWeightAnimal);
            this.Controls.Add(txtTypeAnimal);
            this.Controls.Add(txtBreedAnimal);
            this.Controls.Add(txtAgeAnimal);
            this.Controls.Add(txtWeightAnimal);
            this.Controls.Add(inputTypeField);
            this.Controls.Add(inputAreaField);
            this.Controls.Add(inputSoilField);
            this.Controls.Add(txtTypeField);
            this.Controls.Add(txtAreaField);
            this.Controls.Add(txtSoilField);

            

            this.Controls.Add(btnSubmitAnimal);
            this.Controls.Add(btnSubmitField);


        }

        private void LoadForm(object sender, EventArgs e)
        {
            AfiseazaInformatii();
        }

        private void AdaugaAnimal(object sender, EventArgs e)
        {
            if (validareAnimal())
            {
                Animal animalNou = new Animal((FarmAnimalType)Enum.Parse(typeof(FarmAnimalType), txtTypeAnimal.Text), Convert.ToInt32(txtAgeAnimal.Text), Convert.ToDouble(txtWeightAnimal.Text), txtBreedAnimal.Text);
                dataManagerAnimal.AddToFile(animalNou);
            }
            else
            {

            }

        }

        private void AdaugaCamp(object sender, EventArgs e)
        {
            if (validareCamp())
            {
                Field fieldNou = new Field((FieldType)Enum.Parse(typeof(FieldType), txtTypeField.Text), Convert.ToInt32(txtAreaField.Text), (SoilType)Enum.Parse(typeof(SoilType), txtSoilField.Text), Actions.None);
                dataManagerField.AddToFile(fieldNou);
            }


        }

        private bool validareAnimal()
        {
            int err = 0;
            bool isOnlyNuberAge = Regex.IsMatch(txtAgeAnimal.Text, @"^\d+$");
            bool isOnlyNuberWeigth = Regex.IsMatch(txtWeightAnimal.Text, @"^\d+$");

            if (txtTypeAnimal.SelectedIndex == 0)
            {
                err++;
                this.Controls.Add(errorInputTypeAnimal);
            }
            else
            {
                this.Controls.Remove(errorInputTypeAnimal);
            }

            if (!isOnlyNuberAge)
            {
                err++;
                this.Controls.Add(errorInputAgeAnimal);
            }
            else
            {
                this.Controls.Remove(errorInputAgeAnimal);
            }

            if (!isOnlyNuberWeigth)
            {
                err++;
                this.Controls.Add(errorInputWeightAnimal);
            }
            else
            {
                this.Controls.Remove(errorInputWeightAnimal);
            }

            if (txtBreedAnimal.Text.Length < 3 || string.IsNullOrEmpty(txtBreedAnimal.Text))
            {
                err++;
                this.Controls.Add(errorInputBreedAnimal);
            }
            else
            {
                this.Controls.Remove(errorInputBreedAnimal);
            }
            if (err > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            

        }

        private bool validareCamp()
        {
            int err = 0;
            bool isOnlyNuberArea = Regex.IsMatch(txtAreaField.Text, @"^\d+$");

            if (txtTypeField.SelectedIndex == 0)
            {
                err++;
                this.Controls.Add(errorInputTypeField);
            }
            else
            {
                this.Controls.Remove(errorInputTypeField);
            }

            if (!isOnlyNuberArea)
            {
                err++;
                this.Controls.Add(errorInputAreaField);
            }
            else
            {
                this.Controls.Remove(errorInputAreaField);
            }

            if (txtSoilField.SelectedIndex == 0)
            {
                err++;
                this.Controls.Add(errorInputSoilField);
            }
            else
            {
                this.Controls.Remove(errorInputSoilField);
            }
            if (err > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    Left = DIMENSIUNE_PAS_WINDOW2,
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
