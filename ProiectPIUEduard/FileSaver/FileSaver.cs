using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSaver
{
    public class DataFileManager
    {
        private const int MaxDataIndex = 50;
        private string FileName;

        public DataFileManager(string numeFisier)
        {
            this.FileName = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddToFile<T>(T dataToBeSaved) where T : FileHandling
        {

            using (StreamWriter streamWriterFisierText = new StreamWriter(FileName, true))
            {
                streamWriterFisierText.WriteLine(dataToBeSaved.ConvertToFileString());
            }
        }

        public T[] GetObjects<T>(out int nrObjects) where T : FileHandling
        {
            List<T> objectsList = new List<T>();

            using (StreamReader streamReader = new StreamReader(FileName))
            {
                string lineFromFile;
                nrObjects = 0;

                while ((lineFromFile = streamReader.ReadLine()) != null)
                {
                    T newObj = (T)Activator.CreateInstance(typeof(T), new object[] { lineFromFile });
                    objectsList.Add(newObj);
                    nrObjects++;
                }
            }

            return objectsList.ToArray();
        }

        //public Student GetStudent(string nume, string prenume)
        //{
        //    // instructiunea 'using' va apela streamReader.Close()
        //    using (StreamReader streamReader = new StreamReader(numeFisier))
        //    {
        //        string linieFisier;

        //        // citeste cate o linie si creaza un obiect de tip Student
        //        // pe baza datelor din linia citita
        //        while ((linieFisier = streamReader.ReadLine()) != null)
        //        {
        //            Student student = new Student(linieFisier);
        //            if (student.Nume.Equals(nume) && student.Prenume.Equals(prenume))
        //                return student;
        //        }
        //    }

        //    return null;
        //}

        //public Student GetStudent(int idStudent)
        //{
        //    // instructiunea 'using' va apela streamReader.Close()
        //    using (StreamReader streamReader = new StreamReader(numeFisier))
        //    {
        //        string linieFisier;

        //        // citeste cate o linie si creaza un obiect de tip Student
        //        // pe baza datelor din linia citita
        //        while ((linieFisier = streamReader.ReadLine()) != null)
        //        {
        //            Student student = new Student(linieFisier);
        //            if (student.IdStudent == idStudent)
        //                return student;
        //        }
        //    }

        //    return null;
        //}
    }
}
