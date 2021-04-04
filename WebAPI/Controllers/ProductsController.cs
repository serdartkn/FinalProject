using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{ // BU KLASÖR ALTINA HER NESNEMİZİN BUSINESS KODLARINA YÖNELİK GET POST KODLARINI YAZIYORUZ.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        //Bu operasyonu çalıstırabilmesi için kişinin tokenı olması gerek. (parantezz içinin boş olması yetkisi yoksa dahi token'ı varsa işlem yaptırıyor.)
        //( ise .netten geliyor.)
        //[Authorize(Roles ="Products.List,Admin")]
        public IActionResult GetAll()
        {
            Thread.Sleep(5000);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _productService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }        
        
        [HttpPost("update")]
        public IActionResult update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }        
        
        [HttpPost("delete")]
        public IActionResult delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
