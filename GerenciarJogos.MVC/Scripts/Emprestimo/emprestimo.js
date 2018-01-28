$ListaEmprestimo = [];

$(function () {
    bind.iniciarTabela();
});

var constantes = {
    idTabela: "#tblEmprestimo",
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
        emprestimo: '#formEmprestimo',
    },
    campo: {
        emprestimoID: '#hdnEmprestimoId',
        observacao: '#txtObservacao',
    }
}

var request = {
    controler: {
        api: "/api",
        emprestimo: "/Emprestimo",
    },
    action: {
        buscarTodos: "/BuscarTodosEmprestimos",
        manter: "/ManterEmprestimo",
        alterar: "/AlterarStatus",
        recuperar: "/RecuperarEmprestimoPorId",
        visualizar: "/Visualizar",
        finalizarEmprestimo: "/FinalizarEmprestimo",
        index: "/Index"

    }
}

var bind = {
    iniciarTabela: function () {
        var form = $(seletores.form.jogo).serialize();
        $.ajax({
            type: HTTP.post,
            url: request.controler.api + request.controler.emprestimo + request.action.buscarTodos,
            data: form,
            success: function (data) {
                if (data != null) {
                    $ListaEmprestimo = data;
                    tabela.carregarTabela();
                }
            }
        });
    },

    cadastrar: function () {
        if ($(seletores.form.emprestimo).valid()) {

            if ($('#ddlJogos').is(':disabled')) {
                $('#ddlAmigos').prop("disabled", false);
                $('#ddlJogos').prop("disabled", false);
            }

            var form = $(seletores.form.emprestimo).serialize();
            $.ajax({
                type: HTTP.post,
                url: request.controler.api + request.controler.emprestimo + request.action.manter,
                data: form,
                success: function (data) {
                    if (data != null) {
                        limparCampos();
                        bootbox.alert({
                            message: $mensagens.MSG_CADASTRO,
                            callback: function () {
                                window.location = request.controler.emprestimo + request.action.index;
                            }
                        });
                    }
                }
            });
        }
    },

    alterarStatus: function (codigo) {
        $.ajax({
            type: HTTP.get,
            url: request.controler.api + request.controler.emprestimo + request.action.alterar,
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
        window.location = request.controler.emprestimo + request.action.visualizar + parametro + codigo;
    },

    editar: function (codigo) {
        if (codigo > 0) {
            $.ajax({
                type: HTTP.get,
                url: request.controler.api + request.controler.emprestimo + request.action.recuperar,
                data: { codigo: codigo },
                success: function (data) {
                    if (data != null) {
                        limparCampos();
                        $(seletores.campo.emprestimoID).val(data.EmprestimoId);
                        $(seletores.campo.observacao).val(data.Observacao);
                        $('#ddlAmigos option[value=' + data.Amigo.AmigoId + ']').prop('selected', true);
                        adicionarJogoSelecionadoCombo(data.Jogo);
                        desabilitarCombos();
                    }
                }
            });
        }
    },

    devolver: function (codigo) {
        if (codigo > 0) {
            $.ajax({
                type: HTTP.get,
                url: request.controler.api + request.controler.emprestimo + request.action.finalizarEmprestimo,
                data: { codigo: codigo },
                success: function (data) {
                    if (data != null) {
                        bootbox.alert({
                            message: $mensagens.MSG_EMPRESTIMO_FINALIZADO,
                            callback: function () {
                                window.location = request.controler.emprestimo + request.action.index;
                            }
                        });
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
            "aaData": $ListaEmprestimo,
            columns: [
                {
                    mData: "Jogo.Nome", sTitle: "Jogo", sWidth: "30%", bSortable: true
                },
                {
                    mData: "Amigo.Nome", sTitle: "Amigo", sWidth: "25%", bSortable: true
                },
                {
                    mData: "DataCadastroFormatado", sTitle: "Data do Emprestimo", sWidth: "10%", bSortable: true
                },
                {
                    mData: "DataDevolucaoFormatado", sTitle: "Data da Devolucao", sWidth: "10%", bSortable: true
                },
                {
                    mData: "EmprestadoFormatado", sTitle: "Status", sWidth: "10%", bSortable: true
                },
                {
                    mData: null, sTitle: "Ação", bSortable: false, sWidth: '15%',
                    mRender: function (objeto) {
                        var botoes = "";
                        botoes += '<button type="button" onclick="bind.visualizar(' + objeto.EmprestimoId + ');" class="btn btn-default btn-xs" title="Visualizar" style="margin-right: 5px;"><span class="glyphicon glyphicon-eye-open" style"padding: 5px;"></span></button>';

                        if (objeto.IsAtivo) {
                            botoes += '<button type="button" onclick="bind.editar(' + objeto.EmprestimoId + ');" class="btn btn-default btn-xs" title="Editar" style="margin-right: 5px;"><span class="glyphicon glyphicon-edit" style"padding: 5px;"></span></button>';
                            if (objeto.IsEmprestado)
                                botoes += '<button type="button" onclick="bind.devolver(' + objeto.EmprestimoId + ');" class="btn btn-success btn-xs" title="Devolver Jogo" style="margin-right: 5px;"><span class="glyphicon glyphicon-check" style"padding: 5px;"></span></button> ';
                        }

                        return botoes;
                    }
                }
            ],
        });
    },
}

function limparCampos() {
    $(seletores.campo.emprestimoID).val("");
    $(seletores.campo.observacao).val("");
    $('#ddlJogos option[value=0]').prop('selected', true);
    $('#ddlAmigos option[value=0]').prop('selected', true);

    //$("#ddlAmigos").each(function () {
    //    $(this).removeAttr("selected");
    //});
}

function adicionarJogoSelecionadoCombo(objeto) {
    $('#ddlJogos').append($('<option>', {
        value: objeto.JogoId,
        text: objeto.Nome
    }));
    $('#ddlJogos option[value=' + objeto.JogoId + ']').prop('selected', true);
}

function desabilitarCombos() {
    $('#ddlAmigos').prop("disabled", true);
    $('#ddlJogos').prop("disabled", true);
}