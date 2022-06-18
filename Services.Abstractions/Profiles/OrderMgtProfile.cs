using AutoMapper;
using Contracts.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class OrderMgtProfile: Profile
    {
        public OrderMgtProfile()
        {
            CreateMap<PersonForCreatingDto, Person>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<Order, OrderDto>();
           
            CreateMap<Person, PersonDto>();
        }
    }
}
