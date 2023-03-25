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
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ClientesController(IUnitOfWork contexto, IMapper mapper)
        {
            _uof = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAllCliente([FromQuery] ClienteParameters clienteParameters)
        {
            var cliente = await _uof.ClienteRepository.GetClientes(clienteParameters);
            if(cliente is null)
                return NotFound("Cliente não encontrado");


            var metadata = new
            {
                cliente.TotalCount,
                cliente.PageSize,
                cliente.CurrentPage,
                cliente.TotalPage,
                cliente.HasNext,
                cliente.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            var clienteDTO = _mapper.Map<List<ClienteDTO>>(cliente);
            
            return clienteDTO;
        }

        [HttpGet("{id}" , Name="ObterCliente")]
        public async Task<ActionResult<ClienteDTO>> GetClienteById(int id)
        {
            var cliente = await _uof.ClienteRepository.GetById(p => p.ClienteId == id);
            if(cliente is null)
                return NotFound("cliente não encontrado...");

            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            
            return clienteDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ClienteDTO clienteDto)
        {
            if (clienteDto is null)
                return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteDto);

            _uof.ClienteRepository.Add(cliente);
            await _uof.Commit();

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.ClienteId }, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ClienteDTO clienteDto)
        {
            if (id != clienteDto.ClienteId)
                return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteDto);

            _uof.ClienteRepository.Update(cliente);
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var cliente = await _uof.ClienteRepository.GetById(c => c.ClienteId == id);
            if (cliente is null)
                return NotFound("cliente não encontrado");

            _uof.ClienteRepository.Delete(cliente);
            await _uof.Commit();

            var clienteDto = _mapper.Map<ClienteDTO>(cliente);

            return Ok();
        }
    }
}
