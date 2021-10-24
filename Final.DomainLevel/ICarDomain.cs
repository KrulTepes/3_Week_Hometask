using Final.DatabaseLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.DomainLevel
{
    public interface ICarDomain
    {
        public DataModel Add(DataModel dataModel);

        public List<DataModel> GetAll();

        public bool Delete(DataModel datamodel);

        public DataModel Update(DataModel dataModel);
    }
}