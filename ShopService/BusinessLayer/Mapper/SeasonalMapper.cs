using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;

namespace BusinessLayer.Mapper
{
	public class SeasonalMapper : IMapper<Seasonal, ViewSeasonal>
	{
        /// <summary>
        /// Converts a database Seasonal object to a view Seasonal object
        /// </summary>
        /// <param name="season">Aholycow</param>
        /// <returns>A view Seasonal object</returns>
        public ViewSeasonal ModelToViewModel(Seasonal season)
        {
            ViewSeasonal viewSeasonal = new ViewSeasonal();
            viewSeasonal.SeasonalId = season.SeasonalId;
            viewSeasonal.SeasonalName = season.SeasonalName;
            viewSeasonal.SeasonalStartDate = season.SeasonalStartDate;
            viewSeasonal.SeasonalEndDate = season.SeasonalEndDate;

            return viewSeasonal;
        }

        /// <summary>
        /// Converts a view Seasonal object from the view to a database Seasonal object
        /// </summary>
        /// <param name="viewSeasonal"></param>
        /// <returns>A database Seasonal object</returns>
        public Seasonal ViewModelToModel(ViewSeasonal viewSeasonal)
        {
            Seasonal season = new Seasonal();
            season.SeasonalId = viewSeasonal.SeasonalId;
            season.SeasonalName = viewSeasonal.SeasonalName;
            season.SeasonalStartDate = viewSeasonal.SeasonalStartDate;
            season.SeasonalEndDate = viewSeasonal.SeasonalEndDate;

            return season;
        }

        /// <summary>
        /// Converts a list of database Seasonal objects to a list of view Seasonal objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A list of view Seasonal objects</returns>
        public List<ViewSeasonal> ModelToViewModel(List<Seasonal> obj)
        {
            List<ViewSeasonal> seasons = new List<ViewSeasonal>();
            try
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    seasons.Add(new ViewSeasonal());
                    seasons[i].SeasonalId = obj[i].SeasonalId;
                    seasons[i].SeasonalName = obj[i].SeasonalName;
                    seasons[i].SeasonalStartDate = obj[i].SeasonalStartDate;
                    seasons[i].SeasonalEndDate = obj[i].SeasonalEndDate;
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                throw new Exception("Augument Out of Range Exception: ", e);
			}
            return seasons;
        }

        public int ListLength(List<Seasonal> obj)
        {
            return obj.Count;
        }

        /// <summary>
        /// Converts a list of view Seasonal objects to a list of database Seasonal objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A list of database Seasonal objects</returns>
        public List<Seasonal> ViewModelToModel(List<ViewSeasonal> obj)
        {
            List<Seasonal> seasons = new List<Seasonal>(obj.Count);
            for (int i = 0; i < obj.Count; i++)
            {
                seasons.Add(new Seasonal());
                seasons[i].SeasonalId = obj[i].SeasonalId;
                seasons[i].SeasonalName = obj[i].SeasonalName;
                seasons[i].SeasonalStartDate = obj[i].SeasonalStartDate;
                seasons[i].SeasonalEndDate = obj[i].SeasonalEndDate;
            }
            return seasons;
        }
    }
}
