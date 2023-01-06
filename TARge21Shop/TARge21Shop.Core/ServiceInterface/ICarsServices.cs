﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> GetAsync(Guid id);
        Task<Car> Create(CarDto dto);
        Task<Car> GetUpdate(Guid id);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
    }
}
