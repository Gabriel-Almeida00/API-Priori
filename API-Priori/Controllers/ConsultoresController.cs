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
    public class ConsultoresController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public ConsultoresController(IUnitOfWork contexto)
        {
            _uof = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Consultor>> GetAllConsultores()
        {
            var consultores = _uof.ConsultorRepository.GetAll().ToList();
            if (consultores is null)
                return NotFound("Consultor não encontrado");

                return consultores;
        }

        [HttpGet("{id}",Name = "ObterConsultor")]
        public ActionResult<Consultor> GetConsultorById (int id)
        {
            var consultor = _uof.ConsultorRepository.GetById(c => c.ConsultorId == id);
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
            _uof.ConsultorRepository.Add(consultor);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterConsultor", 
                new { id = consultor.ConsultorId }, consultor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Consultor consultor)
        {
            if (id != consultor.ConsultorId)
                return BadRequest();

            _uof.ConsultorRepository.Update(consultor);
            _uof.Commit();

            return Ok(consultor);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var consultor = _uof.ConsultorRepository.GetById(c => c.ConsultorId == id);
            if (consultor is null)
                return NotFound("cliente não encontrado");

            _uof.ConsultorRepository.Delete(consultor);
            _uof.Commit();

            return Ok();
        }
    }
}
