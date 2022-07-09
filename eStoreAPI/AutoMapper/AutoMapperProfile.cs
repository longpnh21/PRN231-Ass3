using AutoMapper;
using BusinessObject.Dtos;
using BusinessObject.Entities;

namespace eStoreAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
