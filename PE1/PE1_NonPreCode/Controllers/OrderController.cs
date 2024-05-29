using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE1_NonPreCode.DTOs;
using PE1_NonPreCode.Mapper;
using PE1_NonPreCode.Models;
using System.Globalization;

namespace PE1_NonPreCode.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly PRN_Sum22_B1Context _context;
        private readonly IMapper _mapper;

        public OrderController(PRN_Sum22_B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getAllOrder")]
        public IActionResult GetAllOrder()
        {
            var listOrder = _context.Orders.Select(o => new OrderDTO()
            {
                CustomerId = o.CustomerId,
                CustomerName = o.Customer.CompanyName,
                EmployeeId = o.EmployeeId,
                EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName,
                EmployeeDepartmentId = o.Employee.DepartmentId,
                EmployeeDepartmentName = o.Employee.Department.DepartmentName,
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                Freight = o.Freight,
                ShipName = o.ShipName,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry
            })
                                            .ToList();

            /*var listOrder = _context.Orders.ToList();
            var listOrderDTO = _mapper.Map<List<OrderDTO>>(listOrder);*/
            return Ok(listOrder);
        }

        [HttpGet("getOrderByDate/{From}/{To}")]
        public IActionResult GetOrderByDate(string From, string To)
        {
            DateTime fromTime = DateTime.ParseExact(From, "dd MMM yyyy", CultureInfo.InvariantCulture);
            DateTime toTime = DateTime.ParseExact(To, "dd MMM yyyy", CultureInfo.InvariantCulture);
            /*DateTime fromTime = new DateTime(1996, 10, 10); 
            DateTime toTime = new DateTime(1996, 10, 15);*/
            var listOrder = _context.Orders.Where(o => o.OrderDate >= fromTime && o.OrderDate <= toTime)
                .Select(o => new OrderDTO()
                {
                    CustomerId = o.CustomerId,
                    CustomerName = o.Customer.CompanyName,
                    EmployeeId = o.EmployeeId,
                    EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName,
                    EmployeeDepartmentId = o.Employee.DepartmentId,
                    EmployeeDepartmentName = o.Employee.Department.DepartmentName,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipRegion = o.ShipRegion,
                    ShipPostalCode = o.ShipPostalCode,
                    ShipCountry = o.ShipCountry
                })
                .ToList(); 
            return Ok(listOrder);
        }

        [HttpPost("customer/delete/{CustomerId}")]
        public IActionResult DeleteCustomer(string CustomerId)
        {
            try
            {
                var customerFound = _context.Customers.Where(c => c.CustomerId == CustomerId)
                                .Include(c => c.Orders)
                                .FirstOrDefault();
                if (customerFound == null)
                {
                    return NotFound();
                }
                else
                {
                    // If customer found, delete associated orders
                    _context.OrderDetails.RemoveRange(customerFound.Orders.SelectMany(o => o.OrderDetails));
                    _context.Orders.RemoveRange(customerFound.Orders);
                    _context.Customers.Remove(customerFound);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting customer: {ex}");

                // Return Conflict response with the specified message
                return Conflict("There was an unknown error when performing data deletion.");
            }

        }
    }
}
