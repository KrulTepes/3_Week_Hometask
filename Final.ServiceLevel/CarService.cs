using Final.DatabaseLevel;
using Final.DomainLevel;
using System.Collections.Generic;
using System.Linq;

namespace Final.ServiceLevel
{
    public class CarService : ICarService
    {
        private readonly ICarDomain _carDomain;

        public CarService(ICarDomain carDomain)
        {
            _carDomain = carDomain;
        }

        public int? Create(Car car)
        {
            var newCar = _carDomain.Add(new DataModel { Name = car.Name, Id = car.Id });

            return newCar.Id == null ? null : (int)newCar.Id;
        }

        public List<Car> GetAll()
        {
            List<DataModel> newList = _carDomain.GetAll();

            List<Car> result = new List<Car>();

            foreach(var item in newList)
            {
                result.Add(new Car { Id = item.Id, Name = item.Name });
            }

            return result;
        }

        public List<Car> GetCarsByPagination(int? page, int? count)
        {
            List<DataModel> newList = _carDomain.GetModelsByPagination();

            List<Car> result = new List<Car>();

            foreach (var item in newList)
            {
                result.Add(new Car { Id = item.Id, Name = item.Name});
            }

            return result.OrderBy(x => x.Id).Skip(((int)page - 1) * (int)count).Take((int)count).ToList();
        }

        public bool Delete(Car car)
        {
            var newCar = _carDomain.Delete(new DataModel { Name = car.Name, Id = car.Id });

            return newCar; 
        }

        public bool Update(Car car)
        {
            var newCar = _carDomain.Update(new DataModel { Name = car.Name, Id = car.Id });

            return newCar;
        }
    }
}
