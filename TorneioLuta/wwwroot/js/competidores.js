/*------ Index - Competidores ------*/

//funcao para contar a quantidade de competidores selecionados
var selectionCounter = function () {
    var checkedValue = $("input:checked").length;
    $("#checkcount").text("Competidores selecionados: " + checkedValue);
}
selectionCounter();
$("input[type=checkbox]").on("click", selectionCounter);



//funcao para habilitar ou desabilitar o botao de iniciar o torneio
var buttonState = function () {
    var checkedValue = $("input:checked").length;

    if (checkedValue == 16) {
        document.querySelector(".btn-start").disabled = false;
        $(".btn-start").css("background-color", "#f7b551");

        $(".btn-start").hover(
            function () {
                $(this).css("border-bottom", "2px solid #fff");
            },
            function () {
                $(this).css("border-bottom", "none");
            }
        )
    } else {
        document.querySelector(".btn-start").disabled = true;
        $(".btn-start").css("background-color", "#ff0008");
    }
}
$("input[type=checkbox]").on("click", buttonState);



//funcao para limpar todos os checkboxs selecionados
var clearAll = function () {
    var inputs = $("input[type=checkbox]");
    inputs.prop('checked', false);

    $("#checkcount").text("Competidores selecionados: 0");

    document.querySelector(".btn-start").disabled = true;

    $(".btn-start").css("background-color", "#ff0008");
}
$(".btn-clear-all").on("click", clearAll);



//funcao para alterar o fundo para preto
var darkMode = function () {
    var element = document.body;
    element.classList.toggle("dark-mode-body");
}
$(".btn-dark-mode").on("click", darkMode);



//funcao para verificar se o competidor foi selecionado
function checkFighter(id) {
    var checkedItem = $(`#${id}`);

    if (checkedItem.val() === 'true') {
        checkedItem.val('false');
    } else {
        checkedItem.val('true');
    }
}
