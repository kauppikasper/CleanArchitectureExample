using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureExample.Domain.Entities;

namespace CleanArchitectureExample.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);

        Task<bool> EmailExistsAsync(string email);

        Task AddAsync(User user);

        Task<User?> GetByEmailAsync(string email);
    }
}


