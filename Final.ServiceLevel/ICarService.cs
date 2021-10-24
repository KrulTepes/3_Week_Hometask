using Final.DatabaseLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ServiceLevel
{
    public interface ICarService
    {
        int? Create(Car car);

        bool Delete(Car car);

        List<Car> GetAll();

        bool Update(Car car);
    }
}
