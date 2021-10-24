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
        private readonly ICarService _carService;

        public MainController(ICarService carService)
        {
            _carService = carService;
        }

        [Route("db/create")]
        public IActionResult Create(Car car)
        {
            if (car.Id == null || car.Name == null)
                return BadRequest();
            return Ok(_carService.Create(car));
        }

        [Route("db/delete")]
        public IActionResult Delete(Car car)
        {
            if (car.Id == null || car.Name == null)
                return BadRequest();
            return Ok(_carService.Delete(car));
        }

        [Route("db/update")]
        public IActionResult Update(Car car)
        {
            if (car.Id == null || car.Name == null)
                return BadRequest();
            return Ok(_carService.Update(car));
        }


        [Route("db/getall")]
        public IActionResult Get()
        {
            return Ok(_carService.GetAll());
        }

        [Route("db/get/{index}&{count}")]
        [HttpGet("{index}&{count}")]
        public IActionResult Get(int? index, int? count)
        {
            return Ok(_carService.GetCarsByPagination(index, count));
        }


    }
}
