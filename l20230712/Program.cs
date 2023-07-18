using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace L20230712
{
    internal class Program
    {
        static int Add(int num1, int num2)
        {
             return num1 + num2;
        }
        static int Sub(int num1, int num2)
        {
            return num1 - num2;
        }
        static int Multiply(int num1, int num2)
        {
            return (num1 * num2);
        }
        static int Div(int num1, int num2)
        {
            return num1/num2;
        }
        static int Remain(int num1, int num2)
        {
            return num1 % num2;
        }
        //ASTAR중단
        static void AStar(int[,] map, int startX, int startY, int destinationX, int destinationY)
        {
            double f = 0;
            double g = 0;
            double h = 0;
            while(true)
            {
                h = Math.Sqrt(Math.Pow((double)(destinationX-startX),2) + Math.Pow((double)(destinationY - startY), 2));
                g += 10;
                f = g + h;
            }
        }
        static void Main(string[] args)
        {
            int number1 = 2147483647;
            int number2 = -2147483648;

            Console.WriteLine(Add(number1, number2));
            Console.WriteLine(Sub(number1, number2));
            Console.WriteLine(Multiply(number1, number2));
            Console.WriteLine(Div(number1, number2));
            Console.WriteLine(Remain(number1, number2));



            //만들다만팩맨실행
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.P)
            {
                key = Console.ReadKey();
                if(key.Key == ConsoleKey.L)
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.A)
                    {
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            Main2(args);
                        }
                    }
                }
            }
        }
        static void Main2(string[] args)
        {
            /*
            string size = Console.ReadLine();
            int intSize = int.Parse(size);*/
            int[,] map = new int[,] { 
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 }, 
                { 1, 0, 0, 0, 1, 0, 0, 0, 0, 1 }, 
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            /*
            for (int i = 0; i < intSize; i++)
            {
                for (int j = 0; j < intSize; j++)
                {
                    if (i == 0 || i == intSize - 1)
                    {
                        if (j == 0)
                        {
                            map[i, j] = 1;
                        }
                        else if (j == intSize - 1)
                        {
                            map[i, j] = 1;
                        }
                        else
                        {
                            map[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            map[i, j] = 1;
                        }
                        else if (j == intSize - 1)
                        {
                            map[i, j] = 1;
                        }
                        else
                        {
                            map[i, j] = 0;
                        }
                    }
                }
            }*/
            int playerX = 1;
            int playerY = 1;
            int rand1, rand2;
            int score = 0;

            Random random = new Random();
            while (true)
            {
                rand1 = random.Next(10);
                rand2 = random.Next(10);
                if (map[rand1, rand2] == 0)
                {
                    map[rand1, rand2] = 2;
                    break;
                }
            }

            Console.WriteLine("SCORE : " + score);
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (map[i,j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@"+ " ");
                    }
                    else if(i == playerY && j == playerX)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("P" + " ");
                    }
                    else if (map[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("*" + " ");
                    }
                    else 
                    {
                        Console.Write(" " + " ");
                    }
                }
                Console.WriteLine();
            }

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                bool reward = true;
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        score--;
                        if (map[playerY + 1, playerX] == 1)
                        {
                            break;
                        }
                        else if(map[playerY + 1, playerX] == 2)
                        {
                            map[playerY + 1, playerX] = 0;
                            score += 10;
                            reward = false;
                        }
                        playerY += 1;
                        break;
                    case ConsoleKey.UpArrow:
                        score--;
                        if (map[playerY - 1, playerX] == 1)
                        {
                            break;
                        }
                        else if (map[playerY - 1, playerX] == 2)
                        {
                            map[playerY - 1, playerX] = 0;
                            score += 10;
                            reward = false;
                        }
                        playerY -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        score--;
                        if (map[playerY, playerX+1] == 1)
                        {
                            break;
                        }
                        else if (map[playerY , playerX + 1] == 2)
                        {
                            map[playerY, playerX+1] = 0;
                            score += 10;
                            reward = false;
                        }
                        playerX += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        score--;
                        if (map[playerY, playerX - 1] == 1)
                        {
                            break;
                        }
                        else if (map[playerY, playerX - 1] == 2)
                        {
                            map[playerY, playerX - 1] = 0;
                            score += 10;
                            reward = false;
                        }
                        playerX -= 1;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("SCORE : " + score);
                if (!reward)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (map[i, j] == 2)
                            {
                                reward = true;
                                break;
                            }
                        }
                        if (reward)
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        rand1 = random.Next(10);
                        rand2 = random.Next(10);
                        if (map[rand1, rand2] == 0)
                        {
                            map[rand1, rand2] = 2;
                            break;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("@" + " ");
                        }
                        else if (i == playerY && j == playerX)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("P" + " ");
                        }
                        else if (map[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("*" + " ");
                        }
                        else
                        {
                            Console.Write(" " + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
