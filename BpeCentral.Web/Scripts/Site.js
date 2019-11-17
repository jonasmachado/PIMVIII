$(document).ready(function () {
    mask();
    menuMarcarAtivacao();
    mensagemSistema();
    dateTable();
    datePicker();
});

function mask() {
    if ($('.cpf').length > 0)
        $(".cpf").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });

    if ($('.cep').length > 0)
        $(".cep").inputmask("mask", { "mask": "99999-999" }, { reverse: true });

    if ($('.telefone').length > 0)
        $(".telefone").inputmask("mask", { "mask": "(99) 99999-9999" }, { reverse: true });

    if ($('.date').length > 0)
        $(".date").inputmask("mask", { "mask": "99/99/9999" }, { reverse: true });

    if ($('.hora').length > 0)
        $(".hora").inputmask("mask", { "mask": "99:99" }, { reverse: true });

    if ($('.data-hora').length > 0)
        $(".data-hora").inputmask("mask", { "mask": "99/99/9999 99:99" }, { reverse: true });

    if ($('.cnpj').length > 0)
        $(".cnpj").inputmask("mask", { "mask": "99.999.999/9999-99" }, { reverse: true });

    if ($('.password').length > 0)
        $('.password').prop('type', 'password');

    if ($('.uf').length > 0)
        $(".uf").inputmask("mask", { "mask": "AA" }, { reverse: true });

    if ($('.codigoIbge').length > 0)
        $(".codigoIbge").inputmask("mask", { "mask": "999999999999999" }, { reverse: true });

    if ($('.price-formater').length > 0) {
        var configPrices = {
            prefix: 'R$ ',
            centsSeparator: ',',
            thousandsSeparator: '.',
            allowNegative: true,
            insertPlusSign: false
        }
        $('.price-formater').priceFormat(configPrices);
        configPrices.prefix = '';
        $('input.price-formater').priceFormat(configPrices);
    }

    $("form").submit(function () {
        if ($('input.price-formater').length > 0) {
            $('input.price-formater').each(function () {
                var valorSemFormatacao = $(this).unmask();
                var valorFloat = parseFloat(valorSemFormatacao);
                var valorSemDecimal = valorFloat / 100;
                var valorDecimal = valorSemDecimal.toFixed(2).replace('.', ',');
                console.log($(this).val(), valorDecimal);
                $(this).val(valorDecimal);
            });
        }
    });
}

function datePicker() {
    if ($('.datepicker').length > 0) {
        $('.datepicker').datepicker({
            format: 'dd/mm/yyyy',
            language: "pt-BR",
            orientation: 'left bottom',
            autoclose: true,
        });
    }
}

function menuMarcarAtivacao() {
    var url = window.location;

    $('ul.nav a').filter(function () {
        return url.toString().indexOf(this.href) > -1;
    }).parent().addClass('active');

    $('.menu .list-group a').filter(function () {
    
        return url.toString() === (this.href);
    }).addClass('active');

    $('.pagination a').on('click', function () {
        $('.pagination li.active').removeClass('active');
        $(this).parent().addClass('active');
    });
}

function mensagemSistema() {

    $('[data-toggle="popover"]').popover({ title: "Ajuda", trigger: "hover" });

    if ($('.alert').length > 0) {
        setTimeout(function () {
            $(".alert").fadeOut("300", function () { });
        }, 5500);
    }
}

function dateTable() {
    $(document).ready(function () {

        var config = {
            "lengthChange": false,
            "pageLength": 15,
            "language": {
                "sEmptyTable": "Nenhum registro encontrado",
                "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "",
                "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "_MENU_ resultados por página",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Processando...",
                "sZeroRecords": "Nenhum registro encontrado",
                "sSearch": "Pesquisar",
                "oPaginate": {
                    "sNext": "Próximo",
                    "sPrevious": "Anterior",
                    "sFirst": "Primeiro",
                    "sLast": "Último"
                },
                "oAria": {
                    "sSortAscending": ": Ordenar colunas de forma ascendente",
                    "sSortDescending": ": Ordenar colunas de forma descendente"
                }
            }
        };

        $('.dataTable').DataTable(config);

        config.destroy = true;
        config.paging = false,

            $('.dataTable_Not_Pag').DataTable(config);

        config.destroy = true;
        config.paging = true,
            config.order = [[0, "desc"]];

        $('.dataTable_Historico').DataTable(config);

    });
}
