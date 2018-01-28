$ListaJogos = [];
$(function () {
    bind.iniciarTabela();
});

var constantes = {
    idTabela: "#tblJogos",
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
        jogo: '#frmJogo',
    },
    campo: {
        jogoId: '#hdnJogoId',
        nome: '#txtNome',
    }
}

var request = {
    controler: {
        api: "/api",
        jogo: "/Jogo",
    },
    action: {
        buscarTodos: "/Buscar",
        manter: "/ManterJogo",
        alterar: "/AlterarStatus",
        recuperar: "/RecuperarJogoPorId",
        visualizar: "/Visualizar",
    },

}

var bind = {
    iniciarTabela: function () {
        var form = $(seletores.form.jogo).serialize();
        $.ajax({
            type: HTTP.post,
            url: request.controler.api + request.controler.jogo + request.action.buscarTodos,
            data: form,
            success: function (data) {
                if (data != null) {
                    $ListaJogos = data;
                    tabela.carregarTabela();
                }
            }
        });
    },

    cadastrar: function () {
        if ($(seletores.form.jogo).valid()) {
            var form = $(seletores.form.jogo).serialize();
            $.ajax({
                type: HTTP.post,
                url: request.controler.api + request.controler.jogo + request.action.manter,
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
            url: request.controler.api + request.controler.jogo + request.action.alterar,
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
        window.location = request.controler.jogo + request.action.visualizar + parametro + codigo;
    },

    editar: function (codigo) {
        if (codigo > 0) {
            $.ajax({
                type: HTTP.get,
                url: request.controler.api + request.controler.jogo + request.action.recuperar,
                data: { codigo: codigo },
                success: function (data) {
                    if (data != null) {
                        $(seletores.campo.jogoId).val(data.JogoId);
                        $(seletores.campo.nome).val(data.Nome);
                        $('#ddlTipoConsole option[value=' + data.ConsoleSelecionado + ']').prop('selected', true);
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
            "aaData": $ListaJogos,
            columns: [
                {
                    mData: "Nome", sTitle: "Nome", sWidth: "20%", bSortable: true
                },
                {
                    mData: "Console.Nome", sTitle: "Console", sWidth: "20%", bSortable: true
                },
                {
                    mData: "EmprestadoFormatado", sTitle: "Emprestado", sWidth: "20%", bSortable: true
                },
                {
                    mData: "StatusFormatado", sTitle: "Status", sWidth: "20%", bSortable: true
                },
                {
                    mData: null, sTitle: "Ação", bSortable: false, sWidth: '10%',
                    mRender: function (objeto) {
                        var botoes = "";
                        var botoes = "";
                        if (!objeto.Ativo)
                            botoes += '<button type="button" onclick="bind.alterarStatus(' + objeto.JogoId + ');" class="btn btn-success btn-xs" title="Ativar" style="margin-right: 5px;"><span class="glyphicon glyphicon-ok-circle" style"padding: 5px;"></span></button> ';
                        else
                            botoes += '<button type="button" onclick="bind.alterarStatus(' + objeto.JogoId + ');" class="btn btn-danger btn-xs" title="Desativar" style="margin-right: 5px;"><span class="glyphicon glyphicon-remove-circle" style"padding: 5px;"></span></button> ';

                        botoes += '<button type="button" onclick="bind.visualizar(' + objeto.JogoId + ');" class="btn btn-default btn-xs" title="Visualizar" style="margin-right: 5px;"><span class="glyphicon glyphicon-eye-open" style"padding: 5px;"></span></button>';
                        botoes += '<button type="button" onclick="bind.editar(' + objeto.JogoId + ');" class="btn btn-default btn-xs" title="Editar" style="margin-right: 5px;"><span class="glyphicon glyphicon-edit" style"padding: 5px;"></span></button>';

                        return botoes;
                    }
                }
            ],
        });
    },
}

function limparCampos() {
    $(seletores.campo.jogoId).val("");
    $(seletores.campo.nome).val("");
    $('#ddlTipoConsole>option:eq(0)').prop('selected', true);
}