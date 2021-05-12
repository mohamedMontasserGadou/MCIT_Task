using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateUser(Object user);
    }
}
