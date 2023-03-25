using API_Priori.DTOs;
using API_Priori.Models;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public InvestimentoController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet("atualizacoes")]
        public async Task<ActionResult<List<InvestimentoDTO>>> GetInvestimentoByAtualizacao()
        {
            var investimento = await _uof.InvestimentoRepository.GetInvestimentosByAtualizacao();
            var investimentoDTO = _mapper.Map<List<InvestimentoDTO>>(investimento);

            return investimentoDTO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestimentoDTO>>> GetAllInvestimentos([FromQuery] InvestimentoParameters investimentoParameters)
        {
            var investimento = await _uof.InvestimentoRepository.GetInvestimentos(investimentoParameters);
            if (investimento is null)
                return NotFound();

            var metadata = new
            {
                investimento.TotalCount,
                investimento.PageSize,
                investimento.CurrentPage,
                investimento.TotalPage,
                investimento.HasNext,
                investimento.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            var investimentoDTO = _mapper.Map<List<InvestimentoDTO>>(investimento);

            return investimentoDTO;
        }

        [HttpGet("{id}", Name = "ObterInvestimento")]
        public async Task<ActionResult<InvestimentoDTO>> GetinvestimentoById(int id)
        {
            var investimento = await _uof.InvestimentoRepository.GetById(i => i.InvestimentoId == id);
            if (investimento is null)
                return NotFound();

            var investimentoDTO = _mapper.Map<InvestimentoDTO>(investimento);

            return investimentoDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(InvestimentoDTO investimentoDto)
        {
            if (investimentoDto is null)
                return BadRequest();

            var investimento = _mapper.Map<Investimento>(investimentoDto);

            _uof.InvestimentoRepository.Add(investimento);
            await _uof.Commit();

            var investimentoDTO = _mapper.Map<InvestimentoDTO>(investimento);

            return new CreatedAtRouteResult("ObterInvestimento",
                new { id = investimento.InvestimentoId }, investimentoDTO); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, InvestimentoDTO investimentoDto)
        {
            if (id != investimentoDto.InvestimentoId)
                return BadRequest();

            var investimento = _mapper.Map<Investimento>(investimentoDto);

            _uof.InvestimentoRepository.Update(investimento);
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InvestimentoDTO>> Delete(int id)
        {
            var investimento = await _uof.InvestimentoRepository.GetById(i => i.InvestimentoId == id);
            if (investimento is null)
                return NotFound();

            _uof.InvestimentoRepository.Delete(investimento);
            await _uof.Commit();

            var investimentoDto = _mapper.Map<InvestimentoDTO>(investimento);

            return Ok();
        }
    }
}
