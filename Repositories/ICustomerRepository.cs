using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Models;

namespace Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public Customer GetCustomer(string username, string password);
        public void Add(Customer customer);

        public void Remove(Customer customer);
        public void Update(Customer customer);
    }
}
