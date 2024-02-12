using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTagihanPenaltyDanPembayaran
{
    public class Tagihan
    {
        public string NoTagihan { get; }
        public DateTime DueDate { get; }
        public double TotalTagihan { get; }

        public Tagihan(string noTagihan, DateTime dueDate, double totalTagihan)
        {
            NoTagihan = noTagihan;
            DueDate = dueDate;
            TotalTagihan = totalTagihan;
        }

        public int HitungHariKeterlambatan()
        {
            int hariKeterlambatan = (DateTime.Now - DueDate).Days;
            return Math.Max(hariKeterlambatan, 0);
        }

        public double HitungPenalty()
        {
            double tarifPenaltyPerHari = 0.002; // Ubah sesuai dengan tarif penalty yang sesuai
            int hariKeterlambatan = HitungHariKeterlambatan();
            return hariKeterlambatan * tarifPenaltyPerHari * TotalTagihan;
        }
    }
    
}
