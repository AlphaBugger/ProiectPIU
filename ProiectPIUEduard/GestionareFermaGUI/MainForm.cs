using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionareFermaGUI
{
    public partial class MainForm : Form
    {
        private bool isAnimalAddOpen;
        private bool isAnimalViewOpen;
        private bool isFieldAddOpen;
        private bool isFieldViewOpen;

        private Button ViewAnimals;
        private Button ViewFields;
        private Button AddAnimal;
        private Button AddField;

        private Button QuitApp;

        private ViewAnimal viewAnimal;
        private ViewFields viewFields;
        private AdaugaAnimalForm adauagaAnimal;
        private AdaugaCampForm adaugaField;

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            LoadContent();
        }
        private void LoadContent()
        {
            this.Width = 400;
            this.Height = 600;

            ViewAnimals = new Button()
            {
                Text = "View Animals",
                Top = 20,
                Left = 20,
                Width = this.Width - 60
            };

            ViewFields = new Button()
            {
                Text = "View Fields",
                Top = 60,
                Left = 20,
                Width = this.Width - 60
            };

            AddAnimal = new Button()
            {
                Text = "Add Animals",
                Top = 100,
                Left = 20,
                Width = this.Width - 60
            };

            AddField = new Button()
            {
                Text = "Add Field",
                Top = 140,
                Left = 20,
                Width = this.Width - 60
            };

            QuitApp = new Button()
            {
                Text = "Quit App",
                Top = this.Height - 80,
                Left = 20,
                Width = this.Width - 60
            };

            ViewAnimals.Click += ViewAnimals_Click;
            ViewFields.Click += ViewFields_Click;
            AddAnimal.Click += AddAnimal_Click;
            AddField.Click += AddField_Click;
            QuitApp.Click += QuitApp_Click;

            this.Controls.Add(ViewAnimals);
            this.Controls.Add(ViewFields);
            this.Controls.Add(AddAnimal);
            this.Controls.Add(AddField);
            this.Controls.Add(QuitApp);


        }

        private void QuitApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit", "Confirm Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AddField_Click(object sender, EventArgs e)
        {
            if (isFieldAddOpen)
            {
                CloseAddField();
            }
            else
            {
                OpenAddField();
                
            }
        }

        private void AddAnimal_Click(object sender, EventArgs e)
        {
            if (isAnimalAddOpen)
            {
                CloseAddAnimal();
            }
            else
            {
                OpenAddAnimal();
            }
        }

        private void ViewFields_Click(object sender, EventArgs e)
        {
            if (isFieldViewOpen)
            {
                CloseViewFields();
            }
            else
            {
                OpenViewFields();
            }
        }

        private void ViewAnimals_Click(object sender, EventArgs e)
        {
            if (isAnimalViewOpen)
            {
                CloseViewAnimals();
            }
            else
            {
                OpenViewAnimals();
            }
        }

        private void OpenAddAnimal()
        {
            if (adauagaAnimal == null)
            {
                adauagaAnimal = new AdaugaAnimalForm()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Visible = true,
                    Top = 20,
                    Left = this.Width,
                };
                this.Controls.Add(adauagaAnimal);
                this.Width += adauagaAnimal.Width;
                isAnimalAddOpen = true;
            }
        }

        private void CloseAddAnimal()
        {
            if (adauagaAnimal != null)
            {
                this.Controls.Remove(adauagaAnimal);
                this.Width -= adauagaAnimal.Width;
                adauagaAnimal.Dispose();
                adauagaAnimal = null;
                isAnimalAddOpen = false;
            }
        }

        private void OpenViewFields()
        {
            if (viewFields == null)
            {
                viewFields = new ViewFields()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Visible = true,
                    Top = 20,
                    Left = this.Width,
                };
                this.Controls.Add(viewFields);
                this.Width += viewFields.Width;
                isFieldViewOpen = true;
            }
        }

        private void CloseViewFields()
        {
            if (viewFields != null)
            {
                this.Controls.Remove(viewFields);
                this.Width -= viewFields.Width;
                viewFields.Dispose();
                viewFields = null;
                isFieldViewOpen = false;
            }
        }

        private void OpenViewAnimals()
        {
            if (viewAnimal == null)
            {
                viewAnimal = new ViewAnimal()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Visible = true,
                    Top = 20,
                    Left = this.Width,
                };
                this.Controls.Add(viewAnimal);
                this.Width += viewAnimal.Width;
                isAnimalViewOpen = true;
            }
        }

        private void CloseViewAnimals()
        {
            if (viewAnimal != null)
            {
                this.Controls.Remove(viewAnimal);
                this.Width -= viewAnimal.Width;
                viewAnimal.Dispose();
                viewAnimal = null;
                isAnimalViewOpen = false;
            }
        }

        private void OpenAddField()
        {
            if(adaugaField == null)
            {
                adaugaField = new AdaugaCampForm()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Visible = true,
                    Top = 20,
                    Left = this.Width,
                };
                this.Controls.Add(adaugaField);
                this.Width += adaugaField.Width;
                isFieldAddOpen = true;


            }
        }
        private void CloseAddField()
        {
            if(adaugaField != null)
            {
                this.Controls.Remove(adaugaField);
                this.Width -= adaugaField.Width;
                adaugaField.Dispose();
                adaugaField = null;
                isFieldAddOpen= false;
            }
        }
    }
}
