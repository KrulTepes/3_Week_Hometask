using System.Collections.Generic;

namespace Final.ServiceLevel
{
    public interface ICarService
    {
        int? Create(Car car);

        bool Delete(Car car);

        List<Car> GetAll();

        bool Update(Car car);

        List<Car> GetCarsByPagination(int? page, int? count);
    }
}
