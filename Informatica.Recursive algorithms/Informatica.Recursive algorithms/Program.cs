using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace Informatica.Recursive_algorithms
{
    class Program
    {      
        public class Solution
        {
            public static int GetProcessCount()
            {
                int count=0;
                foreach (Process process in Process.GetProcesses())
                {
                    count++;
                }
                return count;
            }
            public static uint InputValues()
            {
                uint value;
                Console.WriteLine("Вводите значения не больше 3 и не меньше 1:\n");
                while (((!uint.TryParse(Console.ReadLine(), out value)) || (value == 0) || (value > 3)))
                {
                    Console.WriteLine("Введите корректные данные");
                }
                return value;
            }
            public static uint ack_recursive(uint m, uint n)
            {
            if (m == 0)
                    {
                        return n + 1;
                    }
                    else if (n == 0 && m > 0)
                    {
                        return ack_recursive(m - 1, 1);
                    }
                    else
                    {
                        return ack_recursive(m - 1, ack_recursive(m, n - 1));
                    }
            }

            static public uint ack_nonrecursive(uint m, uint n)
            {
                LinkedList<uint> value = new LinkedList<uint>();

                value.AddLast(m);
                while (value.Count > 0)
                {
                    m = value.Last();
                    value.RemoveLast();

                    if (m == 0)
                        n += (m + 1);
                    else if (n == 0)
                    {
                        value.AddLast(m - 1);
                        n = 1;
                    }
                    else
                    {
                        value.AddLast(m - 1);
                        value.AddLast(m);
                        n--;
                    }
                }

                return n;
            }

            public static void Main(String[] args)
            {                 
                uint m= InputValues();
                uint n= InputValues();

                Console.WriteLine("[{0}] - время после ввода", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                Console.WriteLine("[{0}] ack_recursion_result ({1},{2})={3}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"), m,n, ack_recursive(m, n)+"\n");
                Console.WriteLine("Количество процессов для выполнения операции :  "+ GetProcessCount() + "\n");

                uint i= InputValues();
                uint j = InputValues();
                Console.WriteLine("[{0}] - время после ввода", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                Console.WriteLine("[{0}] ack_non_recursion_result({1},{2})={3}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"), i, j, ack_nonrecursive(i, j)+"\n");
                Console.WriteLine("Количество процессов для выполнения операции :  " + GetProcessCount() + "\n");
                Console.WriteLine("Press any key to finish...");
                Console.ReadKey();
                Console.ReadKey();
            }
        }
    }
}

