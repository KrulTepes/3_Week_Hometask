using Final.DatabaseLevel;
using Final.DomainLevel;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ServiceLevel
{
    public class CarService : ICarService
    {
        private readonly ICarDomain _domain;
        
        public CarService(ICarDomain domain)
        {
            _domain = domain;
        }

        public string Create(Car car)
        {

            _domain.Add(car);
            return car.Id == 0 ? "Fail" : "Success";
        }

        public string Delete(Car car)
        {
            _domain.Delete(car);
            return "Success";
        }

        public List<Car> GetAll()
        {
            return _domain.GetAll();
        }

        public string Update(Car car)
        {
            _domain.Update(car);
            return "Success";
        }

        public List<Car> GetCarsByPagination(int? index, int? count)
        {
            if (index == null || count == null)
                return null;
            List<Car> Cars = new List<Car>();
            Cars.AddRange(_domain.GetAll().ToList().OrderBy(x => x.Id));
            
            List<Car> result = new List<Car>();
            for(int i = 0; i< count; i++)
            {
                result.Add(Cars[i+(int)index]);
            }
            return result;
        }
    }
}
