using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTagihanPenaltyDanPembayaran
{
    public class Pembayaran
    {
        public string NoPayment { get; }
        public string NoTagihan { get; }
        public DateTime PmtDate { get; }
        public double PmtAmount { get; }

        public Pembayaran(string noPayment, string noTagihan, DateTime pmtDate, double pmtAmount)
        {
            NoPayment = noPayment;
            NoTagihan = noTagihan;
            PmtDate = pmtDate;
            PmtAmount = pmtAmount;
        }
    }
}
