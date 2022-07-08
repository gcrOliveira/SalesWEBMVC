using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models.Enum;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Size Should be Between {2} and {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a valid Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        [Range(100.0,50000.0,ErrorMessage ="{0} should be between R${2} and R${1}")]
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
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
