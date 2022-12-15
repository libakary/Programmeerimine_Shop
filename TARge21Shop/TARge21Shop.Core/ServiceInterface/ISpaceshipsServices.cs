using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> GetUpdate(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        //Task<Spaceship> DeleteConfirmation(Guid id);
        Task<Spaceship> GetAsync(Guid id);
        Task<Spaceship> Delete(Guid id);
    }
}
