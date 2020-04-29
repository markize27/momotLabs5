using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace momotLabs
{

   
    public partial class Form1 : Form
    {

        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "momotLabsDBDataSet.vendors". При необходимости она может быть перемещена или удалена.
            this.vendorsTableAdapter.Fill(this.momotLabsDBDataSet.vendors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "momotLabsDBDataSet.parts". При необходимости она может быть перемещена или удалена.
            this.partsTableAdapter.Fill(this.momotLabsDBDataSet.parts);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "momotLabsDBDataSet.items". При необходимости она может быть перемещена или удалена.
            this.itemsTableAdapter.Fill(this.momotLabsDBDataSet.items);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "momotLabsDBDataSet.orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.momotLabsDBDataSet.orders);

            DataTable dt = new DataTable();
            dt = ordersTableAdapter.GetData();


            Serialization.Class1 ser = new Serialization.Class1();

            ser.Serialize(dt, "D:/XAI/momotLabs/SavedTable.txt");
           
           
           
            

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(@"D:/XAI/momotLabs/momotLabs/bin/Debug/SaverTable.txt", FileMode.Create);
            //formatter.Serialize(stream, dt);
            //stream.Close();

            
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string.  
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString =
                    "Data Source=<SQL Server>;Initial Catalog=Northwind;" +
                    "Integrated Security=True";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView3.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String cellData = this.dataGridView4.CurrentRow.Cells[0].Value.ToString();
            if (e.ColumnIndex.Equals(0)){
               
                string connstr = @"Server=LAPTOP-CT7MEFN5\MSSQL;Initial Catalog=MomotLabsDB;Integrated Security=True;";
                string query = "Select *  from Parts where VendorNo = @vendorNo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connstr);
                adapter.SelectCommand.Parameters.Add("@vendorNo", SqlDbType.Char, 10, "VendorNo").Value = cellData;
                DataTable table = new DataTable();
                adapter.Fill(table);
                bindingSource1 = new BindingSource();
                bindingSource1.DataSource = table;
                dataGridView3.DataSource = bindingSource1;
                tabControl1.SelectedTab = tabPageParts;

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ProcessStartInfo infoStartProcess = new ProcessStartInfo();

            infoStartProcess.WorkingDirectory = "D:/XAI/momotLabs/help";
            infoStartProcess.FileName = "D:/XAI/momotLabs/help/momotHelp.chm";
            Process.Start(infoStartProcess);
        }
    }
   
}
