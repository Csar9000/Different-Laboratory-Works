using System;

namespace FourthLabWorkInheritance_Handing_out_gadgets
{

    public class Gadget// класс гаджет (предок)
    {
        public static Random rnd = new Random();// сохдаём экземпляр переменной типа Random

        public static string[] laptopDisSizeArr = new string[] { "11''", "12''", "13.3''", "14''", "15''", "15.6''", "17''", "19''" };// Размеры дисплея ноутбуков

        public static string[] tabletDisSizeArr = new string[] {"7.0''","7.9''","8.9''","9.7''" };// Размеры дисплея планшетов

        public static string[] smartphoneDisSizeArr = new string[] {"3.2''","3.3''","3.9''","4.4''","4.7''","5.0''","5.1''","5.3''","5.5''","6.0''" };// Размеры дисплея смартфонов

        public static int[] screenDpiArr = new int[] {72, 150, 300, 600 };// dpi планшета

        public static string[] KeyBackLight = new string[] { "есть", "нету" };// наличие подсветки у клавиатуры

        public string displaySize = "";// размер дисплея

        public static int[] coresArr = new int[] { 2, 4, 6, 8 };// количество ядер у ноутбука

        public static int[] megapixelsArr = new int[] {2,3,4,5,6,7,8,10,12,16 };// количество мегапикселей у камеры смартфона

        

        public static string[] hardArr = new string[] { "50 Gb", "64 Gb", "100 Gb", "128 Gb", "256 Gb", "200 Gb", "512 Gb", "500 Gb", "1024 Gb", "1000 Gb", "2048 Gb", "2000 Gb" };// объём памяти у ноутбука

        public virtual String GetInfo()// метод формирования строки базового свойства гаджетов
        {
            var str = String.Format("\nРазмер диагонали: {0}", this.displaySize);// общая для раздачи гаджетов
            return str;
        }
            
    }


    public class Laptop : Gadget//класс ноутбук - наследник Gadget
    {
        public string KeyboardBacklight = "";  // подсветка
        public int numberOfCores = 0; // ядра
        public string hardDriveVolume = "";// объём

        public override String GetInfo()
        {
            var str = "Ноутбук";
            str += base.GetInfo();// вызываем родительский метод для формирования строки базового свойства для всх гаджетов

            str += String.Format("\nНаличие подсветки: {0}", this.KeyboardBacklight);
            str += String.Format("\nКоличество ядер: {0}", this.numberOfCores);                     
            str += String.Format("\nОбъём памяти: {0}", this.hardDriveVolume);
            return str;
        }
        public static Laptop Generate()
        {
            return new Laptop
            {
                displaySize = laptopDisSizeArr[rnd.Next()%7], // размер дисплея
                KeyboardBacklight = KeyBackLight[rnd.Next() % 2], // подсветка
                numberOfCores = coresArr[rnd.Next() % 4], // количество ядер
                hardDriveVolume = hardArr[rnd.Next() % 12] // объём             
            };
        }
    }

    public class Tablet : Gadget//класс планшет - наследник Gadget
    {
        public string CameraAvailability = "";// камера
        public int screenDpi = 0; // dpi

        public override String GetInfo()
        {
            var str = "Планшет";
            str += base.GetInfo();// вызываем родительский метод для формирования строки базового свойства для всх гаджетов

            str += String.Format("\nНаличие камеры: {0}", this.CameraAvailability);
            str += String.Format("\nТочек на дюйм: {0} dpi", this.screenDpi);
            return str;
        }

        public static Tablet Generate()
        {
            return new Tablet
            {
                displaySize = tabletDisSizeArr[rnd.Next() % 4], // размер дисплея
                CameraAvailability = KeyBackLight[rnd.Next() % 2], // наличие камеры
                screenDpi = screenDpiArr[rnd.Next() % 4], // количество ядер        
            };
        }
    }

    public class Smartphone : Gadget// класс смартфон - наследник Gadget
    {
        public int numOfSlots = 0;// слоты под сим карту
        public int numCameraMegapixels = 0; // мегапиксели
        public int Battery = 0; // объём батареи

        public override String GetInfo()
        {
            var str = "Смартфон";
            str += base.GetInfo();// вызываем родительский метод для формирования строки базового свойства для всх гаджетов

            str += String.Format("\nКоличество слотов под sim карту: {0}", this.numOfSlots);
            str += String.Format("\nКоличество мегапикселей у камеры: {0} MP", this.numCameraMegapixels);
            str += String.Format("\nБатарея: {0} mAh", this.Battery);
            return str;
        }
        public static Smartphone Generate()
        {
            return new Smartphone
            {
                displaySize = smartphoneDisSizeArr[rnd.Next() % 10], // размер дисплея
                numOfSlots = rnd.Next(1,3), // количество слотов под sim карту
                numCameraMegapixels = megapixelsArr[rnd.Next() % 10], // мегапиксели

                Battery = rnd.Next(1500, 8000)/10*10,// объём батареи
            };
        }
    }
}
