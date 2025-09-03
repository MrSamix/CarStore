// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const deleteAlert = (id) => {
    
    if (confirm("Are you sure you want to delete this car?")) {
        window.location.href = `/Car/Delete/${id}`;
    }
}