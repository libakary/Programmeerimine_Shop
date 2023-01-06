using Microsoft.AspNetCore.Mvc;
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

        public CarsController
            (
                TARge21ShopContext context,
                ICarsServices carsServices
            )
        {
            _context = context;
            _carsServices = carsServices;
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

            var vm = new CarDetailsViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                BodyStyle = car.BodyStyle,
                Make = car.Make,
                Model = car.Model,
                EnginePower = car.EnginePower,
                MaxPassengers = car.MaxPassengers,
                WeightCapacity = car.WeightCapacity,
                BuiltDate = car.BuiltDate,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

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
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carsServices.GetUpdate(id);

            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarUpdateViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                BodyStyle = car.BodyStyle,
                Make = car.Make,
                Model = car.Model,
                EnginePower = car.EnginePower,
                MaxPassengers = car.MaxPassengers,
                WeightCapacity = car.WeightCapacity,
                BuiltDate = car.BuiltDate,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View(vm);
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
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                BodyStyle = car.BodyStyle,
                Make = car.Make,
                Model = car.Model,
                EnginePower = car.EnginePower,
                MaxPassengers = car.MaxPassengers,
                WeightCapacity = car.WeightCapacity,
                BuiltDate = car.BuiltDate,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View(vm);
        }
    }
}
