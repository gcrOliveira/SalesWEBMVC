using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMVC.Models

{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> SellerList { get; set; } = new List<Seller>();
        public Department()
        {

        }
        public Department(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
           
        }
        public void addSeller(Seller salesperson)
        {
            SellerList.Add(salesperson);
        }
        public double totalSales(DateTime initial, DateTime final)
        {
            return SellerList.Sum(Seller => Seller.totalSales(initial, final));
        }
    }

}
