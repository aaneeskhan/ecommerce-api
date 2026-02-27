using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Persistence.Repository
{
    public class AuthRepository(ECommerceContext context) : BaseRepository<Users>(context), IAuthRepository
    {
    }
}
