using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ECommerce.Application.Abstraction.IContextService;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Address;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services
{
    public class AddressService(IAdddressRepository adddressRepository, IContextService contextService) : IAddressService
    {
        public async Task<Result<AddressResponse>> AddAddress(AddressRequest model)
        {
            var userId = contextService.GetId();
            if (userId == Guid.Empty)
            {
                return Result<AddressResponse>.Failure("unauthorized user please login again", StatusCodes.Status401Unauthorized);
            }
            
            var addresses =await adddressRepository.FindByAsync(x=> x.UserId == userId);
            var isAny=addresses.Any(x=>x.Landmark==model.Landmark && x.City==model.City && x.State==model.State && x.AddressLine==model.AddressLine);

            if(isAny)
            {
                return Result<AddressResponse>.Failure("Address already exists", StatusCodes.Status409Conflict);
            }


            var address = new Address
            {
                AddressLine = model.AddressLine,
                Landmark = model.Landmark,
                State = model.State,
                City = model.City,
                Pincode = model.Pincode,
                ContactNo = model.ContactNo,
                UserId = userId,
            };
            var returnValue = await adddressRepository.AddAsync(address);
            if (returnValue > 0)
            {
                return Result<AddressResponse>.Success(value: new AddressResponse
                {
                    Id = address.Id,
                    AddressLine = address.AddressLine,
                    Landmark = address.Landmark,
                    City = address.City,
                    State = address.State,
                    Pincode = address.Pincode,
                    ContactNo = address.ContactNo,
                    UserId = address.UserId
                }, message: "Address added successfully", statusCode: StatusCodes.Status201Created);
            }
            return Result<AddressResponse>.Failure("Failed to add", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<int>> DeleteAddresses(IEnumerable<Guid> ids)
        {
            var isDeleted=await adddressRepository.DeleteRangeAsync(ids);
            if (isDeleted > 0)
            {
                return Result<int>.Success(message: "Addresses Deleted successfully");
            }
            return Result<int>.Failure("Something Went wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<int>> DeleteAllAddresses()
        {
            var userId = contextService.GetId();
            if (userId == Guid.Empty)
            {
                return Result<int>.Failure("unauthorized user please login again", StatusCodes.Status401Unauthorized);
            }
            var addresses=await adddressRepository.FindByAsync(x => x.UserId == userId);
            if(addresses is null)
            {
                return Result<int>.Failure("No addresses found", StatusCodes.Status404NotFound);
            }
            var isDeleted=await adddressRepository.DeleteRangeAsync(addresses);
            if(isDeleted > 0)
            {
                return Result<int>.Success(message:"Addresses Deleted successfully");
            }
            return Result<int>.Failure("Something Went wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<AddressResponse>> DeleteById(Guid id)
        {
            var address=await adddressRepository.GetByIdAsync(id);
            if(address is null)
            {
                return Result<AddressResponse>.Failure("No address found", StatusCodes.Status404NotFound);
            }
            var isDeleted=await adddressRepository.DeleteAsync(id);
            if(isDeleted > 0)
            { 
                return Result<AddressResponse>.Success(value: new AddressResponse
                {
                    Id = address.Id,
                    AddressLine = address.AddressLine,
                    Landmark = address.Landmark,
                    City = address.City,
                    State = address.State,
                    Pincode = address.Pincode,
                    ContactNo = address.ContactNo,
                    UserId = address.UserId
                }, message: "Address Deleted successfully", statusCode: StatusCodes.Status200OK);
            }
            return Result<AddressResponse>.Failure("Something Went wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<AddressResponse>> GetAddressById(Guid id)
        {
            var address=await adddressRepository.GetByIdAsync(id);
            if(address is not null)
            {
                return Result<AddressResponse>.Success(value: new AddressResponse
                {
                    Id = address.Id,
                    AddressLine = address.AddressLine,
                    Landmark = address.Landmark,
                    City = address.City,
                    State = address.State,
                    Pincode = address.Pincode,
                    ContactNo = address.ContactNo,
                    UserId = address.UserId
                }, message: "Address Fetched successfully", statusCode: StatusCodes.Status200OK);
            }

            return Result<AddressResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);

        }
        

             public async Task<Result<IEnumerable<AddressResponse>>> GetAddressByUserId(Guid userId)
        {
            //if (userId == Guid.Empty)
            //{
            //    return Result<IEnumerable<AddressResponse>>.Failure("unauthorized user please login again", StatusCodes.Status401Unauthorized);
            //}
            var addresses = await adddressRepository.FindByAsync(x => x.UserId == userId);
            if (addresses is not null)
            {
                var allAddresses = addresses.Select(x => new AddressResponse
                {
                    Id = x.Id,
                    AddressLine = x.AddressLine,
                    Landmark = x.Landmark,
                    City = x.City,
                    State = x.State,
                    Pincode = x.Pincode,
                    ContactNo = x.ContactNo,
                    UserId = x.UserId
                });
                return Result<IEnumerable<AddressResponse>>.Success(value: allAddresses, message: "Addresses Fetched successfully", statusCode: StatusCodes.Status200OK);
            }

            return Result<IEnumerable<AddressResponse>>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<IEnumerable<AddressResponse>>> GetAddressesOfLogenInUserId()
        {
            var userId = contextService.GetId();
            if (userId == Guid.Empty)
            {
                return Result<IEnumerable<AddressResponse>>.Failure("unauthorized user please login again", StatusCodes.Status401Unauthorized);
            }
            var addresses = await adddressRepository.FindByAsync(x=>x.UserId==userId);
            if (addresses is not null)
            {
                var allAddresses = addresses.Select(x => new AddressResponse
                {
                    Id = x.Id,
                    AddressLine = x.AddressLine,
                    Landmark = x.Landmark,
                    City = x.City,
                    State = x.State,
                    Pincode = x.Pincode,
                    ContactNo = x.ContactNo,
                    UserId = x.UserId
                });
                return Result<IEnumerable<AddressResponse>>.Success(value: allAddresses, message: "Addresses Fetched successfully", statusCode: StatusCodes.Status200OK);
            }

            return Result<IEnumerable<AddressResponse>>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<AddressResponse>> UpdateAddress(UpdateAddressRequest model)
        {
            var address = await adddressRepository.GetByIdAsync(model.Id);
            if (address is null)
            {
                return Result<AddressResponse>.Failure("No Address found matching such id", StatusCodes.Status401Unauthorized);
            }

            address.Landmark = model.Landmark;
            address.City = model.City;
            address.AddressLine = model.AddressLine;
            address.ContactNo = model.ContactNo;
            address.State = model.State;
            address.Pincode = model.Pincode;

            var isUpdated=await adddressRepository.UpdateAsync(address);

            if(isUpdated > 0)
            {
                var addressResponse=new AddressResponse()
                {
                    Landmark = address.Landmark,
                    City = address.City,
                    AddressLine = address.AddressLine,
                    ContactNo= address.ContactNo,
                    State = address.State,
                    Pincode = address.Pincode,
                    Id = address.Id,
                    UserId=address.UserId
                };
                return Result<AddressResponse>.Success(value: addressResponse, message: "Address updated Successfully");
            }

            return Result<AddressResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }
    }
}
