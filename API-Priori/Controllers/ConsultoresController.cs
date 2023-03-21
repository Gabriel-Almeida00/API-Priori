using API_Priori.Context;
using API_Priori.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Consultor>> GetAllConsultores()
        {
            var consultores = _context.tblConsultores.ToList();
            if (consultores is null)
                return NotFound("Consultor não encontrado");

                return consultores;
        }

        [HttpGet("{id}",Name = "ObterConsultor")]
        public ActionResult<Consultor> GetConsultorById (int id)
        {
            var consultor = _context.tblConsultores.FirstOrDefault(c => c.ConsultorId == id);
            if (consultor is null)
                return NotFound("Consultor não encontrado");

            return consultor;
        }

        [HttpPost]
        public ActionResult Post(Consultor consultor)
        {
            if(consultor is null)
            {
                return BadRequest();
            }
            _context.tblConsultores.Add(consultor);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterConsultor", 
                new { id = consultor.ConsultorId }, consultor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Consultor consultor)
        {
            if (id != consultor.ConsultorId)
                return BadRequest();

            _context.Entry(consultor).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(consultor);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var consultor = _context.tblConsultores.FirstOrDefault(c => c.ConsultorId == id);
            if (consultor is null)
                return NotFound("cliente não encontrado");

            _context.tblConsultores.Remove(consultor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
