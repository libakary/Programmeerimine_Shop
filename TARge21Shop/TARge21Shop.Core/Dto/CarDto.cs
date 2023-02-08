using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain.Car;

namespace TARge21Shop.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } //informal name by owners
        public string BodyStyle { get; set; }
        //https://www.caranddriver.com/research/a31875496/difference-between-make-and-model/
        public string Make { get; set; }    //brand of the car, Honda
        public string Model { get; set; }   //the specific product, Civic
        public int EnginePower { get; set; }
        public int MaxPassengers { get; set; }
        public int WeightCapacity { get; set; }
        public DateTime BuiltDate { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

		// only in database
		public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
