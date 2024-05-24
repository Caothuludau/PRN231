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
        public IActionResult GetOrderByDate(string from, string to)
        {
            DateTime fromTime = DateTime.ParseExact(from, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            DateTime toTime = DateTime.ParseExact(to, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
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
    }
}
