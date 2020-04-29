using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace CustomSerializationMomotLabs
{
    public class Class1
    {

        static readonly string rootFolder = @"D:/XAI/momotLabs/momotLabs/bin/Debug";

        public void Serialize(DataTable dt)
        {
            string authorsFile = "SavedTable.txt";
            if (File.Exists(Path.Combine(rootFolder, authorsFile)))
            {
                // If file found, delete it    
                File.Delete(Path.Combine(rootFolder, authorsFile));
                Console.WriteLine("File deleted.");
            }



            string filepath = @"D:/XAI/momotLabs/momotLabs/bin/Debug/";
            string filename = "SaverTable.txt";
        

            // serialize
            using (FileStream strm = File.OpenWrite(Path.Combine(filepath, filename)))
            {
                BinaryFormatter ser = new BinaryFormatter();
             
                ser.Serialize(strm, dt);
            }
        }

        public Object Deserialize(string dataFilePath)
        {
            Object obj = null;

            FileStream fs = new FileStream(dataFilePath, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                obj = formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return obj;
        }

        public void Serialize(Object obj, string savePath)
        {
            FileStream fs = new FileStream(savePath, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public DataTable Deserialize()
        { 
            string filepath = @"D:/XAI/momotLabs/momotLabs/bin/Debug/";
            string filename = "SaverTable.txt"; 
            DataTable dTable = new DataTable();

            // serialize
            using (FileStream strm = File.OpenWrite(Path.Combine(filepath, filename)))
            {
                BinaryFormatter ser = new BinaryFormatter();
                dTable = ser.Deserialize(strm) as DataTable;
            }
            return dTable;
        }

       
    }
  
}
    





