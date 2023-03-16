using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using Xunit;
using TARge21Shop.SpaceshipTest;
using TARge21Shop.Core.Domain;

namespace TARge21Shop.SpaceshipTest
{
	public class SpaceshipTest : TestBase
	{
		[Fact]
		public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
		{
			string guid = Guid.NewGuid().ToString();

			SpaceshipDto spaceship = new SpaceshipDto();

			spaceship.Id = Guid.Parse(guid);
			spaceship.Name = "asd";
			spaceship.Type = "asd";
			spaceship.Crew = 123;
			spaceship.Passengers = 123;
			spaceship.CargoWeight = 123;
			spaceship.FullTripsCount = 123;
			spaceship.MaintenanceCount = 1000;
			spaceship.LastMaintenance = DateTime.Now;
			spaceship.EnginePower = 1000;
			spaceship.MaidenLaunch = DateTime.Now;
			spaceship.BuiltDate = DateTime.Now;
			spaceship.CreatedAt = DateTime.Now;
			spaceship.ModifiedAt = DateTime.Now;

			var result = await Svc<ISpaceshipsServices>().Create(spaceship);

			Assert.NotNull(result);
		}

		[Fact]
		public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
		{
			//Arrange
			// kui vale id tuleb sisse, küsib id mis meil pole
			Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
			//Näide sissetulevast guid'st
			Guid guid = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");

			//Act
			await Svc<ISpaceshipsServices>().GetAsync(guid);

			//Assert
			// võrdleb
			Assert.NotEqual(wrongGuid, guid);
		}

		[Fact]
		public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
		{
			// arrange
			Guid databaseGuid = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");
			Guid getGuid = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");


			// act
			await Svc<ISpaceshipsServices>().GetAsync(getGuid);

			// assert
			Assert.Equal(databaseGuid, getGuid);

		}

		[Fact]
		public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
		{
			// arrange
			//Guid guid = Guid.NewGuid();
			Guid guid = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");

			SpaceshipDto spaceship = new SpaceshipDto();

			spaceship.Id = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");
			spaceship.Name = "asd";
			spaceship.Type = "asd";
			spaceship.Crew = 123;
			spaceship.Passengers = 123;
			spaceship.CargoWeight = 123;
			spaceship.FullTripsCount = 123;
			spaceship.MaintenanceCount = 1000;
			spaceship.LastMaintenance = DateTime.Now;
			spaceship.EnginePower = 1000;
			spaceship.MaidenLaunch = DateTime.Now;
			spaceship.BuiltDate = DateTime.Now;
			spaceship.CreatedAt = DateTime.Now;
			spaceship.ModifiedAt = DateTime.Now;

			//act
			await Svc<ISpaceshipsServices>().Delete(guid);

			//assert
			Assert.Equal(guid, spaceship.Id);
		}
	}
}
