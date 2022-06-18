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
    public class PersonService: IPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ApiResponseDto> GetAllPeopleAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default)
        {

            var people = await _repositoryManager.PersonRepository.GetAllPeopleAsync(pageNo, pageSize, cancellationToken);
            if(people is null || people.Count() <= 0)
            {
                throw new PeopleNotFoundException("No record found in the database");// Enumerable.Empty<PersonDto>();
            }

            var peopleDto =  _mapper.Map<List<PersonDto>>(people);
            
            return new ApiResponseDto { Data = peopleDto, Message = "Retrieved successfully", Code = (int)HttpStatusCode.OK, TimeStamp =DateTime.Now};
        }
        public async Task<PersonDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.PersonRepository.FindByEmailAsync(email, cancellationToken);
            if (person is null)
            {
                throw new PersonNotFoundException(email);
            }
          
            var persontDto = _mapper.Map<PersonDto>(person);
            return persontDto;
        }   

        public async Task<ApiResponseDto> registerPerson(PersonForCreatingDto personDto, CancellationToken cancellationToken = default)
        {
            var existPerson = await _repositoryManager.PersonRepository.FindByEmailAsync(personDto.Email, cancellationToken);
            if (existPerson is not null) 
            {
                throw new EmailInUseException($"Another person with the email {personDto.Email} exist in the database");
            }
            var person = _mapper.Map<Person>(personDto);
            person.CreatedDate = DateTime.Now;
         
            this._repositoryManager.PersonRepository.Insert(person);
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return new ApiResponseDto {Message = "Created successfully", Code = (int)HttpStatusCode.OK, TimeStamp = DateTime.Now };
        }
      
    }
}
