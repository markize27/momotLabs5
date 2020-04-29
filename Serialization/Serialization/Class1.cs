using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Class1
    {


        static readonly string rootFolder = @"D:/XAI/momotLabs/SavedTable.txt";
        public DataTable Deserialize(string dataFilePath)
        {
            DataTable dt = new DataTable();

            FileStream fs = new FileStream(dataFilePath, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                dt = (DataTable) formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {

                throw;
            }
            finally
            {
                fs.Close();
            }

            return dt;
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
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
