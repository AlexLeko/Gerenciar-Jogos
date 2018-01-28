using AutoMapper;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;

namespace GerenciarJogos.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TipoConsoleViewModel, TipoConsole>();
            Mapper.CreateMap<JogoViewModel, Jogo>();
            Mapper.CreateMap<AmigoViewModel, Amigo>();
            Mapper.CreateMap<EmprestimoViewModel, Emprestimo>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();

        }
    }
}