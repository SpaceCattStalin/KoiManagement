using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        public List<Order> GetAll(int userId);

        public List<Order> GetAll();
        public void CreateOrder(Order order);
        public void UpdateOrder(Order order, List<OrderDetail> details);


    }
}
