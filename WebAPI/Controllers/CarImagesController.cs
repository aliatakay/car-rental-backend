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
    }
}
