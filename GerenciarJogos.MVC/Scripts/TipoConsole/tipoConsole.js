$ListaConsoles = [];

$(function () {
    bind.iniciarTabela();
});

var constantes = {
    idTabela: "#tblConsoles",
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
        console: '#formConsole',
    },
    campo: {
        consoleId: '#hdnConsoleId',
        nome: '#txtNome',
    }
}

var request = {
    controler: {
        api: "/api",
        tipoConsole: "/TipoConsole",
    },
    action: {
        buscarTodos: "/BuscarTodos",
        manter: "/ManterConsole",
        alterar: "/AlterarStatus",
        recuperar: "/RecuperarConsole",
        visualizar: "/Visualizar",
        deletar: "RemoverConsole"
    },

}

var bind = {

    iniciarTabela: function () {
        var form = $(seletores.form.console).serialize();
        $.ajax({
            type: HTTP.post,
            url: request.controler.api + request.controler.tipoConsole + request.action.buscarTodos,
            data: form,
            success: function (data) {
                if (data != null) {
                    $ListaConsoles = data;
                    tabela.carregarTabela();
                }
            }
        });
    },

    cadastrar: function () {
        if ($(seletores.form.console).valid()) {
            var form = $(seletores.form.console).serialize();
            $.ajax({
                type: HTTP.post,
                url: request.controler.api + request.controler.tipoConsole + request.action.manter,
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
            url: request.controler.api + request.controler.tipoConsole + request.action.alterar,
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
        window.location = request.controler.tipoConsole + request.action.visualizar + parametro + codigo;
    },

    editar: function (codigo) {
        if (codigo > 0) {
            $.ajax({
                type: HTTP.get,
                url: request.controler.api + request.controler.tipoConsole + request.action.recuperar,
                data: { codigo: codigo },
                success: function (data) {
                    if (data != null) {
                        $(seletores.campo.consoleId).val(data.ConsoleId);
                        $(seletores.campo.nome).val(data.Nome);
                    }
                }
            });
        }
    },

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
            "aaData": $ListaConsoles,
            columns: [
                {
                    mData: "Nome", sTitle: "Nome", sWidth: "60%", bSortable: true
                },
                {
                    mData: "Status", sTitle: "Status", sWidth: "20%", bSortable: true
                },
                {
                    mData: null, sTitle: "Ação", bSortable: false, sWidth: '20%',
                    mRender: function (objeto) {
                        var botoes = "";
                        if (!objeto.Ativo)
                            botoes += '<button type="button" onclick="bind.alterarStatus(' + objeto.ConsoleId + ');" class="btn btn-success btn-xs" title="Ativar" style="margin-right: 5px;"><span class="glyphicon glyphicon-ok-circle" style"padding: 5px;"></span></button> ';
                        else
                            botoes += '<button type="button" onclick="bind.alterarStatus(' + objeto.ConsoleId + ');" class="btn btn-danger btn-xs" title="Desativar" style="margin-right: 5px;"><span class="glyphicon glyphicon-remove-circle" style"padding: 5px;"></span></button> ';

                        botoes += '<button type="button" onclick="bind.visualizar(' + objeto.ConsoleId + ');" class="btn btn-default btn-xs" title="Visualizar" style="margin-right: 5px;"><span class="glyphicon glyphicon-eye-open" style"padding: 5px;"></span></button>';
                        botoes += '<button type="button" onclick="bind.editar(' + objeto.ConsoleId + ');" class="btn btn-default btn-xs" title="Editar" style="margin-right: 5px;"><span class="glyphicon glyphicon-edit" style"padding: 5px;"></span></button>';

                        return botoes;
                    }
                }
            ],
        });
    },
}

function limparCampos() {
    $(seletores.campo.consoleId).val("");
    $(seletores.campo.nome).val("");
}