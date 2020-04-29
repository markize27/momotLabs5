using Newtonsoft.Json;
using sun.corba;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace momotLabs1Part2
{

    public partial class Form1 : Form
    {

        static readonly string rootFolder = "D:/XAI/momotLabs/SavedTable.txt";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //ProcessStartInfo infoStartProcess = new ProcessStartInfo();

            //infoStartProcess.WorkingDirectory = "D:/XAI/momotLabs/momotLabs/bin/Debug";
            //infoStartProcess.FileName = "D:/XAI/momotLabs/momotLabs/bin/Debug/momotLabs.exe";

            //Process.Start(infoStartProcess);

            Serialization.Class1 ser = new Serialization.Class1();
         
            DataTable dTable = (DataTable) ser.Deserialize(rootFolder);   


            dataGridView1.DataSource = dTable;

            dataGridView1.Update();
        }
    }
   
}
