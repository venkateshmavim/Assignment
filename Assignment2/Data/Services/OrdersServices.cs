using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment2.Data.Services
{
    public class OrdersServices
    {
        private NorthwindContext _context;
        public OrdersServices(NorthwindContext context)
        {
            _context = context;

        }

        string[] countries = { "Brazil", "Mexico", "Argentina", "Venezuela" };


        public List<Order> GetAllOrder() => _context.Orders.Where(p => countries.Contains(p.ShipCountry)).ToList(); 


    }
}
