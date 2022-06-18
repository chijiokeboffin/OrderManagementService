using AutoMapper;
using Contracts.Dtos;
using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class OrderService: IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
             _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ApiResponseDto> CreateAsync(OrderForCreationDto creationDto, CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.PersonRepository.FindByEmailAsync(creationDto.CreateBy, cancellationToken);

            if (person is null)
            {
                throw new PersonNotFoundException(creationDto.CreateBy);
            }

            if(await _repositoryManager.OrderRepository.IsOrderNumberExistAsync(creationDto.OderNo))
            {
                throw new DuplicateOrderNumberException($"Order number {creationDto.OderNo} already in the database");
            }

            var order = _mapper.Map<Order>(creationDto);

            order.PersonId = person.Id;
            order.OrderDate = DateTime.Now;

            _repositoryManager.OrderRepository.Insert(order);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponseDto { Code = (int)HttpStatusCode.Created, Message = "Order created successfully", TimeStamp = DateTime.Now };
        }
        public async Task<ApiResponseDto> GetAllByPersonEmailAsync(string createdBy, CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.PersonRepository.FindByEmailAsync(createdBy, cancellationToken);
            if (person is null)
            {
                throw new PersonNotFoundException(createdBy);
            }

            var orders = await _repositoryManager.OrderRepository.GetAllByPersonEmailAsync(createdBy, cancellationToken);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return new ApiResponseDto { Data = ordersDto, Code = (int)HttpStatusCode.Created, Message = "Order created successfully", TimeStamp = DateTime.Now };
        }     

        public async Task<OrderDto> GetByIdAsync(Guid orderId, string createdBy, CancellationToken cancellationToken = default)
        {

            var person = await _repositoryManager.PersonRepository.FindByEmailAsync(createdBy, cancellationToken);
            if (person is null)
            {
                throw new PersonNotFoundException(createdBy);
            }

            var order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId, cancellationToken);
            if (order is null)
            {
                throw new OrderNotFoundException(orderId);
            }

            if (order.PersonId != person.Id)
            {
                throw new OrderDoesNotBelongToPersonException(orderId, createdBy);
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
       

    }
}
