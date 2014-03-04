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
    public partial class SatisGuncelle : Form
    {
        public SatisGuncelle()
        {
            InitializeComponent();
        }

        DbOperation db = new DbOperation();
        DataTable table1, table2,table3,table4,table5,sales;
        private void SatisGuncelle_Load(object sender, EventArgs e)
        {
            table1 = db.SelectTable("select * from Musteriler");
            comboBox3.DataSource = table1;
            comboBox3.ValueMember = "CusId";
            comboBox3.DisplayMember = "CusId";
            table3 = db.SelectTable("select * from Urunler");
            comboBox1.DataSource = table3;
            comboBox1.DisplayMember = "UrunName";
            comboBox1.ValueMember = "UrunName";
            table4 = db.SelectTable("select * from Urunler Where UrunName='" + comboBox1.SelectedValue.ToString() + "'");
            comboBox2.DataSource = table4;
            comboBox2.DisplayMember = "UrunId";
            comboBox2.ValueMember = "UrunId";
            textBox3.Text = ((Form1)Application.OpenForms["Form1"]).GetSalesCusQuant().ToString();
            textBox4.Text = ((Form1)Application.OpenForms["Form1"]).Amount().ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string command = "select * from Musteriler Where CusId='" + comboBox3.SelectedValue.ToString() + "'";
            table2 = db.SelectTable(command);
            for (int i = 0; i < table2.Rows.Count; i++)
			{
			    if (table2.Rows[i][0].ToString()==comboBox3.SelectedValue.ToString())
	            {
		            string s=table2.Rows[i][1].ToString();
                    textBox1.Text=s;
                    textBox2.Text = table2.Rows[i][2].ToString();
	            }

			}
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table4 = db.SelectTable("select * from Urunler Where UrunName='" + comboBox1.SelectedValue.ToString() + "'");
            comboBox2.DataSource = table4;
            comboBox2.DisplayMember = "UrunId";
            comboBox2.ValueMember = "UrunId";

            try
            {
                if (textBox4.Text != "" && textBox3.Text != "")
                {
                    int number = int.Parse(textBox4.Text);
                    int number2 = int.Parse(textBox3.Text);
                    int price = (number / number2);
                    int total = price * number2;
                    this.Refresh();
                    textBox4.Text = total.ToString();
                    this.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your values!");
            }

            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            table5 = db.SelectTable("select * from Satislar Where ProName='" + comboBox1.SelectedValue.ToString() + "' AND CusName='" + textBox1.Text + "' AND CusSurname='" + textBox2.Text + "'");
           
            for (int i = 0; i < table5.Rows.Count; i++)
            {
                if (table5.Rows[i][4].ToString() == comboBox1.SelectedValue.ToString())
                {
                    int count = int.Parse(table5.Rows[i][6].ToString());
                    int count2=int.Parse(table5.Rows[i][7].ToString());
                    textBox3.Text = count.ToString();
                    textBox4.Text = count2.ToString();
                }

            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "" && textBox3.Text != "")
                {
                    int number = int.Parse(textBox4.Text);
                    int number2 = int.Parse(textBox3.Text);
                    int price = (number / number2);
                    int total = price * number2;
                    this.Refresh();
                    textBox4.Text = total.ToString();
                    this.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your values!");
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "" && textBox3.Text != "")
                {
                    int number = int.Parse(textBox4.Text);
                    int number2 = int.Parse(textBox3.Text);
                    int price = (number / number2);
                    int total = price * number2;
                    this.Refresh();
                    textBox4.Text = total.ToString();
                    this.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your values!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

                string command = "update Satislar set CusId='" + comboBox3.SelectedValue.ToString() + "',CusName='" + textBox1.Text + "',CusSurname='" + textBox2.Text + "',ProId='" + comboBox2.SelectedValue.ToString() + "',ProName='" + comboBox1.SelectedValue.ToString() + "',Date='" + s + "',Quantity='" + textBox3.Text + "',Amount='" + textBox4.Text + "' where CusId='" + ((Form1)Application.OpenForms["Form1"]).GetSalesCusId().ToString() + "'AND ProId='" + ((Form1)Application.OpenForms["Form1"]).SalesProId().ToString() + "'AND Amount='"+ ((Form1)Application.OpenForms["Form1"]).Amount().ToString()+"'";
               
                int count = db.runCommand(command);

                if (count < 0)
                {
                    MessageBox.Show("Errorr!");
                }
                else
                {
                    MessageBox.Show("successfully updated! ");
                    ((Form1)Application.OpenForms["Form1"]).dataGridView2.Refresh();

                    string command2 = "select * from Satislar";
                    sales = db.SelectTable(command2);
                    ((Form1)Application.OpenForms["Form1"]).dataGridView2.DataSource = sales;
                    ((Form1)Application.OpenForms["Form1"]).dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;   
                    this.Close();
                }
        }
    }
}
