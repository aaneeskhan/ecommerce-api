using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IRepository
{
    public interface IUserRepository:IBaseRepository<User> 
    {
     
    }
}
