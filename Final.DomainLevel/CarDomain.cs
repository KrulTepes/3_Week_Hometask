using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DataModel Update(DataModel datamodel)
        {
            if (datamodel == null)
                return null;

            var newObj = _myDBContext.Cars.Where(x => x.Id == datamodel.Id).FirstOrDefault();
            newObj.Name = datamodel.Name;
            _myDBContext.Cars.Update(newObj);
            _myDBContext.SaveChanges();
            return datamodel;
        }
    }
}