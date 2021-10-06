using BusinessLayer.Interface;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
	class SeasonRepo : IRepo<Seasonal>
	{
		/// <summary>
		/// Returns a list of seasons
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<Seasonal> ReadAll(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
