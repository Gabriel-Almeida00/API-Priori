﻿using API_Priori.DTOs;
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
        public async Task<ActionResult<IEnumerable<AtualizacaoDTO>>> GetAll([FromQuery] AtualizacaoParameters atualizacaoParameters)
        {
            var atualizcao = await _uof.AtualizacaoRepository.GetAtualizacaos(atualizacaoParameters);
            if (atualizcao is null)
                return NotFound("Atualização não encontrada");

            var metadata = new
            {
                atualizcao.TotalCount,
                atualizcao.PageSize,
                atualizcao.CurrentPage,
                atualizcao.TotalPage,
                atualizcao.HasNext,
                atualizcao.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            var atualizacaoDTO = _mapper.Map<List<AtualizacaoDTO>>(atualizcao);
            return atualizacaoDTO;
        }

        [HttpGet("{id}", Name = "ObterAtualizacao")]
        public async Task<ActionResult<AtualizacaoDTO>> GetAtualizacaoById(int id)
        {
            var atualizacao = await _uof.AtualizacaoRepository.GetById(a => a.AtualizacaoId == id);
            if (atualizacao is null)
                return NotFound();

            var atualizacaoDTO = _mapper.Map<AtualizacaoDTO>(atualizacao);
            return atualizacaoDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AtualizacaoDTO atualizacaoDTO)
        {
            if (atualizacaoDTO is null)
                return BadRequest();

            var atualizacao = _mapper.Map<Atualizacao>(atualizacaoDTO);
            
            _uof.AtualizacaoRepository.Add(atualizacao);
            await _uof.Commit();

            var atualizacaoDto = _mapper.Map<AtualizacaoDTO>(atualizacao);

            return new CreatedAtRouteResult("ObterAtualizacao",
               new { id = atualizacao.AtualizacaoId }, atualizacaoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, AtualizacaoDTO atualizacaoDTO)
        {
          if(id != atualizacaoDTO.AtualizacaoId)
                return BadRequest();

            var atualizacao = _mapper.Map<Atualizacao>(atualizacaoDTO);

            _uof.AtualizacaoRepository.Update(atualizacao);
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AtualizacaoDTO>> Delete(int id)
        {
            var atualizacao = await _uof.AtualizacaoRepository.GetById(a => a.AtualizacaoId == id);
            if(atualizacao is null)
                return NotFound();

            _uof.AtualizacaoRepository.Delete(atualizacao);
            await _uof.Commit();

            var atualizacaoDto = _mapper.Map<AtualizacaoDTO>(atualizacao);

            return Ok();    
        }
    }
}
