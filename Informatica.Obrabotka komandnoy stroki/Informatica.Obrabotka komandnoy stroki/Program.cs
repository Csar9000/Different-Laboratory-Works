using System;
using System.Linq;

namespace Лабораторная_работа_по_информатике._Обработка_командной_строки
{
    class Program
    {
        static Random rnd = new Random();
        static int[][] InputRandomMatr(int size1, int size2)
        {
            int[][] N = new int[size1][];
            for (int i = 0; i < size1; i++)
                N[i] = new int[size2];
            for (int i = 0; i < size1; i++)
                for (int j = 0; j < size2; j++)
                {
                    int[] array = Enumerable.Range(0, size1 * size2).OrderBy(x => rnd.Next()).ToArray();
                    for (int k = 0; k < size1; k++)
                        for (int r = 0; r < size2; r++)
                            N[i][j] = array[k * size2 + r] - array[k * size2];
                }
            return N;
        }
        static int[][] InputMatr(int size1, int size2)
        {
            int[][] N = new int[size1][];
            for (int i = 0; i < size1; i++)
                N[i] = new int[size2];
            for (int i = 0; i < size1; i++)
                for (int j = 0; j < size2; j++)
                {
                    int value;
                    Console.WriteLine($"Введите {i} {j} элемент массива: ");
                    while (!int.TryParse(Console.ReadLine(), out value))
                        Console.WriteLine("Введите корректные данные");
                    N[i][j] = value;
                }
            return N;
        }
        public static int[][] UniqueMatrix(int[][] matrix, int size1, int size2)
        {
            if ((matrix.Length <= 0) || (matrix[0].Length <= 0)
            || (matrix.Length != size1) || (matrix[0].Length != size2))
                return null;

            int[][] new_matrix = new int[size1][];
            for (int i = 0; i < size1; i++)
            {
                new_matrix[i] = new int[size2];
                matrix[i].CopyTo(new_matrix[i], 0);
            }

            for (int r = 0; r < size1; r++)
            {
                for (int i = 0; i < size2; i++)
                {
                    int value1 = new_matrix[r][i],
                    value2 = new_matrix[(size1 - 1)][i];
                    for (int k = 0; k < i; k++)
                    {
                        if (new_matrix[r][k] == value1)
                        {
                            new_matrix[r][k] = 0;
                            new_matrix[r][i] = 0;
                        }
                        if (new_matrix[(size1 - 1)][k] == value2)
                        {
                            new_matrix[(size1 - 1)][k] = 0;
                            new_matrix[(size1 - 1)][i] = 0;
                        }
                    }
                    for (int k = (i + 1); k < size2; k++)
                    {
                        if (new_matrix[r][k] == value1)
                        {
                            new_matrix[r][k] = 0;
                            new_matrix[r][i] = 0;
                        }
                        if (new_matrix[(size1 - 1)][k] == value2)
                        {
                            new_matrix[(size1 - 1)][k] = 0;
                            new_matrix[(size1 - 1)][i] = 0;
                        }
                    }
                }
            }

            for (int i = 1; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        for (int p = 0; p < size2; p++)
                            if (new_matrix[k][p] == new_matrix[i][j])
                            {
                                new_matrix[k][p] = 0;
                                new_matrix[i][j] = 0;
                            }
                    }
                }
            }

