namespace TARge21Shop.Models.Car
{
	public class CarDeleteViewModel
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

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
