using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        readonly ICompradorRepository _compradorRepository;

        public CompradorController(ICompradorRepository compradorRepository)
        {
            _compradorRepository = compradorRepository;
        }

        // GET: api/<CompradorRepository>
        [HttpGet]
        public ActionResult<List<Comprador>> Get()
        {
            return Ok(_compradorRepository.GetComprador());
        }

        [HttpGet("{id}")]
        public ActionResult<Comprador> GetById(int id)
        {
            return Ok(_compradorRepository.GetCompradorById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Eventos> CreateComprador(Comprador comprador)
        {
            _compradorRepository.InsertComprador(comprador);
            return CreatedAtAction(nameof(GetById), new { id = comprador.UserId }, comprador);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Comprador comprador)
        {
            try
            {
                if (comprador == null)
                    return NotFound();

                _compradorRepository.UpdateComprador(comprador);
                return Ok("Comprador Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Comprador comprador)
        {
            try
            {
                if (comprador == null)
                    return NotFound();

                _compradorRepository.DeleteComprador(comprador);
                return Ok("Comprador Excluído com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
