using AutoMapper;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;

namespace GerenciarJogos.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TipoConsole, TipoConsoleViewModel>();
            Mapper.CreateMap<Jogo, JogoViewModel>();
            Mapper.CreateMap<Amigo, AmigoViewModel>();
            Mapper.CreateMap<Emprestimo, EmprestimoViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();

        }
    }
}