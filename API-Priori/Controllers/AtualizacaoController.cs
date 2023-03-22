using API_Priori.Models;
using API_Priori.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtualizacaoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public AtualizacaoController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Atualizacao>> GetAll()
        {
            var atualizcao = _uof.AtualizacaoRepository.GetAll().ToList();
            if (atualizcao is null)
                return NotFound("Atualização não encontrada");

            return atualizcao;
        }

        [HttpGet("{id}", Name = "ObterAtualizacao")]
        public ActionResult<Atualizacao> GetAtualizacaoById(int id)
        {
            var atualizacao = _uof.AtualizacaoRepository.GetById(a => a.AtualizacaoId == id);
            if (atualizacao is null)
                return NotFound();

            return atualizacao;
        }

        [HttpPost]
        public ActionResult Post(Atualizacao atualizacao)
        {
            if (atualizacao is null)
                return BadRequest();
            
            _uof.AtualizacaoRepository.Add(atualizacao);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterAtualizacao",
               new { id = atualizacao.AtualizacaoId }, atualizacao);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Atualizacao atualizacao)
        {
          if(id != atualizacao.AtualizacaoId)
                return BadRequest();

            _uof.AtualizacaoRepository.Update(atualizacao);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var atualizacao = _uof.AtualizacaoRepository.GetById(a => a.AtualizacaoId == id);
            if(atualizacao is null)
                return NotFound();

            _uof.AtualizacaoRepository.Delete(atualizacao);
            _uof.Commit();

            return Ok();    
        }
    }
}
