using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FourthLabWorkInheritance_Handing_out_gadgets
{
    public partial class Form1 : Form
    {
        List<Gadget> gadgetsList = new List<Gadget>();// лист гаджетов
        public Form1()
        {
            InitializeComponent();
            ShowInfo();// показываем, что при запуске программы в списке гаджетов ничего нет
        }

        private void btmRefill_Click(object sender, EventArgs e)// кнопка перезаполнить
        {
            listBox1.Items.Clear();// чистим список справа
            this.gadgetsList.Clear();// чистим список гаджетов
            var rnd = new Random();
            for (var i = 0; i < 20; ++i)// генерируем случайным образом 20 гаджетов
            {
                switch (rnd.Next() % 3) 
                {
                    case 0: 
                        this.gadgetsList.Add(Laptop.Generate());// ноубуки
                        break;
                    case 1: 
                        this.gadgetsList.Add(Tablet.Generate());// планшеты
                        break;
                    case 2:
                        this.gadgetsList.Add(Smartphone.Generate());// смартфоны
                        break;
                }
                // заполняем список справа значениями из списка гаджетов, если объект...
                if (gadgetsList[i] is Laptop)// ..ноутбук, то записыввам в список ноутбук
                {
                    listBox1.Items.Add("Ноутбук");
                }
                else if (gadgetsList[i] is Tablet)// ..планшет, то записыввам в список планшет
                {
                    listBox1.Items.Add("Планшет");
                }
                else if (gadgetsList[i] is Smartphone)// ..смартфон, то записыввам в список смартфон
                {
                    listBox1.Items.Add("Смартфон");
                }
            }
            ShowInfo();
        }
        private void ShowInfo()// метод отображения количества каджетов 
        {
            int laptopCount = 0;// кол-во ноутбуков
            int tabletCount = 0;// кол-во планшетов
            int smartphoneCount = 0;// кол-во смартфонов

            foreach (var gadget in this.gadgetsList)// если гаджет в списке гаджетов...
            {
                if (gadget is Laptop) //.. ноутбук, то прибавляем к количеству ноутбуков 1 ...
                {
                    laptopCount += 1;
                }
                else if (gadget is Tablet)// ..аналогично с планшетами...
                {
                    tabletCount += 1;
                }
                else if (gadget is Smartphone)// ... и смартфонами
                {
                    smartphoneCount += 1;
                }
            }
            //выводим информмацию на экран
            txtInfo.Text = "Ноутбуки | Планшеты | Смартфоны";
            txtInfo.Text += "\n";                            //
            txtInfo.Text += String.Format("     {0}                 {1}                  {2}", laptopCount, tabletCount, smartphoneCount);
        }

        private void btnGet_Click(object sender, EventArgs e)// кнопка "Взять"
        {
            if (this.gadgetsList.Count == 0)// если гаджетов нет, то вывод сообщения "Пусто"
            {
                txtOut.Text = "Пусто";
                return;
            }

            var gadget = this.gadgetsList[0];

            this.gadgetsList.RemoveAt(0);// удаляем 0 элемент из списка гаджетов
            listBox1.Items.RemoveAt(0);// и из списка справа

            txtOut.Text = gadget.GetInfo();// вызов метода для отображения информациии о гаджете

            ShowInfo();// обновляем число гаджетов
        }
    }


}

