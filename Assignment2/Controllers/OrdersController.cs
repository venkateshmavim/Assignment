using Assignment2.Data.Services;
using Assignment2.Model;
using Assignment2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Assignment2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersServices _orderservices;
        private IJWTManagerRepository jwtManager;

        public OrdersController(OrdersServices ordersServices,IJWTManagerRepository jWTManager)
        {
            _orderservices = ordersServices;
            jwtManager = jWTManager;
        }

        [HttpGet("Get-Orders")]
        public IActionResult GetAllOrder()
        {
            
            var allorders=_orderservices.GetAllOrder();
            return Ok(allorders);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate")]
        public IActionResult Authenticate(User userData)
        {
            var token = jwtManager.Authenticate(userData);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select OrderId,CustomerId,ShipCoutry from dbo.Orders where ShipCountry in ('Brazil','Mexico','Argentina','Venezuela') ";

            DataTable table = new DataTable();
            SqlDataReader myreader;
            using(SqlConnection mycon=new SqlConnection())
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    myreader = mycmd.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        
    }
}
