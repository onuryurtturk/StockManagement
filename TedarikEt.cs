using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP10052013;

namespace TermProject
{
    public partial class TedarikEt : Form
    {
        public TedarikEt()
        {
            InitializeComponent();
        }

        DbOperation db = new DbOperation();
        DataTable table1,table2;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table2 = db.SelectTable("select * from Urunler where Supplier='" + comboBox1.SelectedValue.ToString() + "'");
            comboBox2.DataSource = table2;
            comboBox2.DisplayMember = "UrunName";
            comboBox2.ValueMember = "UrunName";
            this.Refresh();

            //table2 = db.SelectTable("select * from Urunler where SupName='"+comboBox1.SelectedValue.ToString()+"'");
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            //comboBox2.DataSource = table2;
            //comboBox2.DisplayMember = "UrunName";
            //this.Refresh();
        }
        
        private void TedarikEt_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Popup;
            table1=db.SelectTable("select * from Tedarikciler");
            comboBox1.DataSource = table1;
            comboBox1.ValueMember = "SupName";
            comboBox1.DisplayMember = "SupName";          
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //table2 = db.SelectTable("select * from Urunler where Supplier='" + comboBox1.SelectedValue.ToString() + "'");
            //comboBox2.DataSource = table2;
            //comboBox2.DisplayMember = "UrunName";
            //this.Refresh();
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            double totalprice = 0;
            try
            {
                count = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(" Wrong Quantity!");
            }
            string s = "";
             s += dateTimePicker1.Value.Year;
             if (dateTimePicker1.Value.Month<10)
             {
                 s = s + '-'+'0'+ dateTimePicker1.Value.Month;
             }
             else
             {
                 s = s + '-' + dateTimePicker1.Value.Month;
             }
             
             s = s + '-' + dateTimePicker1.Value.Day;
             int getinf = 0;
             for (int i = 0; i < table2.Rows.Count; i++)
             {
                 if ((table2.Rows[i][1].ToString()) == comboBox2.SelectedValue.ToString())
                 {
                     getinf = int.Parse(table2.Rows[i][4].ToString());
                 }
             }

             totalprice = getinf * count;


             label6.Text = totalprice.ToString() + " TL";
           
            string command = "insert into Tedarikler values('"+comboBox1.SelectedValue.ToString()+"','"+comboBox2.SelectedValue.ToString()+"','"+s+"','"+count+"','"+totalprice+"')";
            int number=db.runCommand(command);
            
            string cmd2="select UrunName,Quantity from Urunler ";
            DataTable value = db.SelectTable(cmd2);
            this.Refresh();

            int getvalue=0;
            for (int i = 0; i < value.Rows.Count; i++)
            {              
                if (string.Compare(value.Rows[i][0].ToString().Trim(),comboBox2.SelectedValue.ToString().Trim())==0)
                {
                     getvalue = Convert.ToInt32(value.Rows[i][1].ToString());
                }               
            }
            int total = count + getvalue;//toplam miktar

            string cmd3 = "update Urunler Set Quantity='" + total + "' where UrunName='" + comboBox2.SelectedValue.ToString() + "'";
            int number2 = db.runCommand(cmd3);

            
            if (number<0 || number2<0)
            {
                MessageBox.Show("Error!!");
            }
            if (number2 > 0)
            {
                MessageBox.Show("Successfully updated to Products Table");
                ((Form1)Application.OpenForms["Form1"]).TedarikGoster();
            }
            if(number>0)
            {
                MessageBox.Show("Successfully inserted to Supplies Table");
            }

           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
           
        }
    }
}
