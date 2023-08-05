using System;
using Common.Constants.Product;

namespace Common.Entitties
{
	public class Product:BaseEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Photo { get; set; }
        public ProductType Type { get; set; }

    }
}

