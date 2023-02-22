document.addEventListener("DOMContentLoaded", function () {
    var element = document.createElement("p");
    element.textContent = "Этот элемент создан в файле fourth.js";
    document.querySelector("body").appendChild(element);
});