using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models.Enum;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Seller()
        {

        }
        public Seller(int Id, string Name, string Email, DateTime Birthday, double BaseSalary, Department Department)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Birthday = Birthday;
            this.BaseSalary = BaseSalary;
            this.Department = Department;
            
        }
        public void addSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date>=initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
