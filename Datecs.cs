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
    public partial class Datecs : Form
    {
        public Datecs()
        {
            InitializeComponent();
        }

        DbOperation db = new DbOperation();
        DataTable table1, table2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Search Supplies By Date")
            {   
                
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
                if (dateTimePicker1.Value.Day < 10)
                {
                     s = s + "-0" + dateTimePicker1.Value.Day;
                }
                else
                {
                    s = s + '-' + dateTimePicker1.Value.Day;
                }

               

                string s2 = string.Empty;
                s2 += dateTimePicker2.Value.Year;
                if (dateTimePicker2.Value.Month < 10)
                {
                    s2 = s2 + '-' + '0' + dateTimePicker2.Value.Month;
                }
                else
                {
                    s2= s2 + '-' + dateTimePicker2.Value.Month;
                }
                 if (dateTimePicker2.Value.Day < 10)
                {
                     s2 = s2 + "-0" + dateTimePicker2.Value.Day;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Day;
                }

                string command = "select * from Tedarikler Where DateTed between '"+s+"' and '"+s2+"'";
                table1 = db.SelectTable(command);
               
                Results rst = new Results();
                this.Close();
                rst.Show();
                if (table1.Rows.Count == 0)
                {
                    MessageBox.Show("No records found!!");
                }
                rst.dataGridView1.DataSource = table1;
                rst.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                rst.dataGridView1.Refresh();

            }
            else if (label3.Text == "Search Sales By Date")
            {

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
                if (dateTimePicker1.Value.Day < 10)
                {
                    s = s + "-0" + dateTimePicker1.Value.Day;
                }
                else
                {
                    s = s + '-' + dateTimePicker1.Value.Day;
                }
                string s2 = string.Empty;
                s2 += dateTimePicker2.Value.Year;
                if (dateTimePicker2.Value.Month < 10)
                {
                    s2 = s2 + '-' + '0' + dateTimePicker2.Value.Month;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Month;
                }
                if (dateTimePicker2.Value.Day < 10)
                {
                    s2 = s2 + "-0" + dateTimePicker2.Value.Day;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Day;
                }

                string command = "select * from Satislar Where Date between '" + s + "' and '" + s2 + "'";
                table1 = db.SelectTable(command);
                Results rst = new Results();
                this.Close();
                rst.Show();
                if (table1.Rows.Count == 0)
                {
                    MessageBox.Show("No records found!!");
                }
                rst.dataGridView1.DataSource = table1;
                rst.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                rst.dataGridView1.Refresh();

            }
            else if (label3.Text == "Sales Report")
            {
                
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
                if (dateTimePicker1.Value.Day < 10)
                {
                    s = s + "-0" + dateTimePicker1.Value.Day;
                }
                else
                {
                    s = s + '-' + dateTimePicker1.Value.Day;
                }
                string s2 = string.Empty;
                s2 += dateTimePicker2.Value.Year;
                if (dateTimePicker2.Value.Month < 10)
                {
                    s2 = s2 + '-' + '0' + dateTimePicker2.Value.Month;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Month;
                }
                if (dateTimePicker2.Value.Day < 10)
                {
                    s2 = s2 + "-0" + dateTimePicker2.Value.Day;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Day;
                }

                SalesReport sls = new SalesReport();
                string command = "select * from Satislar Where Date between '" + s + "' and '" + s2 + "'";
                table1 = db.SelectTable(command);
                sls.dataGridView1.DataSource = table1;
                sls.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sls.dataGridView1.Refresh();
                this.Close();
                sls.Show();
                if (table1.Rows.Count == 0)
                {
                    MessageBox.Show("No records found!!");
                }
                
                sls.label1.Text = "Total Amount : ";
                sls.label2.Text = "Number Of Sales : ";
                sls.textBox2.Text = table1.Rows.Count.ToString();
                double total = 0;
                for (int i = 0; i < sls.dataGridView1.RowCount-1; i++)
                {
                    //MessageBox.Show(sls.dataGridView1.Rows[i].Cells[7].Value.ToString());
                   total += int.Parse(sls.dataGridView1.Rows[i].Cells[7].Value.ToString());
                }
                sls.textBox1.Text=total.ToString();           
            }
            else if (label3.Text == "Supply Report")
            {
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
                if (dateTimePicker1.Value.Day < 10)
                {
                    s = s + "-0" + dateTimePicker1.Value.Day;
                }
                else
                {
                    s = s + '-' + dateTimePicker1.Value.Day;
                }
                string s2 = string.Empty;
                s2 += dateTimePicker2.Value.Year;
                if (dateTimePicker2.Value.Month < 10)
                {
                    s2 = s2 + '-' + '0' + dateTimePicker2.Value.Month;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Month;
                }
                if (dateTimePicker2.Value.Day < 10)
                {
                    s2 = s2 + "-0" + dateTimePicker2.Value.Day;
                }
                else
                {
                    s2 = s2 + '-' + dateTimePicker2.Value.Day;
                }


                SalesReport sls = new SalesReport();
                string command = "select * from Tedarikler Where DateTed between '" + s + "' and '" + s2 + "'";
                table1 = db.SelectTable(command);
                sls.dataGridView1.DataSource = table1;
                sls.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sls.dataGridView1.Refresh();
                this.Close();
                sls.Show();
                if (table1.Rows.Count == 0)
                {
                    MessageBox.Show("No records found!!");
                }

                sls.label1.Text = "Total Amount : ";
                sls.label2.Text = "Number Of Supply : ";
                sls.textBox2.Text = table1.Rows.Count.ToString();
                double total = 0;
                for (int i = 0; i < sls.dataGridView1.RowCount-1; i++)
                {
                    
                    total += int.Parse(sls.dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                sls.textBox1.Text = total.ToString();   
                
            }
        }
    }
}
