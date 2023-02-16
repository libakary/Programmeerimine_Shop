﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.RealEstate;

namespace TARge21Shop.Controllers
{
	public class RealEstatesController : Controller
	{
		private readonly TARge21ShopContext _context;
		private readonly IRealEstatesServices _realEstatesServices;

		public RealEstatesController
			(
				TARge21ShopContext context,
				IRealEstatesServices realEstatesServices
			) 
		{
			_context = context;
			_realEstatesServices = realEstatesServices;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var result = _context.RealEstates
				.OrderByDescending(y => y.CreatedAt)
				.Select(x => new RealEstateIndexViewModel
				{
					Id = x.Id,
					Address = x.Address,
					City = x.City,
					Country = x.Country,
					Size = x.Size,
					Price = x.Price,
				});

			return View(result);
		}

		[HttpGet]
		public IActionResult Create()
		{
			RealEstateCreateUpdateViewModel vm = new();

			return View("CreateUpdate", vm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
		{
			var dto = new RealEstateDto()
			{
				Id = vm.Id,
				Address = vm.Address,
				City = vm.City,
				Country = vm.Country,
				Size = vm.Size,
				Price = vm.Price,
				Floor = vm.Floor,
				Region = vm.Region,
				Phone = vm.Phone,
				Fax = vm.Fax,
				PostalCode = vm.PostalCode,
				RoomCount = vm.RoomCount,
				CreatedAt = vm.CreatedAt,
				ModifiedAt = vm.ModifiedAt,
				Files = vm.Files,
				FileToApiDtos = vm.FileToApiViewModels
					.Select(x => new FileToApiDto
					{
						Id = x.ImageId,
						FilePath = x.FilePath,
						RealEstateId = x.RealEstateId
					}).ToArray()
			};

			var result = await _realEstatesServices.Create(dto);

			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction("Index", vm);
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var realEstate = await _realEstatesServices.GetAsync(id);
			if (realEstate == null)
			{
				return NotFound();
			}

			var images = await _context.FileToApis
				.Where(x => x.RealEstateId == id)
				.Select(y => new FileToApiViewModel
				{
					FilePath = y.FilePath,
					ImageId = y.Id

				}).ToArrayAsync();

			var vm = new RealEstateCreateUpdateViewModel();

			vm.Id = realEstate.Id;
			vm.Address = realEstate.Address;
			vm.City = realEstate.City;
			vm.Country = realEstate.Country;
			vm.Size = realEstate.Size;
			vm.Price = realEstate.Price;
			vm.Floor = realEstate.Floor;
			vm.Region = realEstate.Region;
			vm.Phone = realEstate.Phone;
			vm.Fax = realEstate.Fax;
			vm.PostalCode = realEstate.PostalCode;
			vm.RoomCount = realEstate.RoomCount;
			vm.CreatedAt = realEstate.CreatedAt;
			vm.ModifiedAt = realEstate.ModifiedAt;
			vm.FileToApiViewModels.AddRange(images);

			return View("CreateUpdate", vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
		{
			var dto = new RealEstateDto()
			{
				Id = vm.Id,
				Address = vm.Address,
				City = vm.City,
				Country = vm.Country,
				Size = vm.Size,
				Price = vm.Price,
				Floor = vm.Floor,
				Region = vm.Region,
				Phone = vm.Phone,
				Fax = vm.Fax,
				PostalCode = vm.PostalCode,
				RoomCount = vm.RoomCount,
				CreatedAt = vm.CreatedAt,
				ModifiedAt = vm.ModifiedAt,
			};

			var result = await _realEstatesServices.Update(dto);
			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var realEstate = await _realEstatesServices.GetAsync(id);

			if (realEstate == null)
			{
				return NotFound();
			}

			var images = await _context.FileToApis
				.Where(x => x.RealEstateId == id)
				.Select(y => new FileToApiViewModel
				{
					FilePath = y.FilePath,
					ImageId = y.Id

				}).ToArrayAsync();

			var vm = new RealEstateDetailsViewModel();

			vm.Id = realEstate.Id;
			vm.Address = realEstate.Address;
			vm.City = realEstate.City;
			vm.Country = realEstate.Country;
			vm.Size = realEstate.Size;
			vm.Price = realEstate.Price;
			vm.Floor = realEstate.Floor;
			vm.Region = realEstate.Region;
			vm.Phone = realEstate.Phone;
			vm.Fax = realEstate.Fax;
			vm.PostalCode = realEstate.PostalCode;
			vm.RoomCount = realEstate.RoomCount;
			vm.CreatedAt = realEstate.CreatedAt;
			vm.ModifiedAt = realEstate.ModifiedAt;
			vm.FileToApiViewModels.AddRange(images);

			return View(vm);

		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var realEstate = await _realEstatesServices.GetAsync(id);

			if (realEstate == null)
			{
				return NotFound();
			}

			var images = await _context.FileToApis
				.Where(x => x.RealEstateId == id)
				.Select(y => new FileToApiViewModel
				{
					FilePath = y.FilePath,
					ImageId = y.Id

				}).ToArrayAsync();

			var vm = new RealEstateDeleteViewModel();

			vm.Id = realEstate.Id;
			vm.Address = realEstate.Address;
			vm.City = realEstate.City;
			vm.Country = realEstate.Country;
			vm.Size = realEstate.Size;
			vm.Price = realEstate.Price;
			vm.Floor = realEstate.Floor;
			vm.Region = realEstate.Region;
			vm.Phone = realEstate.Phone;
			vm.Fax = realEstate.Fax;
			vm.PostalCode = realEstate.PostalCode;
			vm.RoomCount = realEstate.RoomCount;
			vm.CreatedAt = realEstate.CreatedAt;
			vm.ModifiedAt = realEstate.ModifiedAt;
			vm.FileToApiViewModels.AddRange(images);

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var realEstateId = await _realEstatesServices.Delete(id);
			if (realEstateId == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(Index));
		}

	}
}
