using System;
using System.Collections.Generic;
using ConsoleTables;

namespace CodeTestTagihanPenaltyDanPembayaran;
public class Program
{
    static List<Tagihan> dataTagihan = new List<Tagihan>
    {
        new Tagihan("Tagihan#1", new DateTime(2023, 1, 10), 165000),
        new Tagihan("Tagihan#2", new DateTime(2023, 2, 15), 80000),
        new Tagihan("Tagihan#3", new DateTime(2023, 1, 20), 130000),
        new Tagihan("Tagihan#4", new DateTime(2023, 3, 30), 416000),
        new Tagihan("Tagihan#5", new DateTime(2023, 2, 10), 95500)
    };

    static List<Pembayaran> dataPembayaran = new List<Pembayaran>
    {
        new Pembayaran("Payment#1", "Tagihan#1", new DateTime(2023, 1, 10), 165000),
        new Pembayaran("Payment#2", "Tagihan#3", new DateTime(2023, 2, 20), 130000),
        new Pembayaran("Payment#2", "Tagihan#5", new DateTime(2023, 2, 20), 95500),
        new Pembayaran("Payment#3", "Tagihan#2", new DateTime(2023, 2, 25), 30000),
        new Pembayaran("Payment#4", "Tagihan#2", new DateTime(2023, 3, 30), 50000),
        new Pembayaran("Payment#4", "Tagihan#4", new DateTime(2023, 3, 30), 50000)
    };

    static void Main()
    {
        MainMenu();
    }

    public static void MainMenu()
    {
        Console.WriteLine("Soal Test Lippo Karawaci Tbk");
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tampilkan Data Tagihan ");
        Console.WriteLine("2. Tampilkan Data Pembayaran");
        Console.WriteLine("3. Hitung dan Tampilkan Data Penalty");
        Console.WriteLine("4. Exit");
        Console.WriteLine("Pilih: ");

        try
        {
            int pilihMenu = Int32.Parse(Console.ReadLine());

            switch (pilihMenu)
            {

                case 1:
                    Console.Clear();
                    Console.WriteLine("1. Tampilkan Data Tagihan");
                    TampilkanDataTagihan(dataTagihan);
                    MainMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("2. Tampilkan Data Pembayaran");
                    TampilkanDataPembayaran(dataPembayaran);
                    MainMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("3.Hitung dan Tampilkan Data Penalty");
                    //HitungDanTampilkanPenalty(dataTagihan, dataPembayaran);
                    MainMenu();
                    break;
                case 4:
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

    static void TampilkanDataTagihan(List<Tagihan> tagihanList)
    {
        Console.Clear();
        Console.WriteLine("Data Table Tagihan");

        // Urutkan tagihanList berdasarkan bulan dari Due Date
        tagihanList = tagihanList.OrderBy(tagihan => tagihan.DueDate.Month).ThenBy(tagihan => tagihan.DueDate.Day).ToList();

        var table = new ConsoleTable("No Tagihan", "Due Date", "Total Tagihan");

        foreach (var tagihan in tagihanList)
        {
            table.AddRow(tagihan.NoTagihan, $"Due: {tagihan.DueDate:dd MMM yy}", tagihan.TotalTagihan.ToString("C"));
        }

        table.Write(Format.MarkDown);
    }



    static void TampilkanDataPembayaran(List<Pembayaran> pembayaranList)
    {
        Console.Clear();
        Console.WriteLine("Data Table Pembayaran");
        var table = new ConsoleTable("No Payment", "No Tagihan", "Pmt Date", "Pmt Amount");

        foreach (var pembayaran in pembayaranList)
        {
            table.AddRow(pembayaran.NoPayment, pembayaran.NoTagihan, pembayaran.PmtDate.ToString("dd MMM yy"), pembayaran.PmtAmount.ToString("C"));
        }

        table.Write(Format.MarkDown);
    }


    //percobaan 1 gagal
    //static void HitungDanTampilkanPenalty(List<Tagihan> tagihanList)
    //{
    //    Console.Clear();
    //    var table = new ConsoleTable("No Tagihan", "Total Tagihan", "Penalty");

    //    foreach (var tagihan in tagihanList)
    //    {
    //        double penalty = tagihan.HitungPenalty();
    //        table.AddRow(tagihan.NoTagihan, tagihan.TotalTagihan.ToString("C"), penalty.ToString("C"));
    //    }

    //    table.Write(Format.MarkDown);

    //}


    /////////BEDA dan masih GAGAL
    //static void HitungDanTampilkanPenalty(List<Tagihan> tagihanList, List<Pembayaran> pembayaranList)
    //{
    //    Console.Clear();
    //    var table = new ConsoleTable("No Tagihan", "No Penalty", "Tagihan Overdue", "Hari Keterlambatan", "Amount Penalty");

    //    foreach (var tagihan in tagihanList)
    //    {
    //        double penalty = tagihan.HitungPenalty();
    //        int noPenalty = HitungNomorPenalty(tagihan.NoTagihan, pembayaranList);
    //        double tagihanOverdue = HitungTagihanOverdue(tagihan.NoTagihan, tagihan.TotalTagihan, pembayaranList);
    //        int hariKeterlambatan = tagihan.HitungHariKeterlambatan();

    //        table.AddRow(tagihan.NoTagihan, noPenalty, tagihanOverdue.ToString("C"), hariKeterlambatan, penalty.ToString("C"));
    //    }

    //    table.Write(Format.MarkDown);
    //}

    //static int HitungNomorPenalty(string noTagihan, List<Pembayaran> pembayaranList)
    //{
    //    int nomorPenalty = 0;

    //    foreach (var pembayaran in pembayaranList)
    //    {
    //        if (pembayaran.NoTagihan == noTagihan)
    //        {
    //            nomorPenalty++;
    //        }
    //    }

    //    return nomorPenalty;
    //}

    //static double HitungTagihanOverdue(string noTagihan, double totalTagihan, List<Pembayaran> pembayaranList)
    //{
    //    double tagihanOverdue = totalTagihan;

    //    foreach (var pembayaran in pembayaranList)
    //    {
    //        if (pembayaran.NoTagihan == noTagihan)
    //        {
    //            tagihanOverdue -= pembayaran.PmtAmount;
    //        }
    //    }

    //    return tagihanOverdue;
    //}
} 
