using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Строка не заполнена!");
            }
            else
            {
                listBox1.Items.Clear();
                checkedListBox1.Items.Clear();
                string[] st = string_to_arr(textBox1.Text);
                foreach (string s in st)
                {
                    if (!String.IsNullOrEmpty(s))
                    {
                        this.listBox1.Items.Add(s + "(" + s.Length + ")");
                    }
                }
                for (int i = 0; i < st.Length; i++)
                {
                    if (!String.IsNullOrEmpty(st[i]))
                    {
                        checkedListBox1.Items.Add(st[i]);
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int j = 0;
            string Elem;
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                this.listBox2.Items.Clear();
                for (j = 0; j < this.checkedListBox1.Items.Count; j++)
                {
                    if (checkedListBox1.GetItemChecked(j))
                    {
                        Elem = this.checkedListBox1.Items[j].ToString();
                        this.listBox2.Items.Add(Elem);

                    }
                }
            }
            else
            {
                MessageBox.Show("Отметьте  слова для выбора");
            }
        }

        static string[] multiply(string digit_str)
        {
            digit_str = CheckNum(digit_str);
            if (digit_str != string.Empty)
            {
                string[] MultArr = digit_str.Split(',');

                for (int i = 0; i < MultArr.Length; i++)
                {
                    MultArr[i] = 5 + " * " + MultArr[i] + " = " + 5 * Convert.ToInt32(MultArr[i]);
                }
                return MultArr;
            }
            else
            {
                MessageBox.Show("В строке нет цифровых слов!");
                return null;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Строка не заполнена!");
            }
            else if (multiply(textBox1.Text) != null)
            {
                comboBox1.Items.AddRange(multiply(textBox1.Text));
            }
        }

        static string[] string_to_arr(string orig_str)
        {
            if (orig_str.Contains("."))
            {
                orig_str = orig_str.Replace(".", "");
            }
            string[] Arr = orig_str.Split(',');
            return Arr;
        }

        static string CheckNum(string orig_str)
        {
            int num;
            string[] str_arr = string_to_arr(orig_str);
            string r = "";
            for (int i = 0; i < str_arr.Length; i++)
            {
                if (int.TryParse(str_arr[i], out num) == true)
                {
                    r += str_arr[i] + ",";
                }
            }
            if (r != string.Empty)
            {
                int index = r.LastIndexOf(',');
                r = r.Remove(r.LastIndexOf(','), 1);
            }
            return r;
        }

        static string delete_num(string orig_str)
        {
            string str_red="";
            string[] str_array = string_to_arr(orig_str);
            char[] s;
            for (int i = 0; i < str_array.Length; i++)
            {
                s = str_array[i].ToCharArray();
                for (int j=0;j<s.Length;j++)
                {
                    if (Char.IsDigit(s[j]))
                    {
                        str_array[i] = "";
                    }
                }
                if (str_array[i]!="")
                {
                    str_red += str_array[i]+",";
                }
            }
            if (str_red.Length > 0)
            {
                str_red = str_red.Replace(",,", "");
                if (str_red[0] == ',')
                {
                    str_red = str_red.Replace(Convert.ToString(str_red.First()), "");
                }
                if (str_red.Contains(",."))
                {
                    str_red = str_red.Remove(str_red.LastIndexOf(","));
                    str_red += ".";
                }
            }
            return str_red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Строка не заполнена!");
            }
            else
            {
                textBox1.Text = delete_num(textBox1.Text);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                comboBox1.Items.Clear();
            }
        }
    }
}
