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
        private readonly IDomain _domain;
        
        public CarService(IDomain domain)
        {
            _domain = domain;
        }

        public string Create(Car car)
        {
            if (car.Id == null || car.Name == null)
                return "Не удалось создать объект: один из параметров равен null.";
            _domain.Add(car);
            return $"Объект {car.Name} успешно создан с ключем {car.Id}";
        }

        public string Delete(Car car)
        {
            if (car.Id == null || car.Name == null)
                return "Не удалось создать объект: один из параметров равен null.";
            _domain.Delete(car);
            return $"Объект {car.Name} с ключем {car.Id} был успешно удален";
        }

        public List<Car> GetAll()
        {
            return _domain.GetAll();
        }

        public string Update(Car car)
        {
            if (car.Id == null || car.Name == null)
                return "Не удалось обновить объект: один из параметров нового объекта равен null";
            _domain.Update(car);
            return $"Объект под ключу {car.Id} был успешно изменён";
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
