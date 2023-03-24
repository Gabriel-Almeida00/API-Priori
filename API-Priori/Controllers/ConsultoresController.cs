using API_Priori.Context;
using API_Priori.DTOs;
using API_Priori.Models;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultoresController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ConsultoresController(IUnitOfWork contexto, IMapper mapper)
        {
            _uof = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConsultorDTO>> GetAllConsultores([FromQuery] ConsultorParameters consultorParameters) 
        {
            var consultores = _uof.ConsultorRepository.GetConsultors(consultorParameters);
            if (consultores is null)
                return NotFound("Consultor não encontrado");

            var metadata = new
            {
                consultores.TotalCount,
                consultores.PageSize,
                consultores.CurrentPage,
                consultores.TotalPage,
                consultores.HasNext,
                consultores.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            var consultorDTO = _mapper.Map<List<ConsultorDTO>>(consultores);

                return consultorDTO;
        }

        [HttpGet("{id}",Name = "ObterConsultor")]
        public ActionResult<ConsultorDTO> GetConsultorById (int id)
        {
            var consultor = _uof.ConsultorRepository.GetById(c => c.ConsultorId == id);
            if (consultor is null)
                return NotFound("Consultor não encontrado");

            var consultorDTO = _mapper.Map<ConsultorDTO>(consultor);

            return consultorDTO;
        }

        [HttpPost]
        public ActionResult Post(ConsultorDTO consultorDto)
        {
            if(consultorDto is null)
                return BadRequest();
            
            var consultor = _mapper.Map<Consultor>(consultorDto);

            _uof.ConsultorRepository.Add(consultor);
            _uof.Commit();

            var consultorDTO = _mapper.Map<ConsultorDTO>(consultor);    

            return new CreatedAtRouteResult("ObterConsultor", 
                new { id = consultor.ConsultorId }, consultorDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, ConsultorDTO consultorDto)
        {
            if (id != consultorDto.ConsultorId)
                return BadRequest();

            var consultor = _mapper.Map<Consultor>(consultorDto);

            _uof.ConsultorRepository.Update(consultor);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<ConsultorDTO> Delete(int id)
        {
            var consultor = _uof.ConsultorRepository.GetById(c => c.ConsultorId == id);
            if (consultor is null)
                return NotFound("cliente não encontrado");

            _uof.ConsultorRepository.Delete(consultor);
            _uof.Commit();

             var consultorDto = _mapper.Map<ConsultorDTO>(consultor);

            return Ok();
        }
    }
}
