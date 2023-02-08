﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
	public class RealEstatesServices : IRealEstatesServices
	{
		private readonly TARge21ShopContext _context;
	
		public RealEstatesServices
			(
				TARge21ShopContext context
			)
		{
			_context = context;

		}
		public async Task<RealEstate> GetAsync(Guid id)
		{
			var result = await _context.RealEstates
				.FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}

		public async Task<RealEstate> Create(RealEstateDto dto)
		{
			RealEstate realEstate = new();

			realEstate.Id = Guid.NewGuid();
			realEstate.Address = dto.Address;
			realEstate.City = dto.City;
			realEstate.Region = dto.Region;
			realEstate.PostalCode = dto.PostalCode;
			realEstate.Country = dto.Country;
			realEstate.Phone = dto.Phone;
			realEstate.Fax = dto.Fax;
			realEstate.Size = dto.Size;
			realEstate.Floor = dto.Floor;
			realEstate.Price = dto.Price;
			realEstate.RoomCount = dto.RoomCount;
			realEstate.ModifiedAt = DateTime.Now;
			realEstate.CreatedAt= DateTime.Now;

			await _context.RealEstates.AddAsync(realEstate);
			await _context.SaveChangesAsync();

			return realEstate;
		}

		public async Task<RealEstate> Update(RealEstateDto dto)
		{
			var domain = new RealEstate()
			{
				Id = dto.Id,
				Address = dto.Address,
				City = dto.City,
				Region = dto.Region,
				PostalCode = dto.PostalCode,
				Country = dto.Country,
				Phone = dto.Phone,
				Fax = dto.Fax,
				Size = dto.Size,
				Floor = dto.Floor,
				Price = dto.Price,
				RoomCount = dto.RoomCount,
				ModifiedAt = DateTime.Now,
			};

			_context.RealEstates.Update(domain);
			await _context.SaveChangesAsync();
			return domain;
		}

		public async Task<RealEstate> Delete(Guid id)
		{
			var realEstateId = await _context.RealEstates
				.FirstOrDefaultAsync(x => x.Id == id);

			//siia tuleb images

			_context.RealEstates.Remove(realEstateId);
			await _context.SaveChangesAsync();

			return realEstateId;
		}
	}
}
