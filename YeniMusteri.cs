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
    public partial class YeniMusteri : Form
    {
        public YeniMusteri()
        {
            InitializeComponent();
        }

        DbOperation op = new DbOperation();
        DataTable TblCust;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                if (namebox.Text!="" && surbox.Text!="" && adbox.Text!="" && telbox.Text!="")
                {
                    string command = "insert into Musteriler values('" + namebox.Text + "','" + surbox.Text + "','" + telbox.Text+ "','" + adbox.Text + "')";
                    count = op.runCommand(command);
                
                    if (count > 0)
                    {
                        MessageBox.Show(" Customer Added Successfully!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(" Errorr!");
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Fill and Check all forms!");
            }
        }
    }
}
