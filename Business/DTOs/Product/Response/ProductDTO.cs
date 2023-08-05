﻿using System;
using Common.Constants.Product;

namespace Business.DTOs.Product.Response
{
	public class ProductDTO
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Photo { get; set; }
        public ProductType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}

