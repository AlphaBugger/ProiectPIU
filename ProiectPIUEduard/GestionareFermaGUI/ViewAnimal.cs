using AnimalClass;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionareFermaGUI
{
    public partial class ViewAnimal : Form
    {
        DataFileManager dataManagerAnimal;
        static List<Animal> animals = new List<Animal>();
        private ListView listView1;

        private Button btnSearch;
        private Button btnRefresh;

        private ComboBox txtCautaTip;
        private Label lblCautaTip;


        private const int LATIME_CONTROL = 100;

        private const int DIMENSIUNE_PAS_X = 120;

        private const int PADDING = 20;
        private const int LATIME_CONTROL_TITLE = (LATIME_CONTROL + PADDING) * 4 - PADDING;
        private const int LATIME_CONTROL_3 = (LATIME_CONTROL_TITLE) / 3 - (PADDING * 2) / 3;
        private const int WINDOW_TAB = 300;
        private const int DIMENSIUNE_PAS_WINDOW2 = 30 + WINDOW_TAB + PADDING;
        private const int DIMENSIUNE_PAS_WINDOW = 30;
        public ViewAnimal()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 600;
            listView1 = new ListView();
            listView1.Width = this.Size.Width - 60;
            //listView1.Height = this.Size.Height-60;
            listView1.Top = 20;
            listView1.Left = 20;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Scrollable = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.Controls.Add(listView1);


            string numeFisierAnimal = ConfigurationManager.AppSettings["FileNameAnimal"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(locatieFisierSolutie, "Data");
            string caleCompletaFisierAnimal = dataFolderPath + "\\" + numeFisierAnimal;
            dataManagerAnimal = new DataFileManager(caleCompletaFisierAnimal);

            lblCautaTip = new Label()
            {
                Text = "Cauta dupa tip",
                Top = 420,
                Width = listView1.Width / 3 - 10,
                Left = listView1.Left
            };
            this.Controls.Add(lblCautaTip);
            txtCautaTip = new ComboBox()
            {
                Top = 450,
                Width = listView1.Width / 3 - 10,
                Left = listView1.Left,
                DataSource = Enum.GetValues(typeof(FarmAnimalType))
            };
            this.Controls.Add(txtCautaTip);

            btnRefresh = new Button();
            btnRefresh.Text = "Improspateaza";
            btnRefresh.Top = txtCautaTip.Top + txtCautaTip.Height + 20;
            btnRefresh.ForeColor = Color.Gray;
            btnRefresh.Left = listView1.Left;
            btnRefresh.Width = listView1.Width / 2 - 10;
            btnRefresh.Click += BtnRefresh_Click;
            this.Controls.Add(btnRefresh);

            btnSearch = new Button();
            btnSearch.Text = "Cauta";
            btnSearch.Top = txtCautaTip.Top + txtCautaTip.Height + 20;
            btnSearch.ForeColor = Color.Gray;
            btnSearch.Left = btnRefresh.Left + btnRefresh.Width + 20;
            btnSearch.Width = listView1.Width / 2 - 10;
            btnSearch.Click += Cauta;
            this.Controls.Add(btnSearch);


        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaInformatii();
        }

        private void Cauta(object sender, EventArgs e)
        {
            List <Animal> filterAnimal = new List<Animal> ();
            Animal[] animals = dataManagerAnimal.GetObjects<Animal>(out int nrAnimals);

            FarmAnimalType farmAnimalType = (FarmAnimalType)txtCautaTip.SelectedItem;
            

            foreach (Animal animal in animals)
            {
                if (animal.Type == farmAnimalType)
                {
                    filterAnimal.Add(animal);
                    
                }
            }
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;

            listView1.Columns.Add("Type", listView1.Width / 4);
            listView1.Columns.Add("Age", listView1.Width / 4);
            listView1.Columns.Add("Weight", listView1.Width / 4);
            listView1.Columns.Add("Breed", listView1.Width / 4);

            foreach (Animal animal in filterAnimal)
            {
                ListViewItem item = new ListViewItem();
                item.Text = animal.Type.ToString();
                item.SubItems.Add(animal.Age.ToString());
                item.SubItems.Add(animal.Weight.ToString());
                item.SubItems.Add(animal.Breed.ToString());

                listView1.Items.Add(item);
            }

        }

        private void ViewAnimal_Load(object sender, EventArgs e)
        {
            AfiseazaInformatii();
        }
        private void AfiseazaInformatii()
        {
            Animal[] animals = dataManagerAnimal.GetObjects<Animal>(out int nrAnimals);
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;

            listView1.Columns.Add("Type", listView1.Width / 4);
            listView1.Columns.Add("Age", listView1.Width / 4);
            listView1.Columns.Add("Weight", listView1.Width / 4);
            listView1.Columns.Add("Breed", listView1.Width / 4);

            foreach (Animal animal in animals)
            {
                ListViewItem item = new ListViewItem();
                item.Text = animal.Type.ToString();
                item.SubItems.Add(animal.Age.ToString());
                item.SubItems.Add(animal.Weight.ToString());
                item.SubItems.Add(animal.Breed.ToString());

                listView1.Items.Add(item);
            }
            int itemHeight = listView1.GetItemRect(0).Height; // Assuming all items have the same height
            listView1.Height = itemHeight * 20 + SystemInformation.HorizontalScrollBarHeight;
            listView1.Scrollable = true;
        }

    }
}
