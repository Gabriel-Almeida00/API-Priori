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
    public class CarteiraInvestimentoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CarteiraInvestimentoController(IUnitOfWork context , IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarteiraInvestimentoDTO>>> GetAllCarteiraInvetimento
            ([FromQuery] CarteiraInvestimentoParameters carteiraInvestimentoParameters)
        {
            var carteira = await _uof.CarteiraInvestimentoRepository.GetCarteiraInvestimentos(carteiraInvestimentoParameters);
            if(carteira is null)
                return NotFound();

            var metadata = new
            {
                carteira.TotalCount,
                carteira.PageSize,
                carteira.CurrentPage,
                carteira.TotalPage,
                carteira.HasNext,
                carteira.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            var carteiraDTO = _mapper.Map<List<CarteiraInvestimentoDTO>>(carteira);

            return carteiraDTO;
        }

        [HttpGet("{id}", Name = "ObterCarteira")]
        public async Task<ActionResult<CarteiraInvestimentoDTO>> GetCarteiraById(int id)
        {
            var carteira = await _uof.CarteiraInvestimentoRepository.GetById(c => c.CarteiraInvestimentoId == id);
            if (carteira is null)
                return NotFound();

            var carteiraDTO = _mapper.Map<CarteiraInvestimentoDTO>(carteira);

            return carteiraDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CarteiraInvestimentoDTO carteiraDto)
        {
            if (carteiraDto is null)
                return BadRequest();

            var carteira = _mapper.Map<CarteiraInvestimento>(carteiraDto);

            _uof.CarteiraInvestimentoRepository.Add(carteira);
            await _uof.Commit();

            var carteiraDTO = _mapper.Map<CarteiraInvestimentoDTO>(carteira);

            return new CreatedAtRouteResult("ObterCarteira",
                new { id = carteira.CarteiraInvestimentoId }, carteiraDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CarteiraInvestimentoDTO carteiraDto)
        {
            if (id != carteiraDto.CarteiraInvestimentoId)
                return BadRequest();

            var carteira = _mapper.Map<CarteiraInvestimento>(carteiraDto);

            _uof.CarteiraInvestimentoRepository.Update(carteira);
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CarteiraInvestimentoDTO>> Delete(int id)
        {
            var carteira = await _uof.CarteiraInvestimentoRepository.GetById(c => c.CarteiraInvestimentoId == id);
            if (carteira is null)
                return NotFound();

            _uof.CarteiraInvestimentoRepository.Delete(carteira);
            await _uof.Commit();

            var carteiraDTO = _mapper.Map<CarteiraInvestimentoDTO>(carteira);

            return Ok();
        }
    }
}
