$ListaAmigos = [];

$(function () {
    bind.iniciarTabela();
    $('#txtTelefone').inputmask("(99)99999-9999");
});

var constantes = {
    idTabela: "#tblAmigos",
    tabela: {
        menu: 'Mostrando _MENU_ registros por página',
        nenhumRegistro: 'Nenhum registro foi encontrado.',
        registroEncontrado: '<b>REGISTROS ENCONTRADOS: _TOTAL_</b>',
        filtros: '(filtrados _MAX_ registros)',
    }
}

var HTTP = {
    post: 'POST',
    get: 'GET',
}

var seletores = {
    form: {
        amigo: '#formAmigo',
    },
    campo: {
        amigoID: '#hdnAmigoId',
        nome: '#txtNome',
        apelido: '#txtApelido',
        telefone: '#txtTelefone',
        email: '#txtEmail',
    },
    mascara: {
        celular: "(99)99999-9999",
    }
}

var request = {
    controler: {
        api: "/api",
        amigo: "/Amigo",
    },
    action: {
        buscarTodos: "/BuscarTodosAmigos",
        manter: "/ManterAmigo",
        alterar: "/AlterarStatusAmigo",
        recuperar: "/RecuperarAmigoPorId",
        visualizar: "/Visualizar",
    },

}

var bind = {

    iniciarTabela: function () {
        var form = $(seletores.form.amigo).serialize();
        $.ajax({
            type: HTTP.post,
            url: request.controler.api + request.controler.amigo + request.action.buscarTodos,
            data: form,
            success: function (data) {
                if (data != null) {
                    $ListaAmigos = data;
                    tabela.carregarTabela();
                }
            }
        });
    },

    cadastrar: function () {
        if ($(seletores.form.amigo).valid()) {
            var form = $(seletores.form.amigo).serialize();
            $.ajax({
                type: HTTP.post,
                url: request.controler.api + request.controler.amigo + request.action.manter,
                data: form,
                success: function (data) {
                    if (data != null) {
                        bind.iniciarTabela();
                        limparCampos();
                        bootbox.alert($mensagens.MSG_CADASTRO);
                    }
                }
            });
        }
    },

    alterarStatus: function (codigo) {
        $.ajax({
            type: HTTP.get,
            url: request.controler.api + request.controler.amigo + request.action.alterar,
            data: { codigo: codigo },
            success: function (data) {
                if (data != null) {
                    bind.iniciarTabela();
                    bootbox.alert($mensagens.MSG_ALTERACAO);
                }
            }
        });
    },

    visualizar: function (codigo) {
        var parametro = "?codigo=";
        window.location = request.controler.amigo + request.action.visualizar + parametro + codigo;
    },

    editar: function (codigo) {
        if (codigo > 0) {
            $.ajax({
                type: HTTP.get,
                url: request.controler.api + request.controler.amigo + request.action.recuperar,
                data: { codigo: codigo },
                success: function (data) {
                    if (data != null) {
                        $(seletores.campo.amigoID).val(data.AmigoId);
                        $(seletores.campo.nome).val(data.Nome);
                        $(seletores.campo.apelido).val(data.Apelido);
                        $(seletores.campo.telefone).val(data.Telefone);
                        $(seletores.campo.email).val(data.Email);
                    }
                }
            });
        }
    }

}


var tabela = {
    carregarTabela: function () {
        $(constantes.idTabela).DataTable({
            destroy: true,
            paginate: true,
            language: {
                lengthMenu: constantes.tabela.menu,
                zeroRecords: constantes.tabela.nenhumRegistro,
                info: constantes.tabela.registroEncontrado,
                infoEmpty: '',
                infoFiltered: constantes.tabela.filtros,
                paginate: {
                    first: '←',
                    last: '→',
                    next: '»',
                    previous: '«'
                },
                thousands: '.',
                decimal: ','
            },
            autoWidth: true,
            lengthChange: false,
            searching: false,
            "aaData": $ListaAmigos,
            columns: [
                {
                    mData: "Nome", sTitle: "Nome", sWidth: "35%", bSortable: true
                },
                {
                    mData: "Apelido", sTitle: "Apelido", sWidth: "20%", bSortable: true
                },
                {
                    mData: "Telefone", sTitle: "Celular", sWidth: "15%", bSortable: true
                },
                {
                    mData: "StatusFormatado", sTitle: "Status", sWidth: "15%", bSortable: true
                },
                {
                    mData: null, sTitle: "Ação", bSortable: false, sWidth: '15%',
                    mRender: function (objeto) {
                        var botoes = "";
                        if (!objeto.Ativo)
                            botoes += '<button type="button" onclick="bind.alterarStatus(' + objeto.AmigoId + ');" class="btn btn-success btn-xs" title="Ativar" style="margin-right: 5px;"><span class="glyphicon glyphicon-ok-circle" style"padding: 5px;"></span></button> ';
                        else
                            botoes += '<button type="button" onclick="bind.alterarStatus(' + objeto.AmigoId + ');" class="btn btn-danger btn-xs" title="Desativar" style="margin-right: 5px;"><span class="glyphicon glyphicon-remove-circle" style"padding: 5px;"></span></button> ';

                        botoes += '<button type="button" onclick="bind.visualizar(' + objeto.AmigoId + ');" class="btn btn-default btn-xs" title="Visualizar" style="margin-right: 5px;"><span class="glyphicon glyphicon-eye-open" style"padding: 5px;"></span></button>';
                        botoes += '<button type="button" onclick="bind.editar(' + objeto.AmigoId + ');" class="btn btn-default btn-xs" title="Editar" style="margin-right: 5px;"><span class="glyphicon glyphicon-edit" style"padding: 5px;"></span></button>';

                        return botoes;
                    }
                }
            ],
        });
    },
}

function limparCampos() {
    $(seletores.campo.amigoID).val("");
    $(seletores.campo.nome).val("");
    $(seletores.campo.apelido).val("");
    $(seletores.campo.telefone).val("");
    $(seletores.campo.email).val("");
}

function aplicaMascara() {
    $(seletores.campo.telefone).inputmask(seletores.mascara.celular);

}