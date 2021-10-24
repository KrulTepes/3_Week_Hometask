using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ServiceLevel
{
    public interface ICarService
    {
        string Delete(Car car);

        string Create(Car car);

        List<Car> GetAll();

        string Update(Car car);

        List<Car> GetCarsByPagination(int? id, int? count);
    }
}
