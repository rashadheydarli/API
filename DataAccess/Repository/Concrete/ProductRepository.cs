using System;
using Common.Entitties;
using DataAccess.Context;
using DataAccess.Repository.Abstract;
using DataAccess.Repository.Base;

namespace DataAccess.Repository.Concrete
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
		{
		}
	}
}

