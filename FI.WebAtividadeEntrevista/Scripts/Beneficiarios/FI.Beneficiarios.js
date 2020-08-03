
$(document).ready(function () {
    $('#formCadastro').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#Nome").val(),
                "IdCliente": $(this).find("#idCliente").val(),
                "CPF": $(this).find("#CPF").val()
            },
            error:
                function (r, jr) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor." + jr);
                },
            success:
                function (r) {
                    ModalDialog("Sucesso!", r.message)
                    $("#formCadastro")[0].reset();
                }
        });
    })

})

$('#CPF').change(function (e) {
var cpfSemMascara=$("#CPF").val().replace(".","").replace("-","").replace(".","");
if (!validarCPF($("#CPF").val())){
ModalDialog("Atenção:", "O CPF informado é inválido.");
                    $("#formCadastro")[0].reset();}
});

$('#CPF').keydown(function (e) {
var cpf=document.getElementById("CPF").value.length;
if (cpf==3)
{$("#CPF").val($("#CPF").val()+".")}
else
if (cpf==7)
{$("#CPF").val($("#CPF").val()+".")}
else
if (cpf==11)
{$("#CPF").val($("#CPF").val()+"-")}
});

$('#CPF').blur(function (e) {
    e.preventDefault();
    $.ajax({
        url: urlVerificaCPF,
        method: "GET",
        data: {
            "CPF": $("#CPF").val()
        },
        error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
        success:
            function (r) {
                if (r.message != "") {
                    ModalDialog("Atenção:", r.message);
                    $("#formCadastro")[0].reset();
                }
            }
    });
});

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}
