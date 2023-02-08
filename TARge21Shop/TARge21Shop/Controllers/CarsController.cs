using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;
using TARge21Shop.Models.Spaceship;

namespace TARge21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ICarsServices _carsServices;
        private readonly IFilesServices _filesServices;

        public CarsController
            (
                TARge21ShopContext context,
                ICarsServices carsServices,
                IFilesServices filesServices
            )
        {
            _context = context;
            _carsServices = carsServices;
            _filesServices = filesServices;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Make = x.Make,
                    Model = x.Model,
                    MaxPassengers = x.MaxPassengers,
                    EnginePower = x.EnginePower
                });
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

			var photos = await _context.FileToDatabases
				.Where(x => x.CarId == id)
				.Select(y => new ImageViewModel
				{
					CarId = y.Id,
					ImageId = y.Id,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();

            var vm = new CarDetailsViewModel();

			vm.Id = car.Id;
			vm.Name = car.Name;
			vm.BodyStyle = car.BodyStyle;
			vm.Make = car.Make;
			vm.Model = car.Model;
			vm.EnginePower = car.EnginePower;
			vm.MaxPassengers = car.MaxPassengers;
			vm.WeightCapacity = car.WeightCapacity;
			vm.BuiltDate = car.BuiltDate;
			vm.MaintenanceCount = car.MaintenanceCount;
			vm.LastMaintenance = car.LastMaintenance;
			vm.CreatedAt = car.CreatedAt;
			vm.ModifiedAt = car.ModifiedAt;
			vm.Image.AddRange(photos);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarUpdateViewModel car = new CarUpdateViewModel();
            return View("Update", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                BodyStyle = vm.BodyStyle,
                Make = vm.Make,
                Model = vm.Model,
                EnginePower = vm.EnginePower,
                MaxPassengers = vm.MaxPassengers,
                WeightCapacity = vm.WeightCapacity,
                BuiltDate = vm.BuiltDate,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId
                })
            };

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabases
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarUpdateViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.BodyStyle = car.BodyStyle;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.EnginePower = car.EnginePower;
            vm.MaxPassengers = car.MaxPassengers;
            vm.WeightCapacity = car.WeightCapacity;
            vm.BuiltDate = car.BuiltDate;
            vm.MaintenanceCount = car.MaintenanceCount;
            vm.LastMaintenance = car.LastMaintenance;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.Image.AddRange(photos);
            

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                BodyStyle = vm.BodyStyle,
                Make = vm.Make,
                Model = vm.Model,
                EnginePower = vm.EnginePower,
                MaxPassengers = vm.MaxPassengers,
                WeightCapacity = vm.WeightCapacity,
                BuiltDate = vm.BuiltDate,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId
                })
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

			var photos = await _context.FileToDatabases
				.Where(x => x.CarId == id)
				.Select(y => new ImageViewModel
				{
					CarId = y.Id,
					ImageId = y.Id,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();

            var vm = new CarDeleteViewModel();

			vm.Id = car.Id;
			vm.Name = car.Name;
			vm.BodyStyle = car.BodyStyle;
			vm.Make = car.Make;
			vm.Model = car.Model;
			vm.EnginePower = car.EnginePower;
			vm.MaxPassengers = car.MaxPassengers;
			vm.WeightCapacity = car.WeightCapacity;
			vm.BuiltDate = car.BuiltDate;
			vm.MaintenanceCount = car.MaintenanceCount;
			vm.LastMaintenance = car.LastMaintenance;
			vm.CreatedAt = car.CreatedAt;
			vm.ModifiedAt = car.ModifiedAt;
			vm.Image.AddRange(photos);

            return View(vm);
        }

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var carId = await _carsServices.Delete(id);
			if (carId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };

            var image = await _filesServices.RemoveImage(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
