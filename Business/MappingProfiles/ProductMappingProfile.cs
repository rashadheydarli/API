using System;
using AutoMapper;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Common.Entitties;

namespace Business.MappingProfiles
{
	public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<ProductCreateDTO, Product>();
			//.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name)); // prop adlari ferqlidirse bele edirik

			CreateMap<Product, ProductDTO>();
			CreateMap<ProductUpdateDTO, Product>();
				//.ForMember(dest => dest.Title, opt => opt.Ignore()) --- //eger productun icindeki title nedirse onu da saxlayacaq updateden geleni deyismeyecek
		}
	}
}

