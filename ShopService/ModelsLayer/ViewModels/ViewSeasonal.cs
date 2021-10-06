using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
	class ViewSeasonal
	{
		public int SeasonalId { get; set; }
		public string SeasonalName { get; set; }
		public DateTime SeasonalStartDate { get; set; }
		public DateTime SeasonalEndDate { get; set; }
	}
}
