using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINetCore01.Controllers
{
    [Route("api/articulo")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //example.ObtenerPorId(1);
            //var asdf = articuloService.ObtenerPorId(1);
            return new string[] { "value1", "value2" };
        }
    }
}