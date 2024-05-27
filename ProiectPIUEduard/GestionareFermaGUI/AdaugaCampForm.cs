using FieldClass;
using FileSaver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionareFermaGUI
{
    public partial class AdaugaCampForm : Form
    {

        DataFileManager dataManagerField;

        //Fields


        private Label inputTypeField;
        private Label inputAreaField;
        private Label inputSoilField;

        private Label errorInputTypeField;
        private Label errorInputAreaField;
        private Label errorInputSoilField;



        private ComboBox txtTypeField;
        private TextBox txtAreaField;
        private ComboBox txtSoilField;

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

        public AdaugaCampForm()
        {
            InitializeComponent();

            string numeFisierField = ConfigurationManager.AppSettings["FileNameField"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(locatieFisierSolutie, "Data");

            string caleCompletaFisierField = dataFolderPath + "\\" + numeFisierField;


            dataManagerField = new DataFileManager(caleCompletaFisierField);

            this.Width = 500;

            inputTypeField = new Label()
            {
                Width = LATIME_CONTROL,
                Text = "Tip Camp",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = DIMENSIUNE_PAS_WINDOW,
                Top = PADDING,
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

            btnSubmitField.Click += AdaugaCamp;
            btnSubmitField.Click += LoadForm;

            this.Controls.Add(inputTypeField);
            this.Controls.Add(inputAreaField);
            this.Controls.Add(inputSoilField);
            this.Controls.Add(txtTypeField);
            this.Controls.Add(txtAreaField);
            this.Controls.Add(txtSoilField);
            this.Controls.Add(btnSubmitField);
        }

        private void LoadForm(object sender, EventArgs e)
        {

        }
        private void AdaugaCamp(object sender, EventArgs e)
        {
            if (validareCamp())
            {
                Field fieldNou = new Field((FieldType)Enum.Parse(typeof(FieldType), txtTypeField.Text), Convert.ToInt32(txtAreaField.Text), (SoilType)Enum.Parse(typeof(SoilType), txtSoilField.Text), Actions.None);
                dataManagerField.AddToFile(fieldNou);
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
    }
}
