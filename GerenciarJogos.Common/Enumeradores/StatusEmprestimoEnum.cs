using System.ComponentModel;

namespace GerenciarJogos.Common.Enumeradores
{
    public enum StatusEmprestimoEnum
    {
        [Description("Livre")]
        LIVRE = 0,

        [Description("Emprestado")]
        EMPRESTADO = 1,

        [Description("Devolvido")]
        DEVOLVIDO = 2,

    }
}
