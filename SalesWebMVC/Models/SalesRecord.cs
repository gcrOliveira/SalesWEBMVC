using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models.Enum;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
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
