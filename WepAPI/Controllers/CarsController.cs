using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)  //
        {
            var result = _carService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        // IDataResult<List<Car>> GetByPrince(decimal min, decimal mix);

        [HttpGet("getbyprince")]
        public IActionResult GetByPrince(decimal min, decimal max)
        {
            var result = _carService.GetByPrince(min, max);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Added(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Deleted(car);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        // IDataResult<List<CarDetailsDto>> GetCarDetails(); 

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }


}
