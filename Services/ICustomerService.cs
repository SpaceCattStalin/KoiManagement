using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        public List<Customer> GetAll();

        public void Add(Customer customer);
        public void Remove(Customer customer);

        public Customer GetCustomer(string username, string password);

        public void Update(Customer customer);

    }
}
