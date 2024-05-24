using PE1_NonPreCode.DTOs;
using PE1_NonPreCode.Models;
using AutoMapper;

namespace PE1_NonPreCode.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile() { 
            CreateMap<Order, OrderDTO>();
        }
        
    }
}
