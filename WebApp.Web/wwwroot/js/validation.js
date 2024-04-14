document.addEventListener("DOMContentLoaded", function () {
    const forms = document.querySelectorAll("form");
    const deleteCheckbox = document.getElementById("deleteCheckbox");
    const deleteButton = document.getElementById("deleteButton");

    deleteCheckbox.addEventListener("change", function () {
        deleteButton.disabled = !deleteCheckbox.checked;
    });

    forms.forEach(function (form) {
        form.addEventListener("submit", function (event) {
            if (!validateForm(form)) {
                event.preventDefault();
            }
        });
    });

    function validateForm(form) {
        const fields = form.querySelectorAll(".input-group [data-validate]");

        for (let i = 0; i < fields.length; i++) {
            const field = fields[i];
            const value = field.value.trim();
            const validationType = field.dataset.validate;

            switch (validationType) {
                case "required":
                    if (!value) {
                        alert("Please fill in all required fields.");
                        return false;
                    }
                    break;
                case "email":
                    if (value && !validateEmail(value)) {
                        alert("Please enter a valid email address.");
                        return false;
                    }
                    break;
                case "password":
                    if (value && value.length < 8) {
                        alert("Password must be at least 8 characters long.");
                        return false;
                    }
                    break;
                case "confirm-password":
                    const passwordField = form.querySelector('[data-validate="password"]');
                    if (value !== passwordField.value.trim()) {
                        alert("Passwords do not match.");
                        return false;
                    }
                    break;
                case "checkbox-required":
                    if (!field.checked) {
                        alert("You must agree to the terms and conditions.");
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }

        return true;
    }

    function validateEmail(email) {
        const re = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return re.test(String(email).toLowerCase());
    }
});
