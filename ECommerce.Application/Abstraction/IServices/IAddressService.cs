using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.RRModels.Address;
using ECommerce.Application.Utils.Result;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface IAddressService
    {
        Task<Result<AddressResponse>> AddAddress(AddressRequest model);
        Task<Result<AddressResponse>> UpdateAddress(UpdateAddressRequest model);
        Task<Result<AddressResponse>> GetAddressById(AddressRequest model);
        Task<Result<IEnumerable< AddressResponse>>> GetAddressByUserId(AddressRequest model);
        Task<Result<AddressResponse>> DeleteById(AddressRequest model);
    }
}
