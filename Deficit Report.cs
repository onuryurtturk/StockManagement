using OOP10052013;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    public partial class Deficit_Report : Form
    {
        public Deficit_Report()
        {
            InitializeComponent();
        }
        DbOperation db = new DbOperation();
        public DataTable products, needed, supplier, supplies, sales, customers;    
        
        private void Deficit_Report_Load(object sender, EventArgs e)
        {
          
            string command = "select * from Urunler where Quantity<50";
            needed = db.SelectTable(command);
            dataGridView1.DataSource = needed;           


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {             
                   dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
               
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Refresh();
            if (needed.Rows.Count == 0)
            {
                MessageBox.Show("No Record!");
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
