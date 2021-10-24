using System.Collections.Generic;
using System.Linq;
using Final.DatabaseLevel;

namespace Final.DomainLevel
{
    public class CarDomain : ICarDomain
    {
        private readonly MyDBContext _myDBContext;

        public CarDomain(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public DataModel Add(DataModel datamodel)
        {
            if (datamodel == null)
                return null;

            _myDBContext.Cars.Add(datamodel);
            _myDBContext.SaveChanges();
            return datamodel;
        }

        public List<DataModel> GetAll()
        {
            return _myDBContext.Cars.ToList();
        }

        public bool Delete(DataModel datamodel)
        {
            if (datamodel == null)
                return false;

            var newObj = _myDBContext.Cars.Where(x => x.Id == datamodel.Id).FirstOrDefault();
            _myDBContext.Remove(newObj);
            _myDBContext.SaveChanges();
            return true;
        }

        public bool Update(DataModel datamodel)
        {
            if (datamodel == null)
                return false;

            _myDBContext.Cars.Update(new DataModel { Name = datamodel.Name, Id = datamodel.Id});
            _myDBContext.SaveChanges();
            return true;
        }

        public List<DataModel> GetModelsByPagination()
        {
            return _myDBContext.Cars.ToList();
        }
    }
}