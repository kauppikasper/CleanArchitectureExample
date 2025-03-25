﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureExample.Domain.Interfaces;

namespace CleanArchitectureExample.Application.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet (string name)
        {
            return $"Hello, {name}!";
        }
 
    }
}