            return new_matrix;
        }
        public static int[][] UniqueMatrixChar(int[][] matrix, int size1, int size2)
        {
            if ((matrix.Length <= 0) || (matrix[0].Length <= 0)
            || (matrix.Length != size1) || (matrix[0].Length != size2))
                return null;

            int[][] new_matrix = new int[size1][];
            for (int i = 0; i < size1; i++)
            {
                new_matrix[i] = new int[size2];
                matrix[i].CopyTo(new_matrix[i], 0);
            }

            for (int r = 0; r < size1; r++)
            {
                for (int i = 0; i < size2; i++)
                {
                    int value1 = new_matrix[r][i],
                    value2 = new_matrix[(size1 - 1)][i];
                    for (int k = 0; k < i; k++)
                    {
                        if (new_matrix[r][k] == value1)
                        {
                            new_matrix[r][k] = (new Random()).Next(0, 10);
                            new_matrix[r][i] = (new Random()).Next(0, 10);
                        }
                        if (new_matrix[(size1 - 1)][k] == value2)
                        {
                            new_matrix[(size1 - 1)][k] = (new Random()).Next(0, 10);
                            new_matrix[(size1 - 1)][i] = (new Random()).Next(0, 10);
                        }
                    }
                    for (int k = (i + 1); k < size2; k++)
                    {
                        if (new_matrix[r][k] == value1)
                        {
                            new_matrix[r][k] = (new Random()).Next(0, 10);
                            new_matrix[r][i] = (new Random()).Next(0, 10);
                        }
                        if (new_matrix[(size1 - 1)][k] == value2)
                        {
                            new_matrix[(size1 - 1)][k] = (new Random()).Next(0, 10);
                            new_matrix[(size1 - 1)][i] = (new Random()).Next(0, 10);
                        }
                    }
                }
            }

            for (int i = 1; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        for (int p = 0; p < size2; p++)
                            if (new_matrix[k][p] == new_matrix[i][j])
                            {
                                new_matrix[k][p] = 0;
                                new_matrix[i][j] = 0;
                            }
                    }
                }
            }
            return new_matrix;
        }
        static void UserChoiceYes(string m, int size1, int size2)
        {
            if (m == "Null")
            {
                Console.WriteLine("Вы выбрали самостоятельный ввод данных\n");
                Console.WriteLine($"Ввод матрицы А \n");
                int[][] A = InputMatr(size1, size2);
                Console.WriteLine("Вывод введённых элементов массива A:\n ");
                OutputArray(A, size1, size2);
                int[][] B = new int[size1][];
                B = UniqueMatrix(A, size1, size2);
                Console.WriteLine("Переписываем значения матрицы В на проверенные значения матрицы А:\n");
                Console.WriteLine(" В=:\n");
                OutputArray(B, size1, size2);
                Console.WriteLine("\n Нажмите любую клавишу, чтобы закончить...");
            }
            if (m == "Char")
            {
                Console.WriteLine("Вы выбрали самостоятельный ввод данных\n");
                Console.WriteLine($"Ввод матрицы А \n");
                int[][] A = InputMatr(size1, size2);
                Console.WriteLine("Вывод введённых элементов массива A:\n ");
                OutputArray(A, size1, size2);
                int[][] B = new int[size1][];
                B = UniqueMatrixChar(A, size1, size2);
                Console.WriteLine("Переписываем значения матрицы В на проверенные значения матрицы А:\n");
                Console.WriteLine(" В=:\n");
                OutputArray(B, size1, size2);
                Console.WriteLine("\n Нажмите любую клавишу, чтобы закончить...");
            }
            else
            {
                Console.WriteLine("\n Введите корректный 4 параметр!");
            }

        }
        static void UserChoiceNo(string m, int size1, int size2)
        {
            if (m == "Null")
            {
                Console.WriteLine("Вы выбрали ввод данных компьютером:\n");
                int[][] A = InputRandomMatr(size1, size2);
                Console.WriteLine("Вывод сгенерированных элементов массива A:\n ");
                OutputArray(A, size1, size2);
                int[][] B = new int[size1][];
                B = UniqueMatrix(A, size1, size2);
                Console.WriteLine("Переписываем значения матрицы В на проверенные значения матрицы А:\n");
                Console.WriteLine(" В=:\n");
                OutputArray(B, size1, size2);
                Console.WriteLine("\n Нажмите любую клавишу, чтобы закончить...");
            }
            if (m == "Char")
            {
                Console.WriteLine("Вы выбрали ввод данных компьютером:\n");
                int[][] A = InputRandomMatr(size1, size2);
                Console.WriteLine("Вывод сгенерированных элементов массива A:\n ");
                OutputArray(A, size1, size2);
                int[][] B = new int[size1][];
                B = UniqueMatrixChar(A, size1, size2);
                Console.WriteLine("Переписываем значения матрицы В на проверенные значения матрицы А:\n");
                Console.WriteLine(" В=:\n");
                OutputArray(B, size1, size2);
                Console.WriteLine("\n Нажмите любую клавишу, чтобы закончить...");
            }
            else
            {
                Console.WriteLine("\n Введите корректный 4 параметр!");
            }
        }

        static void OutputArray(int[][] N, int size1, int size2)
        {
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    Console.Write(N[i][j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {

            int size1 = 0, size2 = 0;
            if (args.Length > 0)
            {

                if (args[0] == "Help")
                {
                    Console.WriteLine("\n[параметр0] - напишите Help, чтобы вызвать справку, чтобы продолжить работу программы, напишите * вместо Help \n[параметр1]-введите количество строк матрицы (от 2 до 10) \n[параметр2] введите количество столбцов матрицы (от 2 до 10)\n[параметр3] - напишите Yes, если хотите самостоятельно заполнить матрицу \n[параметр3] - напишите No, если хотите чтобы матрицу заполнил компьтер \n[параметр4] - напишите Null,если хотите, чтобы все повторяющиеся элементы были заменены на 0 \n[параметр 4] - напишите Char, чтобы заменить повторяющиеся элементы на определённый символ(0...9)\n");
                }
                if (args[0] == "*")
                {
                    size1 = Convert.ToInt32(args[1]);
                    size2 = Convert.ToInt32(args[2]);

                    if ((size1 > 0) || (size2 > 0))
                    {
                            if (args[3] == "Yes")
                            {
                                string m = args[4];
                                UserChoiceYes(m, size1, size2);
                            }
                            if (args[3] == "No")
                            {
                                string m = args[4];
                                UserChoiceNo(m, size1, size2);
                            }
                        else
                        {
                            Console.WriteLine("Введите корректный 3 параметр!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: 1 и 2 параметры меньше или равны 0");
                    }
                }
                else
                {
                            Console.WriteLine("Введите Help для вызова справки или *");
                }
            } 
            else
            {
                    Console.WriteLine("\n Данная программа запускается ТОЛЬКО с определённым параметром, пример ввода параметра:\n (Название программы) [параметр0] [параметр1] [параметр2] [параметр3] [параметр4].\n Для вызова справки введите параметр Help вместо [параметр0],\n как показано на схеме(через пробел).\n");
            }                                 
        }                      
     }           
 }
            
        



