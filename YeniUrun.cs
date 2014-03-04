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
    public partial class YeniUrun : Form
    {
        public YeniUrun()
        {
            InitializeComponent();
            
        }
        DbOperation op = new DbOperation();
        DataTable table, tableProduct,table2;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="")
                {
                    string command = "insert into Urunler values('" + textBox1.Text + "','" + textBox2.Text + "',0,'" + textBox4.Text + "','" + comboBox1.SelectedValue.ToString() + "','" + textBox3.Text + "')";
                    int count = op.runCommand(command);// kaç tane satırın etkilendiğini döndürüyor.
                   
                    if (count < 0)
                    {
                        MessageBox.Show("Errorr!");
                    }
                    else
                    {
                        MessageBox.Show("successfully inserted! ");
                        this.Close();
                        
                    }
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                MessageBox.Show(" You must fill all forms!");
            }           
        }

        private void YeniUrun_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            this.Opacity = 0.95;
            table2=op.SelectTable("select * from Tedarikciler");
            comboBox1.DataSource = table2;
            comboBox1.ValueMember = "SupName";
            comboBox1.DisplayMember = "SupName";     
           
        }
    }
}
