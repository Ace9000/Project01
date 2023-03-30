using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dddd dd-MM-yyyy HH:mm:ss");
        }

        private void txt_br1_TextChanged(object sender, EventArgs e)
        {
            Int32 i;
            Int32.TryParse(txt_br1.Text, out i);
            txt_br2.Text = txt_br1.Text;
            txt_br2.Text = i.ToString("#,##");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal i = 0;
            Boolean b;
            b = decimal.TryParse(textBox2.Text, out i);
            if(b == true)
            {
                MessageBox.Show($"This is Number {i}");
            }
            else
            {
                MessageBox.Show($"This is Not Number {i}");
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sure", "Exit", MessageBoxButtons.OKCancel,MessageBoxIcon.Error,MessageBoxDefaultButton.Button2);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox3.Text.Length.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string t;
            t = textBox3.Text;
            textBox4.Text = textBox3.Text.Length.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "...";
            //01/02/2021 = lenght = 10
            if (txtDate.Text.Trim().Length == 10)
            {
                DateTime DataXX; // = DateTime.Now.AddYears(-1);

                try
                {
                    DataXX = Convert.ToDateTime(txtDate.Text + " 00:00:01");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                    return;
                }

                txtDD.Text = txtDate.Text.Substring(0, 2);
                txtMM.Text = txtDate.Text.Substring(3, 2);
                txtGG.Text = txtDate.Text.Substring(6, 4);

                string str_mesec = "...";
                Int16 i_mesec;
                Int16.TryParse(txtMM.Text, out i_mesec);

                switch (i_mesec)
                {
                    case 1:
                        str_mesec = "Januari";
                        break;
                    case 2:
                        str_mesec = "Februari";
                        break;
                    case 3:
                        str_mesec = "Mart";
                        break;
                    case 4:
                        str_mesec = "April";
                        break;
                    case 5:
                        str_mesec = "Maj";
                        break;
                    case 6:
                        str_mesec = "Juni";
                        break;
                    case 7:
                        str_mesec = "Juli";
                        break;
                    case 8:
                        str_mesec = "Avgust";
                        break;
                    case 9:
                        str_mesec = "Septemvri";
                        break;
                    case 10:
                        str_mesec = "Oktomvri";
                        break;
                    case 11:
                        str_mesec = "Noemvri";
                        break;
                    case 12:
                        str_mesec = "Dekemvri";
                        break;                        
                }
                lblMM.Text = str_mesec;

                if (i_mesec <= 12)
                {
                    // isto kako 'case' samo sega so niza
                    string[] NizaMeseci = { "Januar", "Februar", "MArt", "April", "Maj", "Juni", "Juli", "Avgust", "Septemvri", "Oktomvri", "Noemvri", "Dekemvri" };
                    lblMM2.Text = NizaMeseci[i_mesec - 1];

                    // i ova moze ama ne se preporacuva
                    string[] NizaMeseci2 = { "", "Januar", "Februar", "MArt", "April", "Maj", "Juni", "Juli", "Avgust", "Septemvri", "Oktomvri", "Noemvri", "Dekemvri" };
                    lblMM2.Text = NizaMeseci2[i_mesec - 0];

                }
                else
                {
                    txtMM.Text = ""; lblMM2.Text = "";
                }
               
            }
            else
            {
                toolStripStatusLabel2.Text = "Gresna data ... nemate 10 karakteri";
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "...";
            DateTime DataXX;

            try
            {
                DataXX = Convert.ToDateTime($"{txtDD.Text}.{txtMM.Text}.{txtGG.Text} 00:00:01");    // txtDD.Text + "." + txtMM.Text + " 00:00:01");
                toolStripStatusLabel2.Text = "Ok data ...";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = "Gresna data ...";
                MessageBox.Show($"{ex.Message}");
                return;
            }

            dateTimePicker1.Value = DataXX;

            string xxs = $"{DataXX.Day.ToString("00")}.{DataXX.Month.ToString("00")}.{DataXX.Year}";
            txtDate.Text = xxs;

        }
        private void button7_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "...";
            DateTime d1 = new DateTime(dtpOd.Value.Year, dtpOd.Value.Month, dtpOd.Value.Day, 1, 1, 1);
            DateTime d2 = new DateTime(dtpDo.Value.Year, dtpDo.Value.Month, dtpDo.Value.Day, 1, 1, 1);

            var iRazlika = (d2 - d1).TotalDays;

            string sRazlika = $"{iRazlika}";
            txtRazlika.Text = sRazlika;

            if (iRazlika >= 0)
            {

                for (int i = 0; i <= iRazlika; i++)
                {
                    DateTime xxD = d1.AddDays(i);
                    MessageBox.Show($"Zemam podatoci za: {xxD}");

                }
            }
            else
            {
                toolStripStatusLabel2.Text = "Gresna razlika ...";
            }

        }
    }
}
