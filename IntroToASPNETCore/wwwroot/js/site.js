﻿// Write your JavaScript code.
$(document).ready(function () {
    //Wire up the Add button to send the new item to the server
    $('#add-item-button').on('click', addItem);
});

function addItem() {
    //hide the error message
    $('#add-item-error').hide();
    //take the words for a new title and pass it to newTitle - this is the important heart of the function
    var newTitle = $('#add-item-title').val();

    $.post('/Todo/AddItem',
        { title: newTitle },
        function () {
            window.location = '/Todo';
        })
        //do stuff when there is an error
        .fail(function (data) {
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
                $('#add-item-error').text(firstError);
                $('#add-item-error').show();
            }
        });
}