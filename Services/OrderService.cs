using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
        }

        public List<Order> GetAll(int userId)
        {
            return _orderRepository.GetAll(userId);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void UpdateOrder(Order order, List<OrderDetail> details)
        {
            _orderRepository.UpdateOrder(order, details);
        }


    }
}
