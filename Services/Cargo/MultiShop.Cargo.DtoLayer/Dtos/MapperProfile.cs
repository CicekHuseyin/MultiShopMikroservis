using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<UpdateCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<CreateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<UpdateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<CreateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<UpdateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<CreateCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<UpdateCargoOperationDto, CargoOperation>().ReverseMap();
        }
    }
}
