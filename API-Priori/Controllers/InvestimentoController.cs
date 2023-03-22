using API_Priori.Models;
using API_Priori.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public InvestimentoController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Investimento>> GetAllInvestimentos()
        {
            var investimento = _uof.InvestimentoRepository.GetAll().ToList();
            if (investimento is null)
                return NotFound();

            return investimento;
        }

        [HttpGet("{id}", Name = "ObterInvestimento")]
        public ActionResult<Investimento> GetinvestimentoById(int id)
        {
            var investimento = _uof.InvestimentoRepository.GetById(i => i.InvestimentoId == id);
            if (investimento is null)
                return NotFound();

            return investimento;
        }

        [HttpPost]
        public ActionResult Post(Investimento investimento)
        {
            if (investimento is null)
                return BadRequest();

            _uof.InvestimentoRepository.Add(investimento);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterInvestimento",
                new { id = investimento.InvestimentoId }, investimento); 
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Investimento investimento)
        {
            if (id != investimento.InvestimentoId)
                return BadRequest();

            _uof.InvestimentoRepository.Update(investimento);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var investimento = _uof.InvestimentoRepository.GetById(i => i.InvestimentoId == id);
            if (investimento is null)
                return NotFound();

            _uof.InvestimentoRepository.Delete(investimento);
            _uof.Commit();

            return Ok();
        }
    }
}
