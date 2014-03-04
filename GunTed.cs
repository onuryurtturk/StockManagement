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
    public partial class GunTed : Form
    {
        public GunTed()
        {
            InitializeComponent();
        }
        DbOperation db = new DbOperation();

        private void GunTed_Load(object sender, EventArgs e)
        {
            textBox1.Text = ((Form1)Application.OpenForms["Form1"]).GetName();
            textBox2.Text = ((Form1)Application.OpenForms["Form1"]).GetTel();
            textBox3.Text = ((Form1)Application.OpenForms["Form1"]).GetAdd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command="update Tedarikciler set SupName='"+textBox1.Text+"', SupTel='"+
              
            textBox2.Text + "', SupAddress='" + textBox3.Text + "' where SupId='" + ((Form1)Application.OpenForms["Form1"]).GetId()+"'";
            int count= db.runCommand(command);
           
            if (count < 0)
            {
                MessageBox.Show("Errorr!");
            }
            else
            {
                MessageBox.Show("successfully updated! ");
                ((Form1)Application.OpenForms["Form1"]).GosTed();
                this.Close();
            }
        }
    }
}
