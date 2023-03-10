using System;

namespace Seminar7_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            void Zadacha47()
            {
                // Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
                // m = 3, n = 4.
                // 0,5 7 -2 -0,2
                // 1 -3,3 8 -9,9
                // 8 7,8 -7,1 9

                int rows = 3;
                int colums = 4;
                double[,] array = new double[rows, colums];

                FillArray(array);
                Console.WriteLine();
                PrintArray(array);
            }

            // Zadacha47();

            void Zadacha50()
            {
                // Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание,
                // что такого элемента нет.
                // Например, задан массив:
                // 1 4 7 2
                // 5 9 2 3
                // 8 4 2 4
                // 17 -> такого числа в массиве нет

                int rows = 3;
                int colums = 4;
                int[,] array = new int[rows, colums];
                int nums = 99999; 
                
                FillArray(array);

                while (nums == 99999)
                {
                    Console.WriteLine("Дан массив данных:");
                    Console.WriteLine();
                    PrintArray(array);                    
                    Console.WriteLine();
                    Console.Write("Укажите номер строки в массиве: ");
                    int positionInArray1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Укажите номер столбца в массиве: ");
                    int positionInArray2 = Convert.ToInt32(Console.ReadLine());

                    nums = CheckArray(array, positionInArray1, positionInArray2, nums);
                }
                Console.WriteLine("По заданным параметрам элемент в массиве = " + nums); 
            }
            // Zadacha50();

            void Zadacha52()
            {
                // Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
                // Например, задан массив:
                // 1 4 7 2
                // 5 9 2 3
                // 8 4 2 4
                // Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

                int rows = 3;
                int colums = 4;
                int[,] array = new int[rows, colums];

                FillArray(array);
                PrintArray(array);
                Console.WriteLine();
                AvgArray(array);
            }

            // Zadacha52();
        }

        static void FillArray(int[,] array, int startNumber = -10, int finishNumber = 10)
        {
            Random random = new Random();
            finishNumber++;
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    array[i, j] = random.Next(startNumber, finishNumber);
                }
            }
        }

        static void FillArray(double[,] array)
        {
            Random random = new Random();
            // finishNumber++;
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    array[i, j] = random.NextDouble() * 20 - 10;
                }
            }
        }        

        static void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    Console.Write(array[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }    

        static void PrintArray(double[,] array)
        {
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    Console.Write(Math.Round((array[i,j]), 1) + "\t");
                }
                Console.WriteLine();
            }
        }

        static int CheckArray(int[,] array, int positionInArray1, int positionInArray2, int nums)
        {
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);
            if (positionInArray1 <= rows && positionInArray2 <= colums)
            {
                positionInArray1--;
                positionInArray2--;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < colums; j++)
                    {
                        if(i == positionInArray1 && j == positionInArray2) nums = array[i,j];
                    }
                }
                positionInArray1++;
                positionInArray2++;                
                Console.WriteLine(positionInArray1 + ", " + positionInArray2 + " -> " + nums);
                return nums;
            }
            else 
            Console.WriteLine("Заданы некоректные границы массива, попробуйте снова");
            Console.WriteLine();
            return nums;                            
        }

        static void AvgArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);
            double sum = 0;
            int count = 1;

            for (int i = 0; i < colums; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    sum += array[j,i];
                    if (count == rows)
                    {
                        sum /= count;
                        Console.WriteLine("AVG " + (i = i + 1) + " = " + Math.Round(sum,1));
                        sum = 0;
                        count = 1;
                        i--;
                    }
                    else count++;
                }
            }
        }            
    }
}
