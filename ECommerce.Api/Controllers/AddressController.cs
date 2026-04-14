using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController(IAddressService addressService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IResult> CreateAddress(AddressRequest model)
        {
            return this.ApiResponse(await addressService.AddAddress(model));
        }


        [HttpDelete("")]
        public async Task<IResult> DeleteAllAdresses()
        {
            return this.ApiResponse(await addressService.DeleteAllAddresses());
        }



        [HttpDelete("{ids}")]
        public async Task<IResult> DeleteAdresses(IEnumerable<Guid> ids)
        {
            return this.ApiResponse(await addressService.DeleteAddresses(ids));
        }


        [HttpDelete("id-{id}")]
        public async Task<IResult> DeleteAddressById(Guid id)
        {
            return this.ApiResponse(await addressService.DeleteById(id));
        }


        [HttpGet("{id}")]
        public async Task<IResult> GetAddressById(Guid id)
        {
            return this.ApiResponse(await addressService.GetAddressById(id));
        }


        [HttpGet("")]
        public async Task<IResult> GetAddressByUserId()
        {
            return this.ApiResponse(await addressService.GetAddressByUserId());
        }


        [HttpPut("")]
        public async Task<IResult> UpdateAddress(UpdateAddressRequest model)
        {
            return this.ApiResponse(await addressService.UpdateAddress(model));
        }


    }
}
