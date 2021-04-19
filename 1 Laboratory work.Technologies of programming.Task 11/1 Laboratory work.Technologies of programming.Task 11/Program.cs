using System;

namespace _1_Laboratory_work.Technologies_of_programming.Task_11
{
    class Program
    {
        static string GetString(string message)// функция получения строки
        {
            bool flag = true;
            string str = "";
            while ((str=="")||(flag==false))
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                char[] symbols = input.ToCharArray();
                for (int i = 0; i < symbols.Length; i++)
                {
                    if (Char.IsLetter(symbols[i]))
                    {
                        str += symbols[i];
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag==false)
                {
                    Console.WriteLine("Ваша строка содержит некорректные символы! \n");
                }
            }
            return str;    
        }
        static string GetMatchesCount(char SearchedChar,string second_str)// функция подсчёта повторяющихся символов
        {
            int count = 0;
            char[] str = second_str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.ToLower(str[i]) == Char.ToLower(SearchedChar))
                {
                    count++;
                }
            }
            string s = "";
            if (count == 1)
            {
                s = Convert.ToString(count) + " совпадение";
            }
            if ((count<=4)&&(count!=1)&&(count!=0))
            {
                s = Convert.ToString(count) + " совпадения";              
            }
            else if(count!=1)
            {
                s = Convert.ToString(count) + " совпадений";
            }
            return s;
        }
        static string GetMatches(string first_str, string second_str)// функция получения искомого результата
        {
            string matches = "";
            //удаляем повторяющиеся символы
            for (int i = 0; i <= first_str.Length - 2; i++)
            {
                for (int j = i + 1; j <= first_str.Length - 1; j++)
                {
                    if (Char.ToLower(first_str[i]) == Char.ToLower(first_str[j]))
                    {
                        first_str = first_str.Remove(j, 1);
                    }
                }
            }
            //проверяем вторую строку на содержание символов первой строки
            for (int i = 0; i < first_str.Length; i++)
            {
                if (second_str.Contains(Char.ToLower(first_str[i])))
                {
                    matches += first_str[i] + " найдено " + GetMatchesCount(first_str[i], second_str)+"\n";
                }
                else
                {
                    matches += first_str[i] + " не найдено совпадений\n";
                }
            }

            return matches;
        }
        static void Main(string[] args)
        {
            string first_str = GetString("Введите первое слово");
            string second_str = GetString("Введите второе слово");
            string answer = GetMatches(first_str, second_str);
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}

