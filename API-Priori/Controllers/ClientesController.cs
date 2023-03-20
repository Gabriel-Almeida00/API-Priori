using API_Priori.Context;
using API_Priori.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Priori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetAllCliente()
        {
            var cliente = _context.tblClientes.ToList();
            if(cliente is null)
            {
                return NotFound("Cliente não encontrado");
            }
            return cliente;
        }

        [HttpGet("{id}" , Name="ObterCliente")]
        public ActionResult<Cliente> GetClienteById(int id)
        {
            var cliente = _context.tblClientes.FirstOrDefault(p => p.ClienteId == id);
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

            _context.tblClientes.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
                return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(cliente);
        }
    }
}
