// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const dropdownItems = document.querySelectorAll('.dropdown-item');

    dropdownItems.forEach(item => {
        item.addEventListener('click', function (event) {
            event.preventDefault();
            const techStackId = event.target.getAttribute('data-techstack-id');
            if (techStackId) {
                window.location.href = `/Video/TechStack/${techStackId}`;
            }
        });
    });
});

let container = document.getElementById('auth-container')

toggle = () => {
    container.classList.toggle('sign-in')
    container.classList.toggle('sign-up')
}

setTimeout(() => {
    container.classList.add('sign-in')
}, 200)


/*$(document).ready(function () {
    $('#createTechStackBtn').click(function (e) {
        e.preventDefault();
        $('#createTechStackModal').modal('show');
    });
});*/
