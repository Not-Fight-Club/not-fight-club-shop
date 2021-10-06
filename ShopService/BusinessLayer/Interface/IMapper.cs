using System.Collections.Generic;

namespace NotFightClub_Logic.Interfaces
{
    public interface IMapper<T, Y>
    {
        /// <summary>
        /// transroms a view model to a model
        /// </summary>
        /// <param name="obj"> view model</param>
        /// <returns>an entity model</returns>
        public T ViewModelToModel(Y obj);

        /// <summary>
        /// transforms a model to a view model
        /// </summary>
        /// <param name="obj"> an entity model</param>
        /// <returns> a view model</returns>
        public Y ModelToViewModel(T obj);

        public List<T> ViewModelToModel(List<Y> obj);

        public List<Y> ModelToViewModel(List<T> obj);


    }
}
