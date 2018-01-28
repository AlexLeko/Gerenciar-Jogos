
$(function () {
    bind.validarAcesso();
});

var seletores = {
    form: {
        login: '#frmLogin',
    },
    campo: {
        erro: '#hddnIsErro',
        usuario: '#txtUsuario',
        senha: '#txtSenha',
        criarConta: '#linkPrimeiroAcesso',
    }
}

var HTTP = {
    post: 'POST',
}

var request = {
    controler: {
        api: "/api",
        login: "/Login",
        home: "/Home",
    },
    action: {
        adicionarConta: "/AdicionarConta",
        index: "/Index",
    }
}

var bind = {

    validarAcesso: function () {
        if ($(seletores.campo.erro).val().toString().toUpperCase() == 'TRUE') {
            bootbox.alert($mensagens.MSG_LOGIN_INVALIDO);
        }
    },

    cadastrar: function () {
        if ($(seletores.campo.usuario).val() != "" && $(seletores.campo.senha).val() != "") {
            var form = $(seletores.form.login).serialize();
            $.ajax({
                type: HTTP.post,
                url: request.controler.api + request.controler.login + request.action.adicionarConta,
                data: form,
                success: function (data) {
                    if (data != null) {
                        bootbox.alert({
                            message: $mensagens.MSG_CADASTRO,
                            callback: function () {
                                bootbox.alert({
                                    message: $mensagens.MSG_LOGIN_CONFIRMACAO,
                                });
                            }
                        });
                    }
                }
            });
        }
        else{
            bootbox.alert($mensagens.MSG_LOGIN_INVALIDO);
        }            
    },


}


$(seletores.campo.criarConta).on('click', function () {
    bind.cadastrar();
});