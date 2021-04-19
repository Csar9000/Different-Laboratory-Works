using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string Col = "";
                if (this.radioButton1.Checked)
                    Col = this.radioButton1.Text;
                if (this.radioButton2.Checked)
                    Col = this.radioButton2.Text;
                if (this.radioButton3.Checked)
                    Col = this.radioButton3.Text;
                if (this.radioButton4.Checked)
                    Col = this.radioButton4.Text;
                if (this.radioButton5.Checked)
                    Col = this.radioButton5.Text;
                MessageBox.Show("Вы выбрали марку автомобиля: "+ Col);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Col = "";
            string Col1 = "";
            string Col2 = "";
            string Col3 = "";
            string Col4 = "";
            string Col5 = "";
            if (this.checkBox1.Checked)
                Col = this.checkBox1.Text + " ";
            if (this.checkBox2.Checked)
                Col1 = this.checkBox2.Text + " ";
            if (this.checkBox3.Checked)
                Col2 = this.checkBox3.Text + " ";
            if (this.checkBox4.Checked)
                Col3 = this.checkBox4.Text + " ";
            if (this.checkBox5.Checked)
                Col4 = this.checkBox5.Text + " ";
            if (this.checkBox6.Checked)
                Col5= this.checkBox6.Text + " ";
            MessageBox.Show( "Ваши любимые виды животных:  "  + Col + Col1 + Col2 + Col3 + Col4 + Col5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool IsDigit1 = Regex.IsMatch(maskedTextBox1.Text, @"^[0-9]{1,8}[,]{0,1}[0-9]{0,8}$");
            bool IsDigit2 = maskedTextBox2.Text.All(char.IsDigit);
            if ((IsDigit1 == true)&&(IsDigit2==true))
            {
                if (!String.IsNullOrEmpty(maskedTextBox1.Text)
                    || !String.IsNullOrWhiteSpace(maskedTextBox1.Text)
                    || !String.IsNullOrEmpty(maskedTextBox2.Text)
                    || !String.IsNullOrWhiteSpace(maskedTextBox2.Text))
                {
                    float cost = float.Parse(maskedTextBox1.Text);
                    float number = float.Parse(maskedTextBox2.Text);
                    float buy = cost * number;
                    textBox1.Text = (Convert.ToString(buy));
                }
            }
            else
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void анимацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void информацияПоЭкзаменамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
