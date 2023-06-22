// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.querySelector("#generatedSequenceNumberIdLink").addEventListener("click", () => {
    let generatedNumber = document.querySelector("#generatedSequenceNumberId").innerHTML;
    let clipboard = navigator.clipboard;
    clipboard.writeText(generatedNumber);
})