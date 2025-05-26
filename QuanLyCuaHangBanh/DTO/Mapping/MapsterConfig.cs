using AutoMapper;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace QuanLyCuaHangBanh.DTO.Mapping
{
    public class MapsterConfig : Profile
    {
        public static void Configure()
        {
            TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
                .Map(dest => dest.ID, src => src.ID); 
        }

    }
}
