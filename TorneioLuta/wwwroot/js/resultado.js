/*------ Index - Resultado ------*/

//funcao para alterar o fundo para preto
var modeDark = function () {

    var element = document.body;
    element.classList.toggle("dark-mode-body");

    var t = document.querySelector(".title");
    t.classList.toggle("title-mode-dark");

    $(".btn-back").hover(
        function () {
            this.classList.toggle("btn-back-dark-mode");
        }
    )
}
$(".btn-dark").on("click", modeDark);