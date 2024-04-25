using APICatalogo.DTOs;
using APICatalogo.Models;
using AutoMapper;

namespace APICatalogo.Mappings;

public class ProductDTOMappingProfile : Profile
{
    public ProductDTOMappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
