﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCagetoryId(int id);
        List<Product> GetAllByUnitPrice(decimal min, decimal max);
        List<ProductDetailsDto> GetProductDetails();

    }
}
