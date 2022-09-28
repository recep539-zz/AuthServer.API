﻿using CoreLayer.DTOs;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.GenericServices
{
    public interface IUserService
    {
        Task<Response<UserAppDTO>> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<Response<UserAppDTO>> GetUserByNameAsync(string userName);
        Task<Response<NoDataDTO>> CreateUserRoles(string UserName);
    }
}
