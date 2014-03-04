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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();           
        }
        DbOperation db = new DbOperation();
        public DataTable products,needed,supplier,supplies,sales,customers;    

        public void StokDurum()
        {
          
            string command = "select * from Urunler";
            //MessageBox.Show(command);
            products = db.SelectTable(command);
            dgStokdurum.DataSource = products;
            //DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            dgStokdurum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Refresh();
            if (products.Rows.Count == 0)
            {
                MessageBox.Show("Kayıt Bulunamadı");
            }
            ChangeColor();

                
        }
        public void ChangeColor()
        {
            for (int i = 0; i < dgStokdurum.Rows.Count; i++)
            {
                //if ((Convert.ToInt32(dgStokdurum.Rows[i].Cells[4].Value) < 500))

                    if ((Convert.ToInt32(dgStokdurum.Rows[i].Cells["Quantity"].Value)) <50)
                {
                    dgStokdurum.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            StokDurum();
            GosTed();
            TedarikGoster();
            GetSales();
            GetCustomer();
            ChangeColor();
          

            ImageList imageList1 = new ImageList();
            imageList1.Images.Add("key1", Image.FromFile(@"C:\Users\ZuckerBerg\Documents\Visual Studio 2012\Projects\TermProject\TermProject\bin\Debug\supplier3.png"));
            imageList1.Images.Add("key2", Image.FromFile(@"C:\Users\ZuckerBerg\Documents\Visual Studio 2012\Projects\TermProject\TermProject\bin\Debug\shine1.png"));
            imageList1.Images.Add("key3", Image.FromFile(@"C:\Users\ZuckerBerg\Documents\Visual Studio 2012\Projects\TermProject\TermProject\bin\Debug\1370199636_Usercard_01.png"));
            imageList1.Images.Add("key4", Image.FromFile(@"C:\Users\ZuckerBerg\Documents\Visual Studio 2012\Projects\TermProject\TermProject\bin\Debug\1370199413_inventory-maintenance.png"));
            imageList1.Images.Add("key5", Image.FromFile(@"C:\Users\ZuckerBerg\Documents\Visual Studio 2012\Projects\TermProject\TermProject\bin\Debug\1370199449_user_male.png"));


            //initialize the tab control
           
            tabControl1.ImageList = imageList1;
            //tabControl1.SelectedTab.ImageKey = "key1";
            tabControl1.TabPages[0].ImageKey = "key1";
            tabControl1.TabPages[1].ImageKey = "key2";
            tabControl1.TabPages[2].ImageKey = "key3";
            tabControl1.TabPages[3].ImageKey = "key4";
            tabControl1.TabPages[4].ImageKey = "key5";

            //tabControl1.TabPages.Add("tabKey1", "TabText1", "key1"); // icon using ImageKey
            //tabControl1.TabPages.Add("tabKey2", "TabText2", 1);      // icon using ImageIndex
            this.Controls.Add(tabControl1);

        }
        private void button7_Click(object sender, EventArgs e)
        {
            StokDurum();
      
        }
        private void GetSales()
        {
            string command = "select * from Satislar";
            sales = db.SelectTable(command);
            dataGridView2.DataSource = sales;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;   
        
        
        }
        public void GetCustomer()
        {
            string command = "select * from Musteriler";
            customers = db.SelectTable(command);
            dgcustomer.DataSource = customers;
            dgcustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            YeniUrun yeni = new YeniUrun();
            yeni.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to delete the Product Record ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string command = "delete from Urunler where UrunId='" +
               dgStokdurum.SelectedRows[0].Cells[0].Value.ToString() + "'";
                db.runCommand(command);
                int count = db.runCommand(command);

                if (count < 0)
                {
                    MessageBox.Show("Errorr!");
                }
                else
                {
                    MessageBox.Show("successfully deleted! ");
                }
            }
            else if (dialog == DialogResult.No)
            {
                //don't do anything
            }           
           
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string command = "select * from Urunler where Quantity<50";
            needed = db.SelectTable(command);
            dgStokdurum.DataSource = needed;

            for (int i = 0; i < dgStokdurum.Rows.Count; i++)
            {
                if ((Convert.ToInt32(dgStokdurum.Rows[i].Cells["Quantity"].Value)) < 50)
                {
                    dgStokdurum.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            dgStokdurum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Refresh();
            if (needed.Rows.Count == 0)
            {
                MessageBox.Show("No Record!");
            }   
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GosTed();
        }


        public void TedarikGoster()
        {
            string command = "select * from Tedarikler";
            supplies = db.SelectTable(command);
            dgtedarikler.DataSource = supplies;
            dgtedarikler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Refresh();

            if (supplier.Rows.Count == 0)
            {
                MessageBox.Show("No Record!");
            }       
        
        }
        public void GosTed()
        {
            string command = "select * from Tedarikciler";
            supplier = db.SelectTable(command);
            dgtedarikci.DataSource = supplier;
            dgtedarikci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Refresh();

            if (supplier.Rows.Count == 0)
            {
                MessageBox.Show("No Record!");
            }       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniTedarikci ted1 = new YeniTedarikci();
            ted1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to delete the Supplier Record ?", "Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                string command = "delete from Tedarikciler where SupId='" + dgtedarikci.SelectedCells[0].Value.ToString() + "'";
                db.runCommand(command);
                int count = db.runCommand(command);

                if (count < 0)
                {
                    MessageBox.Show("Errorr!");
                }
                else
                {
                    MessageBox.Show("successfully deleted! ");
                }
            }
            else if (dialog == DialogResult.No)
            {
                //don't do anything
            }           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GunTed gun = new GunTed();
            gun.Show();
        }
        public string GetId()
        {
            return dgtedarikci.SelectedCells[0].OwningRow.Cells[0].Value.ToString();  
        }
        public string GetName()
        {
            return dgtedarikci.SelectedCells[0].OwningRow.Cells[1].Value.ToString();          
        }
        public string GetTel()
        {
            return dgtedarikci.SelectedCells[0].OwningRow.Cells[2].Value.ToString();
        }
        public string GetAdd()
        {
            return dgtedarikci.SelectedCells[0].OwningRow.Cells[3].Value.ToString();
        }

        /// <summary>
        /// customer'ın metodları
        /// </summary>
        /// <returns></returns>
        /// 

        public string SalesCusID()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
        }
        public string SalesCusName()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
        }
        public string SalesProId()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[3].Value.ToString();
        }
        public string SalesProName()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[4].Value.ToString();
        }
        public string SalesDate()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[5].Value.ToString();
        }
        public string SalesQuant()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[6].Value.ToString();
        }
        public string Amount()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[7].Value.ToString();
        }
        public string GetcustId()
        {
            return dgcustomer.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
        }
        public string GetcustName()
        {
            return dgcustomer.SelectedCells[0].OwningRow.Cells[1].Value.ToString();   
        }
        public string GetSurName()
        {
            return dgcustomer.SelectedCells[0].OwningRow.Cells[2].Value.ToString();
        }
        public string GetcustTel()
        {
            return dgcustomer.SelectedCells[0].OwningRow.Cells[3].Value.ToString();
        }
        public string Getcustad()
        {
            return dgcustomer.SelectedCells[0].OwningRow.Cells[4].Value.ToString();
        }
        
        public string GetSalesCusName()
        { 
            return dataGridView2.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
        }
        public string GetSalesCusId()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
        }
        public string GetSalesCusSurName()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[2].Value.ToString();
        }
        public string GetSalesCusQuant()
        {
            return dataGridView2.SelectedCells[0].OwningRow.Cells[6].Value.ToString();
        }
        public string tName()
        {
            return dgtedarikler.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
        }
        public string pName()
        {
            return dgtedarikler.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
        }
        public string tDate()
        {
            return dgtedarikler.SelectedCells[0].OwningRow.Cells[2].Value.ToString();
        }
        public string Tqunat()
        {
            return dgtedarikler.SelectedCells[0].OwningRow.Cells[3].Value.ToString();
        }
        public string Tamount()
        {
            return dgtedarikler.SelectedCells[0].OwningRow.Cells[4].Value.ToString();
        }
        


        private void exitAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu1ToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
           
        }

        private void ü(object sender, EventArgs e)
        {

        }

        private void menu1ToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
                    
        }

        private void menu1ToolStripMenuItem_DropDownOpened_1(object sender, EventArgs e)
        {
            menu1ToolStripMenuItem.ForeColor = Color.SlateBlue;
            menu1ToolStripMenuItem.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void menu1ToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            menu1ToolStripMenuItem.ForeColor = Color.White;
            menu1ToolStripMenuItem.Font = new Font(this.Font, FontStyle.Regular);
        }

        private void menu2ToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            menu2ToolStripMenuItem.ForeColor = Color.SlateBlue;
            menu2ToolStripMenuItem.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void menu2ToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            menu2ToolStripMenuItem.ForeColor = Color.White;
            menu2ToolStripMenuItem.Font = new Font(this.Font, FontStyle.Regular);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TedarikEt tdk = new TedarikEt();
            tdk.Show();
            TedarikGoster();
        }

        private void dgStokdurum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgtedarikci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            SatisGuncelle sts = new SatisGuncelle();
            sts.Show();
        }

        private void button13_Click(object sender, EventArgs e)//satış sil
        {
            DialogResult dialog = MessageBox.Show("Do you really want to delete the Supplying Record ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {               

                string command=" delete from Satislar where CusId='"+dataGridView2.Rows[dataGridView2.CurrentCellAddress.Y].Cells[0].Value.ToString()+
 "' AND CusName='" + dataGridView2.Rows[dataGridView2.CurrentCellAddress.Y].Cells[1].Value.ToString() + "'AND CusSurname='" + dataGridView2.Rows[dataGridView2.CurrentCellAddress.Y].Cells[2].Value.ToString() + "'AND ProID='" + dataGridView2.Rows[dataGridView2.CurrentCellAddress.Y].Cells[3].Value.ToString() + "' AND Amount='" + dataGridView2.Rows[dataGridView2.CurrentCellAddress.Y].Cells[7].Value.ToString() + "'";

                db.runCommand(command);
                int count = db.runCommand(command);

                if (count < 0)
                {
                    MessageBox.Show("Errorr!");
                }
                else
                {
                    MessageBox.Show("successfully deleted! ");
                }
                GetSales();

            }
            else if (dialog == DialogResult.No)
            {
                //don't do anything
            }                    
        }

        private void searchSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menu3ToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            menu3ToolStripMenuItem.ForeColor = Color.SlateBlue;
            menu3ToolStripMenuItem.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void menu3ToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            menu3ToolStripMenuItem.ForeColor = Color.White;
            menu3ToolStripMenuItem.Font = new Font(this.Font, FontStyle.Regular);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SatisYap st = new SatisYap();
            st.Show();
            GetSales();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            YeniMusteri mus = new YeniMusteri();
            mus.Show();
            GetCustomer();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UpdateCustomer up = new UpdateCustomer();
            up.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dgcustomer.Refresh();
            GetCustomer();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to delete the Customer Record ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                string command = "delete from Musteriler where CusId='" + dgcustomer.SelectedCells[0].Value.ToString() + "'";
                db.runCommand(command);
                int count = db.runCommand(command);

                if (count < 0)
                {
                    MessageBox.Show("Errorr!");
                }
                else
                {
                    MessageBox.Show("successfully deleted! ");
                }
                dgcustomer.Refresh();
                GetCustomer();
            }
            else if (dialog == DialogResult.No)
            {
                //don't do anything
            }           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TedarikGüncelle tdg = new TedarikGüncelle();
            tdg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to delete the Supplying Record ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                string command = "delete from Tedarikler where SupName='" + dgtedarikler.Rows[dgtedarikler.CurrentRow.Index].Cells[0].Value.ToString() + "' AND ProName='" + dgtedarikler.Rows[dgtedarikler.CurrentRow.Index].Cells[1].Value.ToString() + "' AND amount='" + dgtedarikler.Rows[dgtedarikler.CurrentRow.Index].Cells[4].Value.ToString() + "'";
                db.runCommand(command);
                int count = db.runCommand(command);

                if (count < 0)
                {
                    MessageBox.Show("Errorr!");
                }
                else
                {
                    MessageBox.Show("successfully deleted! ");
                }
                TedarikGoster();
          
            }
            else if (dialog == DialogResult.No)
            {
                //don't do anything
            }           
        }

        private void searchByIdToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Search src = new Search();
            src.Show();
            src.label1.Text = "Search Supplier By Id";           
        }

        private void deficitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deficit_Report dfc = new Deficit_Report();
            dfc.Show();
        }

        private void searchByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search src = new Search();
            src.Show();
            src.label1.Text = "Search Supplier By Name";   
        }

        private void searchByTelephoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search src = new Search();
            src.Show();
            src.label1.Text = "Search Supplier By Telephone";   
        }

        private void searchByNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search src = new Search();
            src.Show();
            src.label1.Text = "Search Customer By Name";
        }

        private void searchByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datecs dt = new Datecs();
            dt.Show();
            dt.label3.Text = "Search Supplies By Date";
        }

        private void searchByDateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Datecs dt = new Datecs();
            dt.Show();
            dt.label3.Text = "Search Sales By Date";
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datecs dt = new Datecs();
            dt.Show();
            dt.label3.Text = "Sales Report";
        }

        private void supplyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datecs dt = new Datecs();
            dt.Show();
            dt.label3.Text = "Supply Report";
        }

    }
}
