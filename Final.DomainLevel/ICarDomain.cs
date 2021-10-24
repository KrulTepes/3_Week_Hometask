using Final.DatabaseLevel;
using System.Collections.Generic;

namespace Final.DomainLevel
{
    public interface ICarDomain
    {
        public DataModel Add(DataModel dataModel);

        public List<DataModel> GetAll();

        public bool Delete(DataModel datamodel);

        public bool Update(DataModel dataModel);

        public List<DataModel> GetModelsByPagination();
    }
}