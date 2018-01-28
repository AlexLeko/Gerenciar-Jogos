namespace GerenciarJogos.Common.Mensagens
{
    public class Mensagem
    {
        /// <summary>
        /// Mensagem de sucesso para um novo cadastro.
        /// </summary>
        public const string MSG_CADASTRO_SUCESSO = "Operação realizada com sucesso.";

        /// <summary>
        /// Mensagem de sucesso para um alteração de cadastro.
        /// </summary>
        public const string MSG_ALTERACAO_SUCESSO = "Alteração realizada com sucesso.";

        /// <summary>
        /// Mensagem de sucesso para um exclusão de cadastro.
        /// </summary>
        public const string MSG_REMOVER_SUCESSO = "Registro removido com sucesso.";

        /// <summary>
        /// Mensagem de sucesso para um exclusão de cadastro.
        /// </summary>
        public const string MSG_EMPRESTIMO_FINALIZADO = "O Emprestimo foi finalizado com sucesso!";



        #region [BANCO DE DADOS]

        /// <summary>
        /// "Problema durante a consulta a dados de emprestimo."
        /// </summary>
        public const string ERRO_ACESSO_DADOS = "Problema durante a consulta a dados de emprestimo.";

        #endregion

        #region [LOGIN]

        /// <summary>
        /// "Mensagem de validação para cadastro de campos no Login."
        /// </summary>
        public const string MSG_LOGIN_INVALIDO = "Por favor digite um nome de usuário e senha válidos!";

        /// <summary>
        /// Mensagem de apoio para o usuário após o cadastro da senha.
        /// </summary>
        public const string MSG_LOGIN_CONFIRMACAO = "Confirme os dados e tecle no botão Entrar.";
        

        #endregion

        
    }





}
