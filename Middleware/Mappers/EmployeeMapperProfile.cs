using ApiSample.Middleware.Commands;
using ApiSample.Middleware.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSample.Middleware.Mappers
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>();
            CreateMap<TopUpCardRequest, TopUpCardCommand>();
            CreateMap<SpendOnCardRequest, SpendOnCardCommand>();
        }
    }
}
