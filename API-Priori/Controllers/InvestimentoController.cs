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
    public class InvestimentoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public InvestimentoController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvestimentoDTO>> GetAllInvestimentos()
        {
            var investimento = _uof.InvestimentoRepository.GetAll().ToList();
            if (investimento is null)
                return NotFound();

            var investimentoDTO = _mapper.Map<List<InvestimentoDTO>>(investimento);

            return investimentoDTO;
        }

        [HttpGet("{id}", Name = "ObterInvestimento")]
        public ActionResult<InvestimentoDTO> GetinvestimentoById(int id)
        {
            var investimento = _uof.InvestimentoRepository.GetById(i => i.InvestimentoId == id);
            if (investimento is null)
                return NotFound();

            var investimentoDTO = _mapper.Map<InvestimentoDTO>(investimento);

            return investimentoDTO;
        }

        [HttpPost]
        public ActionResult Post(InvestimentoDTO investimentoDto)
        {
            if (investimentoDto is null)
                return BadRequest();

            var investimento = _mapper.Map<Investimento>(investimentoDto);

            _uof.InvestimentoRepository.Add(investimento);
            _uof.Commit();

            var investimentoDTO = _mapper.Map<InvestimentoDTO>(investimento);

            return new CreatedAtRouteResult("ObterInvestimento",
                new { id = investimento.InvestimentoId }, investimentoDTO); 
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, InvestimentoDTO investimentoDto)
        {
            if (id != investimentoDto.InvestimentoId)
                return BadRequest();

            var investimento = _mapper.Map<Investimento>(investimentoDto);

            _uof.InvestimentoRepository.Update(investimento);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<InvestimentoDTO> Delete(int id)
        {
            var investimento = _uof.InvestimentoRepository.GetById(i => i.InvestimentoId == id);
            if (investimento is null)
                return NotFound();

            _uof.InvestimentoRepository.Delete(investimento);
            _uof.Commit();

            var investimentoDto = _mapper.Map<InvestimentoDTO>(investimento);

            return Ok();
        }
    }
}
