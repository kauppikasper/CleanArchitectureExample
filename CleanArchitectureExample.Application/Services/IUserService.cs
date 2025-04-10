using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureExample.Domain.Entities;


public interface IUserService
{
    Task<User> GetUserByEmailAsync(string email);
}
