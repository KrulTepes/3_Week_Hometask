using Final.DatabaseLevel;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Final.ServiceLevel;

namespace Final.Controllers
{
    public class MainController : Controller
    {
        private readonly ICarService _carService;

        public MainController(ICarService carService, MyDBContext _md)
        {
            _carService = carService;
        }

        [Route("db/create")]
        [HttpPost]
        public IActionResult Create([FromBody] RequestCar req)
        {
            if (req == null)
                return StatusCode(500);
            int? id = _carService.Create(new Car { Name = req.Name });
            return Ok(id == null ? StatusCode(500) : "Объект успешно создан");
        }

        [Route("db/getall")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_carService.GetAll());
        }

        [Route("db/delete")]
        [HttpDelete]
        public IActionResult Delete(RequestCarDeleteUpdate req)
        {
            if (req == null)
                return StatusCode(500);
            return Ok(_carService.Delete(new Car { Id = req.Id }) == true ? "Удаление прошло успешно." : "Не удалось удалить объект");
        }

        [Route("db/update")]
        [HttpPut]
        public IActionResult Update([FromBody] RequestCarDeleteUpdate req)
        {
            if (req == null)
                return StatusCode(500);
            if (req.Name == null || req.Id == null)
                return StatusCode(500);
            return Ok(_carService.Update(new Car { Id = req.Id , Name = req.Name}) == true ? "Изменение прошло успешно." : "Не удалось изменить объект");
        }

        [Route("db/getpagination/{page}&{count}")]
        [HttpGet]
        public IActionResult GetPagination(int? page, int? count)
        {
            if (page == null || count == null)
                return StatusCode(500);
            return Ok(_carService.GetCarsByPagination(page, count));
        }
    }
}
