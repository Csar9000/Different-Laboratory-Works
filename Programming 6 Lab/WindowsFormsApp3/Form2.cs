using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {        
        float x0 = 300;
        float y0 = 320;
        float t = 0;
        int xRec = 295;
        int yRec = 320;
        int wRec = 10;
        int hRec = 0;

        int checkTime = 0;

        
        public Form2()
        {
            InitializeComponent();
        }

        void DrawTree(Graphics g, float x0, float y0, float t)
        {
            Pen triangle = new Pen(Color.Green, 3); // заготавливаем карандаш для ёлки
            SolidBrush b1 = new SolidBrush(Color.Green);// закрашиваем ёлку зелёным цветом

            Rectangle r1 = new Rectangle(xRec- Convert.ToInt32(0.1*t), yRec- Convert.ToInt32(t), wRec+ Convert.ToInt32(0.2 * t), hRec+ Convert.ToInt32(0.9*t));// данные роста ствола дерева
            Rectangle r2 = new Rectangle(0, 300, 818, 177);// данные для отрисовки снега
            g.FillRectangle(new SolidBrush(Color.White), r2);// закрашиваем снег белым цветом

            g.DrawRectangle(new Pen(Color.Brown), r1);// рисуем ствол дерева по данным r1
            g.FillRectangle(new SolidBrush(Color.Brown), r1);// закрашиваем ствол дерева по данным r1

            PointF[] tr1 = new PointF[] { new PointF(x0 - Convert.ToInt32(1.6 * t), y0 - t), new PointF(x0, y0 - Convert.ToInt32(t*2)), new PointF(x0 + Convert.ToInt32(1.6 * t), y0 - t) };// данные роста первой части ёлки
            PointF[] tr2 = new PointF[] { new PointF(x0 - Convert.ToInt32(1.3 * t), y0 - Convert.ToInt32(t * 2)), new PointF(x0, y0 - Convert.ToInt32(t * 3)), new PointF(x0 + Convert.ToInt32(1.3 * t),y0- Convert.ToInt32(t * 2)) };// данные роста второй части ёлки
            PointF[] tr3 = new PointF[] { new PointF(x0 - Convert.ToInt32(1.0 * t), y0 - Convert.ToInt32(t * 3)), new PointF(x0, y0 - Convert.ToInt32(t * 4)), new PointF(x0 + Convert.ToInt32(1.0 * t), y0 - Convert.ToInt32(t * 3)) };// данные роста третьей части ёлки
            PointF[] tr4 = new PointF[] { new PointF(x0 - Convert.ToInt32(0.7 * t), y0 - Convert.ToInt32(t * 4)), new PointF(x0, y0 - Convert.ToInt32(t * 5)), new PointF(x0 + Convert.ToInt32(0.7 * t), y0 - Convert.ToInt32(t * 4)) };// данные роста четвёртой части ёлки
            g.DrawPolygon(triangle, tr1);// отрисовка первой части ёлки по tr1
            g.FillPolygon(b1, tr1);// закрашивание первой части ёлки по tr1

            g.DrawPolygon(triangle, tr2);// отрисовка первой части ёлки по tr2
            g.FillPolygon(b1, tr2);// закрашивание первой части ёлки по tr2

            g.DrawPolygon(triangle, tr3);// отрисовка первой части ёлки по tr3
            g.FillPolygon(b1, tr3);// закрашивание первой части ёлки по tr3

            g.DrawPolygon(triangle, tr4);// отрисовка первой части ёлки по tr1=4
            g.FillPolygon(b1, tr4);// закрашивание первой части ёлки по tr4
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkTime < 50)// счётчик, посредством которого определяется время работы таймера 
            {
                t++;
                checkTime++;
                Invalidate();// вызывает перерисовку Form 2
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkTime < 50)
            {
                Timer timer = new Timer(); // при нажатии button1 задаём новый таймер
                timer.Enabled = true;// активируем таймер
                timer.Interval = 1000;// задаём интервал в 1 сек
                timer.Tick += new EventHandler(timer1_Tick);// вызываем событие timer1_Tick
            }
            else
            {
                timer1.Stop();// при срабатывании условия отключаем таймер
                MessageBox.Show("Ёлка выросла!");// выводим сообщение об окончании работы программы
            }
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.FromArgb(111, 121, 131);// Цвет заднего фона Form 2
            Graphics g = e.Graphics;
            DrawTree(g,x0,y0,t);// рисуем ёлку
        }
    }
}

