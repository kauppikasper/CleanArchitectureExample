using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.Dtos;
using CleanArchitectureExample.Domain.Entities;

namespace CleanArchitectureExample.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}

