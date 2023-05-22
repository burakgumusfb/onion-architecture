using System;
using Application.Features.ProductOperations.Queries;
using AutoMapper;
using Onion.Architecture.Application.Common.BaseModels.Dtos;

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

