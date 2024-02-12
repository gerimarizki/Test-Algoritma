
namespace AlgorithmInterview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.WriteLine("Soal Test Lippo Karawaci Tbk");
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Soal 1 ");
            Console.WriteLine("2. Soal 2 (A)");
            Console.WriteLine("3. Soal 2 (B)");
            Console.WriteLine("4. Soal 2 (C)");
            Console.WriteLine("5. Soal 2 (D)");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Pilih: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. Soal 1");
                        Soal1();
                        MainMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("2. Soal 2 (A)");
                        Soal2A();
                        MainMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("3. Soal 2 (B)");
                        Soal2B();
                        MainMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("4. Soal 2 (C)");
                        Soal2C();
                        MainMenu();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("5. Soal 2 (D)");
                        Soal2D();
                        MainMenu();
                        break;
                    case 6:
                        Console.Write("Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-5!");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-5!");
                MainMenu();
            }
        }

        public static void Soal1()
        {
            Console.WriteLine("Example Pengisian tanpa tanda (,) contohnya (1 2 3 4 5)");
            Console.Write("Masukkan Angka = ");
            int nilai = 0;
            int x = 8;
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != x)
                {
                    if (arr[i] % 2 == 0)
                    {
                        nilai += 1;
                    }
                    else
                    {
                        nilai += 3;
                    }
                }
                else
                {
                    nilai += 5;
                }
            }
            Console.Write($"Hasilnya Adalah = {nilai}\n\n\n"  );

        }

        public static void Soal2A()
        {
            Console.Write("Masukkan Angka = ");
            int N = Int32.Parse(Console.ReadLine());
            int x = 1;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(x);
                }
                Console.Write("\n");
                x++;

           }
        }

        public static void Soal2B()
        {
            Console.Write("Masukkan Angka = ");
            int N = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    Console.Write(j);
                }
                Console.Write("\n");

            }
        }

        public static void Soal2C()
        {
            Console.Write("Masukkan Angka = ");
            int N = Int32.Parse(Console.ReadLine());
            int z = 1;
            bool max = false;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(z);
                    if (z == N)
                    {
                        max = true;
                    }
                    else if (z == 1)
                    {
                        max = false;
                    }

                    if (max)
                    {
                        z--;
                    }
                    else
                    {
                        z++;
                    }
                }
                Console.Write("\n");
            }

        }

        // penjabaran Array Soal2D 

        //[i,j]

        //i = 0
        //j = 0

        //NomorArray[0,0] = 1

        //i = 0
        //j = 1

        //NomorArray[0,1] = 2

        //i = 0
        //j = 2

        //NomorArray[0,2] = 3

        //i = 0
        //j = 3

        //NomorArray[0,3] = 4

        //NomorArray[0,4] = 5


        //i = 1
        //j = N -1 = 5 -1 = 4

        //NomorArray[j, i][4, 1] = 6

        //j = 3
        //i = 1


        //NomorArray[3, 1] = 7
        //NomorArray[2, 1] = 8
        //NomorArray[1, 1] = 9
        //NomorArray[0, 1] = 10

        //i = 2
        //j = 0

        //NomorArray[0, 2] = 11
        //NomorArray[1, 2] = 12
        //NomorArray[2, 2] = 13
        //NomorArray[3, 2] = 14
        //NomorArray[4, 2] = 15

        //i = 3
        //j = 4
        //NomorArray[4, 3] = 20
        //NomorArray[3, 3] = 19
        //NomorArray[2, 3] = 18
        //NomorArray[1, 3] = 17
        //NomorArray[0, 3] = 16
        

        //[j,i]
        //[0,0] 1 [0,1] 10 [0,2] 11 [0,3] 20 [0,4] 21 [0,5] 30
        //[1,0] 2 [1,1] 9  [1,2] 12 [1,3] 19 [1,4] 22 [1,5] 29
        //[2,0] 3 [2,1] 8  [2,2] 13 [2,3] 18 [2,4] 23 [2,5] 28
        //[3,0] 4 [3,1] 7  [3,2] 14 [3,3] 17 [3,4] 24 [3,5] 27
        //[4,0] 5 [4,1] 6  [4,2] 15 [4,3] 16 [4,4] 25 [4,5] 26


        public static void Soal2D()
        {
            Console.Write("Masukkan Angka = ");
            int N = Int32.Parse(Console.ReadLine());
            int[,] NomorArray = new int[N, N];
            int NilaiSekarang = 1;

            for (int i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < N; j++)
                    {
                        NomorArray[j, i] = NilaiSekarang++;
                    }
                }
                else
                {
                    for (int j = N - 1; j >= 0; j--)
                    {
                        NomorArray[j, i] = NilaiSekarang++;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(NomorArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


    }
}






