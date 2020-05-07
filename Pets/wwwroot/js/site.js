// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 //form encoded data
 var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
 var data = $('form').serialize();

 //JSON data
 var dataType = 'application/json; charset=utf-8';
 var data = {
    FirstName: 'Andrew',
    LastName: 'Lock',
    Age: 31
 }

 console.log('Submitting form...');
 $.ajax({
    type: 'POST',
    url: '/Person/Index',
    dataType: 'json',
    contentType: dataType,
    data: data,
    success: function(result) {
        console.log('Data received: ');
        console.log(result);
    }
 }); 
