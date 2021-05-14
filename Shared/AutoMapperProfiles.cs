﻿using MCIT_Task.Domain.Entities;
using MCIT_Task.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MCIT_Task.Domain.ParameterObjects;

namespace MCIT_Task.Shared
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductInputParameter, CreateProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryInputParameter, CreateCategoryDto>();
        }
    }
}