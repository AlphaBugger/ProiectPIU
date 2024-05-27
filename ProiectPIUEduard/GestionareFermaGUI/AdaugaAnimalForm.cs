using AnimalClass;
using FieldClass;
using FileSaver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace GestionareFermaGUI
{
    public partial class AdaugaAnimalForm : Form
    {


        DataFileManager dataManagerAnimal;





        //Animals
        

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
        private ComboBox txtBreedAnimal;


       

        //Buttons
        private Button btnSubmitAnimal;

        //Constants
        private const int LATIME_CONTROL = 100;

        private const int DIMENSIUNE_PAS_X = 120;

        private const int PADDING = 20;
        private const int LATIME_CONTROL_TITLE = (LATIME_CONTROL + PADDING) * 4 - PADDING;
        private const int LATIME_CONTROL_3 = (LATIME_CONTROL_TITLE) / 3 - (PADDING * 2) / 3;
        private const int WINDOW_TAB = 300;
        private const int DIMENSIUNE_PAS_WINDOW2 = 30 + WINDOW_TAB + PADDING;
        private const int DIMENSIUNE_PAS_WINDOW = 30;






        public AdaugaAnimalForm()
        {
            InitializeComponent();

            string numeFisierAnimal = ConfigurationManager.AppSettings["FileNameAnimal"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(locatieFisierSolutie, "Data");
            string caleCompletaFisierAnimal = dataFolderPath + "\\" + numeFisierAnimal;
            dataManagerAnimal = new DataFileManager(caleCompletaFisierAnimal);

            this.Width = 500;


            //Animals Labels



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

            txtBreedAnimal = new ComboBox()
            {
                Width = LATIME_CONTROL,
                Left = inputBreedAnimal.Left + inputBreedAnimal.Width + PADDING,
                Top = inputBreedAnimal.Top
            };
            txtTypeAnimal.TextChanged += ChooseBreeds;

            Console.WriteLine(txtTypeAnimal.Text);
            

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
            

            btnSubmitAnimal = new Button()
            {
                Text = "Adauga Animal",
                Top = txtWeightAnimal.Top + txtWeightAnimal.Height + PADDING,
                Width = txtWeightAnimal.Width + PADDING + inputWeightAnimal.Width,
                Left = inputWeightAnimal.Left,
            };

            

            btnSubmitAnimal.Click += AdaugaAnimal;
            btnSubmitAnimal.Click += LoadForm;

            


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
            

            this.Controls.Add(inputTypeAnimal);
            this.Controls.Add(inputBreedAnimal);
            this.Controls.Add(inputAgeAnimal);
            this.Controls.Add(inputWeightAnimal);
            this.Controls.Add(txtTypeAnimal);
            this.Controls.Add(txtBreedAnimal);
            this.Controls.Add(txtAgeAnimal);
            this.Controls.Add(txtWeightAnimal);

            this.Controls.Add(btnSubmitAnimal);



        }

        private void LoadForm(object sender, EventArgs e)
        {

        }

        private void ChooseBreeds(object sender, EventArgs e)
        {
            txtBreedAnimal.Items.Clear();
            txtBreedAnimal.Text = "";
            switch (txtTypeAnimal.Text)
            {
                case "Cow":
                    foreach (Enum value in Enum.GetValues(typeof(CowBreed)))
                    {
                        txtBreedAnimal.Items.Add(value);
                    }
                    break;
                case "Horse":
                    foreach (Enum value in Enum.GetValues(typeof(HorseBreed)))
                    {
                        txtBreedAnimal.Items.Add(value);
                    }
                    break;
                case "Pig":
                    foreach (Enum value in Enum.GetValues(typeof(PigBreed)))
                    {
                        txtBreedAnimal.Items.Add(value);
                    }
                    break;
                default:
                    txtBreedAnimal.Items.Add("other");
                    break;
            }
        }

        private void AdaugaAnimal(object sender, EventArgs e)
        {
            if (validareAnimal())
            {
                Animal animalNou = new Animal((FarmAnimalType)Enum.Parse(typeof(FarmAnimalType), txtTypeAnimal.Text), Convert.ToInt32(txtAgeAnimal.Text), Convert.ToDouble(txtWeightAnimal.Text), txtBreedAnimal.Text);
                dataManagerAnimal.AddToFile(animalNou);
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is TextBox)
                    {
                        (ctrl as TextBox).Text = string.Empty; // Reset TextBox
                    }
                    else if (ctrl is ComboBox)
                    {
                        (ctrl as ComboBox).SelectedIndex = -1; // Reset ComboBox selection
                    }
                }
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

        
    }
}
