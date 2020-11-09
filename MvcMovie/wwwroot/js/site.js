// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    console.log('Staring...')
    $("#searchBoard").submit(function (e) {
        e.preventDefault()
        console.log('On submit search form')

    });


});