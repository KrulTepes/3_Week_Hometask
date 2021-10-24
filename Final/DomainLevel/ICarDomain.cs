using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.DomainLevel
{
    public interface ICarDomain
    {
        List<Car> GetAll();

        void Add(Car car);

        void Delete(Car car);

        void Update(Car car);
    }
}
