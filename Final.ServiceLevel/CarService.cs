﻿using Final.DatabaseLevel;
using Final.DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public bool Delete(Car car)
        {
            var newCar = _carDomain.Delete(new DataModel { Name = car.Name, Id = car.Id });

            return newCar != null ? true : false; 
        }

        public bool Update(Car car)
        {
            var newCar = _carDomain.Update(new DataModel { Name = car.Name, Id = car.Id });

            return newCar != null ? true : false;
        }
    }
}