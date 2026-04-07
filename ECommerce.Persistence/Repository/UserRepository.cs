using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Persistence.Repository
{
    public class UserRepository(ECommerceContext context) : BaseRepository<User>(context), IUserRepository
    {
     
    }
}
