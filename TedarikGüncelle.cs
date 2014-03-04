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
    public partial class TedarikGüncelle : Form
    {
        public TedarikGüncelle()
        {
            InitializeComponent();
        }
        DbOperation db = new DbOperation();
        DataTable table1, table2,table3;

        private void TedarikGüncelle_Load(object sender, EventArgs e)
        {
            table1 = db.SelectTable("select * from Tedarikciler");
            name1.DataSource = table1;
            name1.ValueMember = "SupName";
            name1.DisplayMember = "SupName";
        }

        private void name1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table2 = db.SelectTable("select * from Urunler where Supplier='" + name1.SelectedValue.ToString() + "'");
            name2.DataSource = table2;
            name2.DisplayMember = "UrunName";
            name2.ValueMember = "UrunName";
            this.Refresh();

            
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

            try
            {
                if (textBox1.Text=="" || textBox2.Text=="")
                {
                    throw new Exception();
                }
                else
                {
                    int number1 = int.Parse(textBox1.Text.ToString().Trim());
                    int number2 = int.Parse(textBox2.Text.ToString().Trim());
                                     
                    string c=((Form1)Application.OpenForms["Form1"]).tDate().ToString();
                 
                    string date1 = c[0].ToString() + c[1].ToString();
                    string date2 = c[3].ToString() + c[4].ToString();
                    string date3 = c[6].ToString() + c[7].ToString() + c[8].ToString() + c[9].ToString();

                    string date = date3 + '-' + date2 + '-' + date1;
                   
                    string cmd = "update Tedarikler set SupName='" + name1.SelectedValue.ToString() + "',ProName='" + name2.SelectedValue.ToString() + "',DateTed='" + s + "',quantity='" + number1 + "',amount='" + number2 + "' where SupName='" + ((Form1)Application.OpenForms["Form1"]).tName().ToString() + "' AND ProName='" + ((Form1)Application.OpenForms["Form1"]).pName().ToString() + "' AND DateTed='" + date + "' AND amount='" + ((Form1)Application.OpenForms["Form1"]).Tamount().ToString() + "'";
                   

                    int count = db.runCommand(cmd);

                    if (count < 0)
                    {
                        MessageBox.Show("Errorr!");
                    }
                    else
                    {
                        MessageBox.Show("successfully updated! ");
                        ((Form1)Application.OpenForms["Form1"]).dgtedarikler.Refresh();

                        string command2 = "select * from Tedarikler";
                        table3= db.SelectTable(command2);
                        ((Form1)Application.OpenForms["Form1"]).dgtedarikler.DataSource = table3;
                        ((Form1)Application.OpenForms["Form1"]).dgtedarikler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        this.Close();
                    }
                }

            }
            catch (Exception)
            {
              
                MessageBox.Show("Check your values!");
            }
        }
    }
}
