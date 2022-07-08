using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Exceptions
{
    public class DbConcurrencyExeception:ApplicationException
    {
        public DbConcurrencyExeception(string Message):base(Message)
        {

        }
    }
}
