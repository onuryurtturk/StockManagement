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
    public partial class YeniTedarikci : Form
    {
        public YeniTedarikci()
        {
            InitializeComponent();
        }

        DbOperation op = new DbOperation();

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "insert into Tedarikciler values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')";
            int count = op.runCommand(command);

            if (count<0)
            {
                MessageBox.Show("Error!");
            }
            else
            {   
                MessageBox.Show("Successfully inserted!");
                this.Close();
            }
        }
    }
}
