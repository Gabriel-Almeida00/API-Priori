using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public ClientesController(IUnitOfWork contexto)
        {
            _uof = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetAllCliente()
        {
            var cliente = _uof.ClienteRepository.GetAll().ToList();
            if(cliente is null)
            {
                return NotFound("Cliente não encontrado");
            }
            return cliente;
        }

        [HttpGet("{id}" , Name="ObterCliente")]
        public ActionResult<Cliente> GetClienteById(int id)
        {
            var cliente = _uof.ClienteRepository.GetById(p => p.ClienteId == id);
            if(cliente is null)
            {
                return NotFound("cliente não encontrado...");
            }
            return cliente;
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
                return BadRequest();

            _uof.ClienteRepository.Add(cliente);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
                return BadRequest();

            _uof.ClienteRepository.Update(cliente);
            _uof.Commit();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = _uof.ClienteRepository.GetById(c => c.ClienteId == id);
            if (cliente is null)
                return NotFound("cliente não encontrado");

            _uof.ClienteRepository.Delete(cliente);
            _uof.Commit();

            return Ok();
        }
    }
}
