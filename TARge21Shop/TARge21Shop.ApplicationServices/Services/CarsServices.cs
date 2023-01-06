using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CarsServices
            (
                TARge21ShopContext context
            )
        {
            _context = context;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Create(CarDto dto)
        {
            var domain = new Car()
            {
                Id = Guid.NewGuid(), // lisab iga kord uue ID
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
                CreatedAt = DateTime.Now, //uue sisestuse kuupäev
                ModifiedAt = DateTime.Now, 
            };

            await _context.Cars.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
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

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
    }
}
