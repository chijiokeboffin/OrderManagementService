using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPersonService
    {
        Task<ApiResponseDto> GetAllPeopleAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);

        Task<PersonDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<ApiResponseDto> registerPerson(PersonForCreatingDto personDto, CancellationToken cancellationToken = default);
    }
}
