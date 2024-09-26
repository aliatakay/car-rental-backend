using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            carImage.Date = DateTime.Now;

            string directory = string.Concat(Environment.CurrentDirectory, @"\wwwroot\Images\CarImages\");

            carImage.Path = FileHelper.StoreImageFile(image, directory);

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
        public IActionResult GetAllByCarId(int id)
        {
            var result = _carImageService.GetAllByCarId(id);
            var images = new List<string>();

            if (result.Success)
            {
                if (result.Data.Count == 0)
                {
                    string defaultImagePath = string.Concat(Environment.CurrentDirectory, @"\wwwroot\Images\CarImages\logo.jpg");
                    images.Add(defaultImagePath);
                }
                else
                {
                    foreach (var carImage in result.Data)
                    {
                        images.Add(carImage.Path);
                    }
                }
                return Ok(images);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var images = _carImageService.GetById(id);
            var result = (images.Data != null) ? images.Message : Messages.NoExisting;

            if (images.Success)
            {
                if (images.Data != null)
                {
                    result = _carImageService.Delete(images.Data).Message;
                }

                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}