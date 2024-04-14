document.addEventListener("DOMContentLoaded", () => {
    menuToggle();
    themeSwitch();
    select();
    markCourse();
});

function menuToggle() {
    try {
        const menuToggle = document.querySelector('.btn-mobile');
        const navLinks = document.querySelector('nav');
        const accLinks = document.querySelector('.account-buttons');

        menuToggle.addEventListener("click", function () {
            // Make menu visible
            navLinks.classList.toggle("show");
            accLinks.classList.toggle("show");

            // Toggle between hamburgericon and crossicon
            menuToggle.innerHTML = navLinks.classList.contains("show")
                ? "&#10005;"
                : "&#9776;";
        });

        function removeShow() {
            navLinks.classList.remove("show");
            accLinks.classList.remove("show");
            menuToggle.innerHTML = "&#9776;"; // Set the hamburger icon
        }

        this.addEventListener("click", function (e) {
            // Check if the clicked element is NOT the menuToggle or a descendant of navLinks
            if (!menuToggle.contains(e.target) && !navLinks.contains(e.target)) {
                removeShow();
            }
        });

        this.addEventListener("resize", () => {
            removeShow();
        });
    } catch { }
}

function themeSwitch() {
    try {
        let themeSwitch = document.querySelector("#switch-mode");

        themeSwitch.addEventListener("change", function () {
            let mode = this.checked ? "dark" : "light";
            fetch(`/sitesettings/theme?mode=${mode}`).then((res) => {
                if (res.ok) window.location.reload();
                else console.log("unable to switch to theme mode");
            });
        });
    } catch { }
}

function markCourse() {
    let mark = document.querySelectorAll('.mark-course');
    mark.forEach(function (mark) {
        // Add click function to 'clicked' to each item with .mark-course class
        mark.addEventListener('click', function () {
            mark.classList.toggle('clicked');
        });
    });
}

function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = selectOptions.style.display === 'block' ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')

        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let dataValue = this.getAttribute('data-value')
                console.log(dataValue);
            })
        })
    }
    catch { }
}