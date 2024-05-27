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
using System.Windows.Forms.VisualStyles;

namespace GestionareFermaGUI
{
    public partial class ViewFields : Form
    {
        DataFileManager dataManagerField;


        static List<Field> fields = new List<Field>();

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
        public ViewFields()
        {
            
            InitializeComponent();
            this.Width = 600;
            this.Height = 600;
            listView1 = new ListView();
            listView1.Width = this.Size.Width - 60;
            
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

            string numeFisierField = ConfigurationManager.AppSettings["FileNameField"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(locatieFisierSolutie, "Data");

            string caleCompletaFisierField = dataFolderPath + "\\" + numeFisierField;


            dataManagerField = new DataFileManager(caleCompletaFisierField);


            int nrFields = 0;


            Field[] fields = dataManagerField.GetObjects<Field>(out nrFields);

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
                DataSource = Enum.GetValues(typeof(FieldType))
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
            List<Field> filterField = new List<Field>();

            Field[] Fields = dataManagerField.GetObjects<Field>(out int nrField);

            FieldType fieldType = (FieldType)txtCautaTip.SelectedItem;


            foreach (Field field in Fields)
            {
                if (field.Type == fieldType)
                {
                    filterField.Add(field);

                }
            }
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;

            listView1.Columns.Add("Type", listView1.Width / 4);
            listView1.Columns.Add("Area", listView1.Width / 4);
            listView1.Columns.Add("Soil", listView1.Width / 4);
            listView1.Columns.Add("Actions", listView1.Width / 4);

            foreach (Field field in filterField)
            {
                ListViewItem item = new ListViewItem();
                item.Text = field.Type.ToString();
                item.SubItems.Add(field.Area.ToString());
                item.SubItems.Add(field.Soil.ToString());

                // Combine categories into a single string separated by commas
                string actions = string.Join(",", field.FieldActions);
                item.SubItems.Add(actions);

                listView1.Items.Add(item);
            }

        }
        private void AfiseazaInformatii()
        {
            Field[] fields = dataManagerField.GetObjects<Field>(out int nrFields);

            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;

            listView1.Columns.Add("Type", listView1.Width / 4);
            listView1.Columns.Add("Area", listView1.Width / 4);
            listView1.Columns.Add("Soil", listView1.Width / 4);
            listView1.Columns.Add("Actions", listView1.Width / 4);

            foreach (Field field in fields)
            {
                ListViewItem item = new ListViewItem();
                item.Text = field.Type.ToString();
                item.SubItems.Add(field.Area.ToString());
                item.SubItems.Add(field.Soil.ToString());

                // Combine categories into a single string separated by commas
                string actions = string.Join(",", field.FieldActions);
                item.SubItems.Add(actions);

                listView1.Items.Add(item);
            }
            int itemHeight = listView1.GetItemRect(0).Height; // Assuming all items have the same height
            listView1.Height = itemHeight * 20 + SystemInformation.HorizontalScrollBarHeight;
            listView1.Scrollable = true;
        }

    }
}
