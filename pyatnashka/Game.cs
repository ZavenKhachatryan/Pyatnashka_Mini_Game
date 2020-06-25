using System;

namespace Pyatnashka
{
    static class Game
    {
        private static int MyI { get; set; }
        private static int MyJ { get; set; }
        private static int N { get; set; }
        private static int[,] Numbers { get; set; }

        private static Random rnd = new Random();

        public static void Start()
        {
            Console.WriteLine("Enter Table Size N x N");
            Console.Write("N = ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            MyI = rnd.Next(0, N);
            MyJ = rnd.Next(0, N);

            InitializeArray();

            while (true)
            {
                Draw();

                if (AreWin())
                {
                    Console.WriteLine("You Win !!!");
                    Console.ReadKey();
                }

                Move();
                Console.WriteLine("Press Esc for Exit");

                Console.Clear();
            }
        }
        private static int[] SortedArray()
        {
            int[] sArr = new int[N * N];

            for (int i = 0; i < sArr.Length; i++)
            {
                if (i == 0)
                    sArr[sArr.Length - 1] = i;
                else
                    sArr[i - 1] = i;
            }
            return sArr;
        }
        private static void InitializeArray()
        {
            int k = 0;
            Numbers = new int[N, N];

            int[] arr = SortedArray();
            ShuffleArray(arr);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Numbers[i, j] = arr[k];
                    k++;
                }
            }
        }
        private static void Draw()
        {
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("+----");
                Console.WriteLine("+");
                if (i < N)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write("| ");
                        if (Numbers[i, j] == 0)
                        {
                            MyI = i;
                            MyJ = j;
                            Console.Write("   ");
                        }
                        else
                        {
                            if (Numbers[i, j] < 10)
                                Console.Write("{0}  ", Numbers[i, j]);
                            else
                                Console.Write("{0} ", Numbers[i, j]);
                        }
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
        }
        private static void Move()
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.RightArrow && MyJ - 1 >= 0)
            {
                int z = Numbers[MyI, MyJ];
                Numbers[MyI, MyJ] = Numbers[MyI, MyJ - 1];
                Numbers[MyI, MyJ - 1] = z;
            }
            else if (key == ConsoleKey.LeftArrow && MyJ + 1 < N)
            {
                int z = Numbers[MyI, MyJ];
                Numbers[MyI, MyJ] = Numbers[MyI, MyJ + 1];
                Numbers[MyI, MyJ + 1] = z;
            }
            else if (key == ConsoleKey.DownArrow && MyI - 1 >= 0)
            {
                int z = Numbers[MyI, MyJ];
                Numbers[MyI, MyJ] = Numbers[MyI - 1, MyJ];
                Numbers[MyI - 1, MyJ] = z;
            }
            else if (key == ConsoleKey.UpArrow && MyI + 1 < N)
            {
                int z = Numbers[MyI, MyJ];
                Numbers[MyI, MyJ] = Numbers[MyI + 1, MyJ];
                Numbers[MyI + 1, MyJ] = z;
            }
        }
        private static bool AreWin()
        {
            int k = 0;
            int res = 0;
            int[] sortedArray = SortedArray();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Numbers[i, j] == sortedArray[k])
                        res++;
                    else
                        return false;
                    k++;
                }
            }
            return true;
        }
        private static void ShuffleArray(int[] arr)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int index = rnd.Next(i + 1);
                int a = arr[index];
                arr[index] = arr[i];
                arr[i] = a;
            }
        }
    }
}