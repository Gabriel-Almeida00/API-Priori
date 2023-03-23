using API_Priori.DTOs;
using API_Priori.Models;
using API_Priori.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtualizacaoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public AtualizacaoController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AtualizacaoDTO>> GetAll()
        {
            var atualizcao = _uof.AtualizacaoRepository.GetAll().ToList();
            if (atualizcao is null)
                return NotFound("Atualização não encontrada");

            var atualizacaoDTO = _mapper.Map<List<AtualizacaoDTO>>(atualizcao);
            return atualizacaoDTO;
        }

        [HttpGet("{id}", Name = "ObterAtualizacao")]
        public ActionResult<AtualizacaoDTO> GetAtualizacaoById(int id)
        {
            var atualizacao = _uof.AtualizacaoRepository.GetById(a => a.AtualizacaoId == id);
            if (atualizacao is null)
                return NotFound();

            var atualizacaoDTO = _mapper.Map<AtualizacaoDTO>(atualizacao);
            return atualizacaoDTO;
        }

        [HttpPost]
        public ActionResult Post(AtualizacaoDTO atualizacaoDTO)
        {
            if (atualizacaoDTO is null)
                return BadRequest();

            var atualizacao = _mapper.Map<Atualizacao>(atualizacaoDTO);
            
            _uof.AtualizacaoRepository.Add(atualizacao);
            _uof.Commit();

            var atualizacaoDto = _mapper.Map<AtualizacaoDTO>(atualizacao);

            return new CreatedAtRouteResult("ObterAtualizacao",
               new { id = atualizacao.AtualizacaoId }, atualizacaoDto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, AtualizacaoDTO atualizacaoDTO)
        {
          if(id != atualizacaoDTO.AtualizacaoId)
                return BadRequest();

            var atualizacao = _mapper.Map<Atualizacao>(atualizacaoDTO);

            _uof.AtualizacaoRepository.Update(atualizacao);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<AtualizacaoDTO> Delete(int id)
        {
            var atualizacao = _uof.AtualizacaoRepository.GetById(a => a.AtualizacaoId == id);
            if(atualizacao is null)
                return NotFound();

            _uof.AtualizacaoRepository.Delete(atualizacao);
            _uof.Commit();

            var atualizacaoDto = _mapper.Map<AtualizacaoDTO>(atualizacao);

            return Ok();    
        }
    }
}
