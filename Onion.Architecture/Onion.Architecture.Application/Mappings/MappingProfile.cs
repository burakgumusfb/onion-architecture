using System;
using Application.Features.ProductOperations.Queries;
using AutoMapper;

namespace Onion.Architecture.Application.Mappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<ProductListItem,GetProductsQueryResponse>();
		}
	}
}

