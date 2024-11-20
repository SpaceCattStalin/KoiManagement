using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public void Add(Customer customer)
        {
            _repository.Add(customer);
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer GetCustomer(string username, string password)
        {
            return _repository.GetCustomer(username, password);
        }

        public void Remove(Customer customer)
        {
            _repository.Remove(customer);
        }

        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }
    }
}
