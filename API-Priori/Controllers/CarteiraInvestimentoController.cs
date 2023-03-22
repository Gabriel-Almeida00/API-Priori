using API_Priori.Models;
using API_Priori.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarteiraInvestimentoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public CarteiraInvestimentoController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarteiraInvestimento>> GetAllCarteiraInvetimento()
        {
            var carteira = _uof.CarteiraInvestimentoRepository.GetAll().ToList();
            if(carteira is null)
                return NotFound();

            return carteira;
        }

        [HttpGet("{id}", Name = "ObterCarteira")]
        public ActionResult<CarteiraInvestimento> GetCarteiraById(int id)
        {
            var carteira = _uof.CarteiraInvestimentoRepository.GetById(c => c.CarteiraInvestimentoId == id);
            if (carteira is null)
                return NotFound();

            return carteira;
        }

        [HttpPost]
        public ActionResult Post(CarteiraInvestimento carteira)
        {
            if (carteira is null)
                return BadRequest();

            _uof.CarteiraInvestimentoRepository.Add(carteira);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterCarteira",
                new { id = carteira.CarteiraInvestimentoId }, carteira);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, CarteiraInvestimento carteira)
        {
            if (id != carteira.CarteiraInvestimentoId)
                return BadRequest();

            _uof.CarteiraInvestimentoRepository.Update(carteira);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var carteira = _uof.CarteiraInvestimentoRepository.GetById(c => c.CarteiraInvestimentoId == id);
            if (carteira is null)
                return NotFound();

            _uof.CarteiraInvestimentoRepository.Delete(carteira);
            _uof.Commit();

            return Ok();
        }
    }
}
