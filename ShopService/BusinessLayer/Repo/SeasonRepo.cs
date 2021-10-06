using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
	class SeasonRepo : IRepo<SeasonRepo>
	{
		public List<SeasonRepo> ReadAll(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
