using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiManagementContext _context;

        public OrderRepository()
        {
            _context = new KoiManagementContext();
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            SaveChanges();
        }

        public List<Order> GetAll(int userId)
        {
            return _context.Orders.Include(o => o.OrderDetails).ThenInclude(k => k.Koi).Where(u => u.UserId == userId).ToList();
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Include(u => u.User).Include(o => o.OrderDetails).ThenInclude(k => k.Koi).OrderBy(o => o.CreatedAt).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order, List<OrderDetail> details)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder != null)
            {
                foreach (var item in details)
                {
                    existingOrder.OrderDetails.Add(item);
                }
            }
            _context.Update(existingOrder);
            SaveChanges();
        }


    }
}
