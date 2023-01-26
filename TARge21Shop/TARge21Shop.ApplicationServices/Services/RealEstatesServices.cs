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
		public async Task<RealEstate> GetAsync()
		{
			//var result = await _context.RealEstates;

			return null;
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
	}
}