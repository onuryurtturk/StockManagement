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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        DbOperation db = new DbOperation();
        
        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
                namebox.Text=((Form1)Application.OpenForms["Form1"]).GetcustName();
                textBox1.Text=((Form1)Application.OpenForms["Form1"]).GetSurName();
                textBox2.Text=((Form1)Application.OpenForms["Form1"]).GetcustTel();
                textBox3.Text = ((Form1)Application.OpenForms["Form1"]).Getcustad();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (namebox.Text != "" && textBox3.Text != "" && textBox2.Text != "" && textBox1.Text != "")
                {
                    string cmd = "update Musteriler set CusName='" + namebox.Text + "', CusSurname='" + textBox1.Text + "',CusTel='" + textBox2.Text + "',CusAdress='" + textBox3.Text + "' where CusId='" + ((Form1)Application.OpenForms["Form1"]).GetcustId() + "'";
                    int count = db.runCommand(cmd);

                    if (count < 0)
                    {
                        MessageBox.Show("Errorr!");
                    }
                    else
                    {
                        MessageBox.Show("successfully updated! ");
                        ((Form1)Application.OpenForms["Form1"]).GetCustomer();
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
                MessageBox.Show(" Fill and check all forms! ");   
            }
            
        }
    }
}
