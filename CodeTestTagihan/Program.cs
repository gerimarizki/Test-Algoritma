using System;
using System.Collections.Generic;
using ConsoleTables;

namespace CodeTestSortingDanAlokasi;
public class Program
{
    public static void Main()
    {
        List<Tagihan> tagihanList = new List<Tagihan>
        {
            new Tagihan { Nomor = 1, DueDate = new DateTime(2023, 1, 10), Amount = 165000 },
            new Tagihan { Nomor = 2, DueDate = new DateTime(2023, 2, 15), Amount = 80000 },
            new Tagihan { Nomor = 3, DueDate = new DateTime(2023, 1, 20), Amount = 130000 },
            new Tagihan { Nomor = 4, DueDate = new DateTime(2023, 3, 25), Amount = 416000 },
            new Tagihan { Nomor = 5, DueDate = new DateTime(2023, 2, 10), Amount = 95500 },
            new Tagihan { Nomor = 6, DueDate = new DateTime(2023, 8, 17), Amount = 523000 }
        };

        while (true)
        {
            Console.Clear();
            var table = new ConsoleTable("Tagihan#", "Due Date", "Amount");

            foreach (var tagihan in tagihanList)
            {
                table.AddRow($"Tagihan#{tagihan.Nomor}", $"{tagihan.DueDate:dd MMM yy}", $"{tagihan.Amount:C}");
            }

            table.Write();

            decimal inputPayment;
            while (true)
            {
                Console.WriteLine("Masukkan jumlah pembayaran : \nMasukkan Input 0 Jika Ingin Keluar ");
                if (decimal.TryParse(Console.ReadLine(), out inputPayment))
                {
                    if (inputPayment < 0)
                    {
                        Console.WriteLine("Tidak dapat melakukan input kurang dari 0!!");
                    }
                    else if (inputPayment == 0)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Input Salah Masukkan Input yang VALID!!");
                }
            }

            AllocatePayment(tagihanList, inputPayment);
        }
    }

    public static void AllocatePayment(List<Tagihan> tagihanList, decimal payment)
    {
        Console.Clear();
        if (tagihanList.Count == 0)
        {
            Console.WriteLine("Tidak ada tagihan yang dapat ditampilkan.");
            Console.WriteLine("\nTekan Enter untuk kembali ke menu utama...");
            Console.ReadLine();
            return;
        }

        tagihanList.Sort((x, y) => x.DueDate.CompareTo(y.DueDate));

        var table = new ConsoleTable("Tagihan#", "Due Date", "Amount", "Payment");

        foreach (var tagihan in tagihanList)
        {
            decimal paidAmount = Math.Min(tagihan.Amount, payment);
            decimal remainingAmount = tagihan.Amount - paidAmount;
            table.AddRow($"Tagihan#{tagihan.Nomor}", tagihan.DueDate.ToString("dd MMM yy"), tagihan.Amount.ToString("C"), paidAmount.ToString("C"));

            payment -= paidAmount;

            if (payment <= 0)
            {
                break;
            }
        }

        table.Write();
        Console.WriteLine("\n1. Menu Utama");
        Console.WriteLine("2. Keluar");
        Console.Write("Pilih opsi: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == 1)
            {
                //Ke Menu Utama
            }
            else if (choice == 2)
            {
                Environment.Exit(0); 
            }
            else
            {
                Console.WriteLine("Input Hanya 1 dan 2 !\n Tekan Enter Untuk Kembali Ke Menu Utama ");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Input Hanya 1 dan 2 !\n Tekan Enter Untuk Kembali Ke Menu Utama ");
            Console.ReadLine();
        }
    }
}
