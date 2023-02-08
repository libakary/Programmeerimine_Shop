using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class CarsServices : ICarsServices //: tähendab pärimist
    {
        private readonly TARge21ShopContext _context;
		private readonly IFilesServices _files;

		public CarsServices
            (
                TARge21ShopContext context,
				IFilesServices files
			)
        {
            _context = context;
			_files = files;
		}

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Create(CarDto dto)
        {
			Car car = new Car();
			FileToDatabase file = new FileToDatabase();
			car.Id = Guid.NewGuid(); // lisab iga kord uue ID
            car.Name = dto.Name;
            car.BodyStyle = dto.BodyStyle;
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.EnginePower = dto.EnginePower;
            car.MaxPassengers = dto.MaxPassengers;
            car.WeightCapacity = dto.WeightCapacity;
            car.BuiltDate = dto.BuiltDate;
            car.MaintenanceCount = dto.MaintenanceCount;
            car.LastMaintenance = dto.LastMaintenance;
            car.CreatedAt = DateTime.Now; //uue sisestuse kuupäev
            car.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Name = dto.Name,
                BodyStyle = dto.BodyStyle,
                Make = dto.Make,
                Model = dto.Model,
                EnginePower = dto.EnginePower,
                MaxPassengers = dto.MaxPassengers,
                WeightCapacity = dto.WeightCapacity,
                BuiltDate = dto.BuiltDate,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, domain);
            }

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        public async Task<Car> GetUpdate(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.CarId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId,
                })
                .ToArrayAsync();

            await _files.RemoveImagesFromDatabase(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
    }
}
