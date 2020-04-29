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

namespace ClassLibrary1
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
                ser.Binder = new CustomizedBinder();
                ser.Serialize(strm, dt);
            }

        }
        public DataTable Deserialize()
        {
            string filepath = @"D:/XAI/momotLabs/momotLabs/bin/Debug/";
            string filename = "SaverTable.txt";
            DataTable dTable = new DataTable();

            // serialize
            using (FileStream strm = File.OpenRead(Path.Combine(filepath, filename)))
            {
                BinaryFormatter ser = new BinaryFormatter();
                ser.Binder = new CustomizedBinder();
                dTable = ser.Deserialize(strm) as DataTable;
            }
            return dTable;
        }
    }

    sealed class CustomizedBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type returntype = null;
            string sharedAssemblyName = "SharedAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            assemblyName = Assembly.GetExecutingAssembly().FullName;
            typeName = typeName.Replace(sharedAssemblyName, assemblyName);
            returntype =
                    Type.GetType(String.Format("{0}, {1}",
                    typeName, assemblyName));

            return returntype;
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            base.BindToName(serializedType, out assemblyName, out typeName);
            assemblyName = "SharedAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        }
    }
}
