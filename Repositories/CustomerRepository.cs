using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Models;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KoiManagementContext _context;

        public CustomerRepository()
        {
            _context = new KoiManagementContext();
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            SaveChanges();
        }



        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(string username, string password)
        {
            return _context.Customers.FirstOrDefault(c => c.Username == username && c.Password == password);
        }

        public void Remove(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.UserId == customer.UserId);
            if (existingCustomer != null)
            {
                existingCustomer.IsActive = 0;
            }
            _context.Customers.Update(existingCustomer);

            SaveChanges();
        }

        public void Update(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.UserId == customer.UserId);
            if (existingCustomer != null)
            {
                existingCustomer.Role = customer.Role;
                existingCustomer.Username = customer.Username;
                existingCustomer.IsActive = customer.IsActive;
                existingCustomer.Fullname = customer.Fullname;
                existingCustomer.Address = customer.Address;
                existingCustomer.Phone = customer.Phone;
            }
            _context.Customers.Update(existingCustomer);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
