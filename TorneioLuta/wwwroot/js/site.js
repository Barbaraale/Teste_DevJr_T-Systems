/*------ Index - Competidores ------*/

//funcao para contar a quantidade de competidores selecionados
var selectionCounter = function () {
    var checkedValue = $("input:checked").length;
    $("#checkcount").text("Competidores selecionados: " + checkedValue);
};
selectionCounter();
$("input[type=checkbox]").on("click", selectionCounter);

//funcao para habilitar ou desabilitar o botao de iniciar o torneio
document.querySelector(".btn-start").disabled = true;

var buttonState = function () {
    var checkedValue = $("input:checked").length;
    if (checkedValue == 3)
    {
        document.querySelector(".btn-start").disabled = false;
    } else {
        document.querySelector(".btn-start").disabled = true;
    }
};
$("input[type=checkbox]").on("click", buttonState);

//funcao para limpar todos os checkboxs selecionados
var t = function () {
    var inputs = $("input[type=checkbox]");
    inputs.prop('checked', false);
    $("#checkcount").text("Competidores selecionados: 0");
    document.querySelector(".btn-start").disabled = true;
}
$(".btn-clear-all").on("click", t);
