using System.ComponentModel.DataAnnotations;

namespace TARge21Shop.Models.Spaceship
{
    public class SpaceshipIndexViewModel
    {
        public Guid? Id { get; set; } // guid parem kasutada, seal rohkem ruumi ja kombinatsioone
        public string Name { get; set; }
        public string Type { get; set; }
        public int Passengers { get; set; }
        public int EnginePower { get; set; }
    }
}
