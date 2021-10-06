using BusinessLayer.Interface;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
	class SeasonRepo : IRepo<Seasonal, int>
	{
		public Task<Seasonal> Add(Seasonal obj)
		{
			throw new NotImplementedException();
		}

		public Task<Seasonal> Read(int obj)
		{
			throw new NotImplementedException();
		}

		public Task<List<Seasonal>> Read()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns a list of seasons
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<Seasonal> ReadAll(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Seasonal>> ReadAll(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
