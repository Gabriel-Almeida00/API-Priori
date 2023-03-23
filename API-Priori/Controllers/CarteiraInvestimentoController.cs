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
        public ActionResult<IEnumerable<CarteiraInvestimentoDTO>> GetAllCarteiraInvetimento()
        {
            var carteira = _uof.CarteiraInvestimentoRepository.GetAll().ToList();
            if(carteira is null)
                return NotFound();

            var carteiraDTO = _mapper.Map<List<CarteiraInvestimentoDTO>>(carteira);

            return carteiraDTO;
        }

        [HttpGet("{id}", Name = "ObterCarteira")]
        public ActionResult<CarteiraInvestimentoDTO> GetCarteiraById(int id)
        {
            var carteira = _uof.CarteiraInvestimentoRepository.GetById(c => c.CarteiraInvestimentoId == id);
            if (carteira is null)
                return NotFound();

            var carteiraDTO = _mapper.Map<CarteiraInvestimentoDTO>(carteira);

            return carteiraDTO;
        }

        [HttpPost]
        public ActionResult Post(CarteiraInvestimentoDTO carteiraDto)
        {
            if (carteiraDto is null)
                return BadRequest();

            var carteira = _mapper.Map<CarteiraInvestimento>(carteiraDto);

            _uof.CarteiraInvestimentoRepository.Add(carteira);
            _uof.Commit();

            var carteiraDTO = _mapper.Map<CarteiraInvestimentoDTO>(carteira);

            return new CreatedAtRouteResult("ObterCarteira",
                new { id = carteira.CarteiraInvestimentoId }, carteiraDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, CarteiraInvestimentoDTO carteiraDto)
        {
            if (id != carteiraDto.CarteiraInvestimentoId)
                return BadRequest();

            var carteira = _mapper.Map<CarteiraInvestimento>(carteiraDto);

            _uof.CarteiraInvestimentoRepository.Update(carteira);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<CarteiraInvestimentoDTO> Delete(int id)
        {
            var carteira = _uof.CarteiraInvestimentoRepository.GetById(c => c.CarteiraInvestimentoId == id);
            if (carteira is null)
                return NotFound();

            _uof.CarteiraInvestimentoRepository.Delete(carteira);
            _uof.Commit();

            var carteiraDTO = _mapper.Map<CarteiraInvestimentoDTO>(carteira);

            return Ok();
        }
    }
}
