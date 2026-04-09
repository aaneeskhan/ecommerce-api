using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Address;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Controllers
{
    public class AddressController(IAddressService addressService) : ControllerBase
    {
        public async Task<IResult> CreateAddress(AddressRequest model)
        {
            return this.ApiResponse(await addressService.AddAddress(model));
        }
    }
}
