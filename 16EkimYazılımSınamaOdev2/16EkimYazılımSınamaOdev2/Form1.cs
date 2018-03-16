using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16EkimYazılımSınamaOdev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int fareKonumX, fareKonumY;
        int nekoyayim = 0;
        //int nesileyim = 0;
        int mcount = 0;
        int ccount = 0;
       // int ecount = 0;
        int lcount = 0;
        int i = 0;
        int j = 0;
        //int ayrı = 0;
        String faresakla = " ";
        String peynirsakla = " ";
       


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            int i, j;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (j = 0; j < 15; j++)
            {
                DataGridViewImageColumn resim = new DataGridViewImageColumn();
                resim.ToolTipText = "5000";
                dataGridView1.Columns.Add(resim);
            }
            for (i = 0; i < 15; i++)
            {
                dataGridView1.Rows.Add(" ");
                DataGridViewRow row = dataGridView1.Rows[i];
                row.Height = 30;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.RowIndex == 0 || cell.RowIndex == 15 || cell.ColumnIndex == 0 || cell.ColumnIndex == 14)
                    {
                        cell.Value = Properties.Resources.la1;
                        cell.ToolTipText = "5000";
                    }
                    else
                    {
                        cell.Style.BackColor = Color.LightYellow;
                        cell.Value = Properties.Resources.af;
                        cell.ToolTipText = "0";
                    }
                }
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = 30;
            }
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nekoyayim = 1;
        }

        private void dataGRidView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //x in koordinatını bulma
            int xkoordinat = dataGridView1.CurrentCellAddress.X;
            // y nin koordinatını bulma
            int ykoordinat = dataGridView1.CurrentCellAddress.Y;

            // test Doluluk kontrolünü tekrar etmişsiniz. Birden çok kez. Bunu çöz.
            
            if (dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText != "0")
            {
                bool exit = true;
                if (dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText == "1" || dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText == "-1")
                {
                    exit = false;
                }
                if (exit == true)
                {
                    MessageBox.Show("Burası Doludur.!");
                    return;
                }
            }



            if (nekoyayim == 1)
            {
                    DataGridViewImageCell resim = new DataGridViewImageCell();
                    resim.Value = Properties.Resources.la1;
                    resim.ToolTipText = "5000";
                    dataGridView1.Rows[ykoordinat].Cells[xkoordinat] = resim;
                    lcount++;
            }
            else if (nekoyayim == 2)
            {
                if (mcount == 0)
                {
                    if (dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText == "0")
                    {
                        DataGridViewImageCell resim = new DataGridViewImageCell();
                        resim.Value = Properties.Resources.fare;
                        resim.ToolTipText = "1";

                        fareKonumY = e.RowIndex;
                        fareKonumX = e.ColumnIndex;

                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat] = resim;
                        faresakla = Convert.ToString(dataGridView1.Rows[ykoordinat].Cells[xkoordinat]);
                        mcount++;
                    }
                    else {

                        MessageBox.Show("Burası Doludur..");
                    
                    }
                }
                else
                {
                    MessageBox.Show("Oyun Kuralları Gereği 1 Fare Koyulabilir. !!!");
                }
            }
            else if (nekoyayim == 3)
            {
                if (ccount == 0)
                {
                    if (dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText == "0")
                    {
                        DataGridViewImageCell resim = new DataGridViewImageCell();

                        resim.Value = Properties.Resources.cheese;
                        resim.ToolTipText = "-1";
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat] = resim;
                        peynirsakla = Convert.ToString(dataGridView1.Rows[ykoordinat].Cells[xkoordinat]);

                        ccount++;
                    }
                    else
                    {

                        MessageBox.Show("Burası Doludur..");
                    
                    }
                }
                else
                {
                    MessageBox.Show("Oyun Kuralı Gereği 1 Peynir Olabilir .!!!");
                }
            }
            else if (nekoyayim == 4)
            {
                

                if (lcount > 0 )
                {
                        DataGridViewImageCell resim = new DataGridViewImageCell();
                        resim.Value = Properties.Resources.af;
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat] = resim;
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText = "0";
                        lcount--;
                   }
                    

                
                else
                {
                    MessageBox.Show("Silinecek labirent bulunamamaktadır.");
                }
            }
    
            else if (nekoyayim == 5)
            {

                if (mcount == 1 )
                {
                    if (dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText == "1")
                    {
                        DataGridViewImageCell resim = new DataGridViewImageCell();

                        resim.Value = Properties.Resources.af;
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat] = resim;
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText = "0";
                        mcount = 0;

                    }
                    else {

                        MessageBox.Show("Bu bir fare değildir !!!");
                    
                    }

               
                }
                else
                {
                    MessageBox.Show("Silinecek fare bulunamamaktadır.");
                }
            }
            else if (nekoyayim == 6)
            { 

                if(ccount ==1)
                {
                if (dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText == "-1")
                    {
                        DataGridViewImageCell resim = new DataGridViewImageCell();

                        resim.Value = Properties.Resources.af;
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat] = resim;
                        dataGridView1.Rows[ykoordinat].Cells[xkoordinat].ToolTipText = "0";
                        ccount = 0;

                    }
                
                    else {

                        MessageBox.Show("Bu bir peynir değildir. !!!");
                    
                    }

               
                }
                else
                {
                    MessageBox.Show("Silinecek peynir bulunamamaktadır.!!!");
                }
            }
        }

        private void FARE_Click(object sender, EventArgs e)
        {
            nekoyayim = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nekoyayim = 3;

        }

        private void sil_Click(object sender, EventArgs e)
        {
            nekoyayim = 4;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nekoyayim = 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nekoyayim = 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    DataGridViewImageCell res4 = new DataGridViewImageCell();
                    res4.Value = Properties.Resources.af;
                    dataGridView1.Rows[i].Cells[j] = res4;

                    if (i == 0)
                    {

                        DataGridViewImageCell res = new DataGridViewImageCell();
                        res.Value = Properties.Resources.la1;
                        dataGridView1.Rows[i + 1].Cells[j] = res;
                    }

                    else if (j == 0)
                    {
                        DataGridViewImageCell res = new DataGridViewImageCell();
                        res.Value = Properties.Resources.la1;
                        dataGridView1.Rows[i].Cells[j] = res;
                    }

                    else if (j == 14)
                    {
                        DataGridViewImageCell res = new DataGridViewImageCell();
                        res.Value = Properties.Resources.la1;
                        dataGridView1.Rows[i].Cells[j] = res;
                    }
                    else if (i == 14)
                    {
                        DataGridViewImageCell res = new DataGridViewImageCell();
                        res.Value = Properties.Resources.la1;
                        dataGridView1.Rows[i - 14].Cells[j] = res;
                    }

                    DataGridViewImageCell res1 = new DataGridViewImageCell();
                    res1.Value = Properties.Resources.la1;
                    dataGridView1.Rows[0].Cells[0] = res1;

                    DataGridViewImageCell res2 = new DataGridViewImageCell();
                    res2.Value = Properties.Resources.la1;
                    dataGridView1.Rows[0].Cells[14] = res2;

                }
                mcount = 0;
                ccount = 0;

            }
     

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mcount != 1 || ccount != 1)
            {
                MessageBox.Show("Oyunun başlaması için  1 fare ve  1  peynir olmalıdır.");
                return;
            }
            dataGridView1.Enabled = false;
            timer1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            FARE.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            timer1.Start();
            // test Labirentte fare ve peynir 1 tane mi? Yoksa kim kimi arar?

        }

        public string HareketYonu()
        {
            int ust=0, sol=0, sag=0, alt=0;
            string yon = "";
            ust = Convert.ToInt32(dataGridView1.Rows[fareKonumY - 1].Cells[fareKonumX].ToolTipText);
            alt = Convert.ToInt32(dataGridView1.Rows[fareKonumY + 1].Cells[fareKonumX].ToolTipText);
            sol = Convert.ToInt32(dataGridView1.Rows[fareKonumY].Cells[fareKonumX - 1].ToolTipText);
            sag = Convert.ToInt32(dataGridView1.Rows[fareKonumY].Cells[fareKonumX + 1].ToolTipText);
            
            if (ust <= sol && ust <= sag && ust <= alt)
            {
                if (ust != 5000)
                    yon = "ust";
            }
            else if (sol <= ust && sol <= sag && sol <= alt)
            {
                if (sol != 5000)
                    yon = "sol";
            }
            else if (sag <= ust && sag <= sol && sag <= alt)
            {
                if (sag != 5000)
                    yon = "sag";
            }
            else if (alt <= ust && alt <= sol && alt <= ust)
            {
                if (alt != 5000)
                    yon = "alt";
            }
            return yon;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tooltip = 0;
            string yon = HareketYonu();
            

            DataGridViewImageCell yenifare = new DataGridViewImageCell();
            yenifare.Value = Properties.Resources.fare;

            if (yon == "ust")
            {
                tooltip = Convert.ToInt32(dataGridView1.Rows[fareKonumY - 1].Cells[fareKonumX].ToolTipText);
                if (tooltip == -1)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show("Peynir bulundu.");
                
                }
                tooltip++;
                yenifare.ToolTipText = tooltip.ToString();
                dataGridView1.Rows[fareKonumY - 1].Cells[fareKonumX] = yenifare;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Style.BackColor = Color.LightYellow;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Value = Properties.Resources.asfalt2;
                fareKonumY--;
            }
            else if (yon == "sol")
            {
                tooltip = Convert.ToInt32(dataGridView1.Rows[fareKonumY].Cells[fareKonumX - 1].ToolTipText);
                if (tooltip == -1)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show("Peynir bulundu.");
                }
                tooltip++;
                yenifare.ToolTipText = tooltip.ToString();
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX - 1] = yenifare;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Style.BackColor = Color.LightYellow;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Value = Properties.Resources.asfalt2;
                fareKonumX--;
            }
            else if (yon == "sag")
            {
                tooltip = Convert.ToInt32(dataGridView1.Rows[fareKonumY].Cells[fareKonumX + 1].ToolTipText);
                if (tooltip == -1)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show("Peynir bulundu.");
                }
                tooltip++;
                yenifare.ToolTipText = tooltip.ToString();
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX + 1] = yenifare;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Style.BackColor = Color.LightYellow;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Value = Properties.Resources.asfalt2;
                fareKonumX++;
            }
            else if (yon == "alt")
            {
                tooltip = Convert.ToInt32(dataGridView1.Rows[fareKonumY + 1].Cells[fareKonumX].ToolTipText);
                if (tooltip == -1)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show("Peynir bulundu.");
                }
                tooltip++;
                yenifare.ToolTipText = tooltip.ToString();
                dataGridView1.Rows[fareKonumY + 1].Cells[fareKonumX] = yenifare;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Style.BackColor = Color.LightYellow;
                dataGridView1.Rows[fareKonumY].Cells[fareKonumX].Value = Properties.Resources.asfalt2;
                fareKonumY++;
                
            }
            else
            {
                
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show("Nereye gidecegim bilmiyorum?");
                
                // Tst Yön geçersiz.
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult cikti = MessageBox.Show("Çıkmak istediğinize emin misiniz ?", "Çıkış", MessageBoxButtons.YesNoCancel);

            if (cikti == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (cikti == DialogResult.No)
            {

            }
            if (cikti == DialogResult.Cancel)
            {
                

            }
        }
    }
}
