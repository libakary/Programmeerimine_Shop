﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
	public interface IRealEstatesServices
	{
		Task<RealEstate> GetAsync();
		Task<RealEstate> Create(RealEstateDto dto);
	}
}
