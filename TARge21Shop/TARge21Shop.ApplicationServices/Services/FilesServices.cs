using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
	public class FilesServices : IFilesServices
	{
		private readonly TARge21ShopContext _context;

		public FilesServices
			(
				TARge21ShopContext context
			)
		{
			_context = context;
		}

		public void UploadFilesToDatabase(CarDto dto, CarDto domain)
		{
			if (dto.Files != null && dto.Files.Count > 0) 
			{
				foreach (var photo in dto.Files)
				{
					using (var target = new MemoryStream())
					{
						FileToDatabase files = new FileToDatabase()
						{
							Id = Guid.NewGuid(),
							ImageTitle = photo.Name,
							CarId = domain.Id,
						};

						photo.CopyTo(target);
						files.ImageData = target.ToArray();

						_context.FileToDatabases.Add(files);
					}
				}
			}
		}
	}
}
