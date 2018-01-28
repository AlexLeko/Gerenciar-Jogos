using System;

namespace GerenciarJogos.Domain.Entities
{
    public class Amigo
    {
        public int AmigoId { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

    }
}
