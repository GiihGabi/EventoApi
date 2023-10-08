using DDD.Domain.GeralContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        readonly IVendaRepository _vendaRepository;

        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet]
        public ActionResult<List<Venda>> Get()
        {
            return Ok(_vendaRepository.GetVendas());
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> GetById(int id)
        {
            return Ok(_vendaRepository.GetVendaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Venda> CreateVenda(int idComprador, int idEvento, DateTime date, int qndIngress)
        {
            Venda vendaSaved = _vendaRepository.InsertVenda(idComprador, idEvento, date, qndIngress);
            return CreatedAtAction(nameof(GetById), new { id = vendaSaved.VendaId }, vendaSaved);
        }
    }
}
