﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using Xunit;
using TARge21Shop.SpaceshipTest;
using TARge21Shop.Core.Domain;
using System.Xml.Linq;

namespace TARge21Shop.SpaceshipTest
{
	public class SpaceshipTest : TestBase
	{
		[Fact]
		public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
		{
			string guid = Guid.NewGuid().ToString();

			SpaceshipDto spaceship = new SpaceshipDto();

			//spaceship.Id = Guid.Parse(guid);
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
			SpaceshipDto spaceship = MockSpaceshipData();
			var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);

			//act
			var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

			//assert
			Assert.Equal(result, addSpaceship);
		}

		[Fact]
		private async Task Should_UpdateSpaceship_WhenUpdateData()
		{
			var guid = new Guid("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");

			Spaceship spaceship = new Spaceship();

			SpaceshipDto dto = MockSpaceshipData();

			spaceship.Id = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");
			spaceship.Name = "Name123";
			spaceship.Type = "asd";
			spaceship.Crew = 123123;
			spaceship.Passengers = 123123;
			spaceship.CargoWeight = 123123;
			spaceship.FullTripsCount = 123123;
			spaceship.MaintenanceCount = 1000123;
			spaceship.LastMaintenance = DateTime.Now.AddYears(1);
			spaceship.EnginePower = 10123;
			spaceship.MaidenLaunch = DateTime.Now.AddYears(1);
			spaceship.BuiltDate = DateTime.Now.AddYears(1);
			spaceship.CreatedAt = DateTime.Now.AddYears(1);
			spaceship.ModifiedAt = DateTime.Now.AddYears(1);

			await Svc<ISpaceshipsServices>().Update(dto);

			Assert.Equal(spaceship.Id, guid);
			Assert.DoesNotMatch(spaceship.Name, dto.Name);
			Assert.DoesNotMatch(spaceship.EnginePower.ToString(), dto.EnginePower.ToString());
			Assert.Equal(spaceship.Crew, dto.Crew);
		}

		[Fact]
		private async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
		{
			SpaceshipDto dto = MockSpaceshipData();
			var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

			SpaceshipDto update = MockUpdateSpaceship();
			var result = await Svc<ISpaceshipsServices>().Update(update);

			Assert.Equal(update.Id, dto.Id);
			Assert.DoesNotMatch(result.Name, createSpaceship.Name);
			Assert.DoesNotMatch(result.EnginePower.ToString(), createSpaceship.EnginePower.ToString());
			Assert.Equal(result.Crew, createSpaceship.Crew);
			Assert.NotEqual(result.ModifiedAt, createSpaceship.ModifiedAt);
		}

		private SpaceshipDto MockSpaceshipData()
		{
			SpaceshipDto spaceship = new()
			{
				Name = "Name",
				Type = "asd",
				Crew = 123,
				Passengers = 123,
				CargoWeight = 123,
				FullTripsCount = 123,
				MaintenanceCount = 1000,
				LastMaintenance = DateTime.Now,
				EnginePower = 1000,
				MaidenLaunch = DateTime.Now,
				BuiltDate = DateTime.Now,
				CreatedAt = DateTime.Now,
				ModifiedAt = DateTime.Now,
			};

			return spaceship;
		}
		private SpaceshipDto MockUpdateSpaceship()
		{
			SpaceshipDto update = new()
			{
				Name = "Name123",
				Type = "asd",
				Crew = 123,
				Passengers = 123123,
				CargoWeight = 123123,
				FullTripsCount = 123123,
				MaintenanceCount = 1000123,
				LastMaintenance = DateTime.Now.AddYears(1),
				EnginePower = 10123,
				MaidenLaunch = DateTime.Now.AddYears(1),
				BuiltDate = DateTime.Now.AddYears(1),
				CreatedAt = DateTime.Now.AddYears(1),
				ModifiedAt = DateTime.Now.AddYears(1),

			};

			return update;

		}
	}
}
