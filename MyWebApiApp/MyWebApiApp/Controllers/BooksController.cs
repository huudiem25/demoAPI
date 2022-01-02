using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IHangHoaResposity _hangHoaResposity;

        public BooksController(IHangHoaResposity hangHoaResposity)
        {
            _hangHoaResposity = hangHoaResposity;
        }
        [HttpGet]
        public IActionResult GettAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        {
            try
            {
                List<Models.HangHoaModel> result = _hangHoaResposity.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can not get the product");
            }
        }
    }
}
