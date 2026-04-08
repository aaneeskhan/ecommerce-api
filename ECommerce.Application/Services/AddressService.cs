using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Address;
using ECommerce.Application.Utils.Result;

namespace ECommerce.Application.Services
{
    public class AddressService : IAddressService
    {
        public Task<Result<AddressResponse>> AddAddress(AddressRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AddressResponse>> DeleteById(AddressRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AddressResponse>> GetAddressById(AddressRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<AddressResponse>>> GetAddressByUserId(AddressRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AddressResponse>> UpdateAddress(UpdateAddressRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
