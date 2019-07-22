using Application.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APINetCore01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Services

        private readonly IArticuloService articuloService;

        #endregion Services

        #region Constructor

        public ValuesController(
            IArticuloService articuloService
        )
        {
            this.articuloService = articuloService;
        }

        #endregion Constructor
    

        #region Actions

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //GetByID
            //var dtoPorId = articuloService.ObtenerPorID(1);
            
            //Create
            var nuevoDto = articuloService.Crear(new Application.DTO.ArticuloDTO {
                Codigo = "note",
                Nombre = "note 01",
                Precio = 1000
            });


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion Actions
    }
}