using Final.DatabaseLevel;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.DomainLevel
{
    public class CarDomain : ICarDomain
    {
        // public DbSet<Car> Cars { get; set; }

        private readonly MyDBContext _myDBContext;

        public CarDomain(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public List<Car> GetAll()
        {
            return _myDBContext.Cars.ToList();
        }

        public void Add(Car car)
        {
            if (car != null)
            {
                _myDBContext.Cars.Add(car);
                _myDBContext.SaveChanges();
            }
        }

        public void Update(Car car)
        {
            if (car != null)
            {
                _myDBContext.Cars.Update(car);
                _myDBContext.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            if (car != null)
            {
                _myDBContext.Cars.Remove(car);
                _myDBContext.SaveChanges();
            }
        }
    }
}