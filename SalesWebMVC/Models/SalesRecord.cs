using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models.Enum;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
        public SalesRecord()
        {

        }
        public SalesRecord(int Id, DateTime Date, double Amount, SaleStatus Status, Seller Seller)
        {
            this.Id = Id;
            this.Date = Date;
            this.Amount = Amount;
            this.Status = Status;
            this.Seller = Seller;
        }
    }
}
