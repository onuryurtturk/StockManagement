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
    public partial class SatisYap : Form
    {
        public SatisYap()
        {
            InitializeComponent();
        }
        DbOperation op=new DbOperation();
        DataTable dtb,table1,table2;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SatisYap_Load(object sender, EventArgs e)
        {
            GetCustomer();
            GetProduct();
        }
        
        private void GetCustomer()
        {
            string command = "select * from Musteriler";
            table1 = op.SelectTable(command);
            dataGridView1.DataSource = table1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;     
        }

        private void GetProduct()
        {
            string command = "select * from Urunler";
            table2 = op.SelectTable(command);
            dataGridView2.DataSource = table2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }
        int count = 0;
        bool control = false;

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            if (control!=false)
            {
                int newquant = 0;
                bool flag = false;

                try
                {
                    int current = int.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    if (count > current)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        newquant = current - count;
                        flag = true;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("There is no enough product! Please Supply it!");
                }

                if (flag == true)
                {
                    string command2 = "update Urunler set Quantity='" + newquant + "' where UrunId='"
                   + dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";

                    int f = op.runCommand(command2);

                    if (f < 0)
                    {
                        MessageBox.Show("Errorrr!");
                    }
                    else
                    {
                        MessageBox.Show("Product sold successfully and updated Products Table");
                    }



                    string s = string.Empty;
                    s += dateTimePicker1.Value.Year;
                    if (dateTimePicker1.Value.Month < 10)
                    {
                        s = s + '-' + '0' + dateTimePicker1.Value.Month;
                    }
                    else
                    {
                        s = s + '-' + dateTimePicker1.Value.Month;
                    }

                    s = s + '-' + dateTimePicker1.Value.Day;

                    int k = int.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    float tot = k * count;


                    string command1 = "insert into Satislar values('" +
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() +
                        "','" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString() +
                        "','" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString() +
                        "','" + dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString() +
                        "','" + dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString() +
                        "','" + s + "','" + count + "','" + tot + "')";

                    int number = op.runCommand(command1);

                    if (number < 0)
                    {
                        MessageBox.Show("Error!!");
                    }
                    else
                    {
                        MessageBox.Show("Successfully inserted to Sales Table");
                        this.Refresh();
                        

                    }

                }           
            }
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            string command = "select * from Satislar";
            dtb = op.SelectTable(command);
             ((Form1)Application.OpenForms["Form1"]).dataGridView2.DataSource = dtb;
           ((Form1)Application.OpenForms["Form1"]).dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;   
           
                   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                count = int.Parse(textBox1.Text); 
                if (textBox1.Text==" " || textBox1.Text=="" || textBox1.Text==string.Empty)
                {
                    throw new FormatException();
                }
                if (textBox1.Text != " " && textBox1.Text != "" && textBox1.Text != string.Empty)
                {
                    control = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong Quantity!");
                control = false;
            }
        }
    }
}
