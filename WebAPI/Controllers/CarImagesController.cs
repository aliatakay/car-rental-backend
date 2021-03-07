using BLL.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm(Name = ("image"))] IFormFile image)
        {
            carImage.ImageDate = DateTime.Now;

            string directory = string.Concat(Environment.CurrentDirectory, @"\wwwroot\Images\CarImages\");

            carImage.ImagePath = FileHelper.StoreImageFile(image, directory);

            var result = _carImageService.Add(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("getallbycar")]
        public IActionResult GetAllByCarId([FromForm(Name = ("CarId"))] int id)
        {
            var result = _carImageService.GetImagesByCarId(id);

            if (result.Success)
            {
                if (result.Data.Count == 0)
                {
                    string directory = string.Concat(Environment.CurrentDirectory, @"\wwwroot\Images\CarImages\logo.jpg");
                    CarImage logo = new CarImage { CarId = id, ImagePath = directory };
                    result.Data.Add(logo);
                }

                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
