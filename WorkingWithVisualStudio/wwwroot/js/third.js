document.addEventListener("DOMContentLoaded", function () {
    var element = document.createElement("p");
    element.textContent = "Этот элемент был создан в (модифицированном) файле third.js";
    document.querySelector("body").appendChild(element);
});