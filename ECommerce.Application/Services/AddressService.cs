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
            bool isExist = await adddressRepository.IsExistAsync(x => x.AddressLine == model.AddressLine && x.State == model.State && x.City == model.City);
            if (isExist)
            {
                return Result<AddressResponse>.Failure("Address already exists", StatusCodes.Status400BadRequest);
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

        public Task<Result<int>> DeleteAddresses(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> DeleteAllAddresses()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AddressResponse>> DeleteById(Guid id)
        {
            var address=await adddressRepository.GetByIdAsync(id);
            if(address is null)
            {
                return Result<AddressResponse>.Failure("No address foung", StatusCodes.Status404NotFound);
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
                }, message: "Address added successfully", statusCode: StatusCodes.Status200OK);
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
                }, message: "Address added successfully", statusCode: StatusCodes.Status200OK);
            }

            return Result<AddressResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<IEnumerable<AddressResponse>>> GetAddressByUserId()
        {
            var userId = contextService.GetId();
            if (userId == Guid.Empty)
            {
                return Result<IEnumerable<AddressResponse>>.Failure("unauthorized user please login again", StatusCodes.Status401Unauthorized);
            }
            var addresses = await adddressRepository.FindByAsync(x=>x.Id==userId);
            if (addresses is not null)
            {
                return Result<IEnumerable<AddressResponse>>.Success(value: addresses.Select(x => new AddressResponse
                {
                    Id = x.Id,
                    AddressLine = x.AddressLine,
                    Landmark = x.Landmark,
                    City = x.City,
                    State = x.State,
                    Pincode = x.Pincode,
                    ContactNo = x.ContactNo,
                    UserId = x.UserId
                }), message: "Address added successfully", statusCode: StatusCodes.Status200OK);
            }

            return Result<IEnumerable<AddressResponse>>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }

        public Task<Result<AddressResponse>> UpdateAddress(UpdateAddressRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
