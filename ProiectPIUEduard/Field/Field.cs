using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace FieldClass
{
    public class Field: FileHandling
    {

        private int FileTYPE = 0;
        private int FileAREA = 2;
        private int FileSOIL = 1;
        private int FileACTIONS = 3;


        public FieldType Type { get; set; }
        public double Area { get; set; }
        public SoilType Soil { get; set; }
        public Actions FieldActions { get; set; }


        public Field() {
            Type = FieldType.Other;
            Area = 0;
            Soil = SoilType.Other;
            FieldActions = Actions.None;
        }
        public Field(string lineFromFile)
        {
            string[] fileData = lineFromFile.Split('$');


            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.Type = (FieldType)Enum.Parse(typeof(FieldType), fileData[FileTYPE]);
            this.Area = Convert.ToInt32(fileData[FileAREA]);
            this.Soil = (SoilType)Enum.Parse(typeof(SoilType), fileData[FileSOIL]);
            this.FieldActions = (Actions)Enum.Parse(typeof(Actions), fileData[FileACTIONS]);

        }
        public Field(FieldType type, double area, SoilType soil, Actions actions)
        {
            Type = type;
            Area = area;
            Soil = soil;
            FieldActions = actions;
        }

        public void DisplayFieldInfo()
        {
            Console.WriteLine($"Crop Type: {Type}");
            Console.WriteLine($"Area: {Area} hectares");
            Console.WriteLine($"Soil Type: {Soil}");
            Console.WriteLine($"Actions: {FieldActions}");
        }

        public string ConvertToFileString()
        {
            string stringFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                "$",
                (Type.ToString() ?? "NECUNOSCUT"),
                (Soil.ToString() ?? " NECUNOSCUT "),
                (Area.ToString() ?? " NECUNOSCUT "),
                (FieldActions.ToString() ?? " NECUNOSCUT ")
                );

            return stringFisier;
        }
    }
}
