using Final.DatabaseLevel;
using Final.Models;
using Final.ServiceLevel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class MainController : Controller
    {
        private readonly ICarService _ICarService;

        public MainController(ICarService carService)
        {
            _ICarService = carService;
        }

        [Route("db/create")] // Создание объекта
        public IActionResult Create(Car car)
        {
            return Ok(_ICarService.Create(car));
        }

        [Route("db/delete")]
        public IActionResult Delete(Car car)
        {
            return Ok(_ICarService.Delete(car));
        }

        
        [Route("db/getall")]
        public IActionResult Get()
        {
            return Ok(_ICarService.GetAll());
        }

        [Route("db/update")]
        public IActionResult Update(Car car)
        {
            return Ok(_ICarService.Update(car));
        }

        [Route("db/get/{index}&{count}")]
        [HttpGet("{index}&{count}")] // Получение объедков по пагинации
        public IActionResult Get(int? index, int? count)
        {
            return Ok(_ICarService.GetCarsByPagination(index, count));
        }


    }
}
