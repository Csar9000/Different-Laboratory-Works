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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            maskedTextBox6.Mask = "L.L.LLLLLLLLLL";// маска для Ф.И.О преподавателя
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int num;

            string inputTeacherName = maskedTextBox6.Text;
            inputTeacherName = inputTeacherName.Replace(" ","");
            inputTeacherName = inputTeacherName.Replace(",", ".");
            MessageBox.Show(inputTeacherName);
            bool SubjectNameCheck = Regex.IsMatch(textBox1.Text,@"[А-Яа-я]");// создаём шаблон для проверки введённой строки textBox1 
            bool TeacherNameCheck = Regex.IsMatch(inputTeacherName, @"[А-Я]{1}[.]{1}[А-Я]{1}[.]{1}[А-Я]{1}[а-я]{2,10}");// создаём шаблон для проверки введённой строки maskedTextBox6
            if (int.TryParse(maskedTextBox1.Text, out num) == false
                || int.TryParse(maskedTextBox2.Text, out num) == false
                || int.TryParse(maskedTextBox3.Text, out num) == false
                || int.TryParse(maskedTextBox4.Text, out num) == false
                || int.TryParse(maskedTextBox5.Text, out num) == false)
            {
                MessageBox.Show("Заполните все поля соотвествующими данными!");
            }
            else 
            {
                if (SubjectNameCheck == false)
                {
                    MessageBox.Show("Введите корректно название учебного предмета!");
                }
                if (TeacherNameCheck == false)
                {
                    MessageBox.Show("Введите корректно Ф.И.О. преподавателя!");
                }
                else
                {
                    string sum = Convert.ToString(Convert.ToInt32(maskedTextBox1.Text) + Convert.ToInt32(maskedTextBox2.Text) +
                            Convert.ToInt32(maskedTextBox3.Text) + Convert.ToInt32(maskedTextBox4.Text) + Convert.ToInt32(maskedTextBox5.Text));// нахождение общего количества студентов

                    dataGridView1.Rows.Add(textBox1.Text, maskedTextBox6.Text, Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text),
                        Convert.ToInt32(maskedTextBox3.Text), Convert.ToInt32(maskedTextBox4.Text), Convert.ToInt32(maskedTextBox5.Text), sum);// ввод в dataGridView1
                }
            }
        }
    }
}
