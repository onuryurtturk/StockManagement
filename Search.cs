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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        DataTable result1;
        DbOperation db = new DbOperation();

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (label1.Text=="Search Supplier By Id")
            {
                try
                {
                    int number = int.Parse(textBox1.Text.ToString());
                    string command = "select * from Tedarikciler where SupId='"+number+"'";
                    result1 = db.SelectTable(command);
                    Results rst = new Results();
                    this.Close();
                    rst.Show();
                    rst.dataGridView1.DataSource = result1;
                    rst.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.Refresh();

                    if (result1.Rows.Count != 0)
                    {

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(" No Record! Check your values!");
                }          
            }

            else if (label1.Text == "Search Supplier By Name")
            {
                try
                {                   
                    string command = "select * from Tedarikciler where SupName='" + textBox1.Text.Trim() + "'";
                    result1 = db.SelectTable(command);
                    Results rst = new Results();
                    this.Close();
                    rst.Show();
                    rst.dataGridView1.DataSource = result1;
                    rst.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.Refresh();

                    if (result1.Rows.Count != 0)
                    {

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(" No Record! Check your values!");
                }          
            }
            else if (label1.Text == "Search Supplier By Telephone")
            {
                try
                {
                    string command = "select * from Tedarikciler where SupTel='" + textBox1.Text.Trim() + "'";
                    result1 = db.SelectTable(command);
                    Results rst = new Results();
                    this.Close();
                    rst.Show();
                    rst.dataGridView1.DataSource = result1;
                    rst.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.Refresh();

                    if (result1.Rows.Count != 0)
                    {

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(" No Record! Check your values!");
                }   
            }
            else if (label1.Text == "Search Customer By Name")
            {
                try
                {
                    string command = "select * from Musteriler where CusName='" + textBox1.Text.Trim() + "'";
                    result1 = db.SelectTable(command);
                    Results rst = new Results();
                    this.Close();
                    rst.Show();
                    rst.dataGridView1.DataSource = result1;
                    rst.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.Refresh();

                    if (result1.Rows.Count != 0)
                    {

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(" No Record! Check your values!");
                }   
            }
         
            
            
        }
    }
}
