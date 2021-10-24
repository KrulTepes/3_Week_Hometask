using Final.DatabaseLevel;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.DomainLevel;
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
        public IActionResult Create(RequestCar req)
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
        public IActionResult Delete(RequestCarDeleteUpdate req)
        {
            if (req == null)
                return StatusCode(500);
            return Ok(_carService.Delete(new Car { Id = req.Id }) == true ? "Удаление прошло успешно." : "Не удалось удалить объект");
        }

        [Route("db/update")]
        public IActionResult Update(RequestCarDeleteUpdate req)
        {
            if (req == null)
                return StatusCode(500);
            if (req.Name == null || req.Id == null)
                return StatusCode(500);
            return Ok(_carService.Update(new Car { Id = req.Id , Name = req.Name}) == true ? "Изменение прошло успешно." : "Не удалось изменить объект");
        }

        /* 
        [Route("db/update")]
        public IActionResult Update(Car car)
        {
            if (car.Id == null || car.Name == null)
                return BadRequest();
            return Ok(_carService.Update(car));
        }
        [Route("db/get/{index}&{count}")]
        [HttpGet("{index}&{count}")]
        public IActionResult Get(int? index, int? count)
        {
            return Ok(_carService.GetCarsByPagination(index, count));
        } */


    }
}
