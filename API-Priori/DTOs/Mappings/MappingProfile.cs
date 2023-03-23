using API_Priori.Models;
using AutoMapper;

namespace API_Priori.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Atualizacao, AtualizacaoDTO>().ReverseMap();
            CreateMap<CarteiraInvestimento, CarteiraInvestimentoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Consultor, ConsultorDTO>().ReverseMap();
            CreateMap<Investimento, InvestimentoDTO>().ReverseMap();

        }
    }
}
